using Ionic.Zip;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace GeneralKiosk
{
    public partial class FrmBackup : Form
    {
        #region DefinitionOfVariables

        //------------------------------Objects---------------------------------------------------------------------
        StringBuilder data = new StringBuilder();

        #endregion

        #region Metodes

        //-----------------------------DefaultMetodes----------------------------------------------------------
        private void GetDateTimeServer()
        {
            try
            {
                string TempDate = Program.GetDateTimeServer();

                Program.SystemDate = DateTime.Parse(TempDate);
                Program.SystemDateMiladi = Program.SystemDate.Year + "/" +
                Program.SystemDate.Month.ToString("00") + "/" +
                Program.SystemDate.Day.ToString("00");
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);

            }
        }
        private string GetAssemblyVer()
        {
            int VersionLocation = Assembly.GetExecutingAssembly().FullName.IndexOf("Version=");
            int CultureLocation = Assembly.GetExecutingAssembly().FullName.IndexOf(", Culture");
            return Assembly.GetExecutingAssembly().FullName.Substring(VersionLocation, (CultureLocation - VersionLocation));
        }
        //-----------------------------LoadMetodes----------------------------------------------------------
       
        public DataSet GetBackupHistory()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        private void LoadHistory()
        {

            try
            {
                #region GetData

                DataTable dt =  GetBackupHistory().Tables[0];

                if (dt.Rows.Count > 0)
                {
                    GridEXTran.DataSource = null;
                    GridEXTran.DataSource = dt;
                    GridEXTran.RetrieveStructure();

                    GridEXTran.RootTable.Columns["LoBH"].Caption = "محل فایل";
                    GridEXTran.RootTable.Columns["DtBH"].Caption = "تاریخ";

                    GridEXTran.AutoSizeColumns();
                }

                #endregion
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);

            }
        }

        public void GetBackup(string DataBase, string Path, string DateBackup)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = "Backup database " + DataBase + " to disk=" + "'" + Path + "\\" + DateBackup + ".RasisBak" + "'";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 1200;
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
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


        private void GetBackup()
        {
            if (string.IsNullOrEmpty(TxtPath.Text))
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "مسیر پشتیبان گیری نمیتواند خالی باشد !");
                return;
            }

            UiGroupBoxMain.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                ProgressBar.Maximum = 5;
                ProgressBar.Step = 1;
                ProgressBar.Value = 0;

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

                ClearOldHistory(TxtPath.Text);

                GetBackup(DataBase, TxtPath.Text, DateTimeString);

                ProgressBar.Value = 4;
                Application.DoEvents();

                try
                {
                    //using (ZipFile zip = new ZipFile())
                    //{
                    //    zip.Password = "k!n*He&7%?q=2R`7";
                    //    zip.AddFile(TxtPath.Text + "\\" + DateTimeString + ".RasisBak");
                    //    zip.Save(TxtPath.Text + "\\" + DateTimeString + ".RasisBak" + ".zip");
                    //}

                    ProgressBar.Value = 5;
                    Application.DoEvents();

                    //File.Delete(TxtPath.Text + "\\" + DateTimeString + ".RasisBak");

                    Shared.ShowMessage(EnumSendMessage.AmaleSabtKamelShod, "");

                    UiGroupBoxMain.Enabled = true;

                    InsertBackupInfo();
                    LoadHistory();

                    ProgressBar.Value = 0;
                    Application.DoEvents();
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

                    UiGroupBoxMain.Enabled = true;
                    Cursor = Cursors.Default;
                    ProgressBar.Value = 0;
                    Application.DoEvents();
                    return;
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

                UiGroupBoxMain.Enabled = true;
                Cursor = Cursors.Default;
                ProgressBar.Value = 0;
                Application.DoEvents();

                return;
            }

            Cursor = Cursors.Default;
        }
        //-----------------------------ButtonMetodes-------------------------------------------------------------
        private void InsertBackupInfo()
        {
            try
            {
                InsertBackupHistory(TxtPath.Text, DateTime.Now.ToString("yyyy/MM/dd HH.mm.ss"));
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
        }

        public int InsertBackupHistory(string LocationFile, string DateBackupHistory)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.ITBH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@LoBH", (object)LocationFile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DtBH", (object)DateBackupHistory ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region Form

        //-----------------------------FormInitialize-------------------------------------------------------
        public FrmBackup()
        {
            InitializeComponent();
        }
        //-----------------------------FormEvents-------------------------------------------------------------
        private void FrmBackup_Load(object sender, EventArgs e)
        {
            UiButtonBackup.Select();

            LoadPath();
            LoadHistory();
        }

        private void LoadPath()
        {
            string TempPath = string.Empty;
            TempPath = IniFile.IniReadValue("MainSetting", "Path", AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");
            if (!string.IsNullOrEmpty(TempPath))
            {
                TxtPath.Text = TempPath;
                TxtPath.Focus();
            }
        }
        private void FrmBackup_KeyDown(object sender, KeyEventArgs e)
        {
            #region MyRegion

            if (e.Control && e.KeyCode == Keys.B)
            {
                UiButtonBackup_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                UiButtonExit_Click(sender, e);
            }

            #endregion
        }
        private void FrmBackup_Shown(object sender, EventArgs e)
        {
            #region MyRegion

            GetDateTimeServer();

            DateTime dtLocalNow = DateTime.Now;
            DateTime dtServerNow = Program.SystemDate;
            TimeSpan tem = dtServerNow.Subtract(dtLocalNow);

            if (tem.TotalMinutes > 5 || tem.TotalMinutes < -5)
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError,
                    "زمان و تاریخ سیستم شما با سرور تنظیم نمی باشد" + "\r\n" + "حداکثر اختلاف مجاز پنج دقیقه می باشد");
                Application.Exit();
            }

            #endregion

            #endregion
        }
        private void FrmBackup_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        #region Buttons

        //-----------------------------FormButtons-------------------------------------------------------------
        private void UiButtonBackup_Click(object sender, EventArgs e)
        {
            GetBackup();
        }
        private void UiButtonExit_Click(object sender, EventArgs e)
        {
            if (Shared.ShowMessage(EnumSendMessage.AiaMikhahidBaPeyghamehAzad, "آیا می خواهید خارج شوید ؟") == DialogResult.Yes)
            {
                Close();
            }
        }


        #endregion

        #region Events

        private void TextBoxPath_Click(object sender, EventArgs e)
        {
            TxtPath.SelectAll();
        }
        private void TextBoxPath_KeyDown(object sender, KeyEventArgs e)
        {
            #region MyRegion

            if (e.KeyCode == Keys.Enter)
            {
                UiButtonBackup.Select();
            }

            #endregion
        }

        #endregion

        private void UiButtonLoadPath_Click_1(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (fbd.SelectedPath.ToLower().Contains("c:"))
                    {
                        Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "بهتر است مسیر در C: نباشد");
                        return;
                    }

                   var TempPath = fbd.SelectedPath.ToLower();
                    if (!string.IsNullOrEmpty(TempPath))
                    {
                        TxtPath.Text = TempPath;
                        TxtPath.Focus();
                    }
                    UiButtonBackup.Select();
                }
            }
        }
    }
}
