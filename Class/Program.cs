using FastReport.Map;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NPOI.XWPF.UserModel;
using SepPaySCG;
using SSP1126.PcPos.BaseClasses;
using SSP1126.PcPos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.AxHost;
using NPOI.SS.Formula.Functions;
using System.Reflection;
using FastReport.Barcode;

namespace GeneralKiosk
{
    static class Program
    {
        public static long ProcessorId { get; private set; }
        public static string Onme { get; internal set; } = "";
        public static string Adres { get; private set; } = "";
        public static string UserCode { get; private set; } = "";
        public static FormStart FrmStart { get; internal set; }
        public static FormMenu FormpatientsMenu { get; internal set; }
        public static string Pass { get; internal set; } = "";
        public static string ConString { get; internal set; }
        public static string VahedPool { get; internal set; } = "ریال";
        public static int ShowPatiaentListDay { get; private set; } = 0;
        public static bool PictureTopCenterVisible { get; private set; } = false;
        public static bool PictureTopLeftVisible { get; private set; } = false;
        public static bool PictureCenterVisible { get; private set; } = false;
        public static bool PictureShowMessagetVisible { get; private set; } = false;
        public static bool PictureDownVisible { get; private set; } = false;
        public static bool PictureTopRightVisible { get; private set; } = false;
        public static bool HasVadie { get; internal set; } = false;
        public static bool HasTarkhis { get; internal set; } = false;
        public static bool ShowReceptionDateTime { get; private set; } = false;
        public static bool ShowGhabzNum { get; private set; } = false;
        public static bool ShowReceptionCode { get; private set; } = false;
        public static bool ShowDocumentCode { get; private set; } = false;
        public static bool ShowPatientName { get; private set; } = false;
        public static bool ShowDoctorName { get; private set; } = false;
        public static bool ShowNationalNumber { get; private set; } = false;
        public static bool ShowPatientRate { get; private set; } = false;
        public static bool ShowInsuranceName { get; private set; } = false;
        public static bool ShowInsuranceRate { get; private set; } = false;
        public static bool ShowSupplementaryName { get; private set; } = false;
        public static bool ShowSupplementaryRate { get; private set; } = false;
        public static bool ShowServiceDescription { get; private set; } = false;
        public static bool ShowRno { get; private set; } = false;
        public static bool ShowParaClinicName { get; private set; } = false;
        public static Image PictureTopRightImage { get; private set; } = null;
        public static byte[] PictureTopRightpic { get; private set; } = null;
        public static byte[] PictureTopCenterpic { get; private set; } = null;
        public static Image PictureTopCenterImage { get; private set; } = null;
        public static byte[] PictureTopLeftpic { get; private set; } = null;
        public static Image PictureTopLeftImage { get; private set; } = null;
        public static byte[] PictureCenterpic { get; private set; } = null;
        public static Image PictureCenterImage { get; private set; } = null;
        public static byte[] PictureShowMessagepic { get; private set; } = null;
        public static Image PictureShowMessageImage { get; private set; } = null;
        public static byte[] PictureDownpic { get; private set; } = null;
        public static Image PictureDownImage { get; private set; } = null;

        public static DataTable dtPaient { get; set; } = null;

        private static CustomOkMsgBox frmCustomOkMsgBox;


        public enum EnumUserType
        {
            Backup = 0,
            Modir = 1

        }

        internal static ResponseLanguage _responseLanguage;
        internal static AccountType _accountType;
        internal static MediaType _mediaType;
        internal static AsyncType _asyncType;
        internal static TransactionType _tracsactionType;
        internal static string pictureBoxTopRightPath;
        internal static string pictureBoxTopCentertPath;
        internal static string pictureBoxTopLeftPath;
        internal static string pictureBoxCenterPath;
        internal static string pictureBoxShowMessagePath;
        internal static string pictureBoxDownPath;
        internal static bool softCode01;
        internal static bool softCode34;
        internal static bool softCode11;

        public static string WebServiceAddres { get; private set; }
        public static byte[] PicturePrintpic { get; internal set; }
        public static Image PrintImage { get; internal set; }
        public static string PrintImagePath { get; internal set; }
        public static bool TestPay { get; internal set; } = false;
        public static bool SenTest { get; internal set; } = false;
        public static bool MuteSound { get; internal set; }
        public static bool ShowEghdamat { get; internal set; }
        public static string TerminalID { get; internal set; }
        public static string PosIP { get; internal set; }
        public static string ComPortNum { get; internal set; }
        public static string StartForm { get; internal set; }
        public static bool SearchByNationalCodeStartFrm { get; internal set; }
        public static bool ExitApp { get; internal set; } = false;
        public static List<PrintInfo> PrintList { get; internal set; }
        public static bool ShowDrug { get; internal set; }
        public static string DrugCode { get; internal set; }
        public static bool UpdatePatient { get; internal set; }
        public static long UpdatePatientTimer { get; internal set; } = 30;
        public static DataTable DtParaClinics { get; internal set; }
        public static Formpatients Formpatients { get; private set; }
        public static int BakhshCount { get; private set; }
        public static string UrlForRefresh { get; internal set; }
        public static bool IsDrug { get; private set; }
        public static bool IsEghdamat { get; private set; }
        public static bool IsTarkhis { get; private set; }
        public static bool IsVadie { get; private set; }
        public static string ParaName { get; private set; }
        public static DataTable DtDrugs { get; private set; }
        public static DateTime SystemDate { get; internal set; }
        public static string SystemDateMiladi { get; internal set; }
        public static string BackPath { get; internal set; }
        public static bool ActiveAutoBack { get; internal set; }
        public static DataTable DtOtherReq { get;  set; }
        public static bool ShowOther { get; internal set; }
        public static bool ShowOtherInstart { get; internal set; }
        public static string ShowCol { get; internal set; }
        public static bool CheckMeli { get; internal set; }
        public static bool ActiveKeyPad { get; internal set; }
        public static bool ShowParaStartForm { get; internal set; }
        public static bool ShowNobat { get; internal set; }
        public static string NobatLink { get; internal set; }
        public static bool CanCloseNumForm { get; internal set; }
        public static bool PayAfterSearchMeli { get; internal set; }
        public static bool SendCardNum { get; internal set; }
        public static bool ShowExternalBeneficiaryName { get; internal set; }
        public static bool ShowSalamatTrackingCode { get; internal set; }
        public static bool PatientNameTopToBott { get; internal set; }
        public static bool SendIssueAfterPay { get; internal set; }
        public static bool SendRefNumAfterPay { get; internal set; }
        public static bool SendTerminalAfterPay { get; internal set; }
        public static bool PrintOtherMoshtari { get; internal set; }
        public static bool PrintOtherMaj { get; internal set; }
        public static bool PrintOtherNormal { get; internal set; }
        public static bool NotSearchsoftCode01 { get; internal set; }
        public static bool NotSearchsoftCode34 { get; internal set; }
        public static bool NotSearchsoftCode11 { get; internal set; }
        public static bool NotSearchsoftCode16 { get; internal set; }
        public static bool NotSearchsoftCode06 { get; internal set; }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-IR");
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
                Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";


                // ثبت لاگ
                //await Program.InsertLogToFile("1");

                // تنظیم اعتبارسنجی گواهی SSL
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                // تابع GetProcessorId را فراخوانی کنید
                GetProcessorId();

                // ادامه کد برنامه
            }
            catch (Exception ex)
            {
                //await Program.InsertLogToFile($"Error: {ex.Message}");
                // در اینجا می‌توانید اقدامات لازم برای مدیریت خطا را انجام دهید
            }

            //var isLicenseValid =  CheckLicenseAsync();

            //if (Shared.ObjectToBool(isLicenseValid))
            //{
            //    Console.WriteLine("License is valid.");
            //}
            //else
            //{
            //    Console.WriteLine("License is invalid or an error occurred.");
            //}


            if (Shared.GetConnectionString() == false)
            {

                FrmMakeNewConnection childForm = null;
                childForm = new FrmMakeNewConnection
                {
                    TopMost = false,
                    ShowInTaskbar = true,
                    MinimizeBox = true,
                    MaximizeBox = false,
                    ControlBox = true,
                    WindowState = FormWindowState.Normal
                };
                childForm.InsertIntoIniFile = true;
                childForm.ShowDialog();
            }

            if (string.IsNullOrEmpty(Program.ConString))
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "فایل اتصال به بانک اطلاعاتی مشکل دارد");
                return;
            }


            using (SqlConnection con = new SqlConnection(Program.ConString))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        #region MyRegion
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmd.CommandText = $@"SELECT   
                                Mc as Mc, 
                                Ace as Ace
                                FROM    BS.TPCG
                                WHERE  (TPCGID = {Program.ProcessorId})";
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                #region MyRegion
                                if (Shared.ObjectToText(dt.Rows[0]["Ace"]) == "")
                                {
                                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "اطلاعات نامعتبر در DB موجود است");
                                    return;
                                }
                                else if (Shared.ObjectToText(dt.Rows[0]["Mc"]) == "")
                                {
                                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "اطلاعات نامعتبر در DB موجود است");
                                    return;
                                }
                                else if (dt.Rows[0]["Ace"].ToString() == "ندارد")
                                {
                                    //OK
                                }
                                else if (dt.Rows[0]["Ace"].ToString() != "ندارد")
                                {
                                    string key = "";
                                    if (Shared.ObjectToText(dt.Rows[0]["Ace"]) == "")
                                    {
                                        Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "اطلاعات نامعتبر در DB موجود است");
                                        return;
                                    }
                                    key = Shared.ObjectToText(dt.Rows[0]["Ace"]);

                                    if (key.IndexOf("-") <= 0)
                                    {
                                        long x = Program.ProcessorId;
                                        if (key == ((x / 1394) + (x / 1355) + (x / 1356) + (x / 1354)).ToString())
                                        {
                                            //OK
                                        }
                                        else
                                        {
                                            Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "اطلاعات نامعتبر در DB موجود است");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        SecurityManager sm = new SecurityManager();
                                        if (!sm.CheckKey(key, "6cEN*8`2wcU:{d5K", Program.ProcessorId))
                                        {
                                            long x = Program.ProcessorId;
                                            if (key == ((x / 1394) + (x / 1355) + (x / 1356) + (x / 1354)).ToString())
                                            {
                                                //OK
                                            }
                                            else
                                            {
                                                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "اطلاعات نامعتبر در DB موجود است");
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            //OK
                                        }
                                    }
                                }
                                else
                                {
                                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "اطلاعات نامعتبر در DB موجود است");
                                    return;
                                }
                                #endregion
                            }
                            else
                            {

                                cmd.CommandText = $@"INSERT INTO BS.TPCG
                                    (TPCGID, Mc, Ace)
                                    SELECT        '{Program.ProcessorId}' AS Expr1, Mc, Ace
                                    FROM            BS.TPCG AS TPCG_1
                                    WHERE        (TPCGID = 1)";

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }

                        #endregion
                    }

                }
                catch (Exception ex)
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "فایل اتصال به بانک اطلاعاتی مشکل دارد" + ex.ToString());
                }
            }



            LoadSetting();


            if (CheckSA() == 666)
            {

                if (UpdatePatient && BakhshCount == 1)
                {
                    Formpatients = new Formpatients();
                    Formpatients.BringToFront();
                    Formpatients.TopMost = true;
                    Formpatients.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Formpatients.Left = 0;
                    Formpatients.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Formpatients.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    //Program.InsertMobMainUIForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    Formpatients.WindowState = FormWindowState.Maximized;




                    Application.Run(new Formpatients());
                }
                else if (StartForm == "StartParaclinicList")
                {
                    FormpatientsMenu = new FormMenu();
                    FormpatientsMenu.BringToFront();
                    FormpatientsMenu.TopMost = true;
                    FormpatientsMenu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    FormpatientsMenu.Left = 0;
                    FormpatientsMenu.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    FormpatientsMenu.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    //Program.InsertMobMainUIForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    FormpatientsMenu.WindowState = FormWindowState.Maximized;


                    Application.Run(new FormMenu());
                }
                else
                {
                    FrmStart = new FormStart();
                    FrmStart.BringToFront();
                    FrmStart.TopMost = true;
                    FrmStart.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    FrmStart.Left = 0;
                    FrmStart.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    FrmStart.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    //Program.InsertMobMainUIForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    FrmStart.WindowState = FormWindowState.Maximized;

                    Application.Run(new FormStart());
                }


            }



        }

        public static async Task<bool> CheckLicenseAsync()
        {
            string apiKey = "162486d844f9408490402c3fd44b7ae3"; // کلید API شما
            string username = "yourUsername"; // نام کاربری شما
            string password = "yourPassword"; // رمز عبور شما
            string sysId = "yourSysId"; // sysid شما
            string productId = "yourProductId"; // شناسه محصول

            var licenseManagementApi = new LicenseManagementApi();

            try
            {
                var result = await licenseManagementApi.Anything(apiKey, username, password, sysId, productId);
                Console.WriteLine("Response: " + result);
                return true; // اگر درخواست موفقیت‌آمیز بود
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // در صورت بروز خطا
            }
        }



        public class PrintInfo
        {

            public bool PrintChecked { get; set; }
            public string PrintCap { get; set; }
            public int PrintNum { get; set; }

            public PrintInfo(bool Print_Checked, string Print_Cap,
                int Print_Num)
            {
                PrintCap = Print_Cap;
                PrintNum = Print_Num;
                PrintChecked = Print_Checked;

            }

        }

        public static string GetDateTimeServer()
        {
            string ReturnValue = string.Empty;

            SqlConnection con = null;
            try
            {
                #region Get Data

                con = new SqlConnection(Program.ConString);

                string SqlString = $@"select getdate()";

                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    cmd.CommandTimeout = 300;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    ReturnValue = Shared.ObjectToText(cmd.ExecuteScalar());

                    con.Close();
                }

                #endregion

            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ReturnValue;
        }

        public static async void GetDrugs()
        {
            if (Program.ShowDrug)
            {
                try
                {
                    DtDrugs = new DataTable();

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
                                cmd.CommandText = @"[BS].[GetDrugs]";

                                cmd.Parameters.AddWithValue("JustTrue", 1);
                                cmd.Parameters.AddWithValue("ProccessId", Program.ProcessorId);

                                da.SelectCommand = cmd;
                                da.Fill(DtDrugs);

                                con.Close();

                            }
                        }
                    }

                }

                catch (Exception ex)
                {
                    await Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
                             " - " + ex.Message);
                }
            }

        }



        public static void CheckBakhshCount()
        {
            BakhshCount = 0;
            IsVadie = false;
            IsTarkhis = false;
            IsEghdamat = false;
            IsDrug = false;

            if (Program.HasVadie)
            {
                BakhshCount++;
                UrlForRefresh = $@"{Program.WebServiceAddres}/CashLessAdvanceListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}";
                IsVadie = true;
                ParaName = "ودیعه";
            }
            if (HasTarkhis)
            {
                BakhshCount++;

                //UrlForRefresh = $@"https://www.pdd.ir/pdd/PDDWebService2/MainWebServices.asmx/CashLessReleaseListFull?FromDate=1403/09/06&ToDate=1403/09/06";
                UrlForRefresh = $@"{Program.WebServiceAddres}/CashLessReleaseListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}";
                IsTarkhis = true;
                ParaName = "ترخیص";
            }
            if (ShowEghdamat)
            {
                BakhshCount++;
                UrlForRefresh = $@"{Program.WebServiceAddres}/CashLessRemedialActivityListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}";
                IsEghdamat = true;
                ParaName = "اقدامات";
            }
            if (ShowDrug && DtDrugs.Rows.Count > 0)
            {
                BakhshCount = BakhshCount + DtDrugs.Rows.Count;

                UrlForRefresh = $@"{Program.WebServiceAddres}/CashLessDrugInventoryListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}&InventoryID={Shared.Val(DtDrugs.Rows[0]["ID"])}";
                IsDrug = true;
                ParaName = Shared.ObjectToText(DtDrugs.Rows[0]["DrugCap"]);
            }
            if (DtParaClinics.Rows.Count > 0)
            {

                ParaName = Shared.ObjectToText(DtParaClinics.Rows[0]["ParaClinicCap"]);

                UrlForRefresh = $@"{Program.WebServiceAddres}/CashLessPatientManagementListFull?FromDate={Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay))}&ToDate={Shared.M2S(DateTime.Now)}&ParaclinicChildID={Shared.Val(DtParaClinics.Rows[0]["ID"])}";
                BakhshCount = BakhshCount + DtParaClinics.Rows.Count;
            }


        }

        public static void GetPrintList()
        {
            try
            {
                PrintList = new List<PrintInfo>();
                var directory = System.IO.Path.GetFileName("Reports");
                var files = System.IO.Directory.GetFiles(directory, "*.*")
                    .Where(s => s.EndsWith(".frx", StringComparison.OrdinalIgnoreCase));

                int i = 0;
                foreach (string file in files)
                {
                    Program.PrintList.Add(new Program.PrintInfo(Shared.ObjectToBool(IniFile.IniReadValue("PubPrintSet", Path.GetFileName(file) + "Checked",
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini")), Path.GetFileName(file), Shared.Val(IniFile.IniReadValue("PubPrintSet", Path.GetFileName(file),
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"))));


                    i++;
                }
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }

        }

        private static int CheckSA()
        {
            #region MyRegion
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        #region MyRegion
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = $@"SELECT   
                        Mc as Mc, 
                        Ace as Ace
                        FROM    BS.TPCG
                        WHERE  (TPCGID = @ProcessorId)";

                        cmd.Parameters.AddWithValue("@ProcessorId", Program.ProcessorId);

                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        #endregion
                    }
                }
            }

            if (dt.Rows.Count > 0)
            {
                #region MyRegion
                if (Shared.ObjectToText(dt.Rows[0]["Ace"]) == "")
                {
                    return -666;
                }
                else if (Shared.ObjectToText(dt.Rows[0]["Mc"]) == "")
                {
                    return -666;
                }
                else if (dt.Rows[0]["Ace"].ToString() == "ندارد")
                {

                    using (FrmSerialActiveCode frm = new FrmSerialActiveCode())
                    {
                        frm.Focus();
                        if (frm.ShowDialog() != DialogResult.OK)
                        {
                            return -666;
                        }
                        else
                        {
                            return 666;
                        }
                    }
                }
                else if (dt.Rows[0]["Ace"].ToString() != "ندارد")
                {
                    string key = "";
                    if (Shared.ObjectToText(dt.Rows[0]["Ace"]) == "")
                    {
                        return -666;
                    }
                    key = Shared.ObjectToText(dt.Rows[0]["Ace"]);

                    if (key.IndexOf("-") <= 0)
                    {
                        long x = Program.ProcessorId;
                        if (key == ((x / 1394) + (x / 1355) + (x / 1356) + (x / 1354)).ToString())
                        {
                            return 666;
                        }
                        else
                        {
                            return -666;
                        }
                    }
                    else
                    {
                        SecurityManager sm = new SecurityManager();
                        if (!sm.CheckKey(key, "6cEN*8`2wcU:{d5K", Program.ProcessorId))
                        {
                            long x = Program.ProcessorId;
                            if (key == ((x / 1394) + (x / 1355) + (x / 1356) + (x / 1354)).ToString())
                            {
                                return 666;
                            }
                            else
                            {
                                return -666;
                            }
                        }
                        else
                        {
                            return 666;
                        }
                    }
                }
                else
                {
                    return -666;
                }
                #endregion
            }
            else
            {
                using (FrmSerialActiveCode frm = new FrmSerialActiveCode())
                {
                    frm.Focus();
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        return -666;
                    }
                    else
                    {
                        return 666;
                    }
                }
            }
            #endregion
        }

        public static async void GetParaClinics()
        {
            try
            {
                Program.DtParaClinics = new DataTable();

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
                            cmd.Parameters.AddWithValue("ProccessId", Program.ProcessorId);

                            da.SelectCommand = cmd;
                            da.Fill(DtParaClinics);

                            con.Close();

                        }
                    }
                }

            }

            catch (Exception ex)
            {
                await Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
                         " - " + ex.Message);
            }
        }
        public static void ReturnToFirst()
        {
            try
            {
                List<Form> openForms = new List<Form>();

                foreach (Form f in Application.OpenForms)
                    openForms.Add(f);
                foreach (Form f in openForms)
                {
                    if (UpdatePatient && BakhshCount == 1)
                    {
                        if (f.Name != "Formpatients")
                            f.Close();
                    }

                    else if ((StartForm != "StartParaclinicList" && f.Name != "FormStart") ||
                         (StartForm == "StartParaclinicList" && f.Name != "FormMenu"))
                        f.Close();
                }

                if (UpdatePatient && BakhshCount == 1)
                {
                    Program.Formpatients.BringToFront();
                    Program.Formpatients.TopMost = true;
                    Program.Formpatients.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Program.Formpatients.Left = 0;
                    Program.Formpatients.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Program.Formpatients.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    //Program.InsertMobMainUIForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    Program.Formpatients.WindowState = FormWindowState.Maximized;
                    //Program.Formpatients.Show();
                }

                else if (StartForm == "StartParaclinicList")
                {

                    Program.FormpatientsMenu.BringToFront();
                    Program.FormpatientsMenu.TopMost = true;
                    Program.FormpatientsMenu.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Program.FormpatientsMenu.Left = 0;
                    Program.FormpatientsMenu.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Program.FormpatientsMenu.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    //Program.InsertMobMainUIForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    Program.FormpatientsMenu.WindowState = FormWindowState.Maximized;
                    //Program.FormpatientsMenu.Show();
                }
                else
                {

                    Program.FrmStart.BringToFront();
                    Program.FrmStart.TopMost = true;
                    Program.FrmStart.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Program.FrmStart.Left = 0;
                    Program.FrmStart.Width = Screen.PrimaryScreen.WorkingArea.Width;
                    Program.FrmStart.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    //Program.InsertMobMainUIForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    Program.FrmStart.WindowState = FormWindowState.Maximized;
                    //Program.FrmStart.Show();



                }



            }
            catch
            {

            }


        }

        public static async void GetOther()
        {
            try
            {

                DtOtherReq = new DataTable();

                if (ShowOther || ShowOtherInstart)
                {
                    //HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(new Uri($@"https://www.pdd.ir/pdd/PDDWebService2/MainWebServices.asmx/CashLessOtherListFull"));
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(new Uri($@"{Program.WebServiceAddres}/CashLessOtherListFull"));
                    myRequest.Method = "GET";

                    WebResponse myResponse;
                    try
                    {
                        myResponse = myRequest.GetResponse();

                        using (Stream responseStream = myResponse.GetResponseStream())
                        {
                            DtOtherReq.ReadXml(responseStream);
                        }
                    }
                    catch
                    { }
                }




            }
            catch (Exception ex)
            {
                frmCustomOkMsgBox = new CustomOkMsgBox("مشکل در خواندن لیست سایر درخواست ها ! "
      , global::GeneralKiosk.Properties.Resources.WarningPic);

                await Program.InsertLogToFile("Error : " + "SendResualtToApi" +
                     " - " + "Program" + " - " + ex.Message);

            }
        }



        public static void LoadSetting()
        {


            #region MyRegion

            Program.PrintImagePath = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "PrintImagePath",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.MuteSound = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "MuteSound",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.ShowEghdamat = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowEghdamat",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.ShowDrug = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowDrug",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.DrugCode = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "DrugCode",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.StartForm = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "StartForm",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.BackPath = Shared.ObjectToText(IniFile.IniReadValue("MainSetting", "Path",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));


            Program.UpdatePatient = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "UpdatePatient",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.UpdatePatientTimer = Shared.ValInt64(IniFile.IniReadValue("PubSystemSet", "UpdatePatientTimer",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.SearchByNationalCodeStartFrm = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "SearchByNationalCodeStartFrm",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.ActiveAutoBack = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ActiveAutoBack",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.ShowOther = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowOther",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.SendIssueAfterPay = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "SendIssueAfterPay",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.SendRefNumAfterPay = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "SendRefNumAfterPay",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.SendTerminalAfterPay = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "SendTerminalAfterPay",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.PrintOtherMoshtari = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "PrintOtherMoshtari",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.PrintOtherMaj = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "PrintOtherMaj",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.PrintOtherNormal = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "PrintOtherNormal",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.ShowOtherInstart = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowOtherInstart",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.ShowCol = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "ShowCol",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.PatientNameTopToBott = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "PatientNameTopToBott",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));


            Program.CheckMeli = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "CheckMeli",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.ActiveKeyPad = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ActiveKeyPad",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.ShowParaStartForm = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowParaStartForm",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.ShowNobat = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowNobat",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.NobatLink = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "NobatLink",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.CanCloseNumForm = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "CanCloseNumForm",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.PayAfterSearchMeli = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "PayAfterSearchMeli",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.SendCardNum = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "SendCardNum",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            #region MyRegion
            Program.NotSearchsoftCode01 = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "NotSearchsoftCode01",
 AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.NotSearchsoftCode34 = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "NotSearchsoftCode34",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.NotSearchsoftCode11 = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "NotSearchsoftCode11",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.NotSearchsoftCode16 = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "NotSearchsoftCode16",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            Program.NotSearchsoftCode06 = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "NotSearchsoftCode06",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini")); 
            #endregion

            Program.ShowReceptionDateTime = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowReceptionDateTime", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowGhabzNum = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowGhabzNum", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowReceptionCode = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowReceptionCode", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowDocumentCode = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowDocumentCode", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowPatientName = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowPatientName", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowDoctorName = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowDoctorName", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowNationalNumber = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowNationalNumber", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowPatientRate = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowPatientRate", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowInsuranceName = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowInsuranceName", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowInsuranceRate = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowInsuranceRate", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowSupplementaryName = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowSupplementaryName", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowSupplementaryRate = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowSupplementaryRate", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowServiceDescription = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowServiceDescription", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowRno = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowRno", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowParaClinicName = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowParaClinicName", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowExternalBeneficiaryName = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowExternalBeneficiaryName", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));
            Program.ShowSalamatTrackingCode = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ShowSalamatTrackingCode", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));


            if (File.Exists(Program.PrintImagePath))
            {
                try
                {

                    PrintImage = Image.FromFile(Program.PrintImagePath);
                }
                catch
                {

                }

            }
            GetPrintList();

            #endregion

            DataTable dt = new DataTable();
            #region MyRegion
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
                        $@"SELECT top 1 *
                        FROM     BS.Setting where ID={Program.ProcessorId}
                        union all 
                        SELECT top 1 *
                        FROM     BS.Setting where ID=1";

                        da.SelectCommand = cmd;
                        da.Fill(dt);



                        if (dt.Rows.Count <= 1)
                        {
                            con.Open();
                            cmd.CommandText =
                               $@"INSERT INTO BS.Setting
                         (ID, Pass, Onme, UserCode, HasVadie, HasTarkhis, VahedPool, ShowPatiaentListDay, PictureTopRight, PictureTopCenter, PictureTopLeft, PictureCenter, PictureShowMessage, PictureDown, PictureTopRightPath, 
                         PictureTopCenterPath, PictureTopLeftPath, PictureCenterPath, PictureShowMessagePath, PictureDownPath, PictureTopRightVisible, PictureTopCenterVisible, PictureTopLeftVisible, PictureCenterVisible, 
                         PictureShowMessageVisible, PictureDownVisible, WebServiceAddres, Adres)
                        SELECT        TOP (1) {Program.ProcessorId}, Pass, Onme, UserCode, HasVadie, HasTarkhis, VahedPool, ShowPatiaentListDay, PictureTopRight, PictureTopCenter, PictureTopLeft, PictureCenter, PictureShowMessage, PictureDown, PictureTopRightPath, 
                        PictureTopCenterPath, PictureTopLeftPath, PictureCenterPath, PictureShowMessagePath, PictureDownPath, PictureTopRightVisible, PictureTopCenterVisible, PictureTopLeftVisible, PictureCenterVisible, 
                        PictureShowMessageVisible, PictureDownVisible, WebServiceAddres, Adres
                        FROM            BS.Setting AS Setting_1 where Setting_1.ID=1";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            LoadSetting();
                        }
                        else
                        {
                            Program.Pass = Shared.ObjectToText(dt.Rows[0]["Pass"]) == "" ? "123" : Shared.ObjectToText(dt.Rows[0]["Pass"]).ToLower();
                            Program.Onme = Shared.ObjectToText(dt.Rows[0]["Onme"]);
                            Program.Adres = Shared.ObjectToText(dt.Rows[0]["Adres"]);
                            Program.UserCode = Shared.ObjectToText(dt.Rows[0]["UserCode"]);
                            Program.HasVadie = Shared.ObjectToBool(dt.Rows[0]["HasVadie"]);
                            Program.HasTarkhis = Shared.ObjectToBool(dt.Rows[0]["HasTarkhis"]);
                            Program.VahedPool = Shared.Val(dt.Rows[0]["VahedPool"]) == 1 ? "تومان" : "ریال";
                            Program.ShowPatiaentListDay = Shared.Val(dt.Rows[0]["ShowPatiaentListDay"]);
                            PictureTopRightVisible = Shared.ObjectToBool(dt.Rows[0]["PictureTopRightVisible"]);
                            PictureTopCenterVisible = Shared.ObjectToBool(dt.Rows[0]["PictureTopCenterVisible"]);
                            PictureTopLeftVisible = Shared.ObjectToBool(dt.Rows[0]["PictureTopLeftVisible"]);
                            PictureCenterVisible = Shared.ObjectToBool(dt.Rows[0]["PictureCenterVisible"]);
                            PictureShowMessagetVisible = Shared.ObjectToBool(dt.Rows[0]["PictureShowMessageVisible"]);
                            PictureDownVisible = Shared.ObjectToBool(dt.Rows[0]["PictureDownVisible"]);

                            pictureBoxTopRightPath = Shared.ObjectToText(dt.Rows[0]["PictureTopRightPath"]);
                            pictureBoxTopCentertPath = Shared.ObjectToText(dt.Rows[0]["PictureTopCenterPath"]);
                            pictureBoxTopLeftPath = Shared.ObjectToText(dt.Rows[0]["PictureTopLeftPath"]);
                            pictureBoxCenterPath = Shared.ObjectToText(dt.Rows[0]["PictureCenterPath"]);
                            pictureBoxShowMessagePath = Shared.ObjectToText(dt.Rows[0]["PictureShowMessagePath"]);
                            pictureBoxDownPath = Shared.ObjectToText(dt.Rows[0]["PictureDownPath"]);
                            dtPaient = new DataTable();
                            dtPaient.Columns.Add("ParaClinicName");
                            dtPaient.Columns.Add("ReceptionDate");
                            dtPaient.Columns.Add("ReceptionTime");
                            dtPaient.Columns.Add("documentCode");
                            dtPaient.Columns.Add("ReceptionCode");
                            dtPaient.Columns.Add("beneficiaryName");
                            dtPaient.Columns.Add("nationalNumber");
                            dtPaient.Columns.Add("NationalNo");
                            dtPaient.Columns.Add("patientRate");
                            dtPaient.Columns.Add("serviceDescription");
                            dtPaient.Columns.Add("insuranceRate");
                            dtPaient.Columns.Add("insuranceSupplementaryName");
                            dtPaient.Columns.Add("cashInsuranceSupplementaryRate");
                            dtPaient.Columns.Add("endRate");
                            dtPaient.Columns.Add("firstName");
                            dtPaient.Columns.Add("lastName");
                            dtPaient.Columns.Add("insuranceName");
                            dtPaient.Columns.Add("ClinicName");
                            dtPaient.Columns.Add("BedCompleteName");
                            dtPaient.Columns.Add("Description");
                            dtPaient.Columns.Add("Comment");
                            dtPaient.Columns.Add("DiscountRate");
                            dtPaient.Columns.Add("ServiceName");
                            dtPaient.Columns.Add("FreeRate");
                            dtPaient.Columns.Add("CalculationReceptionEndRate");
                            dtPaient.Columns.Add("answerDate");
                            dtPaient.Columns.Add("beneficiaryNameReception");
                            dtPaient.Columns.Add("Economiccode");
                            dtPaient.Columns.Add("age");
                            dtPaient.Columns.Add("InsuranceCode");
                            dtPaient.Columns.Add("InsuranceBookNumber");
                            dtPaient.Columns.Add("BeneficiaryCode");
                            dtPaient.Columns.Add("PatientType");
                            dtPaient.Columns.Add("InquiryType");
                            dtPaient.Columns.Add("AgeType");
                            dtPaient.Columns.Add("Sex");
                            dtPaient.Columns.Add("ExternalBeneficiaryName");
                            dtPaient.Columns.Add("SectionID");
                            dtPaient.Columns.Add("ParaclinicChildID");
                            dtPaient.Columns.Add("ParaclinicReceptionCode");
                            dtPaient.Columns.Add("SoftwareCode");
                            dtPaient.Columns.Add("ParaclinicChildName");
                            dtPaient.Columns.Add("GiftRate");
                            dtPaient.Columns.Add("GiftDiscountRate");
                            dtPaient.Columns.Add("Pacscode");
                            dtPaient.Columns.Add("ISAdvanceMode");
                            dtPaient.Columns.Add("DifferenceRate");
                            dtPaient.Columns.Add("CalculationForcePayableRate");
                            dtPaient.Columns.Add("ISCancel");
                            dtPaient.Columns.Add("ISInsuranceReceptionWithoutPrint");
                            dtPaient.Columns.Add("ReceptionUserCode");
                            dtPaient.Columns.Add("InsuranceSupplementaryCode");
                            dtPaient.Columns.Add("GlobalReceptionID");
                            dtPaient.Columns.Add("RoomId");
                            dtPaient.Columns.Add("FatherName");
                            dtPaient.Columns.Add("UserAnswer");
                            dtPaient.Columns.Add("_DESC");
                            dtPaient.Columns.Add("Receptionsepratecode");
                            dtPaient.Columns.Add("Totalrate");
                            dtPaient.Columns.Add("Paymentrate");
                            dtPaient.Columns.Add("DrugSumPreferredRate");
                            dtPaient.Columns.Add("SumPayableRate");
                            dtPaient.Columns.Add("SumOutOfRate");
                            dtPaient.Columns.Add("salamattrackingcode");

                            //dtPaient.Columns.Add("CalculationReceptionTotalRate ");
                            //dtPaient.Columns.Add("CalculationReceptionInsuranceSupplementaryRate ");
                            //dtPaient.Columns.Add("CalculationReceptionInsuranceRate ");


                            Program.WebServiceAddres = Shared.ObjectToText(dt.Rows[0]["WebServiceAddres"]);

                            if (File.Exists(Shared.ObjectToText(dt.Rows[0]["PictureTopRightPath"])))
                            {
                                try
                                {

                                    PictureTopRightImage = Image.FromFile(Shared.ObjectToText(dt.Rows[0]["PictureTopRightPath"]));
                                }
                                catch
                                {

                                }

                            }
                            if (File.Exists(Shared.ObjectToText(dt.Rows[0]["PictureTopCenterPath"])))
                            {
                                try
                                {

                                    PictureTopCenterImage = Image.FromFile(Shared.ObjectToText(dt.Rows[0]["PictureTopCenterPath"]));
                                }
                                catch
                                {

                                }

                            }
                            if (File.Exists(Shared.ObjectToText(dt.Rows[0]["PictureTopLeftPath"])))
                            {
                                try
                                {

                                    PictureTopLeftImage = Image.FromFile(Shared.ObjectToText(dt.Rows[0]["PictureTopLeftPath"]));
                                }
                                catch
                                {

                                }

                            }
                            if (File.Exists(Shared.ObjectToText(dt.Rows[0]["PictureCenterPath"])))
                            {
                                try
                                {

                                    PictureCenterImage = Image.FromFile(Shared.ObjectToText(dt.Rows[0]["PictureCenterPath"]));
                                }
                                catch
                                {

                                }

                            }
                            if (File.Exists(Shared.ObjectToText(dt.Rows[0]["PictureShowMessagePath"])))
                            {
                                try
                                {

                                    PictureShowMessageImage = Image.FromFile(Shared.ObjectToText(dt.Rows[0]["PictureShowMessagePath"]));
                                }
                                catch
                                {

                                }

                            }
                            if (File.Exists(Shared.ObjectToText(dt.Rows[0]["PictureDownPath"])))
                            {
                                try
                                {

                                    PictureDownImage = Image.FromFile(Shared.ObjectToText(dt.Rows[0]["PictureDownPath"]));
                                }
                                catch
                                {

                                }

                            }
                            GetDrugs();
                            GetParaClinics();
                            CheckBakhshCount();
                            GetOther();

                        }

                    }
                }


            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
            #endregion
        }


        public static bool ContainColumn(string columnName, DataTable table)
        {
            DataColumnCollection columns = table.Columns;
            if (columns.Contains(columnName))
            {
                return true;
            }
            return false;
        }

        public async static Task<DataTable> ConvertXmlNodeListToDataTable(XmlNodeList xnl)
        {
            try
            {

                dtPaient.Clear();
                if (!ContainColumn("ServiceName", dtPaient))
                {
                    dtPaient.Columns.Add("ServiceName");
                }
                if (!ContainColumn("CalculationReceptionEndRate", dtPaient))
                {
                    dtPaient.Columns.Add("CalculationReceptionEndRate");
                }

                int ColumnsCount = dtPaient.Columns.Count;
                for (int i = 0; i < xnl.Count; i++)
                {

                    DataRow dr = dtPaient.NewRow();

                    if (xnl.Item(i).ChildNodes.Count > dtPaient.Columns.Count)
                    {
                        ColumnsCount = xnl.Item(i).ChildNodes.Count;
                    }
                    else
                    {
                        ColumnsCount = dtPaient.Columns.Count;
                    }

                    for (int j = 0; j < ColumnsCount; j++)
                    {
                        try
                        {

                            if (xnl.Item(i).ChildNodes[j].Name == "GroupName")
                            {
                                dr["ParaClinicCap"] = xnl.Item(i).ChildNodes[j].InnerText;
                            }
                            else
                            {
                                dr[xnl.Item(i).ChildNodes[j].Name] = xnl.Item(i).ChildNodes[j].InnerText;
                            }
                        }
                        catch
                        {
                            continue;
                            //dt.Columns.Add(xnl.Item(i).ChildNodes[j].Name);
                            //dr[xnl.Item(i).ChildNodes[j].Name] = xnl.Item(i).ChildNodes[j].InnerText;
                        }


                    }

                    dtPaient.Rows.Add(dr);

                    try
                    {

                        if (Shared.ObjectToText(dtPaient.Rows[0]["NationalNo"]) != "" && Shared.ObjectToText(dtPaient.Rows[0]["nationalNumber"]) == "")
                        {
                            dtPaient.Rows[0]["nationalNumber"] = dtPaient.Rows[0]["NationalNo"];
                        }

                    }
                    catch
                    {

                    }
                }

                return dtPaient;
            }
            catch (Exception ex)
            {

                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return null;
            }

        }


        public static DataTable ConvertXmlNodeListToDataTableParaList(XmlNodeList xnl)
        {
            try
            {
                if (xnl.Count == 0)
                    return null;
                DataTable dt = new DataTable();

                int TempColumn = 0;

                foreach (XmlNode node in xnl.Item(0).ChildNodes)
                {

                    TempColumn++;

                    DataColumn dc = new DataColumn(node.Name, System.Type.GetType("System.String"));

                    if (dt.Columns.Contains(node.Name))
                    {

                        dt.Columns.Add(dc.ColumnName = dc.ColumnName + TempColumn.ToString());

                    }
                    else
                    {

                        dt.Columns.Add(dc);

                    }

                }

                int ColumnsCount = dt.Columns.Count;
                for (int i = 0; i < xnl.Count; i++)
                {

                    DataRow dr = dt.NewRow();

                    for (int j = 0; j < ColumnsCount; j++)
                    {

                        if (!(xnl.Item(i).ChildNodes[j] is null))
                        {
                            try
                            {
                                dr[xnl.Item(i).ChildNodes[j].Name] = xnl.Item(i).ChildNodes[j].InnerText;
                            }
                            catch
                            {
                                dt.Columns.Add(xnl.Item(i).ChildNodes[j].Name);
                                dr[xnl.Item(i).ChildNodes[j].Name] = xnl.Item(i).ChildNodes[j].InnerText;
                            }
                            finally
                            {

                            }
                        }


                    }

                    dt.Rows.Add(dr);

                }

                return dt;
            }
            catch (Exception ex)
            {

                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return null;
            }

        }

        private static void GetProcessorId()
        {
            SecurityManager sm = new SecurityManager();
            Program.ProcessorId = sm.GetSerial();
        }


        public static string MakeAPassword()
        {
            try
            {
                MD5 md5Hasher = MD5.Create();
                byte[] hashed = null;
                hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes("kia" + Shared.M2S(DateTime.Now).Replace("/", "") + "moj"));
                return Math.Abs(BitConverter.ToInt32(hashed, 0)).ToString().Substring(0, 6);
            }
            catch (Exception)
            {
                return "error";
            }

        }

        public static void InsertLog(string FormName, string FuncName, string Tozihat)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Program.ConString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = $@"INSERT INTO BS.TLogs 
                        (FormName,
                        FuncName,
                        DteTme,
                        Tozihat)
	                    VALUES   (@p1,
	                    @p2,@P3,@P4)";

                        cmd.Parameters.AddWithValue("@p1", FormName.Trim());
                        cmd.Parameters.AddWithValue("@p2", FuncName.Trim());
                        cmd.Parameters.AddWithValue("@p3", DateTime.Now);
                        cmd.Parameters.AddWithValue("@p4", Tozihat.Trim());

                        cmd.ExecuteNonQuery();


                    }

                    con.Close();
                }
            }
            catch
            {

            }
        }

        public static async Task<bool> InsertLogToFile(string Tozihat)
        {
            try
            {
                Random rnd = new Random();
                int num = rnd.Next();

                IniFile.IniWriteValue("Log", DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString() + num.ToString(),
                    Tozihat,
AppDomain.CurrentDomain.BaseDirectory + $@"\IniFiles\Log{Shared.M2S(DateTime.Now).Substring(0, 10).Replace("/", "")}.ini");
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
