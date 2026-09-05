using GeneralKiosk.Class;
using MakeRasisToken;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SSP1126.PcPos.Infrastructure;
using System;
using System.Collections.Generic;
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
    public partial class FormpatientInfo : Form
    {
        public bool IsVadie { get; internal set; } = false;
        public bool IsTarkhis { get; internal set; } = false;
        public bool IsEghdamat { get; internal set; } = false;
        public bool IsDrug { get; internal set; }
        public string ParaName { get; internal set; }
        public string ReceptionCode { get; set; }
        public bool IsOtherReq { get; internal set; }
        public int OtherReqID { get; internal set; }

        public FormpatientInfo()
        {
            InitializeComponent();
        }


        private string GetField(string Field)
        {
            try
            {

                

                Program.InsertLogToFile(Program.dtPaient.ToString());


                return Program.dtPaient.AsEnumerable()
                       .Where(myRow => myRow.Field<string>("ReceptionCode") == ReceptionCode).FirstOrDefault()[Field].ToString();
            }

            catch (Exception ex)
            {

                Program.InsertLogToFile("Error : " + Field + ex.Message + " - " + Shared.GetCurrentMethod() +
" - " + this.Name);

                return "";
            }
        }


        private void SetPatientInfo()
        {
            try
            {


                if (IsOtherReq)
                {
                    textBoxReceptionCode.Text = " - ";
                    textBoxPatientName.Text = Program.DtOtherReq.Select($@"ID = {OtherReqID} ").FirstOrDefault()["OtherName"].ToString();
                    label1.Text = "عنوان : ";
                    textBoxServiceDescription.Text = Program.DtOtherReq.Select($@"ID = {OtherReqID} ").FirstOrDefault()["OtherDescription"].ToString();


                    textBoxEndRate.Text = Shared.ValDecimal(Program.DtOtherReq.Select($@"ID = {OtherReqID} ").FirstOrDefault()["OtherRate"]).ToString("#,###;(#,###);-");
                    return;
                }

                label1.Text = "نام بیمار : ";
                textBoxReceptionCode.Text = ReceptionCode;
                textBoxPatientName.Text = Shared.ObjectToText(GetField("FirstName")) + " " +
                Shared.ObjectToText(GetField("LastName"));
                try
                {
                    textBoxServiceDescription.Text = Shared.ObjectToText(GetField("ServiceDescription"));
                }
                catch
                {
                    textBoxServiceDescription.Text = Shared.ObjectToText(GetField("ExternalBeneficiaryName"));
                }

                textBoxEndRate.Text = Shared.ValDecimal(GetField("EndRate")).ToString("#,###;(#,###);-");

            }
            catch (Exception ex)
            {

                Program.InsertLogToFile("Error : " + ex.Message + " - " + Shared.GetCurrentMethod() +
" - " + this.Name);
            }
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            textBoxName.Text = Program.Onme;
            SetDoubleBuffered(TableLayoutPanelMain);

            SetPatientInfo();
            timerPayTime.Enabled = true;
            textBoxPayTime.Text = "30";

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


            ClearForm();


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

        private void FormMainUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (Shared.IsHasEvent("uiButtonPay_KeyDown"))
                return;
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

        private void ClearForm()
        {


        }

        private void تنظیماتToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void دربارهیماToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox frm = new AboutBox())
            {
                frm.ShowDialog();
            }
        }



        private void pictureBoxCancelFactor_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private async void uiButtonPay_Click(object sender, EventArgs e)
        {
            FormPayWithCard FormPayWithCard = new FormPayWithCard();
            if (IsOtherReq)
            {
                await Program.InsertLogToFile("OKPay : " + Shared.ConvertToFinglish(ParaName)
 + Shared.GetCurrentMethod() +
 " - " + this.Name);
                this.Hide();
                FormPayWithCard.BringToFront();
                FormPayWithCard.TopMost = true;
                FormPayWithCard.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                FormPayWithCard.Left = Top = 0;
                FormPayWithCard.Width = Screen.PrimaryScreen.WorkingArea.Width;
                FormPayWithCard.Height = Screen.PrimaryScreen.WorkingArea.Height;
                FormPayWithCard.WindowState = FormWindowState.Maximized;
                FormPayWithCard.Amnt = Shared.Val(textBoxEndRate.Text);
                FormPayWithCard.ReceiptCode = Shared.ObjectToText(textBoxReceptionCode.Text);
                FormPayWithCard.FormClosed += childFormClosed;
                FormPayWithCard.IsVadie = IsVadie;
                FormPayWithCard.IsTarkhis = IsTarkhis;
                FormPayWithCard.IsEghdamat = IsEghdamat;
                FormPayWithCard.IsDrug = IsDrug;
                FormPayWithCard.IsOtherReq = IsOtherReq;
                FormPayWithCard.OtherReqID = OtherReqID;
                timerPayTime.Enabled = false;
                textBoxPayTime.Text = "30";
                FormPayWithCard.ReceptionCode = "-";
                FormPayWithCard.Show();
                return;
            }
            await Program.InsertLogToFile("OKPay : " + Shared.ConvertToFinglish(ParaName) + " ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
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
            FormPayWithCard.Amnt = Shared.Val(textBoxEndRate.Text);
            FormPayWithCard.ReceiptCode = Shared.ObjectToText(textBoxReceptionCode.Text);
            FormPayWithCard.FormClosed += childFormClosed;
            FormPayWithCard.IsVadie = IsVadie;
            FormPayWithCard.IsTarkhis = IsTarkhis;
            FormPayWithCard.IsEghdamat = IsEghdamat;
            FormPayWithCard.IsDrug = IsDrug;
            timerPayTime.Enabled = false;
            textBoxPayTime.Text = "30";
            FormPayWithCard.ReceptionCode = Shared.ObjectToText(GetField("ReceptionCode"));
           await  Task.Run(() =>
            {
                // کدهای سنگین و پردازشی شما در اینجا
                // مثل دسترسی به پایگاه داده یا محاسبات
            }).ContinueWith(t =>
            {
                // این قسمت از کد در رشته‌ی اصلی اجرا می‌شود (به UI دسترسی دارد)
                FormPayWithCard.Show(); // یا هر چیز دیگر
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        void childFormClosed(object sender, EventArgs e)
        {
            ((Form)sender).Closed -= childFormClosed;
            textBoxPayTime.Text = "30";
            timerPayTime.Enabled = true;

        }

        private void timerPayTime_Tick(object sender, EventArgs e)
        {
            if (Shared.Val(textBoxPayTime.Text) == 0)
                this.Close();
            textBoxPayTime.Text = Shared.ObjectToText(Shared.Val(textBoxPayTime.Text) - 1);
        }

        private void uiButtonPay_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void uiButtonPay_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxServiceDescription_TextChanged(object sender, EventArgs e)
        {
            if (textBoxServiceDescription.Text.Length == 0)
            {
                return;
            }

            float height = textBoxServiceDescription.Height * 0.99f;
            float width = textBoxServiceDescription.Width * 0.99f;

            textBoxServiceDescription.SuspendLayout();

            Font tryFont = textBoxServiceDescription.Font;
            Size tempSize = TextRenderer.MeasureText(textBoxServiceDescription.Text, tryFont);

            float heightRatio = height / tempSize.Height;
            float widthRatio = width / tempSize.Width;

            tryFont = new Font(tryFont.FontFamily, tryFont.Size * Math.Min(widthRatio, heightRatio), tryFont.Style);

            textBoxServiceDescription.Font = tryFont;
            textBoxServiceDescription.ResumeLayout();
        }
    }
}