
using GeneralKiosk.Template;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

namespace GeneralKiosk
{
    public partial class FrmScheduleAddEdit : FrmTemplateOKCancel
    {
        #region DefinitionOfVariables 

        //------------------------------Objects---------------------------------------------------------------------


        //------------------------------Variables---------------------------------------------------------------------
        public int? PrimaryKey { get; set; }
        public int? TJSType { get; set; }

        #endregion

        #region Metodes

        //-----------------------------DefaultMetodes---------------------------------------------------------
        private void ChangeCursor()
        {
            Cursor = Cursor == Cursors.Default ? Cursors.WaitCursor : Cursors.Default; Application.DoEvents();
        }
      
        private void CheckChangeDailyFrequency()
        {
            if (UiRadioDailyFrequencyOneTime.Checked == true)
            {
                TextBoxDailyFrequencyOneTime.Enabled = true;
                PanelDailyFrequencyEvery.Enabled = false;
                TextBoxDailyFrequencyEveryStart.Text = "12:00";
                TextBoxDailyFrequencyEveryEnd.Text = "23:59";
                UiComboBoxDailyFrequencyEvery.SelectedValue = 1;
                UiComboBoxDailyFrequencyEveryType.SelectedValue = 1;
                if(TextBoxDailyFrequencyOneTime.Text==string.Empty)
                {
                    TextBoxDailyFrequencyOneTime.Text = "12:00";
                }
            }
            else
            {
                TextBoxDailyFrequencyOneTime.Enabled = false;
                PanelDailyFrequencyEvery.Enabled = true;
                TextBoxDailyFrequencyOneTime.Text = "12:00";
                if(TextBoxDailyFrequencyEveryStart.Text==string.Empty)
                {
                    TextBoxDailyFrequencyEveryStart.Text = "12:00";
                }
                if (TextBoxDailyFrequencyEveryEnd.Text == string.Empty)
                {
                    TextBoxDailyFrequencyEveryEnd.Text = "23:59";
                }
            }
        }
        private void CheckChangeDuration()
        {
            if (UiRadioDateEnd.Checked == true)
            {
                TxtDateDurationEnd.Enabled = true;
                if(TxtDateDurationEnd.Text==string.Empty)
                {
                    TxtDateDurationEnd.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    TxtDateDurationEnd.SelectedDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                }
                if (TxtDateDurationEnd.Text.CompareTo(TxtDateDurationStart.Text) < 0)
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "تاریخ پایان باید بزرگتر از تاریخ شروع باشد!");
                    TxtDateDurationEnd.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    TxtDateDurationEnd.SelectedDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                    TxtDateDurationStart.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    TxtDateDurationStart.SelectedDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                }
            }
            else
            {
                TxtDateDurationEnd.Enabled = false;
                TxtDateDurationEnd.Text = string.Empty;
                TxtDateDurationEnd.SelectedDateTime = null;
            }
        }
        private void ClearWeek()
        {
            UiCheckSat.Checked = false;
            UiCheckSun.Checked = false;
            UiCheckMon.Checked = false;
            UiCheckTues.Checked = false;
            UiCheckWed.Checked = false;
            UiCheckThurs.Checked = false;
            UiCheckFri.Checked = false;
        }
        //-----------------------------SetInitialMetodes-------------------------------------------------------------
        private void FillCombo()
        {
            DataTable dt = FillStatus();
            UiCmboStatus.DataSource = dt;
            UiCmboStatus.DisplayMember = "Snme";
            UiCmboStatus.ValueMember = "TGSID";
        }


        #region GetGeneralStatus

        public DataSet GetGeneralStatus()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTGS";
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

        #endregion

        public DataTable FillStatus()
        {
            try
            {
                #region GetData

                DataTable dt =  GetGeneralStatus().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }

                #endregion
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return null;
            }
        }


        private void SetDefaultValues()
        {
            TxtName.Text = string.Empty;

            TxtDateOneTime.Text = DateTime.Now.ToString("yyyy/MM/dd");
            TxtTimeOneTime.Text = DateTime.Now.ToString("HH:mm");

            TxtDateDurationStart.Text = DateTime.Now.ToString("yyyy/MM/dd");
            TxtDateDurationEnd.Text = string.Empty;

            TextBoxDailyFrequencyEveryStart.Text = "12:00";
            TextBoxDailyFrequencyEveryEnd.Text = "23:59";
            TextBoxDailyFrequencyOneTime.Text = "12:00";

            UiCmboStatus.Text = "فعال";
            UiCmboStatus.SelectedValue = 1;

            //UiCmboType.SelectedIndex = 0;
            UiCmboType.SelectedValue = true;

            //UiCmboFrequencyType.SelectedIndex = 0;
            UiCmboFrequencyType.SelectedValue = 1;

            UiCmboFrequencyRecursEvery.SelectedValue = 1;
            UiComboBoxDailyFrequencyEvery.SelectedValue = 1;

            UiComboBoxDailyFrequencyEveryType.SelectedIndex = 0;
            UiComboBoxDailyFrequencyEveryType.SelectedValue = true;

            UiRadioDailyFrequencyOneTime.Checked = true;
            UiRadioDateEndWithout.Checked = true;

            if (TJSType != null && TJSType == 1)
            {
                UiCmboOperation.Text = "Backup";
                UiCmboOperation.SelectedValue = 1;
            }
        }
        //-----------------------------LoadMetodes----------------------------------------------------------




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


        private void LoadFields()
        {
            try
            {
                ChangeCursor();

                if (PrimaryKey != null && PrimaryKey > 0)
                {
                    #region GetData

                    DataTable dt = GetJobSchedule(Shared.Val(PrimaryKey)).Tables[0];

                    #endregion

                    #region SetData

                    if (dt.Rows.Count > 0)
                    {
                        TxtName.Text = Shared.ObjectToText(dt.Rows[0]["Name"], EnumCaseStatus.Nothing);


                        UiCmboStatus.Text = Shared.ObjectToText(dt.Rows[0]["Snme"], EnumCaseStatus.Nothing);
                        UiCmboStatus.SelectedValue = Shared.ObjectToText(dt.Rows[0]["TJSstD"], EnumCaseStatus.Nothing);

                        if (Shared.Val(dt.Rows[0]["TJSType"]) == 1)
                        {
                            UiCmboOperation.Text = "Backup";
                            UiCmboOperation.SelectedValue = 1;
                        }
                        else
                        {
                            UiCmboOperation.Text = string.Empty;
                            UiCmboOperation.SelectedValue = null;
                        }

                        //UiCmboType.Text = Shared.ObjectToText(dt.Rows[0]["JSOT"], EnumCaseStatus.Nothing);
                        if (Shared.ObjectToBool(dt.Rows[0]["JSOT"]))
                        {
                            UiCmboType.SelectedValue = true;
                            TxtDateOneTime.Text = Shared.ObjectToText(dt.Rows[0]["JSOTDate"], EnumCaseStatus.Nothing);
                            TxtTimeOneTime.Text = Shared.ObjectToText(dt.Rows[0]["JSOTTime"], EnumCaseStatus.Nothing);
                        }
                        else
                        {
                            UiCmboType.SelectedValue = false;
                            int FrequencyType = Shared.Val(dt.Rows[0]["FType"]);
                            UiCmboFrequencyType.SelectedValue = FrequencyType;
                            if (FrequencyType == 1)
                                UiCmboFrequencyType.Text = "روزانه";
                            else if (FrequencyType == 2)
                                UiCmboFrequencyType.Text = "هفتگی";
                            else if (FrequencyType == 3)
                                UiCmboFrequencyType.Text = "ماهانه";

                            UiCmboFrequencyRecursEvery.SelectedValue = Shared.Val(dt.Rows[0]["FRecursEvery"]);
                            UiCmboFrequencyRecursEvery.Text = UiCmboFrequencyRecursEvery.SelectedValue.ToString();
                            UiCheckSat.Checked = Shared.ObjectToBool(dt.Rows[0]["FSat"]);
                            UiCheckSun.Checked = Shared.ObjectToBool(dt.Rows[0]["FSun"]);
                            UiCheckMon.Checked = Shared.ObjectToBool(dt.Rows[0]["FMon"]);
                            UiCheckTues.Checked = Shared.ObjectToBool(dt.Rows[0]["FTues"]);
                            UiCheckWed.Checked = Shared.ObjectToBool(dt.Rows[0]["FWed"]);
                            UiCheckThurs.Checked = Shared.ObjectToBool(dt.Rows[0]["FThurs"]);
                            UiCheckFri.Checked = Shared.ObjectToBool(dt.Rows[0]["FFri"]);
                            if (Shared.ObjectToBool(dt.Rows[0]["DFOOA"]))
                            {
                                UiRadioDailyFrequencyOneTime.Checked = true;
                                TextBoxDailyFrequencyOneTime.Text = Shared.ObjectToText(dt.Rows[0]["DFStart"], EnumCaseStatus.Nothing);
                            }
                            else
                            {
                                UiRadioDailyFrequencyEvery.Checked = true;
                                UiComboBoxDailyFrequencyEveryType.SelectedValue = Shared.ObjectToBool(dt.Rows[0]["DFOEHour"]);
                                UiComboBoxDailyFrequencyEvery.SelectedValue = Shared.Val(dt.Rows[0]["DFOE"]);
                                TextBoxDailyFrequencyEveryStart.Text = Shared.ObjectToText(dt.Rows[0]["DFStart"], EnumCaseStatus.Nothing);
                                TextBoxDailyFrequencyEveryEnd.Text = Shared.ObjectToText(dt.Rows[0]["DFEnd"], EnumCaseStatus.Nothing);
                            }
                            TxtDateDurationStart.Text = Shared.ObjectToText(dt.Rows[0]["DStart"], EnumCaseStatus.Nothing);
                            if (Shared.ObjectToText(dt.Rows[0]["DEnd"]) == string.Empty)
                            {
                                UiRadioDateEndWithout.Checked = true;
                            }
                            else
                            {
                                TxtDateDurationEnd.Text = Shared.ObjectToText(dt.Rows[0]["DEnd"], EnumCaseStatus.Nothing);
                                UiRadioDateEnd.Checked = true;
                            }
                        }
                    }

                    #endregion

                }
                else
                {
                    SetDefaultValues();
                }

                //if(TJSType!=null && TJSType == 1)
                //{
                //    LabelOperation.ForeColor = System.Drawing.Color.DarkViolet;
                //    UiCmboOperation.Text = "Backup";
                //    UiCmboOperation.SelectedValue = 1;
                //    UiCmboOperation.Enabled = false;
                //    UiComboBoxDailyFrequencyEveryType.Enabled = false;
                //}
                //else
                //{
                //    LabelOperation.ForeColor = System.Drawing.Color.Black;
                //    UiCmboOperation.Enabled = true;
                //    UiComboBoxDailyFrequencyEveryType.Enabled = true;
                //}
                if (TJSType != null && TJSType == 1 && PrimaryKey>0)
                {
                    UiButtonDelete.Visible = true;
                }
                else
                {
                    UiButtonDelete.Visible = false;
                }

                ChangeCursor();
            }
            catch (Exception ex)
            {
                ChangeCursor();
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
        }
        //-----------------------------ButtonMetodes-------------------------------------------------------------
        private bool CheckForm()
        {
            bool Check = true;
            if (TxtName.Text == string.Empty)
                return false;
            if (Shared.ObjectToBool(UiCmboType.SelectedValue) == true && (TxtDateOneTime.Text == string.Empty || TxtTimeOneTime.Text == string.Empty))
                return false;
            if (Shared.ObjectToBool(UiCmboType.SelectedValue) == false && (TxtDateDurationStart.Text == string.Empty || (UiRadioDateEnd.Checked && TxtDateDurationEnd.Text == string.Empty)))
                return false;
            return Check;
        }

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

        private bool SaveForm(int? PrimaryKey, string Name, bool State, bool OneTime, string DateOneTime, string TimeOneTime, int FrequencyType, int FrequencyRecursEvery,
            bool Sat, bool Sun, bool Mon, bool Tues, bool Wed, bool Thurs, bool Fri, bool DailyFrequencyOneTime, int DailyFrequencyEvery, bool DailyFrequencyEveryType, 
            string DailyFrequencyEveryStart, string DailyFrequencyEveryEnd, string DurationStart, string DurationEnd, int TJSType)
        {
            #region InsertUpdateData

            try
            {
                #region Update

                int ID =  InsertUpdateJobSchedule(PrimaryKey,
                    Name,
                    State,
                    OneTime,
                    DateOneTime,
                    TimeOneTime,
                    FrequencyType,
                    FrequencyRecursEvery,
                    Sat,
                    Sun,
                    Mon,
                    Tues,
                    Wed,
                    Thurs,
                    Fri,
                    DailyFrequencyOneTime,
                    DailyFrequencyEvery,
                    DailyFrequencyEveryType,
                    DailyFrequencyEveryStart,
                    DailyFrequencyEveryEnd,
                    DurationStart,
                    DurationEnd,
                    TJSType);

                #endregion

                if (ID == 0)
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "نام برنامه زمانی نمی تواند تکراری باشد");

                    TxtName.Focus();
                    TxtName.Select();

                    return false;
                }
                if (ID == -2)
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "برای عملیات Backup یک برنامه زمانی ثبت شده است");

                    TxtName.Focus();
                    TxtName.Select();

                    return false;
                }
                if (ID < 0)
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "خطایی رخ داده است");

                    return false;
                }

                return true;

            }
            catch (FaultException ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return false;
            }

            #endregion
        }

        #endregion

        #region Form

        public FrmScheduleAddEdit()
        {
            InitializeComponent();
        }
        private void FrmScheduleAddEdit_Load(object sender, EventArgs e)
        {
            //CheckAccessLevel();
            FillCombo();
            LoadFields();

            TxtName.Focus();
            TxtName.Select();
        }
        private void FrmScheduleAddEdit_KeyDown(object sender, KeyEventArgs e)
        {
            #region MyRegion

            if (e.Control && e.KeyCode == Keys.S && UiButtonSave.Enabled == true)
            {
                UiButtonSave_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.D && UiButtonDelete.Enabled == true && UiButtonDelete.Visible == true)
            {
                UiButtonDelete_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                UiButtonExit_Click(sender, e);
            }

                #endregion
        }
        private void TxtDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion

        #region Events

        private void TxtSelectItem_ButtonBrowseClick(object sender, EventArgs e)
        {
          
        }


        #endregion

        #region Events Radio

        private void UiRadioDateEnd_CheckedChanged(object sender, EventArgs e)
        {
            CheckChangeDuration();
        }
        private void UiRadioDateEndWithout_CheckedChanged(object sender, EventArgs e)
        {
            CheckChangeDuration();
        }
        private void UiRadioDailyFrequencyOneTime_CheckedChanged(object sender, EventArgs e)
        {
            CheckChangeDailyFrequency();
        }
        private void UiRadioDailyFrequencyEvery_CheckedChanged(object sender, EventArgs e)
        {
            CheckChangeDailyFrequency();
        }

        #endregion

        #region Events Combo

        private void UiCmboType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Shared.ObjectToBool(UiCmboType.SelectedValue) == true)
            {
                UiGroupBoxOneTime.Enabled = true;
                UiGroupBoxFrequency.Enabled = false;
                UiGroupBoxDailyFrequency.Enabled = false;
                UiGroupBoxDuration.Enabled = false;

                TxtDateDurationEnd.Text = string.Empty;
                TxtDateDurationEnd.SelectedDateTime = null;
                TxtDateDurationStart.Text = DateTime.Now.ToString("yyyy/MM/dd");
                TxtDateDurationStart.SelectedDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                UiRadioDateEndWithout.Checked = true;
            }
            else
            {
                UiGroupBoxOneTime.Enabled = false;
                UiGroupBoxFrequency.Enabled = true;
                UiGroupBoxDailyFrequency.Enabled = true;
                UiGroupBoxDuration.Enabled = true;

                UiCmboFrequencyType.SelectedValue = 1;
                UiRadioDailyFrequencyOneTime.Checked = true;

                TxtDateOneTime.Text = DateTime.Now.ToString("yyyy/MM/dd");
                TxtDateOneTime.SelectedDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                TxtTimeOneTime.Text = DateTime.Now.ToString("HH:mm");
            }
        }
        private void UiCmboFrequencyType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Shared.Val(UiCmboFrequencyType.SelectedValue) == 1)
            {
                int[] Days = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToArray();
                UiCmboFrequencyRecursEvery.DataSource = Days;
                PanelFrequencyRecursEvery.Enabled = true;
                PanelWeek.Enabled = false;
                LabelFrequencyRecursEvery.Text = "روز";
                ClearWeek();
            }
            else if (Shared.Val(UiCmboFrequencyType.SelectedValue) == 2)
            {
                PanelFrequencyRecursEvery.Enabled = false;
                PanelWeek.Enabled = true;
            }
            else
            {
                int[] Months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                UiCmboFrequencyRecursEvery.DataSource = Months;
                PanelFrequencyRecursEvery.Enabled = true;
                PanelWeek.Enabled = false;
                LabelFrequencyRecursEvery.Text = "ماه";
                ClearWeek();
            }
            UiCmboFrequencyRecursEvery.SelectedValue = 1;
        }
        private void UiComboBoxDailyFrequencyEveryType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Shared.ObjectToBool(UiComboBoxDailyFrequencyEveryType.SelectedValue) == true)
            {
                int[] Hours = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                UiComboBoxDailyFrequencyEvery.DataSource = Hours;
            }
            else
            {
                int[] Minutes = Enumerable.Range(1, 720).ToArray();
                UiComboBoxDailyFrequencyEvery.DataSource = Minutes;
            }
            UiComboBoxDailyFrequencyEvery.SelectedValue = 1;
        }
        private void UiCmboOperation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                UiCmboOperation.Text = string.Empty;
                UiCmboOperation.SelectedValue = null;
            }
        }
        private void UiCmboOperation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Shared.Val(UiCmboOperation.SelectedValue) == 1)
            {
                LabelOperation.ForeColor = System.Drawing.Color.DarkViolet;
                if (TJSType != null && TJSType == 1)
                {
                    UiCmboOperation.Enabled = false;
                }

                UiComboBoxDailyFrequencyEveryType.Enabled = false;
            }
            else
            {
                LabelOperation.ForeColor = System.Drawing.Color.Black;
                UiCmboOperation.Enabled = true;
                UiComboBoxDailyFrequencyEveryType.Enabled = true;
            }
        }

        #endregion

        #region Events Text

        private void TxtTimeOneTime_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Length < 4)
            {
                TxtTimeOneTime.Text = DateTime.Now.ToString("HH:mm");
            }
        }
        private void TextBoxDailyFrequencyEveryEnd_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Length < 4)
            {
                TextBoxDailyFrequencyEveryEnd.Text = "23:59";
            }
            if (TextBoxDailyFrequencyEveryEnd.Text.CompareTo(TextBoxDailyFrequencyEveryStart.Text) < 0)
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "ساعت پایان باید بزرگتر از ساعت شروع باشد!");
                TextBoxDailyFrequencyEveryEnd.Text = "23:59";
            }
        }
        private void TextBoxDailyFrequencyEveryStart_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Length < 4)
            {
                TextBoxDailyFrequencyEveryStart.Text = "12:00";
            }
            if (TextBoxDailyFrequencyEveryStart.Text.CompareTo(TextBoxDailyFrequencyEveryEnd.Text) > 0)
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "ساعت شروع باید کوچکتر از ساعت پایان باشد!");
                TextBoxDailyFrequencyEveryStart.Text = "12:00";
            }
        }
        private void TxtTime_KeyUp(object sender, KeyEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 4)
            {
                TextBox temtxt = (TextBox)sender;
                if (DateTime.TryParse("1355/09/14 " + temtxt.Text.Substring(0, 2) + ":" + temtxt.Text.Substring(2, 2), out DateTime temDate) == false)
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "ساعت را اشتباه وارد کردید");
                    temtxt.Text = "";
                    temtxt.Focus();
                    return;
                }
                temtxt.Text = temtxt.Text.Substring(0, 2) + ":" + temtxt.Text.Substring(2, 2);
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
        private void TextBoxDailyFrequencyOneTime_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim().Length < 4)
            {
                TextBoxDailyFrequencyOneTime.Text = "12:00";
            }
        }
        private void TxtDateDurationEnd_Leave(object sender, EventArgs e)
        {
            if (TxtDateDurationEnd.Text.CompareTo(TxtDateDurationStart.Text) < 0)
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "تاریخ پایان باید بزرگتر از تاریخ شروع باشد!");
                TxtDateDurationEnd.Text = DateTime.Now.ToString("yyyy/MM/dd");
                TxtDateDurationEnd.SelectedDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            }
        }
        private void TxtDateDurationStart_Leave(object sender, EventArgs e)
        {
            if (UiRadioDateEnd.Checked && TxtDateDurationStart.Text.CompareTo(TxtDateDurationEnd.Text) > 0)
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "تاریخ شروع باید کوچکتر از تاریخ پایان باشد!");
                TxtDateDurationStart.Text = DateTime.Now.ToString("yyyy/MM/dd");
                TxtDateDurationStart.SelectedDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
            }
        }

        #endregion

        #region Buttons

        private void UiButtonSave_Click(object sender, EventArgs e)
        {
            if (!CheckForm())
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "اطلاعات را وارد کنید");
                return;
            }
            else
            {
                bool FrequencyOneTime = UiRadioDailyFrequencyOneTime.Checked;
                bool ReturnValue = false;
                if(FrequencyOneTime==true)
                {
                    ReturnValue=SaveForm(PrimaryKey, TxtName.Text, Shared.ObjectToBool(UiCmboStatus.SelectedValue), Shared.ObjectToBool(UiCmboType.SelectedValue),
                    TxtDateOneTime.Text, TxtTimeOneTime.Text, Shared.Val(UiCmboFrequencyType.SelectedValue), Shared.Val(UiCmboFrequencyRecursEvery.SelectedValue),
                    UiCheckSat.Checked, UiCheckSun.Checked, UiCheckMon.Checked, UiCheckTues.Checked, UiCheckWed.Checked, UiCheckThurs.Checked, UiCheckFri.Checked,
                    UiRadioDailyFrequencyOneTime.Checked, Shared.Val(UiComboBoxDailyFrequencyEvery.SelectedValue), Shared.ObjectToBool(UiComboBoxDailyFrequencyEveryType.SelectedValue),
                    TextBoxDailyFrequencyOneTime.Text, TextBoxDailyFrequencyEveryEnd.Text, TxtDateDurationStart.Text, TxtDateDurationEnd.Text,
                    Shared.Val(UiCmboOperation.SelectedValue));
                }
                else
                {
                    ReturnValue=SaveForm(PrimaryKey, TxtName.Text, Shared.ObjectToBool(UiCmboStatus.SelectedValue), Shared.ObjectToBool(UiCmboType.SelectedValue),
                    TxtDateOneTime.Text, TxtTimeOneTime.Text, Shared.Val(UiCmboFrequencyType.SelectedValue), Shared.Val(UiCmboFrequencyRecursEvery.SelectedValue),
                    UiCheckSat.Checked, UiCheckSun.Checked, UiCheckMon.Checked, UiCheckTues.Checked, UiCheckWed.Checked, UiCheckThurs.Checked, UiCheckFri.Checked,
                    UiRadioDailyFrequencyOneTime.Checked, Shared.Val(UiComboBoxDailyFrequencyEvery.SelectedValue), Shared.ObjectToBool(UiComboBoxDailyFrequencyEveryType.SelectedValue),
                    TextBoxDailyFrequencyEveryStart.Text, TextBoxDailyFrequencyEveryEnd.Text, TxtDateDurationStart.Text, TxtDateDurationEnd.Text,
                    Shared.Val(UiCmboOperation.SelectedValue));
                }
                if(!ReturnValue)
                {
                    return;
                }
            }
            Close();
        }
        private void UiButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void UiButtonDelete_Click(object sender, EventArgs e)
        {
            if (Shared.ShowMessage(EnumSendMessage.AiaMikhahidHazfKonid, "") != DialogResult.Yes)
            {
                return;
            }

            DeleteJobSchedule(Shared.Val(PrimaryKey));

            Shared.ShowMessage(EnumSendMessage.AmaleHazfKamelShod, "");

            SetDefaultValues();

            UiButtonExit_Click(sender, e);
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

    }
}
