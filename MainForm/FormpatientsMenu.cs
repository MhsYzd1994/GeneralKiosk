using FastReport;
using FastReport.DevComponents.DotNetBar;
using GeneralKiosk.Class;
using MakeRasisToken;
using Nancy.Extensions;
using Nancy.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using SSP1126.PcPos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GeneralKiosk
{
    public partial class FormMenu : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        System.Media.SoundPlayer playerLotfanBakhsh = new System.Media.SoundPlayer(@"Sounds/LotfanBakhsh.wav");
        private CustomOkMsgBox frmCustomOkMsgBox;

        public int ParaID { get; private set; }
        public DataTable DtPatients { get; private set; }
        public bool ShowOther { get; internal set; }

        public static System.Timers.Timer Backtimer = new System.Timers.Timer();

        public FormMenu()
        {
            InitializeComponent();
        }


        void childFormClosed1(object sender, EventArgs e)
        {
            ((Form)sender).Closed -= childFormClosed1;

            if (Program.StartForm != "StartParaclinicList")
            {
                textBoxPayTime.Text = "50";
                Shared.KeyboardArabic();
                timerPayTime.Enabled = true;
            }

        }


        private async Task SetClickFunc(UserControlItemsButtonMenu b, bool IsOtherReq = false)
        {

            flowLayoutPanelBakhsh.Enabled = false;
            if (b.Name == "ودیعه" && Shared.Val(b.Tag) == -1)
            {
                try
                {
                    flowLayoutPanelBakhsh.Enabled = false;
                    pictureBoxWaiting.Visible = true;
                    labelWaitingTxt.Visible = true;
                    pictureBoxFile.Enabled = false;
                    pictureBoxCancelFactor.Enabled = false;
                    timerPayTime.Enabled = false;
                    if (!Program.MuteSound)
                    {
                        player.Play();
                    }

                    ParaID = Shared.Val(b.Tag);

                    Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessAdvanceListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}");

                    string SentResult = String.Empty;

                    await Program.InsertLogToFile($@"Click Bakhsh : {myUri.AbsoluteUri}");

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                    var response = await (Task<WebResponse>)request.GetResponseAsync();
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());


                    String resultmsg = responseReader.ReadToEnd();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(resultmsg);


                    var XmlNode = JsonConvert.SerializeXmlNode(doc);
                    dynamic data = JObject.Parse(XmlNode.ToString());
                    responseReader.Close();
                    DtPatients = new DataTable();
                    XmlElement root = doc.DocumentElement;
                    XmlNodeList elemList = root.GetElementsByTagName("InquiryView");

                    DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);

                    if (DtPatients is null)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }
                    if (DtPatients.Rows.Count <= 0)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }



                    Formpatients Formpatient = new Formpatients();

                    Formpatient.BringToFront();
                    Formpatient.TopMost = true;
                    Formpatient.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Formpatient.Left = Top = 0;
                    Formpatient.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Formpatient.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    Formpatient.WindowState = FormWindowState.Maximized;
                    Formpatient.DtPatients = DtPatients;

                    Formpatient.DtAfterSearch = DtPatients;
                    Formpatient.IsVadie = true;
                    Formpatient.ParaName = b.Name;
                    Formpatient.FormClosed += childFormClosed1;
                    Formpatient.Show();

                    flowLayoutPanelBakhsh.Enabled = true;
                    pictureBoxWaiting.Visible = false;
                    labelWaitingTxt.Visible = false;
                    pictureBoxFile.Enabled = true;
                    pictureBoxCancelFactor.Enabled = true;
                    //if (Program.StartForm != "StartParaclinicList")
                    //{
                    //    timerPayTime.Enabled = true;
                    //}

                }
                catch
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("وب سرویس قطع است ! "
, global::GeneralKiosk.Properties.Resources.WarningPic);
                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxWaiting.Visible = false;
                        labelWaitingTxt.Visible = false;
                        pictureBoxFile.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;
                        if (Program.StartForm != "StartParaclinicList")
                        {
                            timerPayTime.Enabled = true;
                        }
                    }
                }
            }
            else if (b.Name == "ترخیص" && Shared.Val(b.Tag) == -1)
            {
                try
                {
                    timerPayTime.Enabled = false;
                    flowLayoutPanelBakhsh.Enabled = false;
                    pictureBoxWaiting.Visible = true;
                    labelWaitingTxt.Visible = true;
                    pictureBoxFile.Enabled = false;
                    pictureBoxCancelFactor.Enabled = false;

                    if (!Program.MuteSound)
                    {
                        player.Play();
                    }

                    ParaID = Shared.Val(b.Tag);


                    //Uri myUri = new Uri($@"https://www.pdd.ir/pdd/PDDWebService2/MainWebServices.asmx/CashLessReleaseListFull?FromDate=1403/09/06&ToDate=1403/09/06");


                    Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessReleaseListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}");

                    string SentResult = String.Empty;


                    await Program.InsertLogToFile($@"Click Bakhsh : {myUri.AbsoluteUri}");

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                    var response = await (Task<WebResponse>)request.GetResponseAsync();
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());


                    String resultmsg = responseReader.ReadToEnd();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(resultmsg);


                    var XmlNode = JsonConvert.SerializeXmlNode(doc);
                    dynamic data = JObject.Parse(XmlNode.ToString());
                    responseReader.Close();
                    DtPatients = new DataTable();
                    XmlElement root = doc.DocumentElement;
                    XmlNodeList elemList = root.GetElementsByTagName("InquiryView");

                    DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);

                    if (DtPatients is null)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }
                    if (DtPatients.Rows.Count <= 0)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }

                    Formpatients Formpatient = new Formpatients();

                    Formpatient.BringToFront();
                    Formpatient.FormClosed += childFormClosed1;
                    Formpatient.TopMost = true;
                    Formpatient.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Formpatient.Left = Top = 0;
                    Formpatient.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Formpatient.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    Formpatient.WindowState = FormWindowState.Maximized;
                    Formpatient.DtPatients = DtPatients;
                    Formpatient.DtAfterSearch = DtPatients;
                    Formpatient.ParaName = b.Name;
                    Formpatient.Show();
                    Formpatient.IsTarkhis = true;


                    flowLayoutPanelBakhsh.Enabled = true;
                    pictureBoxWaiting.Visible = false;
                    labelWaitingTxt.Visible = false;
                    pictureBoxFile.Enabled = true;
                    pictureBoxCancelFactor.Enabled = true;
                    //if (Program.StartForm != "StartParaclinicList")
                    //{
                    //    timerPayTime.Enabled = true;
                    //}
                }
                catch
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("وب سرویس قطع است ! "
         , global::GeneralKiosk.Properties.Resources.WarningPic);
                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxWaiting.Visible = false;
                        labelWaitingTxt.Visible = false;
                        pictureBoxFile.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;
                        if (Program.StartForm != "StartParaclinicList")
                        {
                            timerPayTime.Enabled = true;
                        }
                    }

                }
            }
            else if (b.Name == "اقدامات" && Shared.Val(b.Tag) == -1)
            {
                try
                {
                    timerPayTime.Enabled = false;
                    flowLayoutPanelBakhsh.Enabled = false;
                    pictureBoxWaiting.Visible = true;
                    labelWaitingTxt.Visible = true;
                    pictureBoxFile.Enabled = false;
                    pictureBoxCancelFactor.Enabled = false;

                    if (!Program.MuteSound)
                    {
                        player.Play();
                    }

                    ParaID = Shared.Val(b.Tag);

                    Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessRemedialActivityListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}");

                    string SentResult = String.Empty;

                    await Program.InsertLogToFile($@"Click Bakhsh : {myUri.AbsoluteUri}");

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                    var response = await (Task<WebResponse>)request.GetResponseAsync();
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());


                    String resultmsg = responseReader.ReadToEnd();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(resultmsg);


                    var XmlNode = JsonConvert.SerializeXmlNode(doc);
                    dynamic data = JObject.Parse(XmlNode.ToString());
                    responseReader.Close();
                    DtPatients = new DataTable();
                    XmlElement root = doc.DocumentElement;
                    XmlNodeList elemList = root.GetElementsByTagName("InquiryView");

                    DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);

                    if (DtPatients is null)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }
                    if (DtPatients.Rows.Count <= 0)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }

                    Formpatients Formpatient = new Formpatients();

                    Formpatient.BringToFront();
                    Formpatient.FormClosed += childFormClosed1;
                    Formpatient.TopMost = true;
                    Formpatient.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Formpatient.Left = Top = 0;
                    Formpatient.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Formpatient.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    Formpatient.WindowState = FormWindowState.Maximized;
                    Formpatient.DtPatients = DtPatients;
                    Formpatient.DtAfterSearch = DtPatients;
                    Formpatient.Show();
                    Formpatient.IsTarkhis = false;
                    Formpatient.IsEghdamat = true;
                    flowLayoutPanelBakhsh.Enabled = true;
                    pictureBoxWaiting.Visible = false;
                    labelWaitingTxt.Visible = false;
                    pictureBoxFile.Enabled = true;
                    Formpatient.ParaName = b.Name;
                    pictureBoxCancelFactor.Enabled = true;
                    //if (Program.StartForm != "StartParaclinicList")
                    //{
                    //    timerPayTime.Enabled = true;
                    //}
                }
                catch
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("وب سرویس قطع است ! "
, global::GeneralKiosk.Properties.Resources.WarningPic);
                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxWaiting.Visible = false;
                        labelWaitingTxt.Visible = false;
                        pictureBoxFile.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;
                        if (Program.StartForm != "StartParaclinicList")
                        {
                            timerPayTime.Enabled = true;
                        }
                    }
                    return;


                }
            }
            else if (b.Name == "نوبت دهی" && Shared.Val(b.Tag) == -1)
            {
                try
                {
                    timerPayTime.Enabled = false;
                    flowLayoutPanelBakhsh.Enabled = false;
                    pictureBoxWaiting.Visible = true;
                    labelWaitingTxt.Visible = true;
                    pictureBoxFile.Enabled = false;
                    pictureBoxCancelFactor.Enabled = false;

                    if (!Program.MuteSound)
                    {
                        player.Play();
                    }

                    ParaID = Shared.Val(b.Tag);

                    Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessReleaseListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}");

                    string SentResult = String.Empty;


                    await Program.InsertLogToFile($@"Click Bakhsh : {myUri.AbsoluteUri}");

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                    var response = await (Task<WebResponse>)request.GetResponseAsync();
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());


                    String resultmsg = responseReader.ReadToEnd();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(resultmsg);


                    var XmlNode = JsonConvert.SerializeXmlNode(doc);
                    dynamic data = JObject.Parse(XmlNode.ToString());
                    responseReader.Close();
                    DtPatients = new DataTable();
                    XmlElement root = doc.DocumentElement;
                    XmlNodeList elemList = root.GetElementsByTagName("InquiryView");

                    DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);

                    if (DtPatients is null)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }
                    if (DtPatients.Rows.Count <= 0)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }

                    Formpatients Formpatient = new Formpatients();

                    Formpatient.BringToFront();
                    Formpatient.FormClosed += childFormClosed1;
                    Formpatient.TopMost = true;
                    Formpatient.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Formpatient.Left = Top = 0;
                    Formpatient.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Formpatient.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    Formpatient.WindowState = FormWindowState.Maximized;
                    Formpatient.DtPatients = DtPatients;
                    Formpatient.DtAfterSearch = DtPatients;
                    Formpatient.ParaName = b.Name;
                    Formpatient.Show();
                    Formpatient.IsNobat = true;


                    flowLayoutPanelBakhsh.Enabled = true;
                    pictureBoxWaiting.Visible = false;
                    labelWaitingTxt.Visible = false;
                    pictureBoxFile.Enabled = true;
                    pictureBoxCancelFactor.Enabled = true;
                    //if (Program.StartForm != "StartParaclinicList")
                    //{
                    //    timerPayTime.Enabled = true;
                    //}
                }
                catch
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("وب سرویس قطع است ! "
         , global::GeneralKiosk.Properties.Resources.WarningPic);
                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxWaiting.Visible = false;
                        labelWaitingTxt.Visible = false;
                        pictureBoxFile.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;
                        if (Program.StartForm != "StartParaclinicList")
                        {
                            timerPayTime.Enabled = true;
                        }
                    }

                }
            }
            else if (b.Tag.ToString().Contains("drug"))
            {
                try
                {
                    flowLayoutPanelBakhsh.Enabled = false;
                    pictureBoxWaiting.Visible = true;
                    labelWaitingTxt.Visible = true;
                    pictureBoxFile.Enabled = false;
                    pictureBoxCancelFactor.Enabled = false;

                    timerPayTime.Enabled = false;
                    if (!Program.MuteSound)
                    {
                        player.Play();
                    }

                    ParaID = Shared.Val(b.Tag);


                    Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessDrugInventoryListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}&InventoryID={b.Tag.ToString().Replace("drug", "")}");


                    await Program.InsertLogToFile($@"Click Bakhsh : {myUri.AbsoluteUri}");

                    string SentResult = String.Empty;


                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                    var response = await (Task<WebResponse>)request.GetResponseAsync();
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());


                    String resultmsg = responseReader.ReadToEnd();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(resultmsg);


                    var XmlNode = JsonConvert.SerializeXmlNode(doc);
                    dynamic data = JObject.Parse(XmlNode.ToString());
                    responseReader.Close();
                    DtPatients = new DataTable();

                    XmlElement root = doc.DocumentElement;
                    XmlNodeList elemList = root.GetElementsByTagName("DataDocument");


                    DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);



                    if (DtPatients is null)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }
                    if (DtPatients is null)
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxWaiting.Visible = false;
                        labelWaitingTxt.Visible = false;
                        pictureBoxFile.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;
                        if (Program.StartForm != "StartParaclinicList")
                        {
                            timerPayTime.Enabled = true;
                        }
                        Program.ReturnToFirst();
                        return;
                    }
                    if (DtPatients.Rows.Count <= 0)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }


                    Formpatients Formpatient = new Formpatients();
                    Formpatient.IsVadie = false;
                    Formpatient.IsTarkhis = false;
                    Formpatient.IsDrug = true;
                    Formpatient.BringToFront();
                    Formpatient.FormClosed += childFormClosed1;
                    Formpatient.TopMost = true;
                    Formpatient.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Formpatient.Left = Top = 0;
                    Formpatient.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Formpatient.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    Formpatient.WindowState = FormWindowState.Maximized;
                    Formpatient.DtPatients = DtPatients;
                    Formpatient.DtAfterSearch = DtPatients;
                    Formpatient.ParaName = b.Name;
                    Formpatient.FormClosed += childFormClosed;
                    Formpatient.Show();
                    flowLayoutPanelBakhsh.Enabled = true;
                    pictureBoxWaiting.Visible = false;
                    labelWaitingTxt.Visible = false;
                    pictureBoxFile.Enabled = true;
                    pictureBoxCancelFactor.Enabled = true;

                    if (Program.StartForm != "StartParaclinicList")
                    {
                        timerPayTime.Enabled = true;
                    }

                }
                catch
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("وب سرویس قطع است ! "
, global::GeneralKiosk.Properties.Resources.WarningPic);
                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxWaiting.Visible = false;
                        labelWaitingTxt.Visible = false;
                        pictureBoxFile.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;
                        if (Program.StartForm != "StartParaclinicList")
                        {
                            timerPayTime.Enabled = true;
                        }
                    }

                }
            }
            else if (IsOtherReq)
            {
                try
                {

                    if (!Program.MuteSound)
                    {
                        player.Play();
                    }

                    Formpatients Formpatient = new Formpatients();
                    Formpatient.IsVadie = false;
                    Formpatient.IsTarkhis = false;
                    Formpatient.IsOtherReq = true;
                    Formpatient.ParaName = b.Name;
                    Formpatient.ParaID = Shared.Val(b.Tag);
                    Formpatient.BringToFront();
                    Formpatient.FormClosed += childFormClosed1;
                    Formpatient.TopMost = true;
                    Formpatient.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Formpatient.Left = Top = 0;
                    Formpatient.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Formpatient.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    Formpatient.WindowState = FormWindowState.Maximized;
                    Formpatient.DtPatients = DtPatients;
                    Formpatient.DtAfterSearch = DtPatients;
                    Formpatient.FormClosed += childFormClosed;
                    Formpatient.Show();
                    flowLayoutPanelBakhsh.Enabled = true;
                    pictureBoxWaiting.Visible = false;
                    labelWaitingTxt.Visible = false;
                    pictureBoxFile.Enabled = true;
                    pictureBoxCancelFactor.Enabled = true;

                    //if (Program.StartForm != "StartParaclinicList")
                    //{
                    //    timerPayTime.Enabled = true;
                    //}

                }
                catch
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("وب سرویس قطع است ! "
, global::GeneralKiosk.Properties.Resources.WarningPic);
                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxWaiting.Visible = false;
                        labelWaitingTxt.Visible = false;
                        pictureBoxFile.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;
                        if (Program.StartForm != "StartParaclinicList")
                        {
                            timerPayTime.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                try
                {
                    flowLayoutPanelBakhsh.Enabled = false;
                    pictureBoxWaiting.Visible = true;
                    labelWaitingTxt.Visible = true;
                    pictureBoxFile.Enabled = false;
                    pictureBoxCancelFactor.Enabled = false;

                    timerPayTime.Enabled = false;
                    if (!Program.MuteSound)
                    {
                        player.Play();
                    }

                    ParaID = Shared.Val(b.Tag);

                    Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessPatientManagementListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}&ParaclinicChildID={b.Tag}");

                    string SentResult = String.Empty;


                    await Program.InsertLogToFile($@"Click Bakhsh : {myUri.AbsoluteUri}");
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                    var response = await (Task<WebResponse>)request.GetResponseAsync();
                    StreamReader responseReader = new StreamReader(response.GetResponseStream());


                    String resultmsg = responseReader.ReadToEnd();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(resultmsg);


                    var XmlNode = JsonConvert.SerializeXmlNode(doc);
                    dynamic data = JObject.Parse(XmlNode.ToString());
                    responseReader.Close();
                    DtPatients = new DataTable();

                    XmlElement root = doc.DocumentElement;
                    XmlNodeList elemList = root.GetElementsByTagName("InquiryView01");

                    DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);

                    if (DtPatients is null)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }

                    if (DtPatients.Rows.Count <= 0)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("در بخش انتخاب شده بیماری وجود ندارد لطفا از صحیح بودن نام بخش مطمئن شوید و یا دقایقی بعد مجدد تلاش کنید ! "
          , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                            return;
                        }
                    }


                    Formpatients Formpatient = new Formpatients();
                    Formpatient.IsVadie = false;
                    Formpatient.IsTarkhis = false;
                    Formpatient.ParaName = b.Name;
                    Formpatient.BringToFront();
                    Formpatient.FormClosed += childFormClosed1;
                    Formpatient.TopMost = true;
                    Formpatient.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Formpatient.Left = Top = 0;
                    Formpatient.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Formpatient.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    Formpatient.WindowState = FormWindowState.Maximized;
                    Formpatient.DtPatients = DtPatients;
                    Formpatient.DtAfterSearch = DtPatients;
                    Formpatient.FormClosed += childFormClosed;
                    Formpatient.Show();
                    flowLayoutPanelBakhsh.Enabled = true;
                    pictureBoxWaiting.Visible = false;
                    labelWaitingTxt.Visible = false;
                    pictureBoxFile.Enabled = true;
                    pictureBoxCancelFactor.Enabled = true;

                    //if (Program.StartForm != "StartParaclinicList")
                    //{
                    //    timerPayTime.Enabled = true;
                    //}

                }
                catch
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("وب سرویس قطع است ! "
, global::GeneralKiosk.Properties.Resources.WarningPic);
                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxWaiting.Visible = false;
                        labelWaitingTxt.Visible = false;
                        pictureBoxFile.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;
                        if (Program.StartForm != "StartParaclinicList")
                        {
                            timerPayTime.Enabled = true;
                        }
                    }
                    return;

                }
            }

            flowLayoutPanelBakhsh.Enabled = true;
        }


       

        private async Task SetParaClinics()
        {
            if (ShowOther)
            {
                Program.GetOther();
                foreach (var Item in Program.DtOtherReq.AsEnumerable()
           .Select(row => new
           {
               GroupName = row.Field<string>("GroupName"),
               GroupID = row.Field<decimal>("GroupID")
           }).Distinct())
                {
                    UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                    b.Name = Shared.ObjectToText(Item.GroupName);
                    b.Tag = Shared.Val(Item.GroupID);

                    b.Font = new Font("B Yekan", (b.Width + b.Height) / 50, System.Drawing.FontStyle.Bold);
                    if (Program.ShowCol == "ShowTwoCol")
                    {
                        b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 7)) / 2, 100);
                    }
                    else
                    {
                        b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 10)), 100);
                    }
                    flowLayoutPanelBakhsh.Controls.Add(b);

                    b.Click += async (sender, e) =>
                    {
                        await SetClickFunc(b, true);
                    };


                }
                if (Program.DtOtherReq.Rows.Count <= 0)
                {
                    this.Close();
                }
                return;
            }
            if (Program.HasVadie)
            {
                UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                b.Name = "ودیعه";
                b.Tag = -1;
                b.Font = new Font("B Yekan", (b.Width + b.Height) / 50, System.Drawing.FontStyle.Bold);
                if (Program.ShowCol == "ShowTwoCol")
                {
                    b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 7)) / 2, 100);
                }
                else
                {
                    b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 10)), 100);
                }
                flowLayoutPanelBakhsh.Controls.Add(b);

                b.Click += async (sender, e) =>
                {
                    await SetClickFunc(b);

                };


            }
            if (Program.HasTarkhis)
            {
                UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                b.Name = "ترخیص";
                b.Tag = -1;
                b.Font = new Font("B Yekan", (b.Width + b.Height) / 50, System.Drawing.FontStyle.Bold);
                if (Program.ShowCol == "ShowTwoCol")
                {
                    b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 7)) / 2, 100);
                }
                else
                {
                    b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 10)), 100);
                }

                flowLayoutPanelBakhsh.Controls.Add(b);
                b.Click += async (sender, e) =>
                {
                    await SetClickFunc(b);

                };


            }
            if (Program.ShowNobat)
            {
                UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                b.Name = "نوبت دهی";
                b.Tag = -1;
                b.Font = new Font("B Yekan", (b.Width + b.Height) / 50, System.Drawing.FontStyle.Bold);
                if (Program.ShowCol == "ShowTwoCol")
                {
                    b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 7)) / 2, 100);
                }
                else
                {
                    b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 10)), 100);
                }

                flowLayoutPanelBakhsh.Controls.Add(b);
                b.Click += async (sender, e) =>
                {
                    try
                    {
                        Process browserProcess = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = Program.NobatLink,
                                UseShellExecute = true
                            }
                        };

                        browserProcess.EnableRaisingEvents = true;
                        browserProcess.Start();
                    }
                    catch
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("لینک نوبت دهی مشکل دارد ! "
, global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxWaiting.Visible = false;
                            labelWaitingTxt.Visible = false;
                            pictureBoxFile.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;
                            if (Program.StartForm != "StartParaclinicList")
                            {
                                timerPayTime.Enabled = true;
                            }
                        }
                    }
                   

                };


            }
            if (Program.ShowEghdamat)
            {
                UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                b.Name = "اقدامات";
                b.Tag = -1;

                b.Font = new Font("B Yekan", (b.Width + b.Height) / 50, System.Drawing.FontStyle.Bold);
                if (Program.ShowCol == "ShowTwoCol")
                {
                    b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 7)) / 2, 100);
                }
                else
                {
                    b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 10)), 100);
                }

                flowLayoutPanelBakhsh.Controls.Add(b);
                b.Click += async (sender, e) =>
                {

                    await SetClickFunc(b);
                };


            }
            if (Program.ShowDrug)
            {
                for (int i = 0; i < Program.DtDrugs.Rows.Count; i++)
                {
                    UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                    b.Name = Shared.ObjectToText(Program.DtDrugs.Rows[i]["DrugCap"]);
                    b.Tag = Shared.ObjectToText(Program.DtDrugs.Rows[i]["ID"]) + "drug";


                    b.Font = new Font("B Yekan", (b.Width + b.Height) / 50, System.Drawing.FontStyle.Bold);
                    if (Program.ShowCol == "ShowTwoCol")
                    {
                        b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 7)) / 2, 100);
                    }
                    else
                    {
                        b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 7)), 100);
                    }

                    flowLayoutPanelBakhsh.Controls.Add(b);

                    b.Click += async (sender, e) =>
                    {
                        await SetClickFunc(b);
                    };

                }

            }

            for (int i = 0; i < Program.DtParaClinics.Rows.Count; i++)
            {
                UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                b.Name = Shared.ObjectToText(Program.DtParaClinics.Rows[i]["ParaClinicCap"]);
                b.Tag = Shared.Val(Program.DtParaClinics.Rows[i]["ID"]);

                b.Font = new Font("B Yekan", (b.Width + b.Height) / 50, System.Drawing.FontStyle.Bold);
                if (Program.ShowCol == "ShowTwoCol")
                {
                    b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 7)) / 2, 100);
                }
                else
                {
                    b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 10)), 100);
                }

                flowLayoutPanelBakhsh.Controls.Add(b);

                b.Click += async (sender, e) =>
                {
                    await SetClickFunc(b);
                };

            }

            if (Program.ShowOther)
            {
                foreach (var Item in Program.DtOtherReq.AsEnumerable()
.Select(row => new
{
    GroupName = row.Field<string>("GroupName"),
    GroupID = row.Field<decimal>("GroupID")
}).Distinct())
                {
                    UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                    b.Name = Shared.ObjectToText(Item.GroupName);
                    b.Tag = Shared.Val(Item.GroupID);

                    b.Font = new Font("B Yekan", (b.Width + b.Height) / 50, System.Drawing.FontStyle.Bold);
                    if (Program.ShowCol == "ShowTwoCol")
                    {
                        b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 7)) / 2, 100);
                    }
                    else
                    {
                        b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 10)), 100);
                    }


                    flowLayoutPanelBakhsh.Controls.Add(b);

                    b.Click += async (sender, e) =>
                    {
                        await SetClickFunc(b, true);
                    };

                }


            }

        }



        void childFormClosed(object sender, EventArgs e)
        {
            ((Form)sender).Closed -= childFormClosed;
            if (Program.StartForm != "StartParaclinicList")
            {
                textBoxPayTime.Text = "30";
                timerPayTime.Enabled = true;
            }
            else
            {

                timerPayTime.Enabled = false;
                textBoxPayTime.Visible = false;
                pictureBoxCancelFactor.Visible = false;

                SetImages();
                LoadForm();
            }

        }

        private string _barcode = "";
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            char c = (char)keyData;

            if (char.IsNumber(c))
                _barcode += c;

            if (c == (char)Keys.Return)
            {
                //DoSomethingWithBarcode(_barcode);
                //_barcode = "";
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadForm()
        {
            SetDoubleBuffered(TableLayoutPanelMain);
            SetDoubleBuffered(flowLayoutPanelBakhsh);
            flowLayoutPanelBakhsh.Controls.Clear();

            Program.GetParaClinics();
            SetParaClinics();

            if (Program.StartForm == "StartParaclinicList")
            {
                LoadPosSetting();
            }


#if DEBUG
            this.TopMost = false;
#else
            this.TopMost = true;
            this.BringToFront();
            this.TopMost = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Left = Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.WindowState = FormWindowState.Maximized;
#endif
            if (!Program.MuteSound)
            {
                playerLotfanBakhsh.Play();
            }
        }
        private void SetImages()
        {
            pictureBoxTopRight.Image = Program.PictureTopRightImage;
            if (Program.PictureTopCenterImage != null)
                pictureBoxTopCenter.Image = Program.PictureTopCenterImage;
            if (Program.PictureTopLeftImage != null)
                pictureBoxTopLeft.Image = Program.PictureTopLeftImage;


            pictureBoxTopRight.Visible = Program.PictureTopRightVisible;
            pictureBoxTopCenter.Visible = Program.PictureTopCenterVisible;
            pictureBoxTopLeft.Visible = Program.PictureTopLeftVisible;


        }
        private void Form23_Load(object sender, EventArgs e)
        {
            if (Program.StartForm == "StartParaclinicList")
            {
                timerPayTime.Enabled = false;
                textBoxPayTime.Visible = false;
                pictureBoxCancelFactor.Visible = false;
                timerBackup.Enabled = true;

            }
            else
            {
                pictureBoxFile.Visible = false;
                timerPayTime.Enabled = true;
                textBoxPayTime.Text = "30";
                timerBackup.Enabled = false;
            }

            SetImages();


            LoadForm();


        }

        protected override void WndProc(ref Message m)
        {
            // Define DoubleClick...
            const int WM_NCLBUTTONDBLCLK = 163;
            // Define LeftButtonDown event...
            const int WM_NCLBUTTONDOWN = 161;
            // Define MOVE action...
            const int WM_SYSCOMMAND = 274;
            // Define that the WM_NCLBUTTONDOWN is at TitleBar...
            const int HTCAPTION = 2;
            // Trap MOVE action...
            const int SC_MOVE = 61456;
            // Disable moving TitleBar...
            if (((m.Msg == WM_SYSCOMMAND)
                        && (m.WParam.ToInt32() == SC_MOVE)))
            {
                return;
            }
            // Track whether clicked on TitleBar...
            if (((m.Msg == WM_NCLBUTTONDOWN)
                        && (m.WParam.ToInt32() == HTCAPTION)))
            {
                return;
            }
            // Disable double click on TitleBar...
            if ((m.Msg == WM_NCLBUTTONDBLCLK))
            {
                return;
            }
            base.WndProc(ref m);
        }


        private void FormMainUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                prompt frmprompt = new prompt();

                if (frmprompt.ShowDialog() == DialogResult.OK)
                    if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                    {
                        using (FormMainSetting frm = new FormMainSetting())
                        {
                            frm.UserType = (int)Program.EnumUserType.Backup;
                            frm.ShowDialog();
                        }

                    }
                    else if (frmprompt.MyPass == Program.Pass)
                    {
                        using (FormMainSetting frm = new FormMainSetting())
                        {

                            frm.UserType = (int)Program.EnumUserType.Modir;
                            frm.ShowDialog();
                        }
                    }

            }
            else if (e.KeyCode == Keys.F6)
            {
                prompt frmprompt = new prompt();

                if (frmprompt.ShowDialog() == DialogResult.OK)
                    if (frmprompt.MyPass == Program.Pass)
                    {
                        using (frmPosSetting frm = new frmPosSetting())
                        {
                            frm.ShowDialog();
                        }
                    }

            }
            else
            {
                return;
            }
            if (!string.IsNullOrEmpty(_barcode))
            {
                _barcode = "";
                return;
            }
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }


        private void timerPayTime_Tick(object sender, EventArgs e)
        {
            if (Shared.Val(textBoxPayTime.Text) == 0)
                this.Close();
            textBoxPayTime.Text = Shared.ObjectToText(Shared.Val(textBoxPayTime.Text) - 1);
        }

        private void pictureBoxCancelFactor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.ExitApp)
            {
                e.Cancel = false;
                return;
            }
            if (Program.StartForm == "StartParaclinicList")
            {
                prompt frmprompt = new prompt();

                if (frmprompt.ShowDialog() == DialogResult.OK)
                {
                    if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6) || frmprompt.MyPass == Program.Pass)
                    {
                        try
                        {
                            if (frmCustomOkMsgBox != null)
                                frmCustomOkMsgBox.Close();
                        }
                        catch
                        {

                        }
                        e.Cancel = false;

                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                try
                {
                    if (frmCustomOkMsgBox != null)
                        frmCustomOkMsgBox.Close();
                }
                catch
                {

                }
            }

        }

        private void تنظیماتToolStripMenuItem_Click(object sender, EventArgs e)
        {

            prompt frmprompt = new prompt();

            if (frmprompt.ShowDialog() == DialogResult.OK)
                if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                {
                    using (FormMainSetting frm = new FormMainSetting())
                    {
                        frm.IsBackup = true;
                        frm.UserType = (int)Program.EnumUserType.Backup;
                        frm.ShowDialog();
                    }

                }
                else if (frmprompt.MyPass == Program.Pass)
                {
                    using (FormMainSetting frm = new FormMainSetting())
                    {

                        frm.UserType = (int)Program.EnumUserType.Modir;
                        frm.ShowDialog();
                    }
                }

            Program.LoadSetting();
            SetImages();
            flowLayoutPanelBakhsh.Controls.Clear();
            Program.GetParaClinics();
            SetParaClinics();

        }

        private void دربارهیماToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (AboutBox frm = new AboutBox())
            {
                frm.ShowDialog();
            }
        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadPosSetting()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(Program.ConString))
                {

                    SqlDataAdapter da = new SqlDataAdapter();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 300;
                        cmd.Connection = con;

                        cmd.CommandText =
                        $@"SELECT  Ct,  Cpnm,AccSt,IP,  
                        Lng,
                        Sync, Terminal 
                        FROM    BS.TPOS 
                        WHERE  (ID= {Program.ProcessorId} ) ";

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                    }
                }

                #region SetData

                if (dt.Rows.Count <= 0)
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("تنظیمات دستگاه کارتخوان وارد نشده است !" + "\n" +
                        "برای ادامه ی کار ، لطفا ابتدا تنظیمات را تعیین کنید"
, global::GeneralKiosk.Properties.Resources.WarningPic);

                    frmCustomOkMsgBox.ShowDialog();
                    flowLayoutPanelBakhsh.Enabled = false;

                    return;
                }
                else
                {
                    flowLayoutPanelBakhsh.Enabled = true;
                }



                if (Shared.ObjectToText(dt.Rows[0]["Lng"]) == "Persian")
                    Program._responseLanguage = ResponseLanguage.Persian;

                else
                    Program._responseLanguage = ResponseLanguage.English;

                if (Shared.ObjectToText(dt.Rows[0]["AccSt"]) == "چند حسابی")
                    Program._accountType = AccountType.Share;
                else if (Shared.ObjectToText(dt.Rows[0]["AccSt"]) == "چند شبایی")
                    Program._accountType = AccountType.ShareByIban;

                else if (Shared.ObjectToText(dt.Rows[0]["AccSt"]) == "تک حسابی")
                    Program._accountType = AccountType.Single;

                if (Shared.ObjectToText(dt.Rows[0]["Ct"]) == "COM")
                    Program._mediaType = MediaType.Com;
                else
                    Program._mediaType = MediaType.Network;

                if (Shared.ObjectToText(dt.Rows[0]["Sync"]) == "Async")
                    Program._asyncType = AsyncType.Async;
                else
                    Program._asyncType = AsyncType.Sync;
                Program.TerminalID = Shared.ObjectToText(dt.Rows[0]["Terminal"]);

                Program.PosIP = Shared.ObjectToText(dt.Rows[0]["IP"]);
                Program.ComPortNum = Shared.ObjectToText(dt.Rows[0]["Cpnm"]);

                #endregion
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);

            }
        }

        private void تنظیماتدستگاهکارتخوانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prompt frmprompt = new prompt();

            if (frmprompt.ShowDialog() == DialogResult.OK)
                if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                {
                    using (frmPosSetting frm = new frmPosSetting())
                    {
                        frm.ShowDialog();
                    }

                }
                else if (frmprompt.MyPass == Program.Pass)
                {
                    using (frmPosSetting frm = new frmPosSetting())
                    {

                        frm.ShowDialog();
                    }
                }

            LoadPosSetting();
        }

        private void گزارشاتToolStripMenuItem_Click(object sender, EventArgs e)
        {

            prompt frmprompt = new prompt();

            if (frmprompt.ShowDialog() == DialogResult.OK)
                if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                {

                    FormFactorList FormFactorList = new FormFactorList();
                    FormFactorList.BringToFront();
                    FormFactorList.TopMost = true;
                    FormFactorList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    FormFactorList.Left = Top = 0;
                    FormFactorList.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    FormFactorList.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    FormFactorList.WindowState = FormWindowState.Maximized;
                    FormFactorList.Show();

                }
                else if (frmprompt.MyPass == Program.Pass)
                {

                    FormFactorList FormFactorList = new FormFactorList();
                    FormFactorList.BringToFront();
                    FormFactorList.TopMost = true;
                    FormFactorList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    FormFactorList.Left = Top = 0;
                    FormFactorList.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    FormFactorList.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    FormFactorList.WindowState = FormWindowState.Maximized;
                    FormFactorList.Show();
                }


        }

        private void pictureBoxFile_Click(object sender, EventArgs e)
        {
            contextMenuStripFiles.Show(Cursor.Position.X - 10, Cursor.Position.Y + 5);
        }

        private void تهیهفایلپشتبToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void دستیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prompt frmprompt = new prompt();

            if (frmprompt.ShowDialog() == DialogResult.OK)
                if (frmprompt.MyPass == Program.Pass || frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                {
                    using (FrmBackup frm = new FrmBackup())
                    {
                        frm.ShowDialog();
                    }
                }
        }

        private void خودکارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prompt frmprompt = new prompt();

            if (frmprompt.ShowDialog() == DialogResult.OK)
                if (frmprompt.MyPass == Program.Pass || frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                {
                    using (FrmScheduleList frm = new FrmScheduleList())
                    {
                        frm.ShowDialog();
                    }
                }
        }


        private static void ClearOldHistory(string path)
        {
            string[] files = Directory.GetFiles(path);
            if (files.Length > 15)
            {
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.CreationTime < DateTime.Now.AddDays(-9))
                        fi.Delete();
                }
            }
        }


        #region GetBackup

        public static bool GetBackup()
        {
            string TempPath = string.Empty;
            //if (!Directory.Exists(@"Backup\"))
            //{
            //    Directory.CreateDirectory(@"Backup\");
            //}
            TempPath = Program.BackPath;

            if (string.IsNullOrEmpty(TempPath))
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "مسیر پشتیبان گیری نمیتواند خالی باشد !");
                return false;
            }

            try
            {
                string DataBase = string.Empty;

                if (Program.ConString.ToLower().Contains("Initial Catalog".ToLower()))
                {
                    System.Data.Common.DbConnectionStringBuilder builder = new System.Data.Common.DbConnectionStringBuilder
                    {
                        ConnectionString = Program.ConString
                    };

                    DataBase = builder["Initial Catalog"] as string;
                }

                string DateTimeString = DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("HH-mm-ss");
                ClearOldHistory(TempPath);

                new BaseInformation().GetBackup(DataBase, TempPath, DateTimeString);

                try
                {
                    //using (ZipFile zip = new ZipFile())
                    //{
                    //    zip.Password = "k!n*He&7%?q=2R`7";
                    //    zip.AddFile(@"Backup\" + "\\" + DateTimeString + ".RasisBak");
                    //    zip.Save(@"Backup\" + "\\" + DateTimeString + ".RasisBak" + ".zip");
                    //}

                    //File.Delete(@"Backup\" + "\\" + DateTimeString + ".RasisBak");

                    new BaseInformation().InsertBackupHistory(TempPath, DateTime.Now.ToString("yyyy/MM/dd HH.mm.ss"));
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("Cannot open backup device".ToLower()) ||
                       ex.Message.ToLower().Contains("The device is not ready".ToLower()) ||
                       ex.Message.ToLower().Contains("cannot find the path".ToLower()))
                    {
                        Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "دیتابیس در سرور وجود دارد." + "\r\n" + " برای پشتیبان گیری از نرم افزار رسیس نصب بر روی سرور استفاده کنید");
                    }
                    else
                    {
                        Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, ex.Message);
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("Cannot open backup device".ToLower()) ||
                       ex.Message.ToLower().Contains("The device is not ready".ToLower()) ||
                       ex.Message.ToLower().Contains("cannot find the path".ToLower()))
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "دیتابیس در سرور وجود دارد." + "\r\n" + " برای پشتیبان گیری از نرم افزار رسیس نصب بر روی سرور استفاده کنید");
                }
                else
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, ex.Message);
                }

                return false;
            }
            return true;
        }

        #endregion

        public enum enumTypeJobSchedule
        {
            Backup = 1
        }

        private void timerBackup_Tick(object sender, EventArgs e)
        {
            if (!Program.ActiveAutoBack)
                return;
            int IsBackup = new BaseInformation().CheckRunJobSchedule((int)enumTypeJobSchedule.Backup, DateTime.Now.ToString("yyyy/MM/dd"), DateTime.Now.ToString("HH:mm"));
            if (IsBackup == 1)
            {

                labelWaitingTxt.Visible = true;
                labelWaitingTxt.Text = "در حال پشتیبانگیری";
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                if (GetBackup())
                {

                    Application.DoEvents();
                }
                else
                {

                    Application.DoEvents();
                }
                Cursor = Cursors.Default;
                labelWaitingTxt.Visible = false;
                labelWaitingTxt.Text = "لطفا کمی صبر کنید ...";
                Application.DoEvents();
            }


        }

        private void پرینتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dtPaient = new DataTable("dtPaient");
            dtPaient.Columns.Add("ParaClinicName", typeof(string));
            dtPaient.Columns.Add("ReceptionDate", typeof(string));
            dtPaient.Columns.Add("documentCode", typeof(string));
            dtPaient.Columns.Add("serviceDescription", typeof(string));

            // فیلدهای کنترل نمایش
            dtPaient.Columns.Add("ShowParaClinicName", typeof(bool));
            dtPaient.Columns.Add("ShowReceptionDate", typeof(bool));
            dtPaient.Columns.Add("ShowdocumentCode", typeof(bool));
            dtPaient.Columns.Add("ShowserviceDescription", typeof(bool));

            // 2️⃣ افزودن داده‌های تستی
            dtPaient.Rows.Add("Lab Test", "2025-03-01", "DOC123", "Blood Test", true, true, false, true);
            dtPaient.Rows.Add("X-Ray", "2025-03-02", "DOC456", "Chest X-Ray", false, true, true, true);
            dtPaient.Rows.Add("MRI", "2025-03-03", "DOC789", "Brain MRI", true, false, true, false);

            // 3️⃣ ایجاد گزارش
            Report report = new Report();

            // 4️⃣ بارگذاری فایل گزارش (مسیر فایل FRX را وارد کنید)
            report.Load("Reports/FishPrint - Copy.frx");

            // 5️⃣ بارگذاری داده‌ها به گزارش
            report.RegisterData(dtPaient, "dtPaient");

            // 6️⃣ فعال کردن datasource
            var dataSource = report.GetDataSource("dtPaient");
            if (dataSource != null)
            {
                dataSource.Enabled = true; // مطمئن شوید که دیتا سورس فعال است
            }
            else
            {
                Console.WriteLine("داده‌ها به درستی متصل نشده‌اند.");
                return;
            }

            // 7️⃣ پیش آماده‌سازی داده‌ها برای نمایش
            report.Prepare();

            // 8️⃣ نمایش گزارش
            report.Show();


        }
    }
}