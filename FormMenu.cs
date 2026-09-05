using GeneralKiosk.Class;
using MakeRasisToken;
using Nancy.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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

        public DataTable DtParaClinics { get; private set; }
        public int ParaID { get; private set; }
        public DataTable DtPatients { get; private set; }

        public FormMenu()
        {
            InitializeComponent();
        }

        private void GetParaClinics()
        {
            try
            {
                DtParaClinics = new DataTable();

                using (SqlConnection con = new SqlConnection(Program.ConString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            cmd.Parameters.Clear();

                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            con.Open();
                            cmd.CommandText = @"[BS].[GetParaClinics]";

                            cmd.Parameters.AddWithValue("JustTrue", 1);

                            da.SelectCommand = cmd;
                            da.Fill(DtParaClinics);

                            con.Close();

                        }
                    }
                }

            }

            catch (Exception ex)
            {
                Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
                      " - " + this.Name);
            }
        }




        private async Task SetParaClinics()
        {
            
            if (Program.HasVadie)
            {
                UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                b.Name = "ودیعه";
                b.Tag = -1;
                b.Font = new Font("B Yekan", (b.Width + b.Height) / 35, System.Drawing.FontStyle.Bold);
                b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 10)), 100);
                flowLayoutPanelBakhsh.Controls.Add(b);

                b.Click += async (sender, e) =>
                {
                    try
                    {
                        flowLayoutPanelBakhsh.Enabled = false;
                        pictureBoxCancelFactor.Enabled = false;
                        timerPayTime.Enabled = false;
                        if (!Program.MuteSound)
                        {
                            player.Play();
                        }

                        ParaID = Shared.Val(b.Tag);

                        Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessAdvanceListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}");

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
                        XmlNodeList elemList = root.GetElementsByTagName("InquiryView");

                        DtPatients = Program.ConvertXmlNodeListToDataTable(elemList);

                        if (DtPatients is null)
                        {
                            frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
              , global::GeneralKiosk.Properties.Resources.WarningPic);
                            if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                            {
                                flowLayoutPanelBakhsh.Enabled = true;
                                pictureBoxCancelFactor.Enabled = true;

                                timerPayTime.Enabled = true;
                                return;
                            }
                        }
                        if (DtPatients.Rows.Count <= 0)
                        {
                            frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
              , global::GeneralKiosk.Properties.Resources.WarningPic);
                            if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                            {
                                flowLayoutPanelBakhsh.Enabled = true;
                                pictureBoxCancelFactor.Enabled = true;

                                timerPayTime.Enabled = true;
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
                        Formpatient.Show();

                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;

                        timerPayTime.Enabled = true;
                    }
                    catch
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;

                        timerPayTime.Enabled = true;
                    }
                  
                };


            }
            if (Program.HasTarkhis)
            {
                UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                b.Name = "ترخیص";
                b.Tag = -1;
                b.Font = new Font("B Yekan", (b.Width + b.Height) / 35, System.Drawing.FontStyle.Bold);
                b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 10)), 100);

                flowLayoutPanelBakhsh.Controls.Add(b);
                b.Click += async (sender, e) =>
                {

                    try
                    {
                        timerPayTime.Enabled = false;
                        flowLayoutPanelBakhsh.Enabled = false;
                        pictureBoxCancelFactor.Enabled = false;

                        if (!Program.MuteSound)
                        {
                            player.Play();
                        }

                        ParaID = Shared.Val(b.Tag);

                        Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessReleaseListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}");

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
                        XmlNodeList elemList = root.GetElementsByTagName("InquiryView");

                        DtPatients = Program.ConvertXmlNodeListToDataTable(elemList);

                        if (DtPatients is null)
                        {
                            frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
              , global::GeneralKiosk.Properties.Resources.WarningPic);
                            if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                            {
                                flowLayoutPanelBakhsh.Enabled = true;
                                pictureBoxCancelFactor.Enabled = true;

                                timerPayTime.Enabled = true;
                                return;
                            }
                        }
                        if (DtPatients.Rows.Count <= 0)
                        {
                            frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
              , global::GeneralKiosk.Properties.Resources.WarningPic);
                            if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                            {
                                flowLayoutPanelBakhsh.Enabled = true;
                                pictureBoxCancelFactor.Enabled = true;

                                timerPayTime.Enabled = true;
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
                        Formpatient.Show();
                        Formpatient.IsTarkhis = true;


                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;

                        timerPayTime.Enabled = true;
                    }
                    catch 
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;

                        timerPayTime.Enabled = true;

                    }
                };


            }
            if (Program.ShowEghdamat)
            {
                UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                b.Name = "اقدامات";
                b.Tag = -1;

                b.Font = new Font("B Yekan", (b.Width + b.Height) / 35, System.Drawing.FontStyle.Bold);
                b.Size = new Size(((flowLayoutPanelBakhsh.Width) - (flowLayoutPanelBakhsh.Width / 10)), 100);

                flowLayoutPanelBakhsh.Controls.Add(b);
                b.Click += async (sender, e) =>
                {

                    try
                    {
                        timerPayTime.Enabled = false;
                        flowLayoutPanelBakhsh.Enabled = false;
                        pictureBoxCancelFactor.Enabled = false;

                        if (!Program.MuteSound)
                        {
                            player.Play();
                        }

                        ParaID = Shared.Val(b.Tag);

                        Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessRemedialActivityListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}");

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
                        XmlNodeList elemList = root.GetElementsByTagName("InquiryView");

                        DtPatients = Program.ConvertXmlNodeListToDataTable(elemList);

                        if (DtPatients is null)
                        {
                            frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
              , global::GeneralKiosk.Properties.Resources.WarningPic);
                            if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                            {
                                flowLayoutPanelBakhsh.Enabled = true;
                                pictureBoxCancelFactor.Enabled = true;

                                timerPayTime.Enabled = true;
                                return;
                            }
                        }
                        if (DtPatients.Rows.Count <= 0)
                        {
                            frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
              , global::GeneralKiosk.Properties.Resources.WarningPic);
                            if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                            {
                                flowLayoutPanelBakhsh.Enabled = true;
                                pictureBoxCancelFactor.Enabled = true;

                                timerPayTime.Enabled = true;
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
                        Formpatient.Show();
                        Formpatient.IsTarkhis = false;
                        Formpatient.IsEghdamat = true;
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;

                        timerPayTime.Enabled = true;
                    }
                    catch
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
              , global::GeneralKiosk.Properties.Resources.WarningPic);
                        if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;

                            timerPayTime.Enabled = true;
                            return;
                        }

                    }
                };


            }

            for (int i = 0; i < DtParaClinics.Rows.Count; i++)
            {
                UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                b.Name = Shared.ObjectToText(DtParaClinics.Rows[i]["ParaClinicCap"]);
                b.Tag = Shared.Val(DtParaClinics.Rows[i]["ID"]);

                b.Font = new Font("B Yekan", (b.Width + b.Height) / 35, System.Drawing.FontStyle.Bold);
                b.Size = new Size(((flowLayoutPanelBakhsh.Width ) - (flowLayoutPanelBakhsh.Width / 10)), 100);

                flowLayoutPanelBakhsh.Controls.Add(b);

                b.Click += async (sender, e) =>
                {
                    try
                    {
                        flowLayoutPanelBakhsh.Enabled = false;
                        pictureBoxCancelFactor.Enabled = false;

                        timerPayTime.Enabled = false;
                        if (!Program.MuteSound)
                        {
                            player.Play();
                        }

                        ParaID = Shared.Val(b.Tag);

                        Uri myUri = new Uri($@"{Program.WebServiceAddres}/CashLessPatientManagementListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}&ParaclinicChildID={b.Tag}");

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
                        XmlNodeList elemList = root.GetElementsByTagName("InquiryView01");

                        DtPatients = Program.ConvertXmlNodeListToDataTable(elemList);

                        if (DtPatients is null)
                        {
                            frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
              , global::GeneralKiosk.Properties.Resources.WarningPic);
                            if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                            {
                                flowLayoutPanelBakhsh.Enabled = true;
                                pictureBoxCancelFactor.Enabled = true;
 
                                timerPayTime.Enabled = true;
                                return;
                            }
                        }
                        if (DtPatients is null)
                        {
                            flowLayoutPanelBakhsh.Enabled = true;
                            pictureBoxCancelFactor.Enabled = true;

                            timerPayTime.Enabled = true;
                            Program.ReturnToFirst();
                            return;
                        }
                        if (DtPatients.Rows.Count <= 0)
                        {
                            frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
              , global::GeneralKiosk.Properties.Resources.WarningPic);
                            if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                            {
                                flowLayoutPanelBakhsh.Enabled = true;
                                pictureBoxCancelFactor.Enabled = true;

                                timerPayTime.Enabled = true;
                                return;
                            }
                        }


                        Formpatients Formpatient = new Formpatients();
                        Formpatient.IsVadie = false;
                        Formpatient.IsTarkhis = false;
                        Formpatient.BringToFront();
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
                        pictureBoxCancelFactor.Enabled = true;

                        timerPayTime.Enabled = true;

                    }
                    catch 
                    {
                        flowLayoutPanelBakhsh.Enabled = true;
                        pictureBoxCancelFactor.Enabled = true;

                    }
                };

            }

        }

        void childFormClosed(object sender, EventArgs e)
        {
            ((Form)sender).Closed -= childFormClosed;
            textBoxPayTime.Text = "30";
            timerPayTime.Enabled = true;

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

            GetParaClinics();
            SetParaClinics();


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
            SetImages();
            var Tem = (TableLayoutPanelMain.Width / 2) - 320;
            Padding margin = pictureBoxTopRight.Margin;
            margin.Right = Shared.Val(Tem);
            pictureBoxTopRight.Margin = margin;

            margin = pictureBoxTopCenter.Margin;
            margin.Right = Shared.Val(Tem);
            pictureBoxTopCenter.Margin = margin;
            timerPayTime.Enabled = true;
            textBoxPayTime.Text = "30";
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

        private void تنظیماتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void دربارهیماToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تنظیماتدستگاهکارتخوانToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            try
            {
                if(frmCustomOkMsgBox!=null)
                frmCustomOkMsgBox.Close();
            }
            catch
            {

            }

        }
    }
}