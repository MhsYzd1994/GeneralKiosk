using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GeneralKiosk;
using GeneralKiosk.Template;
using Janus.Windows.GridEX;


namespace GeneralKiosk
{
    public partial class FrmScheduleList : FrmTemplateList
    {

        #region DefinitionOfVariables

        //------------------------------Objects---------------------------------------------------------------------


        //------------------------------Variables---------------------------------------------------------------------

        #endregion

        #region Metodes      

        //-----------------------------DefaultMetodes----------------------------------------------------------


        //-----------------------------LoadMetodes-------------------------------------------------------------

        public DataSet GetJobSchedule(int? TJSID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTJS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TJSID", (object)TJSID ?? DBNull.Value);

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

        private void LoadData()
        {
            try
            {


                #region GetData

                DataTable dt = GetJobSchedule(null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridEXScheduleList.DataSource = null;
                    GridEXScheduleList.DataSource = dt;
                    GridEXScheduleList.RetrieveStructure();

                    GridEXScheduleList.RootTable.Columns["TJSID"].Visible = false;
                    GridEXScheduleList.RootTable.Columns["FSat"].Visible = false;
                    GridEXScheduleList.RootTable.Columns["FSun"].Visible = false;
                    GridEXScheduleList.RootTable.Columns["FMon"].Visible = false;
                    GridEXScheduleList.RootTable.Columns["FTues"].Visible = false;
                    GridEXScheduleList.RootTable.Columns["FWed"].Visible = false;
                    GridEXScheduleList.RootTable.Columns["FThurs"].Visible = false;
                    GridEXScheduleList.RootTable.Columns["FFri"].Visible = false;
                    GridEXScheduleList.RootTable.Columns["FRecursEvery"].Visible = false;
                    GridEXScheduleList.RootTable.Columns["DFOE"].Visible = false;
                    GridEXScheduleList.RootTable.Columns["TJSstD"].Visible = false;

                    GridEXScheduleList.RootTable.Columns["Name"].Caption = "نام زمانبندی";
                    GridEXScheduleList.RootTable.Columns["TJSType"].Caption = "عملیات";
                    GridEXScheduleList.RootTable.Columns["Snme"].Caption = "وضعیت";
                    GridEXScheduleList.RootTable.Columns["JSOT"].Caption = "نوع زمانبندی";
                    GridEXScheduleList.RootTable.Columns["JSOTDate"].Caption = "تاریخ یک بار";
                    GridEXScheduleList.RootTable.Columns["JSOTTime"].Caption = "ساعت یک بار";
                    GridEXScheduleList.RootTable.Columns["FType"].Caption = "نوع تکرار";
                    GridEXScheduleList.RootTable.Columns["DFOOA"].Caption = "نوع زمان تکرار";
                    GridEXScheduleList.RootTable.Columns["DFOStart"].Caption = "زمان تکرار یک بار";
                    GridEXScheduleList.RootTable.Columns["DFOEHour"].Caption = "نوع تکرار زمان";
                    GridEXScheduleList.RootTable.Columns["DFStart"].Caption = "ساعت شروع تکرار ";
                    GridEXScheduleList.RootTable.Columns["DFEnd"].Caption = "ساعت پایان تکرار";
                    GridEXScheduleList.RootTable.Columns["DStart"].Caption = "تاریخ شروع تکرار ";
                    GridEXScheduleList.RootTable.Columns["DEnd"].Caption = "تاریخ پایان تکرار";

                    GridEXScheduleList.AutoSizeColumns();
                }

                #endregion


            }
            catch (Exception ex)
            {

                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
        }
        //-----------------------------ButtonMetodes-------------------------------------------------------------


        #region JobSchedule

        public int? AddJobSchedule(int Type)
        {
            FrmScheduleAddEdit form = new FrmScheduleAddEdit
            {
                PrimaryKey = 0,
                TJSType = Type
            };
            form.ShowDialog();

            int? ScheduleID = form.PrimaryKey;

            return (ScheduleID);
        }
        public int? EditJobSchedule(int ID, int Type)
        {
            FrmScheduleAddEdit form = new FrmScheduleAddEdit
            {
                PrimaryKey = ID,
                TJSType = Type
            };
            form.ShowDialog();

            int? ScheduleID = form.PrimaryKey;

            return (ScheduleID);
        }

        #endregion



        #region JobSchedule

        public int InsertUpdateJobSchedule(int? PrimaryKey, string Name, bool State, bool OneTime, string DateOneTime, string TimeOneTime,
            int FrequencyType, int FrequencyRecursEvery, bool Sat, bool Sun, bool Mon, bool Tues, bool Wed, bool Thurs, bool Fri, bool DailyFrequencyOneTime,
            int DailyFrequencyEvery, bool DailyFrequencyEveryType, string DailyFrequencyEveryStart, string DailyFrequencyEveryEnd, string DurationStart,
            string DurationEnd, int Type)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTJS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TJSID", (object)PrimaryKey ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Name", (object)Name ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", (object)State ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@JSOT", (object)OneTime ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@JSOTDate", (object)DateOneTime ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@JSOTTime", (object)TimeOneTime ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FType ", (object)FrequencyType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FRecursEvery", (object)FrequencyRecursEvery ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FSat", (object)Sat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FSun", (object)Sun ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FMon", (object)Mon ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FTues", (object)Tues ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FWed", (object)Wed ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FThurs", (object)Thurs ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FFri", (object)Fri ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DFOOA", (object)DailyFrequencyOneTime ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DFOE", (object)DailyFrequencyEvery ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DFOEHour", (object)DailyFrequencyEveryType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DFStart", (object)DailyFrequencyEveryStart ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DFEnd", (object)DailyFrequencyEveryEnd ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DStart", (object)DurationStart ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DEnd", (object)DurationEnd ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", (object)Type ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

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


        public int CheckJobSchedule(int Type)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckTJS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@Type", (object)Type ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

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

        public int CheckRunJobSchedule(int Type, string Date, string Time)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRJS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@Type", (object)Type ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Date", (object)Date ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Time", (object)Time ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

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

        public void DeleteJobSchedule(int ID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTJS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TJSID", (object)ID ?? DBNull.Value);

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
        }

        #endregion

        private void AddAnItem()
        {
            AddJobSchedule(0);
            LoadData();

            GridEXScheduleList.Select();
            GridEXScheduleList.Focus();
        }
        private void EditAnItem()
        {
            if (GridEXScheduleList.RowCount == 0 ||
                GridEXScheduleList.SelectedItems.Count <= 0 ||
                GridEXScheduleList.CurrentRow.RowType != RowType.Record)
            {
                Shared.ShowMessage(EnumSendMessage.ListeEntekhabKhaliAst, "");
                return;
            }

            EditJobSchedule(Shared.Val(GridEXScheduleList.GetValue("TJSID")), 0);

            int TemRowIndex = GridEXScheduleList.CurrentRow.RowIndex;

            LoadData();

            GridEXScheduleList.Row = TemRowIndex;
            GridEXScheduleList.Select();
            GridEXScheduleList.Focus();
        }
        private void DeleteAnItem()
        {
            if (GridEXScheduleList.RowCount == 0 ||
               GridEXScheduleList.SelectedItems.Count <= 0 ||
               GridEXScheduleList.CurrentRow.RowType != RowType.Record)
            {
                Shared.ShowMessage(EnumSendMessage.ListeEntekhabKhaliAst, "");
                return;
            }

            if (Shared.Val(GridEXScheduleList.GetValue("TJSstD")) == 1 && Shared.ObjectToTextNull(GridEXScheduleList.GetValue("TJSType")) !=null)
            {
                if (Shared.ShowMessage(EnumSendMessage.AiaMikhahidBaPeyghamehAzad,
                          "این زمانبندی به عملیاتی متصل است" + "\r\n" +
                          "آیا می خواهید ادامه دهید؟") != DialogResult.Yes)
                {
                    return;
                }
            }
            else
            {
                if (Shared.ShowMessage(EnumSendMessage.AiaMikhahidHazfKonid, "") != DialogResult.Yes)
                {
                    return;
                }
            }

            try
            {
                #region Delete

                DeleteJobSchedule(Shared.Val(GridEXScheduleList.GetValue("TJSID")));

                GridEXScheduleList.AllowDelete = InheritableBoolean.True;
                GridEXScheduleList.Delete();
                GridEXScheduleList.AllowDelete = InheritableBoolean.False;

                #endregion

                GridEXScheduleList.Select();
                GridEXScheduleList.Focus();

                Shared.ShowMessage(EnumSendMessage.AmaleHazfKamelShod, "");
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
        }
        private void ExitForm()
        {
           this.Close();
        }

        #endregion

        #region Form

        //-----------------------------FormInitialize-------------------------------------------------------
        public FrmScheduleList()
        {
            InitializeComponent();
        }
        //-----------------------------FormEvents-------------------------------------------------------------
        private void FrmScheduleList_Load(object sender, System.EventArgs e)
        {

            LoadData();
        }
        private void FrmScheduleList_KeyDown(object sender, KeyEventArgs e)
        {
            #region MyRegion

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.A && UiButtonNew.Enabled == true)
            {
                UiButtonNew_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.E && UiButtonEdit.Enabled == true)
            {
                UiButtonEdit_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.D && UiButtonDelete.Enabled == true)
            {
                UiButtonDelete_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                UiButtonExit_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.R)
            {
                LoadData();
            }

            #endregion
        }

        #endregion

        #region Buttons

        //-----------------------------FormButtons-------------------------------------------------------------
        private void UiButtonNew_Click(object sender, System.EventArgs e)
        {
            if (UiButtonNew.Enabled == true)
            {
                AddAnItem();
            }
        }
        private void UiButtonEdit_Click(object sender, System.EventArgs e)
        {
            if (UiButtonEdit.Enabled == true)
            {
                EditAnItem();
            }
        }
        private void UiButtonDelete_Click(object sender, EventArgs e)
        {
            if (UiButtonDelete.Enabled == true)
            {
                DeleteAnItem();
            }
        }
        private void UiButtonExit_Click(object sender, System.EventArgs e)
        {
            ExitForm();
        }

        #endregion
    }
}
