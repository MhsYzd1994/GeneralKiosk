using FastReport.Data;
using FastReport.Map;
using GeneralKiosk.Class;
using GeneralKiosk.Common;
using Ionic.Zip;
using MakeRasisToken;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SSP1126.PcPos.BaseClasses;
using SSP1126.PcPos.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Xml;

namespace GeneralKiosk
{
    public partial class FormStart : Form
    {
        System.Media.SoundPlayer playerEnter = new System.Media.SoundPlayer(@"Sounds/Enter.wav");
        private CustomOkMsgBox frmCustomOkMsgBox;

        public DataTable DtPatients { get; private set; }
        public int ClearMeliCnt { get; private set; }
        public bool IsDrug { get; private set; } = false;
        public bool IsTarkhis { get; private set; } = false;
        public bool IsSearchMeli { get; private set; }
        public bool IsVadie { get; private set; } = false;
        public bool IsEghdamat { get; private set; } = false;

        public FormStart()
        {
            InitializeComponent();

        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            SetImages();
            SetSettingToThis();
            var Tem = (TableLayoutPanelMain.Width / 2) - 320;
            Padding margin = pictureBoxTopRight.Margin;
            margin.Right = Shared.Val(Tem);
            pictureBoxTopRight.Margin = margin;

            margin = pictureBoxTopCenter.Margin;
            margin.Right = Shared.Val(Tem);
            pictureBoxTopCenter.Margin = margin;

            SetDoubleBuffered(TableLayoutPanelMain);

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

            LoadPosSetting();


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
                Application.Exit();
            }

        }

        private void panelEnter_Click(object sender, EventArgs e)
        {
            CloseFormsKeyBoard();
            this.TopMost = false;
            if (!Program.MuteSound)
            {
                playerEnter.Play();
            }

            FormMenu FormMenu = new FormMenu();
            FormMenu.BringToFront();
            FormMenu.TopMost = true;
            FormMenu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            FormMenu.Left = Top = 0;
            FormMenu.Width = Screen.PrimaryScreen.WorkingArea.Width;
            FormMenu.Height = Screen.PrimaryScreen.WorkingArea.Height;
            FormMenu.WindowState = FormWindowState.Maximized;

            FormMenu.FormClosed += (s, args) => ShowKeyBoardAsync();

            FormMenu.Show();
        }

        private void FormStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.ExitApp)
            {
                e.Cancel = false;
                return;
            }

            prompt frmprompt = new prompt();

            if (frmprompt.ShowDialog() == DialogResult.OK)
            {
                if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6) || frmprompt.MyPass == Program.Pass)
                {

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

        private void pictureBoxFile_Click(object sender, EventArgs e)
        {
            contextMenuStripFiles.Show(Cursor.Position.X - 10, Cursor.Position.Y + 5);
        }

        private void تنظیماتToolStripMenuItem_Click_1(object sender, EventArgs e)
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
            SetSettingToThis();
            ShowKeyBoardAsync();

        }


        public void SetSettingToThis()
        {
            if (!Program.SearchByNationalCodeStartFrm)
            {
                panelMeli.Visible = false;
                labelMeli.Visible = false;
            }
            else
            {
                labelMeli.Visible = true;
                panelMeli.Visible = true;


                ShowKeyBoardAsync();
            }
            if (!Program.ShowParaStartForm)
            {
                panelEnter.Visible = false;
                panelEnter.Visible = false;
            }
            else
            {
                panelEnter.Visible = true;
                panelEnter.Visible = true;
            }


            if (Program.StartForm == "StartParaclinicList")
            {
                this.TopMost = false;
                if (!Program.MuteSound)
                {
                    playerEnter.Play();
                }

                FormMenu FormMenu = new FormMenu();
                FormMenu.BringToFront();
                FormMenu.TopMost = true;
                FormMenu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                FormMenu.Left = Top = 0;
                FormMenu.Width = Screen.PrimaryScreen.WorkingArea.Width;
                FormMenu.Height = Screen.PrimaryScreen.WorkingArea.Height;
                FormMenu.WindowState = FormWindowState.Maximized;
                FormMenu.Show();
                this.Close();
            }

            if (Program.ShowOtherInstart)
            {
                panel6.Visible = true;
            }
            else
            {
                panel6.Visible = false;
            }

        }


        private void SetImages()
        {
            pictureBoxTopRight.Image = Program.PictureTopRightImage;
            if (Program.PictureTopCenterImage != null)
                pictureBoxTopCenter.Image = Program.PictureTopCenterImage;
            if (Program.PictureTopLeftImage != null)
                pictureBoxTopLeft.Image = Program.PictureTopLeftImage;
            pictureBoxCenter.Image = Program.PictureCenterImage;
            pictureBoxShowMessage.Image = Program.PictureShowMessageImage;
            pictureBoxDown.Image = Program.PictureDownImage;

            pictureBoxTopRight.Visible = Program.PictureTopRightVisible;
            pictureBoxTopCenter.Visible = Program.PictureTopCenterVisible;
            pictureBoxTopLeft.Visible = Program.PictureTopLeftVisible;
            pictureBoxCenter.Visible = Program.PictureCenterVisible;
            pictureBoxShowMessage.Visible = Program.PictureShowMessagetVisible;
            pictureBoxDown.Visible = Program.PictureDownVisible;


        }

        private void دربارهیماToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (AboutBox frm = new AboutBox())
            {
                frm.ShowDialog();
            }

            ShowKeyBoardAsync();
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
                    panelEnter.Enabled = false;
                    panelMeli.Enabled = false;
                    return;
                }
                else
                {
                    panelEnter.Enabled = true;
                    panelMeli.Enabled = true;
                    ShowKeyBoardAsync();
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
                Program.InsertLogToFile("Error : " + ex.Message + " - " + Shared.GetCurrentMethod() +
" - " + this.Name);
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
            ShowKeyBoardAsync();
        }

        private void گزارشاتToolStripMenuItem_Click(object sender, EventArgs e)
        {

            prompt frmprompt = new prompt();

            if (frmprompt.ShowDialog() == DialogResult.OK)
            {
                if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                {

                    FormFactorList FormFactorList = new FormFactorList();

                    FormFactorList.FormClosed += FormFactorList_FormClosed;
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
                    FormFactorList.FormClosed += FormFactorList_FormClosed;

                    FormFactorList.BringToFront();
                    FormFactorList.TopMost = true;
                    FormFactorList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    FormFactorList.Left = Top = 0;
                    FormFactorList.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    FormFactorList.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    FormFactorList.WindowState = FormWindowState.Maximized;
                    FormFactorList.Show();
                }
                else
                {
                    ShowKeyBoardAsync();
                }
            }
            else
                ShowKeyBoardAsync();



        }

        private void FormFactorList_FormClosed(object sender, FormClosedEventArgs e)
        {
            // عملیات مورد نظر بعد از بسته شدن فرم
            ShowKeyBoardAsync();
        }
        private void pictureBoxSearchByNationalCode_Click(object sender, EventArgs e)
        {
            if (!Program.MuteSound)
            {
                playerEnter.Play();
            }
            SearchNational();
        }

        private void textBoxMeliCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        void childFormClosed(object sender, EventArgs e)
        {
            ((Form)sender).Closed -= childFormClosed;

        }


        private void textBoxMeliCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchNational();
            }
        }




        private bool CheckPishNiazMeli()
        {


            if (textBoxMeliCode.Text.Length != 10)
            {
                frmCustomOkMsgBox = new CustomOkMsgBox("کد ملی میبایست 10 رقم باشد ! "
, global::GeneralKiosk.Properties.Resources.WarningPic);
                frmCustomOkMsgBox.ShowDialog();
                return false;
            }
            if (!Shared.CheckMeli(textBoxMeliCode.Text))
            {
                frmCustomOkMsgBox = new CustomOkMsgBox("کد ملی نامعتبر است ! "
, global::GeneralKiosk.Properties.Resources.WarningPic);
                frmCustomOkMsgBox.ShowDialog();
                return false;
            }
            return true;
        }

        private void LockForm(bool IsLock)
        {

            try
            {
                foreach (Form form in Application.OpenForms.OfType<Form>())
                {

                    if (form.Name == "NumericKeyboardForm")
                    {
                        form.Enabled = IsLock;
                    }
                }
            }
            catch
            {

            }
            labelOther.Enabled = IsLock;
            panelEnter.Enabled = IsLock;
            pictureBoxFile.Enabled = IsLock;
            panelMeli.Enabled = IsLock;
            pictureBoxWaiting.Visible = !IsLock;
            textBoxMeliCode.Select();
        }

        private async Task SearchNational()
        {

            try
            {
                IsSearchMeli = false;
                IsVadie = false;
                IsDrug = false;
                IsTarkhis = false;
                IsEghdamat = false;

                if (Program.CheckMeli)
                {
                    if (!CheckPishNiazMeli())
                    {
                        return;
                    }
                }

                LockForm(false);
                timerClearMeli.Enabled = false;

                DtPatients = new DataTable();

                if(!Program.NotSearchsoftCode01)
                {
                    #region Softwarecode 01

                    try
                    {

                        //**
                        //Uri myUri = new Uri($@"https://www.pdd.ir/pdd/PDDWebService2/MainWebServices.asmx/CashLessByNationalNoSoftwareCode?FromDate=1403/09/06&ToDate=1403/09/06&NationalNo=1817784102&SoftwareCode=16");
                        Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessByNationalNoSoftwareCode?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}&NationalNo={textBoxMeliCode.Text.Trim()}&SoftwareCode=01");

                        await Program.InsertLogToFile($@"SearchNational : {myUri.AbsoluteUri}");

                        string SentResult = String.Empty;


                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                        var cts = new CancellationTokenSource();
                        cts.CancelAfter(TimeSpan.FromSeconds(15));  // این 30 ثانیه تایم‌اوت شماست
                        HttpWebResponse response;

                        try
                        {

                            var responseTask = request.GetResponseAsync();

                            // منتظر باشید تا یا پاسخ بیاد یا تایم‌اوت بشه
                            if (await Task.WhenAny(responseTask, Task.Delay(Timeout.Infinite, cts.Token)) == responseTask)
                            {
                                response = (HttpWebResponse)await responseTask;
                                // پردازش پاسخ
                            }
                            else
                            {
                                throw new TimeoutException("The request timed out.");
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            throw new TimeoutException("The request timed out.");
                        }
                        StreamReader responseReader = new StreamReader(response.GetResponseStream());


                        String resultmsg = responseReader.ReadToEnd();

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(resultmsg);


                        var XmlNode = JsonConvert.SerializeXmlNode(doc);
                        dynamic data = JObject.Parse(XmlNode.ToString());
                        responseReader.Close();


                        XmlElement root = doc.DocumentElement;
                        XmlNodeList elemList = root.GetElementsByTagName("CashLess");


                        var dt = new DataTable();
                        dt = await Program.ConvertXmlNodeListToDataTable(elemList);


                        if (elemList.Count > 0)
                        {
                            DataColumnCollection columns = dt.Columns;
                            if (columns.Contains("ServiceName"))
                            {
                                DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);
                                DtPatients = DtPatients.Clone();

                                var cnt = elemList.Count;
                                for (int i = 0; i < cnt; i++)
                                {
                                    DtPatients.ImportRow(dt.Rows[i]);
                                    DtPatients.AcceptChanges();
                                }
                            }

                            IsVadie = true;

                        }
                        await Program.InsertLogToFile($@"SearchNational : {DtPatients.Rows.Count.ToString()}");
                    }
                    catch (Exception ex)
                    {
                        await Program.InsertLogToFile($@"Error  Softwarecode 01 : {ex.Message}");
                    }
                    #endregion
                }


                if (!Program.NotSearchsoftCode34)
                {
                    #region Softwarecode 34

                    try
                    {


                        Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessByNationalNoSoftwareCode?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}&NationalNo={textBoxMeliCode.Text.Trim()}&SoftwareCode=34");

                        await Program.InsertLogToFile($@"SearchNational : {myUri.AbsoluteUri}");

                        string SentResult = String.Empty;


                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                        var cts = new CancellationTokenSource();
                        cts.CancelAfter(TimeSpan.FromSeconds(15));  // این 30 ثانیه تایم‌اوت شماست
                        HttpWebResponse response;

                        try
                        {

                            var responseTask = request.GetResponseAsync();

                            // منتظر باشید تا یا پاسخ بیاد یا تایم‌اوت بشه
                            if (await Task.WhenAny(responseTask, Task.Delay(Timeout.Infinite, cts.Token)) == responseTask)
                            {
                                response = (HttpWebResponse)await responseTask;
                                // پردازش پاسخ
                            }
                            else
                            {
                                throw new TimeoutException("The request timed out.");
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            throw new TimeoutException("The request timed out.");
                        }
                        StreamReader responseReader = new StreamReader(response.GetResponseStream());


                        String resultmsg = responseReader.ReadToEnd();

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(resultmsg);


                        var XmlNode = JsonConvert.SerializeXmlNode(doc);
                        dynamic data = JObject.Parse(XmlNode.ToString());
                        responseReader.Close();

                        XmlElement root = doc.DocumentElement;
                        XmlNodeList elemList = root.GetElementsByTagName("CashLess");
                        await Program.InsertLogToFile($@"CashLess : {elemList.Count.ToString()}");

                        var dt = new DataTable();
                        dt = await Program.ConvertXmlNodeListToDataTable(elemList);


                        if (elemList.Count > 0)
                        {
                            DataColumnCollection columns = dt.Columns;
                            if (columns.Contains("ServiceName"))
                            {
                                DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);
                                DtPatients = DtPatients.Clone();

                                var cnt = elemList.Count;
                                for (int i = 0; i < cnt; i++)
                                {
                                    DtPatients.ImportRow(dt.Rows[i]);
                                    DtPatients.AcceptChanges();
                                }
                            }

                        }

                        await Program.InsertLogToFile($@"SearchNational : {DtPatients.Rows.Count.ToString()}");
                    }
                    catch (Exception ex)
                    {
                        await Program.InsertLogToFile($@"Error  Softwarecode 34 : {ex.Message}");
                    }
                    #endregion
                }


                if (!Program.NotSearchsoftCode11)
                {
                    #region Softwarecode 11

                    try
                    {


                        Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessByNationalNoSoftwareCode?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}&NationalNo={textBoxMeliCode.Text.Trim()}&SoftwareCode=11");

                        await Program.InsertLogToFile($@"SearchNational : {myUri.AbsoluteUri}");

                        string SentResult = String.Empty;


                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                        var cts = new CancellationTokenSource();
                        cts.CancelAfter(TimeSpan.FromSeconds(15));  // این 30 ثانیه تایم‌اوت شماست
                        HttpWebResponse response;

                        try
                        {

                            var responseTask = request.GetResponseAsync();

                            // منتظر باشید تا یا پاسخ بیاد یا تایم‌اوت بشه
                            if (await Task.WhenAny(responseTask, Task.Delay(Timeout.Infinite, cts.Token)) == responseTask)
                            {
                                response = (HttpWebResponse)await responseTask;
                                // پردازش پاسخ
                            }
                            else
                            {
                                throw new TimeoutException("The request timed out.");
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            throw new TimeoutException("The request timed out.");
                        }

                        StreamReader responseReader = new StreamReader(response.GetResponseStream());


                        String resultmsg = responseReader.ReadToEnd();

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(resultmsg);


                        var XmlNode = JsonConvert.SerializeXmlNode(doc);
                        dynamic data = JObject.Parse(XmlNode.ToString());
                        responseReader.Close();


                        XmlElement root = doc.DocumentElement;
                        XmlNodeList elemList = root.GetElementsByTagName("CashLess");


                        var dt = new DataTable();
                        dt = await Program.ConvertXmlNodeListToDataTable(elemList);


                        if (elemList.Count > 0)
                        {
                            DataColumnCollection columns = dt.Columns;
                            if (columns.Contains("ServiceName"))
                            {
                                DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);
                                DtPatients = DtPatients.Clone();
                                var cnt = elemList.Count;
                                for (int i = 0; i < cnt; i++)
                                {
                                    DtPatients.ImportRow(dt.Rows[i]);
                                    DtPatients.AcceptChanges();
                                }
                            }

                            IsDrug = true;
                        }
                        await Program.InsertLogToFile($@"SearchNational : {DtPatients.Rows.Count.ToString()}");

                    }
                    catch (Exception ex)
                    {
                        await Program.InsertLogToFile($@"Error  Softwarecode 11 : {ex.Message}");
                    }
                    #endregion
                }


                if (!Program.NotSearchsoftCode16)
                {
                    #region Softwarecode 16

                    try
                    {


                        Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessByNationalNoSoftwareCode?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}&NationalNo={textBoxMeliCode.Text.Trim()}&SoftwareCode=16");

                        await Program.InsertLogToFile($@"SearchNational : {myUri.AbsoluteUri}");

                        string SentResult = String.Empty;


                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                        var cts = new CancellationTokenSource();
                        cts.CancelAfter(TimeSpan.FromSeconds(15));  // این 30 ثانیه تایم‌اوت شماست
                        HttpWebResponse response;

                        try
                        {

                            var responseTask = request.GetResponseAsync();

                            // منتظر باشید تا یا پاسخ بیاد یا تایم‌اوت بشه
                            if (await Task.WhenAny(responseTask, Task.Delay(Timeout.Infinite, cts.Token)) == responseTask)
                            {
                                response = (HttpWebResponse)await responseTask;
                                // پردازش پاسخ
                            }
                            else
                            {
                                throw new TimeoutException("The request timed out.");
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            throw new TimeoutException("The request timed out.");
                        }
                        StreamReader responseReader = new StreamReader(response.GetResponseStream());


                        String resultmsg = responseReader.ReadToEnd();

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(resultmsg);


                        var XmlNode = JsonConvert.SerializeXmlNode(doc);
                        dynamic data = JObject.Parse(XmlNode.ToString());
                        responseReader.Close();


                        XmlElement root = doc.DocumentElement;
                        XmlNodeList elemList = root.GetElementsByTagName("CashLess");


                        var dt = new DataTable();
                        dt = await Program.ConvertXmlNodeListToDataTable(elemList);


                        if (elemList.Count > 0)
                        {
                            DataColumnCollection columns = dt.Columns;
                            if (columns.Contains("ServiceName"))
                            {
                                DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);
                                DtPatients = DtPatients.Clone();

                                var cnt = elemList.Count;
                                for (int i = 0; i < cnt; i++)
                                {
                                    DtPatients.ImportRow(dt.Rows[i]);
                                    DtPatients.AcceptChanges();
                                }
                            }
                            IsTarkhis = true;

                        }
                        await Program.InsertLogToFile($@"SearchNational : {DtPatients.Rows.Count.ToString()}");
                    }
                    catch (Exception ex)
                    {
                        await Program.InsertLogToFile($@"Error  Softwarecode 16 : {ex.Message}");
                    }
                    #endregion
                }


                if (!Program.NotSearchsoftCode06)
                {
                    #region Softwarecode 06

                    try
                    {


                        Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessByNationalNoSoftwareCode?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}&NationalNo={textBoxMeliCode.Text.Trim()}&SoftwareCode=06");

                        await Program.InsertLogToFile($@"SearchNational : {myUri.AbsoluteUri}");

                        string SentResult = String.Empty;

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

                        var cts = new CancellationTokenSource();
                        cts.CancelAfter(TimeSpan.FromSeconds(15));  // این 30 ثانیه تایم‌اوت شماست
                        HttpWebResponse response;

                        try
                        {

                            var responseTask = request.GetResponseAsync();

                            // منتظر باشید تا یا پاسخ بیاد یا تایم‌اوت بشه
                            if (await Task.WhenAny(responseTask, Task.Delay(Timeout.Infinite, cts.Token)) == responseTask)
                            {
                                response = (HttpWebResponse)await responseTask;
                                // پردازش پاسخ
                            }
                            else
                            {
                                throw new TimeoutException("The request timed out.");
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            throw new TimeoutException("The request timed out.");
                        }
                        StreamReader responseReader = new StreamReader(response.GetResponseStream());


                        String resultmsg = responseReader.ReadToEnd();

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(resultmsg);


                        var XmlNode = JsonConvert.SerializeXmlNode(doc);
                        dynamic data = JObject.Parse(XmlNode.ToString());
                        responseReader.Close();

                        XmlElement root = doc.DocumentElement;
                        XmlNodeList elemList = root.GetElementsByTagName("CashLess");


                        var dt = new DataTable();
                        dt = await Program.ConvertXmlNodeListToDataTable(elemList);


                        if (elemList.Count > 0)
                        {
                            DataColumnCollection columns = dt.Columns;
                            if (columns.Contains("ServiceName"))
                            {
                                DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);
                                DtPatients = DtPatients.Clone();
                                var cnt = elemList.Count;
                                for (int i = 0; i < cnt; i++)
                                {
                                    DtPatients.ImportRow(dt.Rows[i]);
                                    DtPatients.AcceptChanges();
                                }

                                IsEghdamat = true;
                            }



                        }
                        await Program.InsertLogToFile($@"SearchNational : {DtPatients.Rows.Count.ToString()}");
                    }
                    catch (Exception ex)
                    {
                        await Program.InsertLogToFile($@"Error  Softwarecode 06 : {ex.Message}+");
                    }
                    #endregion
                }


                if (DtPatients is null)
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
      , global::GeneralKiosk.Properties.Resources.WarningPic);
                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                    {
                        textBoxMeliCode.Text = "";
                        LockForm(true);
                        return;
                    }
                }

                if (DtPatients.Rows.Count <= 0)
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
      , global::GeneralKiosk.Properties.Resources.WarningPic);
                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                    {
                        textBoxMeliCode.Text = "";
                        LockForm(true);
                        return;
                    }
                }

                CloseFormsKeyBoard();
                Program.dtPaient = new DataTable();
                Program.dtPaient = DtPatients;


                try
                {

                    if (Shared.ValInt64(DtPatients.Rows[0]["endRate"]) == 0)
                    {
                        //DtPatients.Columns.Remove("serviceDescription");
                        DtPatients.Columns.Remove("endRate");
                        //DtPatients.Columns["ServiceName"].ColumnName = "serviceDescription";
                        DtPatients.Columns["CalculationReceptionEndRate"].ColumnName = "endRate";
                        //DtPatients.Columns["CalculationReceptionEndRate"].ColumnName = "endRate";
                    }

                    //if (Shared.ValInt64(DtPatients.Rows[0]["FreeRate"]) == 0)
                    //{
                    //    await Program.InsertLogToFile("FreeRate");
                    //    //DtPatients.Columns.Remove("serviceDescription");
                    //    DtPatients.Columns.Remove("FreeRate");
                    //    //DtPatients.Columns["ServiceName"].ColumnName = "serviceDescription";
                    //    DtPatients.Columns["TotalRate"].ColumnName = "FreeRate";
                    //    //DtPatients.Columns["CalculationReceptionEndRate"].ColumnName = "endRate";
                    //}
                }
                catch
                {

                }

                //foreach (DataColumn item in DtPatients.Columns)
                //{
                //    await Program.InsertLogToFile(item.ColumnName);
                //}

                if (DtPatients.Rows.Count == 1)
                {


                    //await Program.InsertLogToFile(Shared.ObjectToText(DtPatients.Rows[0]["TotalRate"])); 

                    if (Program.PayAfterSearchMeli)
                    {
                        FormPayWithCard FormPayWithCard = new FormPayWithCard();
                        await Program.InsertLogToFile("OKPay : " + Shared.ConvertToFinglish(Shared.ObjectToText(DtPatients.Rows[0]["ParaClinicName"])) + " ReceptionCode : " + Shared.ObjectToText(DtPatients.Rows[0]["ReceptionCode"])
+ Shared.GetCurrentMethod() +
" - " + this.Name);
                        FormPayWithCard = new FormPayWithCard();
                        FormPayWithCard.BringToFront();
                        FormPayWithCard.TopMost = true;
                        FormPayWithCard.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        FormPayWithCard.Left = Top = 0;
                        FormPayWithCard.Width = Screen.PrimaryScreen.WorkingArea.Width;
                        FormPayWithCard.Height = Screen.PrimaryScreen.WorkingArea.Height;
                        FormPayWithCard.WindowState = FormWindowState.Maximized;
                        FormPayWithCard.Amnt = Shared.ValInt64(DtPatients.Rows[0]["EndRate"]);
                        FormPayWithCard.ReceiptCode = Shared.ObjectToText(DtPatients.Rows[0]["ReceptionCode"]);
                        FormPayWithCard.FormClosed += childFormClosed;
                        FormPayWithCard.IsVadie = IsVadie;
                        FormPayWithCard.IsTarkhis = IsTarkhis;
                        FormPayWithCard.IsEghdamat = IsEghdamat;
                        FormPayWithCard.IsDrug = IsDrug;
                        FormPayWithCard.ReceptionCode = Shared.ObjectToText(DtPatients.Rows[0]["ReceptionCode"]);
                        await Task.Run(() =>
                        {
                            // کدهای سنگین و پردازشی شما در اینجا
                            // مثل دسترسی به پایگاه داده یا محاسبات
                        }).ContinueWith(t =>
                        {
                            // این قسمت از کد در رشته‌ی اصلی اجرا می‌شود (به UI دسترسی دارد)
                            FormPayWithCard.Show(); // یا هر چیز دیگر
                        }, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else
                    {
                        FormpatientInfo FormpatientInfoObj = new FormpatientInfo();

                        FormpatientInfoObj.BringToFront();
                        FormpatientInfoObj.TopMost = true;
                        FormpatientInfoObj.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        FormpatientInfoObj.Left = Top = 0;
                        FormpatientInfoObj.Width = Screen.PrimaryScreen.WorkingArea.Width;
                        FormpatientInfoObj.Height = Screen.PrimaryScreen.WorkingArea.Height;
                        FormpatientInfoObj.WindowState = FormWindowState.Maximized;
                        FormpatientInfoObj.FormClosed += childFormClosed;
                        FormpatientInfoObj.IsVadie = IsVadie;
                        FormpatientInfoObj.IsTarkhis = IsTarkhis;
                        FormpatientInfoObj.IsEghdamat = IsEghdamat;
                        FormpatientInfoObj.IsDrug = IsDrug;
                        FormpatientInfoObj.IsOtherReq = false;
                        FormpatientInfoObj.ReceptionCode = Shared.ObjectToText(DtPatients.Rows[0]["ReceptionCode"]);
                        FormpatientInfoObj.ParaName = Shared.ObjectToText(DtPatients.Rows[0]["ParaClinicName"]);
                        FormpatientInfoObj.OtherReqID = 0;
                        FormpatientInfoObj.FormClosed += (s, args) => ShowKeyBoardAsync();
                        FormpatientInfoObj.Show();
                    }

                }
                else
                {


                    Formpatients Formpatient = new Formpatients();
                    Formpatient.IsVadie = IsVadie;
                    Formpatient.IsTarkhis = IsTarkhis;
                    Formpatient.IsEghdamat = IsEghdamat;
                    Formpatient.IsDrug = IsDrug;
                    Formpatient.ParaName = "";
                    Formpatient.BringToFront();
                    Formpatient.TopMost = true;
                    Formpatient.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Formpatient.Left = Top = 0;
                    Formpatient.IsSearchMeli = true;
                    Formpatient.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Formpatient.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    Formpatient.WindowState = FormWindowState.Maximized;
                    Formpatient.DtPatients = DtPatients;
                    Formpatient.DtAfterSearch = DtPatients;
                    Formpatient.FormClosed += childFormClosed;
                    Formpatient.FormClosed += (s, args) => ShowKeyBoardAsync();
                    Formpatient.Show();

                }
                IsDrug = false;
                IsVadie = false;
                IsTarkhis = false;
                IsEghdamat = false;
                textBoxMeliCode.Text = "";
                LockForm(true);

            }
            catch (Exception ex)
            {
                Program.InsertLogToFile("Error : " + ex.Message + " - " + Shared.GetCurrentMethod() +
      " - " + this.Name);

                frmCustomOkMsgBox = new CustomOkMsgBox("مشکلی پیش آمده است ! "
     , global::GeneralKiosk.Properties.Resources.WarningPic);
                if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                {
                    textBoxMeliCode.Text = "";
                    LockForm(true);
                    return;
                }

            }


        }

        private void timerClearMeli_Tick(object sender, EventArgs e)
        {
            if (ClearMeliCnt == 0)
            {
                textBoxMeliCode.Text = "";
                timerClearMeli.Enabled = false;
            }
            else
            {
                ClearMeliCnt--;
            }

        }

        private void textBoxMeliCode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMeliCode.Text == "")
            {
                timerClearMeli.Enabled = false;
                return;
            }

            timerClearMeli.Enabled = true;
            ClearMeliCnt = 20;
        }

        private void pictureBoxClear_Click(object sender, EventArgs e)
        {
            textBoxMeliCode.Text = "";
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

            ShowKeyBoardAsync();
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

            ShowKeyBoardAsync();
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


        private void labelOther_Click(object sender, EventArgs e)
        {
            CloseFormsKeyBoard();
            this.TopMost = false;
            if (!Program.MuteSound)
            {
                playerEnter.Play();
            }

            FormMenu FormMenu = new FormMenu();
            FormMenu.BringToFront();
            FormMenu.TopMost = true;
            FormMenu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            FormMenu.Left = Top = 0;
            FormMenu.Width = Screen.PrimaryScreen.WorkingArea.Width;
            FormMenu.Height = Screen.PrimaryScreen.WorkingArea.Height;
            FormMenu.WindowState = FormWindowState.Maximized;
            FormMenu.ShowOther = true;
            FormMenu.FormClosed += (s, args) =>
            {
                if (Program.DtOtherReq.Rows.Count <= 0)
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
      , global::GeneralKiosk.Properties.Resources.WarningPic);
                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                    {
                        textBoxMeliCode.Text = "";
                        LockForm(true);
                    }
                }

                ShowKeyBoardAsync();
            };
            FormMenu.Show();
        }

        private void textBoxMeliCode_Click(object sender, EventArgs e)
        {
            ShowKeyBoardAsync();
        }


        private void CloseFormsKeyBoard()
        {
            try
            {
                foreach (Form form in Application.OpenForms.OfType<Form>())
                {

                    if (form.Name == "NumericKeyboardForm")
                    {
                        form.Close(); // بستن فرم
                    }
                }
            }
            catch
            {

            }
            // استفاده از Application.OpenForms برای دریافت لیست فرم‌های باز

        }

        private void textBoxMeliCode_MouseLeave(object sender, EventArgs e)
        {

        }

        private void FormStart_Click(object sender, EventArgs e)
        {
            if (!textBoxMeliCode.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                CloseFormsKeyBoard();

            }
        }

        private void textBoxMeliCode_Enter(object sender, EventArgs e)
        {
            ShowKeyBoardAsync();
        }

        private async Task ShowKeyBoardAsync()
        {
            try
            {
                CloseFormsKeyBoard();
                if (Program.ActiveKeyPad)
                {
                    NumericKeyboardForm keyboardForm = new NumericKeyboardForm(textBoxMeliCode);

                    if (keyboardForm == null || keyboardForm.IsDisposed)
                    {
                        keyboardForm = new NumericKeyboardForm(this.textBoxMeliCode);
                    }

                    // تنظیم مکان و اندازه کیبورد
                    var textBoxPosition = this.textBoxMeliCode.PointToScreen(Point.Empty);
                    var textBoxCenterX = textBoxPosition.X + this.textBoxMeliCode.Width / 2;

                    // محاسبه موقعیت فرم برای قرارگیری زیر تکس باکس و هم‌راستایی عرض
                    var formWidth = keyboardForm.Width;
                    var formPositionX = textBoxCenterX - formWidth / 2;
                    var formPositionY = textBoxPosition.Y + this.textBoxMeliCode.Height + 50;

                    keyboardForm.StartPosition = FormStartPosition.Manual;
                    keyboardForm.Location = new Point(formPositionX, formPositionY);
                    keyboardForm.TopMost = true;
                    keyboardForm.Show();
                    //await Task.Delay(100);
                    textBoxMeliCode.Focus();
                }


            }
            catch
            {

            }



            //try
            //{
            //    if(Program.ActiveKeyPad)
            //    Process.Start("C:\\Program Files\\Common Files\\microsoft shared\\ink\\tabtip.exe");
            //}
            //catch
            //{

            //}
        }

        private void FormStart_Shown(object sender, EventArgs e)
        {
            ShowKeyBoardAsync();
        }

    }
}