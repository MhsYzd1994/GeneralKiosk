using FastReport.DevComponents.DotNetBar;
using GeneralKiosk.Class;
using GeneralKiosk.Common;
using Ionic.Zip;
using MakeRasisToken;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
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
using static GeneralKiosk.FormMenu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace GeneralKiosk
{
    public partial class Formpatients : Form
    {

        System.Media.SoundPlayer playerLotfanBimar = new System.Media.SoundPlayer(@"Sounds/LotfanBimar.wav");

        public DataTable DtPatients { get; internal set; }
        public DataTable DtAfterSearch { get; internal set; }
        public bool IsTarkhis { get; internal set; } = false;
        public bool IsVadie { get; internal set; } = false;
        public bool IsEghdamat { get; internal set; } = false;
        public bool IsDrug { get; set; } = false;
        public string ParaName { get; internal set; } = "";
        public bool IsOtherReq { get; internal set; }
        public int ParaID { get; internal set; }
        public bool IsNobat { get; internal set; }
        public bool IsSearchMeli { get; internal set; } = false;
        public DataTable BeforeSearchDt { get; private set; }

        public Formpatients()
        {
            InitializeComponent();

        }

        //private async Task<string> GetPayedReceptionCode()
        //{
        //    try
        //    {
        //        DataTable Dt = new DataTable();

        //        using (SqlConnection con = new SqlConnection(Program.ConString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                using (SqlDataAdapter da = new SqlDataAdapter())
        //                {
        //                    cmd.Parameters.Clear();

        //                    cmd.Connection = con;
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    con.Open();
        //                    cmd.CommandText = @"[BS].[SPayedReceptionCode]";

        //                    da.SelectCommand = cmd;
        //                    da.Fill(Dt);

        //                    con.Close();

        //                }
        //            }
        //        }

        //        var list = Dt.AsEnumerable().Select(r => r["ReceptionCode"].ToString());
        //        return string.Join(",", list);

        //    }

        //    cacatch (Exception ex)
        //    {
        //        await Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
        //                 " - " + this.Name);
        //        return "";
        //    }
        //}

        private DataTable GetPayed()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(Program.ConString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {


                            cmd.CommandType = CommandType.Text;
                            cmd.CommandTimeout = 300;
                            cmd.Connection = con;

                            con.Open();
                            cmd.CommandText = @" select  distinct ReceptionCode , EndRate from op.Factors where IsPayed=1";


                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {
                Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
         " - " + this.Name);
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, ex.Message.ToString());
                return null;
            }
        }

        private async void Setpatients()
        {

            flowLayoutPanelMain.Controls.Clear();

            if (IsOtherReq)
            {
                foreach (DataRow Item in Program.DtOtherReq.Select($@"GroupID = {ParaID}"))
                {

                    UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();
                    b.Name = Shared.ObjectToText(Item["OtherName"]);
                    b.Name += "   " + Shared.ObjectToText(Shared.ValInt64(Item["OtherRate"]).ToString("#,###"));
                    b.Tag = Shared.ObjectToText(Item["ID"]);
                    b.Font = new Font("B Yekan", (b.Width + b.Height) / 60, System.Drawing.FontStyle.Bold);
                    if (Program.ShowCol == "ShowTwoCol")
                    {
                        b.Font = new Font("B Yekan", flowLayoutPanelMain.Width / 80, System.Drawing.FontStyle.Bold);
                        b.Size = new Size(((flowLayoutPanelMain.Width) - (flowLayoutPanelMain.Width / 7)) / 2, flowLayoutPanelMain.Width / 10);
                        //Program.InsertLog(this.Name, "SETP", "Font : " + b.Font.ToString() + " , " + b.Size.ToString() + " , " + b.GetType().ToString());
                    }
                    else
                    {
                        b.Size = new Size(((flowLayoutPanelMain.Width) - (flowLayoutPanelMain.Width / 10)), 100);
                    }

                    //b.Size = new Size(20 , 20);
                    flowLayoutPanelMain.Controls.Add(b);
                    SetDoubleBuffered(TableLayoutPanelMain);
                    SetDoubleBuffered(flowLayoutPanelMain);

                    if (Program.PayAfterSearchMeli)
                    {
                        b.Click += async (sender, e) =>
                        {
                            FormPayWithCard FormPayWithCard = new FormPayWithCard();
                            textBoxSearch.Text = "";



                            timerRefreshPatients.Enabled = false;
                            this.TopMost = false;
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
                            FormPayWithCard.Amnt = Shared.ValInt64(Program.DtOtherReq.Select($@"ID = {Shared.Val(b.Tag)} ").FirstOrDefault()["OtherRate"]);
                            FormPayWithCard.ReceiptCode = " - ";
                            FormPayWithCard.FormClosed += childFormClosed;
                            FormPayWithCard.IsVadie = IsVadie;
                            FormPayWithCard.IsTarkhis = IsTarkhis;
                            FormPayWithCard.IsEghdamat = IsEghdamat;
                            FormPayWithCard.IsDrug = IsDrug;
                            FormPayWithCard.IsOtherReq = IsOtherReq;
                            FormPayWithCard.OtherReqID = Shared.Val(b.Tag);
                            FormPayWithCard.ReceptionCode = "-";

                            timerPayTime.Enabled = false;
                            textBoxPayTime.Text = "50";
                            await Task.Run(() =>
                            {
                                // کدهای سنگین و پردازشی شما در اینجا
                                // مثل دسترسی به پایگاه داده یا محاسبات
                            }).ContinueWith(t =>
                            {
                                // این قسمت از کد در رشته‌ی اصلی اجرا می‌شود (به UI دسترسی دارد)
                                FormPayWithCard.Show(); // یا هر چیز دیگر
                            }, TaskScheduler.FromCurrentSynchronizationContext());
                        };
                    }
                    else
                    {
                        b.Click += (sender, e) =>
                        {

                            textBoxSearch.Text = "";

                            timerRefreshPatients.Enabled = false;
                            this.TopMost = false;
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
                            FormpatientInfoObj.IsOtherReq = IsOtherReq;
                            FormpatientInfoObj.ReceptionCode = b.Tag.ToString();
                            FormpatientInfoObj.ParaName = ParaName;
                            FormpatientInfoObj.OtherReqID = Shared.Val(b.Tag);
                            timerPayTime.Enabled = false;
                            textBoxPayTime.Text = "50";

                            FormpatientInfoObj.Show();
                        };
                    }

                }
                textBoxSearch.Focus();
                textBoxSearch.SelectAll();
                return;

            }
            try
            {
                DtAfterSearch.DefaultView.Sort = "ReceptionDate Desc , ReceptionTime Desc";
            }
            catch
            {

            }

            DataTable PayedDt = new DataTable();

            PayedDt = GetPayed();



            // مرحله 1: استخراج مقادیر و ساخت آرایه excludedCodes
            var excludedCodes = PayedDt.AsEnumerable()
                .Select(row => $"{row.Field<long>("ReceptionCode")}-{row.Field<long>("EndRate")}")
                .ToArray();

            // مرحله 2: بررسی خالی نبودن excludedCodes و ایجاد شرط مناسب برای RowFilter
            string notInCondition = excludedCodes.Any()
                ? string.Join(",", excludedCodes.Select(code => $"'{code}'"))
                : null;

            // مرحله 3: افزودن ستون جدید CombinedCode به DtAfterSearch
            if (!DtAfterSearch.Columns.Contains("CombinedCode"))
            {
                DtAfterSearch.Columns.Add("CombinedCode", typeof(string));
            }

            // مرحله 4: اعمال فیلتر روی DefaultView (در صورت معتبر بودن notInCondition)
            if (!string.IsNullOrEmpty(notInCondition))
            {
                foreach (DataRow row in DtAfterSearch.Rows)
                {
                    row["CombinedCode"] = $"{row["ReceptionCode"]}-{row["EndRate"]}";
                }
                DtAfterSearch.DefaultView.RowFilter = $"CombinedCode NOT IN ({notInCondition})";
            }
            else
            {
                // در صورت خالی بودن excludedCodes، فیلتر را پاک می‌کنیم یا اقدامی دیگر انجام می‌دهیم
                DtAfterSearch.DefaultView.RowFilter = string.Empty;
            }


            DtAfterSearch = DtAfterSearch.DefaultView.ToTable();

            for (int i = 0; i < DtAfterSearch.Rows.Count; i++)
            {
                if (Shared.ObjectToText(DtAfterSearch.Rows[i]["ReceptionCode"]) == "")
                    continue;
                //var GetPayed = await GetPayedReceptionCode();
                //if (GetPayed.Split(',').Contains(Shared.ObjectToText(Shared.ValInt64(DtAfterSearch.Rows[i]["ReceptionCode"]))))
                //    continue;


                UserControlItemsButtonMenu b = new UserControlItemsButtonMenu();

                b.Name = Shared.ObjectToText(DtAfterSearch.Rows[i]["FirstName"]) + " " +
                    Shared.ObjectToText(DtAfterSearch.Rows[i]["LastName"]);

                if (IsSearchMeli)
                {
                    b.Name += "-" + Shared.ObjectToText(DtAfterSearch.Rows[i]["ParaClinicName"]);
                }
                if (Program.PatientNameTopToBott)
                {
                    b.Name += "\n" + Shared.ObjectToText(DtAfterSearch.Rows[i]["ReceptionCode"]);
                }
                else
                {
                    b.Name += "   " + Shared.ObjectToText(DtAfterSearch.Rows[i]["ReceptionCode"]);
                }

                b.Tag = Shared.ObjectToText(DtAfterSearch.Rows[i]["ReceptionCode"]);
                b.Font = new Font("B Yekan", (b.Width) / 60, System.Drawing.FontStyle.Bold);
                if (Program.ShowCol == "ShowTwoCol")
                {
                    b.Font = new Font("B Yekan", flowLayoutPanelMain.Width / 80, System.Drawing.FontStyle.Bold);
                    b.Size = new Size(((flowLayoutPanelMain.Width) - (flowLayoutPanelMain.Width / 7)) / 2, flowLayoutPanelMain.Width / 10);
                    //Program.InsertLog(this.Name, "SETP", "Font : " + b.Font.ToString()+" , "+ b.Size.ToString() + " , " +  b.GetType().ToString());
                }
                else
                {
                    b.Size = new Size(((flowLayoutPanelMain.Width) - (flowLayoutPanelMain.Width / 10)), 100);
                }
                //b.Size = new Size(20 , 20);
                flowLayoutPanelMain.Controls.Add(b);
                SetDoubleBuffered(TableLayoutPanelMain);
                SetDoubleBuffered(flowLayoutPanelMain);


                if (Program.PayAfterSearchMeli)
                {
                    b.Click += async (sender, e) =>
                    {
                        textBoxSearch.Text = "";

                        DataRow SelectedRow = DtAfterSearch.AsEnumerable()
  .Where(myRow => myRow.Field<string>("ReceptionCode") == b.Tag.ToString()).FirstOrDefault();

                        timerRefreshPatients.Enabled = false;
                        this.TopMost = false;
                        FormPayWithCard FormPayWithCard = new FormPayWithCard();
                        await Program.InsertLogToFile("OKPay : " + Shared.ConvertToFinglish(Shared.ObjectToText(SelectedRow["ParaClinicName"])) + " ReceptionCode : " + Shared.ObjectToText(SelectedRow["ReceptionCode"])
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
                        FormPayWithCard.Amnt = Shared.ValInt64(SelectedRow["EndRate"]);
                        FormPayWithCard.ReceiptCode = Shared.ObjectToText(SelectedRow["ReceptionCode"]);
                        FormPayWithCard.FormClosed += childFormClosed;
                        FormPayWithCard.IsVadie = IsVadie;
                        FormPayWithCard.IsTarkhis = IsTarkhis;
                        FormPayWithCard.IsEghdamat = IsEghdamat;
                        FormPayWithCard.IsDrug = IsDrug;
                        FormPayWithCard.ReceptionCode = Shared.ObjectToText(SelectedRow["ReceptionCode"]);
                        timerPayTime.Enabled = false;
                        textBoxPayTime.Text = "50";
                        await Task.Run(() =>
                        {
                            // کدهای سنگین و پردازشی شما در اینجا
                            // مثل دسترسی به پایگاه داده یا محاسبات
                        }).ContinueWith(t =>
                        {
                            // این قسمت از کد در رشته‌ی اصلی اجرا می‌شود (به UI دسترسی دارد)
                            FormPayWithCard.Show(); // یا هر چیز دیگر
                        }, TaskScheduler.FromCurrentSynchronizationContext());
                    };
                }
                else
                {

                    b.Click += (sender, e) =>
            {
                textBoxSearch.Text = "";

                timerRefreshPatients.Enabled = false;
                this.TopMost = false;
                CloseFormsKeyBoard();


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



                DataRow SelectedRow = DtAfterSearch.AsEnumerable()
                  .Where(myRow => myRow.Field<string>("ReceptionCode") == b.Tag.ToString()).FirstOrDefault();


                if (IsVadie)
                {
                    SelectedRow["ParaClinicName"] = Shared.ObjectToText(SelectedRow["ClinicName"]);
                    SelectedRow["ServiceDescription"] = Shared.ObjectToText(SelectedRow["ClinicName"]);
                }
                else if (IsTarkhis)
                {

                    SelectedRow["ServiceDescription"] = Shared.ObjectToText(SelectedRow["ParaClinicName"]);

                }
                else if (IsEghdamat)
                {

                    SelectedRow["ParaClinicName"] = "اقدامات";

                }
                else if (IsDrug)
                {

                    SelectedRow["ParaClinicName"] = "داروخانه";

                }

                FormpatientInfoObj.ReceptionCode = b.Tag.ToString();
                FormpatientInfoObj.ParaName = ParaName;

                timerPayTime.Enabled = false;
                textBoxPayTime.Text = "50";
                FormpatientInfoObj.Show();

            };
                }


            }

            textBoxSearch.Focus();
            textBoxSearch.SelectAll();

        }

        void childFormClosed(object sender, EventArgs e)
        {
            ((Form)sender).Closed -= childFormClosed;
            textBoxSearch.Text = "";
            textBoxSearch.Focus();
            textBoxSearch.SelectAll();



            if (Program.UpdatePatient && Program.BakhshCount == 1)
            {
                RefreshPatients();
                Setpatients();
                timerRefreshPatients.Enabled = true;

                return;
            }
            else
            {
                if(IsOtherReq)
                {
                    Program.DtOtherReq = BeforeSearchDt.Copy();
                }
                else
                {
                    DtAfterSearch = BeforeSearchDt.Copy();
                }
                Setpatients();
                textBoxPayTime.Text = "50";
                textBoxSearch.Focus();
                Shared.KeyboardArabic();
                timerPayTime.Enabled = true;
            }

            DtAfterSearch = DtPatients;





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
        private async void Form23_Load(object sender, EventArgs e)
        {
            if(!IsOtherReq)
            {
                BeforeSearchDt = new DataTable();
                if(DtAfterSearch != null)
                BeforeSearchDt = DtAfterSearch.Copy();
            }
            else 
            {
                BeforeSearchDt = new DataTable();
                BeforeSearchDt = Program.DtOtherReq.Copy();
            }

            textBoxSearch.Focus();
            textBoxSearch.SelectAll();
            timerRefreshPatients.Interval = Shared.Val((Shared.Val(Program.UpdatePatientTimer) < 4 ? 4 : Program.UpdatePatientTimer) * 1000);
            SetImages();
            var Tem = (TableLayoutPanelMain.Width / 2) - 320;
            System.Windows.Forms.Padding margin = pictureBoxTopRight.Margin;
            margin.Right = Shared.Val(Tem);
            pictureBoxTopRight.Margin = margin;

            margin = pictureBoxTopCenter.Margin;
            margin.Right = Shared.Val(Tem);
            pictureBoxTopCenter.Margin = margin;
            flowLayoutPanelMain.Controls.Clear();

            if (Program.UpdatePatient && Program.BakhshCount == 1)
            {
                timerRefreshPatients.Enabled = true;
                timerRefreshPatients.Interval = Shared.Val((Shared.Val(Program.UpdatePatientTimer) < 4 ? 4 : Program.UpdatePatientTimer) * 1000);
                timerPayTime.Enabled = false;
                textBoxPayTime.Visible = false;
                pictureBoxCancelFactor.Visible = false;
                pictureBoxFile.Visible = true;
                IsTarkhis = Program.IsTarkhis;
                IsEghdamat = Program.IsEghdamat;
                IsVadie = Program.IsVadie;
                IsDrug = Program.IsDrug;
                ParaName = Program.ParaName;
                DtAfterSearch = Program.dtPaient;
                DtAfterSearch.DefaultView.Sort = "ReceptionDate Desc  , ReceptionTime Desc";
                DtAfterSearch = DtAfterSearch.DefaultView.ToTable();
                timerBackup.Enabled = true;
                LoadPosSetting();
                await RefreshPatients();
                Setpatients();

                return;
            }
            else
            {
                timerBackup.Enabled = false;
                timerRefreshPatients.Enabled = false;
                timerPayTime.Enabled = true;
                textBoxPayTime.Text = "50";
                pictureBoxCancelFactor.Visible = true;
                pictureBoxFile.Visible = false;
                pictureBoxFile.Visible = false;
            }

            textBoxSearch.Focus();
            Shared.KeyboardArabic();
            Setpatients();
            if (flowLayoutPanelMain.Controls.Count <= 0)
            {
                frmCustomOkMsgBox = new CustomOkMsgBox("موردی یافت نشد ! "
         , global::GeneralKiosk.Properties.Resources.WarningPic);
                if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                {

                    this.Close();
                    return;
                }
            }
            else
            {
                if (!Program.MuteSound)
                {
                    playerLotfanBimar.Play();
                }
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

        }


        //protected override void WndProc(ref Message m)
        //{
        //    // Define DoubleClick...
        //    const int WM_NCLBUTTONDBLCLK = 163;
        //    // Define LeftButtonDown event...
        //    const int WM_NCLBUTTONDOWN = 161;
        //    // Define MOVE action...
        //    const int WM_SYSCOMMAND = 274;
        //    // Define that the WM_NCLBUTTONDOWN is at TitleBar...
        //    const int HTCAPTION = 2;
        //    // Trap MOVE action...
        //    const int SC_MOVE = 61456;
        //    // Disable moving TitleBar...
        //    if (((m.Msg == WM_SYSCOMMAND)
        //                && (m.WParam.ToInt32() == SC_MOVE)))
        //    {
        //        return;
        //    }
        //    // Track whether clicked on TitleBar...
        //    if (((m.Msg == WM_NCLBUTTONDOWN)
        //                && (m.WParam.ToInt32() == HTCAPTION)))
        //    {
        //        return;
        //    }
        //    // Disable double click on TitleBar...
        //    if ((m.Msg == WM_NCLBUTTONDBLCLK))
        //    {
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}


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
            //if (!string.IsNullOrEmpty(_barcode))
            //{
            //    _barcode = "";
            //    return;
            //}
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }


        private string _barcode = "";
        private CustomOkMsgBox frmCustomOkMsgBox;

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


        private void pictureBoxCancelFactor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerPayTime_Tick(object sender, EventArgs e)
        {
            if (Shared.Val(textBoxPayTime.Text) == 0)
                this.Close();
            textBoxPayTime.Text = Shared.ObjectToText(Shared.Val(textBoxPayTime.Text) - 1);
        }

        private void Formpatients_FormClosing(object sender, FormClosingEventArgs e)
        {

            CloseFormsKeyBoard();
            timerRefreshPatients.Enabled = false;
            try
            {
                if (frmCustomOkMsgBox != null)
                    frmCustomOkMsgBox.Close();
            }
            catch
            {

            }

            if (Program.ExitApp)
            {
                e.Cancel = false;
                return;
            }
            if (Program.UpdatePatient && Program.BakhshCount == 1)
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
                        try
                        {
                            foreach (Form f in Application.OpenForms)
                            {
                                if (f.Name == "Formpatients")
                                {
                                    continue;
                                }
                                f.Close();
                            }
                        }
                        catch
                        {

                        }


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
            timerRefreshPatients.Enabled = true;

        }

        private void Formpatients_Activated(object sender, EventArgs e)
        {
            textBoxSearch.Focus();
            Shared.KeyboardArabic();
        }


        private void pictureBoxFile_Click(object sender, EventArgs e)
        {
            contextMenuStripFiles.Show(Cursor.Position.X - 10, Cursor.Position.Y + 5);
        }

        private async Task SelectSettingAsync()
        {
            timerRefreshPatients.Enabled = false;

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

                    Program.LoadSetting();

                    if (Program.UpdatePatient && Program.BakhshCount == 1)
                    {
                        timerRefreshPatients.Enabled = true;
                        timerRefreshPatients.Interval = Shared.Val((Shared.Val(Program.UpdatePatientTimer) < 4 ? 4 : Program.UpdatePatientTimer) * 1000);
                        timerPayTime.Enabled = false;
                        textBoxPayTime.Visible = false;
                        pictureBoxCancelFactor.Visible = false;
                        pictureBoxFile.Visible = true;
                        IsTarkhis = Program.IsTarkhis;
                        IsEghdamat = Program.IsEghdamat;
                        IsVadie = Program.IsVadie;
                        IsDrug = Program.IsDrug;
                        ParaName = Program.ParaName;
                        DtAfterSearch = Program.dtPaient;
                        DtAfterSearch.DefaultView.Sort = "ReceptionDate Desc  , ReceptionTime Desc";
                        DtAfterSearch = DtAfterSearch.DefaultView.ToTable();
                        LoadPosSetting();
                        await RefreshPatients();
                        Setpatients();

                        return;
                    }

                }
                else if (frmprompt.MyPass == Program.Pass)
                {
                    using (FormMainSetting frm = new FormMainSetting())
                    {

                        frm.UserType = (int)Program.EnumUserType.Modir;
                        frm.ShowDialog();
                    }

                    Program.LoadSetting();

                    if (Program.UpdatePatient && Program.BakhshCount == 1)
                    {
                        timerPayTime.Enabled = false;
                        timerRefreshPatients.Enabled = true;
                        timerRefreshPatients.Interval = Shared.Val((Shared.Val(Program.UpdatePatientTimer) < 4 ? 4 : Program.UpdatePatientTimer) * 1000);
                        textBoxPayTime.Visible = false;
                        pictureBoxCancelFactor.Visible = false;
                        pictureBoxFile.Visible = true;
                        IsTarkhis = Program.IsTarkhis;
                        IsEghdamat = Program.IsEghdamat;
                        IsVadie = Program.IsVadie;
                        IsDrug = Program.IsDrug;
                        ParaName = Program.ParaName;
                        DtAfterSearch = Program.dtPaient;
                        DtAfterSearch.DefaultView.Sort = "ReceptionDate Desc  , ReceptionTime Desc";
                        DtAfterSearch = DtAfterSearch.DefaultView.ToTable();
                        LoadPosSetting();
                        await RefreshPatients();
                        Setpatients();

                        return;
                    }
                }

            timerRefreshPatients.Enabled = true;
        }

        private void تنظیماتToolStripMenuItem_Click_1Async(object sender, EventArgs e)
        {
            SelectSettingAsync();
        }

        private void دربارهیماToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            timerRefreshPatients.Enabled = false;
            using (AboutBox frm = new AboutBox())
            {
                frm.ShowDialog();
            }

            timerRefreshPatients.Enabled = true;
        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void تنظیماتدستگاهکارتخوانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerRefreshPatients.Enabled = false;
            prompt frmprompt = new prompt();

            if (frmprompt.ShowDialog() == DialogResult.OK)
                if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                {
                    using (frmPosSetting frm = new frmPosSetting())
                    {
                        frm.ShowDialog();
                        LoadPosSetting();

                        timerRefreshPatients.Enabled = true;
                    }

                }
                else if (frmprompt.MyPass == Program.Pass)
                {
                    using (frmPosSetting frm = new frmPosSetting())
                    {

                        frm.ShowDialog();
                        LoadPosSetting();

                        timerRefreshPatients.Enabled = true;
                    }
                }


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
                    panelMain.Enabled = false;

                    return;
                }
                else
                {
                    panelMain.Enabled = true;
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

        void FormFactorListClosed(object sender, EventArgs e)
        {
            ((Form)sender).Closed -= FormFactorListClosed;
            if (Program.UpdatePatient && Program.BakhshCount == 1)
            {
                timerRefreshPatients.Enabled = true;
            }
        }

        private void گزارشاتToolStripMenuItem_Click(object sender, EventArgs e)
        {

            timerRefreshPatients.Enabled = false;
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
                    FormFactorList.FormClosed += FormFactorListClosed;

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
                    FormFactorList.FormClosed += FormFactorListClosed;
                }
                else
                {
                    if (Program.UpdatePatient && Program.BakhshCount == 1)
                    {
                        timerRefreshPatients.Enabled = true;
                    }
                }



        }

        private string GetTagName()
        {
            if (Program.IsVadie)
            {
                return "InquiryView";
            }
            else if (Program.IsTarkhis)
            {
                return "InquiryView";
            }
            else if (Program.IsEghdamat)
            {
                return "InquiryView";
            }
            else if (Program.IsDrug)
            {
                return "DataDocument";
            }
            else
            {
                return "InquiryView01";
            }
        }
        private async Task RefreshPatients()
        {
            Program.CheckBakhshCount();
            labelInfo.Text = "بروزرسانی بیماران ...";
            timerRefreshPatients.Enabled = false;
            panelMain.Enabled = false;
            pictureBoxFile.Enabled = false;
            pictureBoxCancelFactor.Enabled = false;

            try
            {
                Uri myUri = new Uri(Program.UrlForRefresh);

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
                XmlNodeList elemList = root.GetElementsByTagName(GetTagName());

                DtPatients = await Program.ConvertXmlNodeListToDataTable(elemList);


                if (DtPatients is null)
                {
                    panelMain.Enabled = true;
                    timerRefreshPatients.Enabled = true;
                    pictureBoxFile.Enabled = true;
                    pictureBoxCancelFactor.Enabled = true;
                    labelInfo.Text = "جهت جستجو نام بیمار یا کد پذیرش و یا کد ملی را تایپ کنید";
                    return;
                }
                if (DtPatients.Rows.Count <= 0)
                {
                    panelMain.Enabled = true;
                    timerRefreshPatients.Enabled = true;
                    pictureBoxFile.Enabled = true;
                    pictureBoxCancelFactor.Enabled = true;
                    labelInfo.Text = "جهت جستجو نام بیمار یا کد پذیرش و یا کد ملی را تایپ کنید";
                    return;

                }

                DtPatients = DtPatients;
                DtAfterSearch = DtPatients;
                DtAfterSearch.DefaultView.Sort = "ReceptionDate Desc  , ReceptionTime Desc ";
                DtAfterSearch = DtAfterSearch.DefaultView.ToTable();
                panelMain.Enabled = true;
                timerRefreshPatients.Enabled = true;
                pictureBoxFile.Enabled = true;
                pictureBoxCancelFactor.Enabled = true;
                labelInfo.Text = "جهت جستجو نام بیمار یا کد پذیرش و یا کد ملی را تایپ کنید";
            }
            catch (Exception ex)
            {

                await Program.InsertLogToFile("RefreshPatient Error" + ex.Message);
                labelInfo.Text = "جهت جستجو نام بیمار یا کد پذیرش و یا کد ملی را تایپ کنید";
                panelMain.Enabled = true;
                timerRefreshPatients.Enabled = true;
                pictureBoxFile.Enabled = true;
                pictureBoxCancelFactor.Enabled = true;
            }
        }

        private async void timerRefreshPatients_Tick(object sender, EventArgs e)
        {
            await RefreshPatients();
            Setpatients();
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

        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            ShowKeyBoardAsync(((TextBox)sender));
        }

        private async Task ShowKeyBoardAsync(TextBox textbox)
        {
            try
            {
                CloseFormsKeyBoard();
                if (Program.ActiveKeyPad)
                {
                    NumericKeyboardForm keyboardForm = new NumericKeyboardForm(textbox);

                    if (keyboardForm == null || keyboardForm.IsDisposed)
                    {
                        keyboardForm = new NumericKeyboardForm(textbox);
                    }

                    // تنظیم مکان و اندازه کیبورد
                    var textBoxPosition = textbox.PointToScreen(Point.Empty);
                    var textBoxCenterX = textBoxPosition.X + textbox.Width / 2;

                    // محاسبه موقعیت فرم برای قرارگیری زیر تکس باکس و هم‌راستایی عرض
                    var formWidth = keyboardForm.Width;
                    var formPositionX = textBoxCenterX - formWidth / 2;
                    var formPositionY = textBoxPosition.Y + textbox.Height + 50;

                    keyboardForm.StartPosition = FormStartPosition.Manual;
                    keyboardForm.Location = new Point(formPositionX, formPositionY);
                    keyboardForm.TopMost = true;
                    keyboardForm.Show();
                    //await Task.Delay(100);
                    textbox.Focus();
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

        private void Formpatients_Click(object sender, EventArgs e)
        {
            //if (!textBoxSearch.Bounds.Contains(this.PointToClient(Cursor.Position)))
            //{
            //    CloseFormsKeyBoard();

            //}
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != "")
            {
                if (DtPatients.Rows.Count <= 0)
                    return;
                DtAfterSearch = new DataTable();
                DataRow[] DataArr = DtPatients.Select("ReceptionCode LIKE '%" + textBoxSearch.Text.Trim() +
                    "%' OR FirstName LIKE '%" + textBoxSearch.Text.Trim() +
                    "%' OR LastName LIKE '%" + textBoxSearch.Text.Trim() +
                    "%' OR FirstName LIKE '%" + textBoxSearch.Text.Trim().Replace("ی", "ي") +
                    "%' OR FirstName LIKE '%" + textBoxSearch.Text.Trim().Replace("ک", "ك") +
                    "%' OR LastName LIKE '%" + textBoxSearch.Text.Trim().Replace("ی", "ي") +
                    "%' OR nationalNumber LIKE '%" + textBoxSearch.Text.Trim() +
                    "%' OR NationalNo LIKE '%" + textBoxSearch.Text.Trim()
                    + "%'");
                if (DataArr != null && DataArr.Length > 0)
                {
                    DtAfterSearch = DataArr.CopyToDataTable();
                }

            }
            else
            {
                DtAfterSearch = DtPatients;
            }
            Setpatients();
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (textBoxSearch.Text != "")
                {
                    DtAfterSearch = new DataTable();
                    DataRow[] DataArr = DtPatients.Select("ReceptionCode LIKE '%" + textBoxSearch.Text.Trim() +
                        "%' OR FirstName LIKE '%" + textBoxSearch.Text.Trim() +
                        "%' OR LastName LIKE '%" + textBoxSearch.Text.Trim() +
                        "%' OR FirstName LIKE '%" + textBoxSearch.Text.Trim().Replace("ی", "ي") +
                        "%' OR FirstName LIKE '%" + textBoxSearch.Text.Trim().Replace("ک", "ك") +
                        "%' OR LastName LIKE '%" + textBoxSearch.Text.Trim().Replace("ی", "ي") +
                        "%' OR nationalNumber LIKE '%" + textBoxSearch.Text.Trim() +
                        "%' OR NationalNo LIKE '%" + textBoxSearch.Text.Trim()
                        + "%'");
                    if (DataArr != null && DataArr.Length > 0)
                    {
                        DtAfterSearch = DataArr.CopyToDataTable();
                    }

                }
                else
                {
                    DtAfterSearch = DtPatients;
                }
                Setpatients();
            }
        }
    }
}