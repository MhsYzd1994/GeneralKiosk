using GeneralKiosk.Class;
using Janus.Windows.GridEX;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GeneralKiosk
{
    public partial class FormMainSetting : Form
    {
        public int UserType { get; set; }
        public bool IsBackup { get; internal set; } = false;
        public int TemBakhshCount { get; private set; }
        public int BakhshCount { get; private set; }
        public bool PrintOtherMoshtari { get; private set; }
        public bool PrintOtherMaj { get; private set; }
        public bool PrintOtherNormal { get; private set; }

        OpenFileDialog dlg = new OpenFileDialog();
        private byte[] pic1;
        private byte[] pic2;
        private byte[] pic3;
        private byte[] pic4;
        private byte[] pic5;
        private byte[] pic6;
        private byte[] pic7;
        private CustomOkMsgBox frmCustomOkMsgBox;

        public FormMainSetting()
        {
            InitializeComponent();
        }
        private bool CheckPass()
        {
            if(textBoxNewPass.Text!="" || textBoxLastPass.Text != "" || textBoxRepeatnewPass.Text != "")
            {
                if(textBoxLastPass.Text != "" && (textBoxNewPass.Text== "" || textBoxRepeatnewPass.Text == ""))
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("رمز داخلی جدید یا تکرار آن نمیتواند خالی باشد ! "
        , global::GeneralKiosk.Properties.Resources.WarningPic);

                    frmCustomOkMsgBox.ShowDialog();
                    textBoxNewPass.Select();
                    return false;
                }
                if(Program.Pass==textBoxLastPass.Text)
                {
                    if(textBoxNewPass.Text==textBoxRepeatnewPass.Text)
                    {
                        return true;
                    }
                    else
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("پسورد جدید با تکرار آن مطابقت ندارد "
          , global::GeneralKiosk.Properties.Resources.WarningPic);

                        frmCustomOkMsgBox.ShowDialog();
                        textBoxNewPass.Select();
                        return false;
                    }
                }
                else
                {

                    frmCustomOkMsgBox = new CustomOkMsgBox("پسورد قدیم را اشتباه وارد کرده اید"
            , global::GeneralKiosk.Properties.Resources.WarningPic);

                    frmCustomOkMsgBox.ShowDialog();
                    textBoxLastPass.Select();
                    return false;
                }

            }
            return true;

        }

        private void uiButtonSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if(!CheckPass())
                {
                    return;
                }

                using (SqlConnection con = new SqlConnection(Program.ConString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = con;
                        con.Open();
                        cmd.CommandType = CommandType.Text;


                        cmd.CommandText = $@"SELECT count(*) FROM  BS.Setting WHERE  (ID = {Program.ProcessorId})";

                        var temOBJ = Shared.Val(cmd.ExecuteScalar());
                        cmd.Parameters.Clear();

                        if(temOBJ>0)
                        {
                            cmd.CommandText = $@"UPDATE       BS.Setting
                            SET    Onme = @p1, UserCode = @p2 , HasVadie = @p3 ,
                            HasTarkhis= @p4,VahedPool = @p5, ShowPatiaentListDay = @p6 
                            ,PictureTopRight=@p7
                            ,PictureTopCenter=@p8
                            ,PictureTopLeft=@p9
                            ,PictureCenter=@p10
                            ,PictureShowMessage=@p11
                            ,PictureDown=@p12
                            ,PictureTopRightPath=@p13
                            ,PictureTopCenterPath=@p14
                            ,PictureTopLeftPath=@p15
                            ,PictureCenterPath=@p16
                            ,PictureShowMessagePath=@p17
                            ,PictureDownPath=@p18
                            ,PictureTopRightVisible=@p19
                            ,PictureTopCenterVisible=@p20
                            ,PictureTopLeftVisible=@p21
                            ,PictureCenterVisible=@p22
                            ,PictureShowMessageVisible=@p23
                            ,PictureDownVisible=@p24
                            ,WebServiceAddres=@p25
                            ,Adres = @p26
                            ,Pass =  {(CheckPass() && textBoxNewPass.Text!="" ? textBoxNewPass.Text : Program.Pass ) }
                             WHERE  (ID = @p27)";
                        }
                        else
                        {
                            cmd.CommandText = $@"Insert into   BS.Setting
                            ( Onme ,
                            UserCode ,
                            HasVadie  ,
                            HasTarkhis,
                            VahedPool ,
                            ShowPatiaentListDay 
                            ,PictureTopRight
                            ,PictureTopCenter
                            ,PictureTopLeft
                            ,PictureCenter
                            ,PictureShowMessage
                            ,PictureDown
                            ,PictureTopRightPath
                            ,PictureTopCenterPath
                            ,PictureTopLeftPath
                            ,PictureCenterPath
                            ,PictureShowMessagePath
                            ,PictureDownPath
                            ,PictureTopRightVisible
                            ,PictureTopCenterVisible
                            ,PictureTopLeftVisible
                            ,PictureCenterVisible
                            ,PictureShowMessageVisible
                            ,PictureDownVisible
                            ,WebServiceAddres
                            ,Adres 
                            ,ID
                            ,PASS)
                            values
                            (@p1, 
                             @p2 ,
                             @p3 ,
                             @p4, 
                             @p5,
                             @p6 
                            ,@p7
                            ,@p8
                            ,@p9
                            ,@p10
                            ,@p11
                            ,@p12
                            ,@p13
                            ,@p14
                            ,@p15
                            ,@p16
                            ,@p17
                            ,@p18
                            ,@p19
                            ,@p20
                            ,@p21
                            ,@p22
                            ,@p23
                            ,@p24
                            ,@p25
                            ,@p26
                            ,@p27 
                            ,@p28)";
                        }


                        cmd.Parameters.AddWithValue("@p1", textBoxNameForoshgah.Text.Trim());
                        cmd.Parameters.AddWithValue("@p2", textBoxUserCode.Text.Trim());
                        cmd.Parameters.AddWithValue("@p3", uiCheckBoxShowVadie.Checked);
                        cmd.Parameters.AddWithValue("@p4", uiCheckBoxShowTarkhis.Checked);
                        cmd.Parameters.AddWithValue("@p5", uiRadioButtonToman.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@p6", textBoxShowPatiaentListDay.Text.ToString());
                        cmd.Parameters.Add("@p7", SqlDbType.VarBinary).Value = pic1 == null ? DBNull.Value : (object)pic1;
                        cmd.Parameters.Add("@p8", SqlDbType.VarBinary).Value = pic2 == null ? DBNull.Value : (object)pic2;
                        cmd.Parameters.Add("@p9", SqlDbType.VarBinary).Value = pic3 == null ? DBNull.Value : (object)pic3;
                        cmd.Parameters.Add("@p10", SqlDbType.VarBinary).Value = pic4 == null ? DBNull.Value : (object)pic4;
                        cmd.Parameters.Add("@p11", SqlDbType.VarBinary).Value = pic5 == null ? DBNull.Value : (object)pic5;
                        cmd.Parameters.Add("@p12", SqlDbType.VarBinary).Value = pic6 == null ? DBNull.Value : (object)pic6;
                        cmd.Parameters.Add("@p13",Shared.ObjectToText(pictureBoxTopRight.Tag));
                        cmd.Parameters.Add("@p14", Shared.ObjectToText(pictureBoxTopCenter.Tag));
                        cmd.Parameters.Add("@p15", Shared.ObjectToText(pictureBoxTopLeft.Tag));
                        cmd.Parameters.Add("@p16", Shared.ObjectToText(pictureBoxCenter.Tag));
                        cmd.Parameters.Add("@p17", Shared.ObjectToText(pictureBoxShowMessage.Tag));
                        cmd.Parameters.Add("@p18", Shared.ObjectToText(pictureBoxDown.Tag));
                        cmd.Parameters.Add("@p19", uiCheckBoxTopRight.Checked);
                        cmd.Parameters.Add("@p20", uiCheckBoxTopCenter.Checked);
                        cmd.Parameters.Add("@p21", uiCheckBoxTopLeft.Checked);
                        cmd.Parameters.Add("@p22", uiCheckBoxPictureCenter.Checked);
                        cmd.Parameters.Add("@p23", uiCheckBoxShowMessage.Checked);
                        cmd.Parameters.Add("@p24", uiCheckBoxDown.Checked);
                        cmd.Parameters.Add("@p25", textBoxWebServiceAddres.Text.Trim());
                        cmd.Parameters.Add("@p26", textBoxAdres.Text.Trim());
                        cmd.Parameters.Add("@p27", Program.ProcessorId);
                        cmd.Parameters.Add("@p28", CheckPass() && textBoxNewPass.Text != "" ? textBoxNewPass.Text : "123");
                        cmd.ExecuteNonQuery();

                    }
                }


                IniFile.IniWriteValue("PubSystemSet", "PrintImagePath", pictureBoxPrintImage.Tag.ToString(),
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "MuteSound", uiCheckBoxMuteSound.Checked.ToString(),
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowEghdamat", uiCheckBoxShowEghdamat.Checked.ToString(),
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowDrug", uiCheckBoxShowDrug.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "DrugCode", textBoxDrugCode.Text,
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "StartForm", uiRadioButtonStartParaclinicList.Checked ? "StartParaclinicList" : "StartMainForm",
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "SearchByNationalCodeStartFrm", uiCheckBoxSearchByNationalCodeStartFrm.Checked.ToString(),
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "UpdatePatient", uiCheckBoxUpdatePatient.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "UpdatePatientTimer", textBoxUpdatePatientTimer.Text.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("MainSetting", "Path", TxtPath.Text,
                  AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ActiveAutoBack", uiCheckBoxActiveAutoBack.Checked.ToString(),
  AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "SendIssueAfterPay", uiCheckBoxSendIssue.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "SendRefNumAfterPay", uiCheckBoxSendRefNum.Checked.ToString() ,
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "SendTerminalAfterPay", uiCheckBoxSendTerminal.Checked .ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowOther", uiCheckBoxShowOther.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowOtherInstart", uiCheckBoxShowOtherInstart.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowCol", uiRadioButtonShowOneCol.Checked ? "ShowOneCol" : "ShowTwoCol",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "PatientNameTopToBott", uiRadioButtonShowPatientTopToBottom.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "CheckMeli", uiCheckBoxCheckMeli.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ActiveKeyPad", uiCheckBoxActiveKeyPad.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowParaStartForm", uiCheckBoxShowParaStartForm.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowNobat", uiCheckBoxShowNobat.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "NobatLink", textBoxNobatLink.Text.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "CanCloseNumForm", uiCheckBoxCanCloseNumForm.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "PayAfterSearchMeli", uiCheckBoxPayAfterSearchMeli.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "SendCardNum", uiCheckBoxSendCardNum.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowReceptionDateTime", ShowReceptionDateTime.Checked.ToString(),
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowGhabzNum", ShowGhabzNum.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowReceptionCode", ShowReceptionCode.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowDocumentCode", ShowDocumentCode.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowPatientName", ShowPatientName.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowDoctorName", ShowDoctorName.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowNationalNumber", ShowNationalNumber.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowPatientRate", ShowPatientRate.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowInsuranceName", ShowInsuranceName.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowInsuranceRate", ShowInsuranceRate.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowSupplementaryName", ShowSupplementaryName.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowSupplementaryRate", ShowSupplementaryRate.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowServiceDescription", ShowServiceDescription.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowRno", ShowRno.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowParaClinicName", ShowParaClinicName.Checked.ToString(),
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowSalamatTrackingCode", ShowSalamatTrackingCode.Checked.ToString(),
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ShowExternalBeneficiaryName", ShowExternalBeneficiaryName.Checked.ToString(),
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "PrintOtherMoshtari", PrintOtherMoshtari.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "PrintOtherNormal", PrintOtherNormal.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "PrintOtherMaj", PrintOtherMaj.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                #region MyRegion
                IniFile.IniWriteValue("PubSystemSet", "NotSearchsoftCode01", (!uiCheckBoxSearchsoftCode01.Checked).ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "NotSearchsoftCode34", (!uiCheckBoxSearchsoftCode34.Checked).ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "NotSearchsoftCode11", (!uiCheckBoxSearchsoftCode11.Checked).ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "NotSearchsoftCode16", (!uiCheckBoxSearchsoftCode16.Checked).ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "NotSearchsoftCode06", (!uiCheckBoxSearchsoftCode06.Checked).ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");
                #endregion

                Program.TestPay = uiCheckBoxTestPay.Checked;
                Program.SenTest = uiCheckBoxSenTest.Checked;
                SavePara();
                SaveDrug();
              
                if ((Program.StartForm == "StartParaclinicList" &&
                    !uiRadioButtonStartParaclinicList.Checked) ||
                    (Program.StartForm == "StartMainForm" &&
                    !uiRadioButtonStartMainForm.Checked)
                    ||Program.UpdatePatient!= uiCheckBoxUpdatePatient.Checked
                    || ((Program.BakhshCount==1 || BakhshCount==1) && Program.BakhshCount != BakhshCount)
                    )
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("برای اعمال تغییرات فرم شروع ، برنامه بسته خواهد شد .لطفا مجددا اجرا کنید"
               , global::GeneralKiosk.Properties.Resources.WarningPic);

                    frmCustomOkMsgBox.ShowDialog();
                    Program.ExitApp = true;
                    Application.Exit();
                }



                GridEXRow[] rows = gridEXMain.GetRows();
                foreach (GridEXRow item in rows)
                {

                    IniFile.IniWriteValue("PubPrintSet", Shared.ObjectToText(item.Cells["PrintCap"].Value), Shared.ObjectToText(item.Cells["PrintNum"].Value),
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                    IniFile.IniWriteValue("PubPrintSet", Shared.ObjectToText(item.Cells["PrintCap"].Value) + "Checked", Shared.ObjectToText(item.Cells["PrintChecked"].Value),
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                    if (Shared.ObjectToBool(item.Cells["PrintChecked"].Value) == false && gridEXMain.GetRows().Count() > 1)
                        continue;
                }

                Program.LoadSetting();
                Program.CheckBakhshCount();
                if ( Program.UpdatePatient&& (TemBakhshCount ==1 || Program.BakhshCount==1) && TemBakhshCount != Program.BakhshCount)
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("برای اعمال تغییرات فرم شروع ، برنامه بسته خواهد شد .لطفا مجددا اجرا کنید"
, global::GeneralKiosk.Properties.Resources.WarningPic);

                    frmCustomOkMsgBox.ShowDialog();
                    Program.ExitApp = true;
                    Application.Exit();
                }

                Shared.ShowMessage(EnumSendMessage.AmaleSabtKamelShod, "");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }

        }

        private void LoadPara()
        {
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
                        $@"SELECT ID AS [شناسه],  ParaClinicCap as [عنوان] ,CONVERT(BIT , ISNULL(Show , 0)) AS [نمایش]
                        FROM      BS.ParaClinics 
                        where ProccessId={Program.ProcessorId}
                        ORDER BY ID  ";

                        da.SelectCommand = cmd;
                        da.Fill(dt);


                    }
                }
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
            #endregion
            #region Grid Configuration and Set Data
            gridexDepartments.DataSource = null;
            gridexDepartments.DataSource = dt;

            gridexDepartments.RetrieveStructure();

            gridexDepartments.RootTable.Columns["عنوان"].Width = 400;
            gridexDepartments.RootTable.Columns["شناسه"].Width = 120;
            gridexDepartments.RootTable.Columns["عنوان"].EditType = EditType.NoEdit;
            gridexDepartments.RootTable.Columns["شناسه"].EditType = EditType.NoEdit;
            gridexDepartments.RootTable.Columns["عنوان"].FilterEditType = FilterEditType.TextBox;
            gridexDepartments.RootTable.Columns["شناسه"].FilterEditType = FilterEditType.TextBox;
            //gridexDepartments.RootTable.DynamicFiltering = InheritableBoolean.True;
            #endregion
        }

        private void LoadDrug()
        {
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
                        $@"SELECT ID AS [شناسه],  DrugCap as [عنوان] ,CONVERT(BIT , ISNULL(Show , 0)) AS [نمایش]
                        FROM      BS.Drugs 
                        where ProccessId={Program.ProcessorId}
                        ORDER BY ID  ";

                        da.SelectCommand = cmd;
                        da.Fill(dt);


                    }
                }
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
            #endregion
            #region Grid Configuration and Set Data
            gridEXDrugs.DataSource = null;
            gridEXDrugs.DataSource = dt;

            gridEXDrugs.RetrieveStructure();

            gridEXDrugs.RootTable.Columns["عنوان"].Width = 400;
            gridEXDrugs.RootTable.Columns["شناسه"].Width = 120;
            //gridEXDrugs.RootTable.Columns["عنوان"].EditType = EditType.NoEdit;
            //gridEXDrugs.RootTable.Columns["شناسه"].EditType = EditType.NoEdit;
            //gridEXDrugs.RootTable.Columns["عنوان"].FilterEditType = FilterEditType.TextBox;
            //gridEXDrugs.RootTable.Columns["شناسه"].FilterEditType = FilterEditType.TextBox;
            //gridexDepartments.RootTable.DynamicFiltering = InheritableBoolean.True;
            #endregion
        }

        private void SavePara()
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

                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = $@"delete from   BS.ParaClinics
                        WHERE  (ProccessId ={Program.ProcessorId})";

                        cmd.ExecuteNonQuery();


                        GridEXRow[] rows = gridexDepartments.GetRows();
                        gridexDepartments.MoveFirst();

                        foreach (GridEXRow item in rows)
                        {

                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;

                            cmd.CommandText = $@"insert into  BS.ParaClinics
                            (ParaClinicCap,Show,ID , ProccessId)
                            values
                            (@p1,@p2,@p3 , @p4)";


                            cmd.Parameters.AddWithValue("@p1", Shared.ObjectToText(item.Cells["عنوان"].Value));
                            cmd.Parameters.AddWithValue("@p2", Shared.ObjectToBool(item.Cells["نمایش"].Value));
                            cmd.Parameters.AddWithValue("@p3", Shared.ObjectToText(item.Cells["شناسه"].Value));
                            cmd.Parameters.AddWithValue("@p4", Program.ProcessorId);
                            cmd.ExecuteNonQuery();

                            gridexDepartments.MoveNext();
                        }


                    }

                    con.Close();


                }


            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, ex.Message);
            }
        }

        private void SaveDrug()
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

                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = $@"delete from   BS.Drugs
                        WHERE  (ProccessId ={Program.ProcessorId})";

                        cmd.ExecuteNonQuery();


                        GridEXRow[] rows = gridEXDrugs.GetRows();
                        gridEXDrugs.MoveFirst();

                        foreach (GridEXRow item in rows)
                        {

                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;

                            cmd.CommandText = $@"insert into  BS.Drugs
                            (DrugCap,Show,ID , ProccessId)
                            values
                            (@p1,@p2,@p3 , @p4)";


                            cmd.Parameters.AddWithValue("@p1", Shared.ObjectToText(item.Cells["عنوان"].Value));
                            cmd.Parameters.AddWithValue("@p2", Shared.ObjectToBool(item.Cells["نمایش"].Value));
                            cmd.Parameters.AddWithValue("@p3", Shared.ObjectToText(item.Cells["شناسه"].Value));
                            cmd.Parameters.AddWithValue("@p4", Program.ProcessorId);
                            cmd.ExecuteNonQuery();

                            gridEXDrugs.MoveNext();
                        }


                    }

                    con.Close();


                }


            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, ex.Message);
            }
        }

        private void AddToOtherPrint()
        {
            UcMenuCheck uc1 = new UcMenuCheck();
            uc1.Caption = "پرینت مشتری";
            uc1.Checked = PrintOtherMoshtari;
            uc1.CaptionClick += (s, e) =>
            {
                this.TopMost = false;

                FastReport.Report report = new FastReport.Report();

                report.Load($@"Reports\OtherPrint\OtherPrintCust.frx");

                report.Design();

                this.TopMost = true;
            };
            uc1.CheckChanged += (s, e) =>
            {
                PrintOtherMoshtari = uc1.Checked;
            };

            ToolStripControlHost host1 = new ToolStripControlHost(uc1);
            host1.AutoSize = false;
            host1.Size = uc1.Size;
            host1.Margin = Padding.Empty;
            host1.Padding = Padding.Empty;

            contextMenuStrip1.Items.Add(host1);
            //contextMenuStrip1.Size = uc1.Size;


            UcMenuCheck uc2 = new UcMenuCheck();
            uc2.Caption = "پرینت مجموعه";
            uc2.Checked = PrintOtherMaj;
            uc2.CaptionClick += (s, e) =>
            {
                this.TopMost = false;

                FastReport.Report report = new FastReport.Report();

                report.Load($@"Reports\OtherPrint\OtherPrintMaj.frx");

                report.Design();

                this.TopMost = true;
            };
            uc2.CheckChanged += (s, e) =>
            {
                PrintOtherMaj = uc2.Checked;
            };
            ToolStripControlHost host2 = new ToolStripControlHost(uc2);
            host2.AutoSize = false;
            host2.Size = uc1.Size;
            //host2.Margin = Padding.Empty;
            //host2.Padding = Padding.Empty;

            contextMenuStrip1.Items.Add(host2);

            UcMenuCheck uc3 = new UcMenuCheck();
            uc3.Caption = "پرینت معمولی";
            uc3.Checked = PrintOtherNormal;
            uc3.CaptionClick += (s, e) =>
            {
                this.TopMost = false;

                FastReport.Report report = new FastReport.Report();

                report.Load($@"Reports\OtherPrint\OtherPrintNormal.frx");

                report.Design();

                this.TopMost = true;
            };
            uc3.CheckChanged += (s, e) =>
            {
                PrintOtherNormal = uc3.Checked;
            };
            ToolStripControlHost host3 = new ToolStripControlHost(uc3);
            host3.AutoSize = false;
            host3.Size = uc3.Size;
            //host2.Margin = Padding.Empty;
            //host2.Padding = Padding.Empty;

            contextMenuStrip1.Items.Add(host3);
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {

  
            TemBakhshCount = Program.BakhshCount;
            BakhshCount=Program.BakhshCount;
            uiCheckBoxTestPay.Visible = IsBackup;
            uiCheckBoxSenTest.Visible = IsBackup;
            SetIcons();
            this.BringToFront();
            this.TopMost = true;

            try
            {
                textBoxNameForoshgah.Text = Program.Onme;
                textBoxAdres.Text = Program.Adres;
                textBoxUserCode.Text = Program.UserCode;
                uiCheckBoxShowVadie.Checked = Program.HasVadie;
                uiCheckBoxShowTarkhis.Checked = Program.HasTarkhis;
                uiRadioButtonToman.Checked = Program.VahedPool == "تومان" ? true : false;
                uiRadioButtonRial.Checked = Program.VahedPool == "ریال" ? true : false;
                textBoxShowPatiaentListDay.Text = Shared.ObjectToText(Program.ShowPatiaentListDay);
                uiCheckBoxTestPay.Checked = Program.TestPay;
                uiCheckBoxSenTest.Checked = Program.SenTest;
                textBoxWebServiceAddres.Text = Program.WebServiceAddres;
                uiCheckBoxActiveAutoBack.Checked = Program.ActiveAutoBack;
                uiCheckBoxSendIssue.Checked = Program.SendIssueAfterPay; 
                uiCheckBoxSendRefNum.Checked = Program.SendRefNumAfterPay ;
                uiCheckBoxSendTerminal.Checked = Program.SendTerminalAfterPay;
                uiCheckBoxShowOther.Checked = Program.ShowOther ;
                uiCheckBoxShowOtherInstart.Checked = Program.ShowOtherInstart;
                uiRadioButtonShowOneCol.Checked = Program.ShowCol == "ShowTwoCol" ? false : true;
                uiRadioButtonShowTwoCol.Checked = Program.ShowCol == "ShowTwoCol" ? true : false;
                uiRadioButtonShowPatientRightToLeft.Checked = !Program.PatientNameTopToBott;
                uiRadioButtonShowPatientTopToBottom.Checked = Program.PatientNameTopToBott;
                uiCheckBoxCheckMeli.Checked = Program.CheckMeli;
                uiCheckBoxActiveKeyPad.Checked = Program.ActiveKeyPad;
                uiCheckBoxShowParaStartForm.Checked = Program.ShowParaStartForm;
                uiCheckBoxShowNobat.Checked = Program.ShowNobat;
                textBoxNobatLink.Text = Program.NobatLink;
                uiCheckBoxCanCloseNumForm.Checked = Program.CanCloseNumForm;
                uiCheckBoxPayAfterSearchMeli.Checked = Program.PayAfterSearchMeli;
                uiCheckBoxSendCardNum.Checked = Program.SendCardNum;
                ShowReceptionDateTime.Checked = Program.ShowReceptionDateTime;
                ShowGhabzNum.Checked = Program.ShowGhabzNum;
                ShowReceptionCode.Checked = Program.ShowReceptionCode;
                ShowDocumentCode.Checked = Program.ShowDocumentCode;
                ShowPatientName.Checked = Program.ShowPatientName;
                ShowDoctorName.Checked = Program.ShowDoctorName;
                ShowNationalNumber.Checked = Program.ShowNationalNumber;
                ShowPatientRate.Checked = Program.ShowPatientRate;
                ShowInsuranceName.Checked = Program.ShowInsuranceName;
                ShowInsuranceRate.Checked = Program.ShowInsuranceRate;
                ShowSupplementaryName.Checked = Program.ShowSupplementaryName;
                ShowSupplementaryRate.Checked = Program.ShowSupplementaryRate;
                ShowServiceDescription.Checked = Program.ShowServiceDescription;
                ShowRno.Checked = Program.ShowRno;
                ShowParaClinicName.Checked = Program.ShowParaClinicName;
                ShowExternalBeneficiaryName.Checked = Program.ShowExternalBeneficiaryName;
                ShowSalamatTrackingCode.Checked = Program.ShowSalamatTrackingCode;
                PrintOtherMoshtari = Program.PrintOtherMoshtari;
                PrintOtherMaj = Program.PrintOtherMaj;
                PrintOtherNormal = Program.PrintOtherNormal;
                uiCheckBoxSearchsoftCode01.Checked = !Program.NotSearchsoftCode01;
                uiCheckBoxSearchsoftCode34.Checked = !Program.NotSearchsoftCode34;
                uiCheckBoxSearchsoftCode11.Checked = !Program.NotSearchsoftCode11;
                uiCheckBoxSearchsoftCode16.Checked = !Program.NotSearchsoftCode16;
                uiCheckBoxSearchsoftCode06.Checked = !Program.NotSearchsoftCode06;
                LoadPara();
                LoadDrug();
                LoadPrints();
                AddToOtherPrint();


            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }


        }

        private void LoadPrints()
        {
            try
            {


                gridEXMain.DataSource = null;

                gridEXMain.DataSource = IEnumerableExt.ToDataTable<Program.PrintInfo>(Program.PrintList);

                gridEXMain.RetrieveStructure();

                gridEXMain.Row = Janus.Windows.GridEX.GridEX.filterRowPosition;
                gridEXMain.RootTable.Columns["PrintCap"].Caption = "نام پرینت";
                gridEXMain.RootTable.Columns["PrintChecked"].Caption = "";
                gridEXMain.RootTable.Columns["PrintNum"].Caption = "تعداد";
                gridEXMain.RootTable.Columns["PrintCap"].EditType = EditType.NoEdit;
                gridEXMain.RootTable.Columns["PrintChecked"].EditType = EditType.CheckBox;
                gridEXMain.RootTable.Columns["PrintNum"].EditType = EditType.TextBox;
                gridEXMain.RootTable.Columns["PrintCap"].Width = 300;
                gridEXMain.RootTable.Columns["PrintChecked"].Width = 30;
                gridEXMain.AutoSizeColumns();

                gridEXMain.Col = 0;

                foreach (var item in Program.PrintList)
                {
                    contextMenuStripPrintList.Items.Add(item.PrintCap);
                }

            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
        }

        private void SetIcons()
        {
            try
            {
                pic1 = Program.PictureTopRightpic;
                pic2 = Program.PictureTopCenterpic;
                pic3 = Program.PictureTopLeftpic;
                pic4 = Program.PictureCenterpic;
                pic5 = Program.PictureShowMessagepic;
                pic6 = Program.PictureDownpic;
                pic7 = Program.PicturePrintpic;


                pictureBoxTopRight.Image = Program.PictureTopRightImage;


                pictureBoxTopCenter.Image = Program.PictureTopCenterImage;


                pictureBoxTopLeft.Image = Program.PictureTopLeftImage;


                pictureBoxCenter.Image = Program.PictureCenterImage;


                pictureBoxShowMessage.Image = Program.PictureShowMessageImage;


                pictureBoxDown.Image = Program.PictureDownImage;

                pictureBoxPrintImage.Image = Program.PrintImage;


                pictureBoxTopRight.Tag = Program.pictureBoxTopRightPath;
                pictureBoxTopCenter.Tag = Program.pictureBoxTopCentertPath;
                pictureBoxTopLeft.Tag = Program.pictureBoxTopLeftPath;
                pictureBoxCenter.Tag = Program.pictureBoxCenterPath;
                pictureBoxShowMessage.Tag = Program.pictureBoxShowMessagePath;
                pictureBoxDown.Tag = Program.pictureBoxDownPath;
                pictureBoxPrintImage.Tag = Program.PrintImagePath;
                uiCheckBoxMuteSound.Checked = Program.MuteSound;
                uiCheckBoxShowEghdamat.Checked = Program.ShowEghdamat;
                textBoxDrugCode.Text = Program.DrugCode;
                uiCheckBoxShowDrug.Checked = Program.ShowDrug;
                uiRadioButtonStartParaclinicList.Checked = Program.StartForm == "StartParaclinicList" ? true : false;
                uiRadioButtonStartMainForm.Checked = Program.StartForm == "StartParaclinicList" ? false : true;
                uiCheckBoxSearchByNationalCodeStartFrm.Checked = Program.SearchByNationalCodeStartFrm;
                uiCheckBoxUpdatePatient.Checked = Program.UpdatePatient;
                textBoxUpdatePatientTimer.Text = Program.UpdatePatientTimer.ToString();
                TxtPath.Text = Program.BackPath;

                uiButtonTopLeft.Enabled = IsBackup;
                uiButtonTopCenter.Enabled = IsBackup;
                uiCheckBoxTopLeft.Enabled = IsBackup;
                uiCheckBoxTopCenter.Enabled = IsBackup;
                uiRadioButtonRial.Enabled = IsBackup;
                uiRadioButtonToman.Enabled = IsBackup;


                uiCheckBoxTopRight.Checked = Program.PictureTopRightVisible;

                uiCheckBoxTopCenter.Checked = Program.PictureTopCenterVisible;

                uiCheckBoxTopLeft.Checked = Program.PictureTopLeftVisible;

                uiCheckBoxPictureCenter.Checked = Program.PictureCenterVisible;

                uiCheckBoxShowMessage.Checked = Program.PictureShowMessagetVisible;

                uiCheckBoxDown.Checked = Program.PictureDownVisible;

            }
            catch
            {

            }


        }

        private void uiButtonexit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void uiCheckBoxMenuForm_CheckedChanged(object sender, EventArgs e)
        {


            ActiveSearchComForm.Enabled = uiCheckBoxSearchComForm.Checked;
            ActivePayFactorForm.Enabled = uiCheckBoxPayFactorForm.Checked;
            ActiveMenuForm.Enabled = uiCheckBoxMenuForm.Checked;
            ActiveInsertCustForm.Enabled = uiCheckBoxInsertCustForm.Checked;

            if (!uiCheckBoxInsertCustForm.Checked)
                ActiveInsertCustForm.Checked = false;

            if (!uiCheckBoxSearchComForm.Checked)
                ActiveSearchComForm.Checked = false;


            if (!uiCheckBoxPayFactorForm.Checked)
                ActivePayFactorForm.Checked = false;



            if (!uiCheckBoxMenuForm.Checked)
                ActiveMenuForm.Checked = false;

        }

        private void FormMainSetting_FormClosing(object sender, FormClosingEventArgs e)
        {



        }

        private async void uiButtonPrintSetting_Click(object sender, EventArgs e)
        {
            SavePara();
            this.Enabled = false;
            await SaveNewPara();
            this.Enabled = true;
            LoadPara();
        }

        private async Task SaveNewPara()
        {
            try
            {
                DataTable Dt = new DataTable();

                Uri myUri = new Uri($@"{textBoxWebServiceAddres.Text}/CashLessListFullParaclinic");

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
                Dt = new DataTable();

                XmlElement root = doc.DocumentElement;
                XmlNodeList elemList = root.GetElementsByTagName("BaseParaclinicChild");

                Dt = Program.ConvertXmlNodeListToDataTableParaList(elemList);

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    using (SqlConnection con = new SqlConnection(Program.ConString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;

                            cmd.CommandText = $@"select id from   BS.ParaClinics
                                WHERE  ID ={Shared.Val(Dt.Rows[i]["ParaclinicChildID"])} and ProccessId={Program.ProcessorId}";

                            var TemObj = Shared.Val(cmd.ExecuteScalar());
                            if (TemObj > 0)
                            {
                                continue;
                            }

                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;

                            cmd.CommandText = $@"insert into  BS.ParaClinics
                                (ParaClinicCap,Show,ID,ProccessId)
                                values
                                (@p1,@p2,@p3,@p4)";


                            cmd.Parameters.AddWithValue("@p1", Shared.ObjectToText(Dt.Rows[i]["ParaclinicChildName"]));
                            cmd.Parameters.AddWithValue("@p2", 0);
                            cmd.Parameters.AddWithValue("@p3", Shared.ObjectToText(Dt.Rows[i]["ParaclinicChildID"]));
                            cmd.Parameters.AddWithValue("@p4", Program.ProcessorId);
                            cmd.ExecuteNonQuery();

                            gridexDepartments.MoveNext();
                        }


                        con.Close();


                    }
                }


            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, ex.Message);
            }

        }

        private void uiButtonTopRight_Click(object sender, EventArgs e)
        {
            dlg.Title = "لطفا یک عکس انتخاب نمایید";
            dlg.Filter = "Image Files(*.gif;*.png;*.jpg; *.jpeg; *.bmp)|*.gif;*.png;*.jpg; *.jpeg; *.bmp";
            dlg.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Pics";
            dlg.RestoreDirectory = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxTopRight.Tag = dlg.FileName;
                pictureBoxTopRight.Image = new Bitmap(dlg.OpenFile());

                MemoryStream stream = new MemoryStream();
                pictureBoxTopRight.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                pic1 = stream.ToArray();
            }
            dlg.Dispose();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {

            dlg.Title = "لطفا یک عکس انتخاب نمایید";
            dlg.Filter = "Image Files(*.gif;*.png;*.jpg; *.jpeg; *.bmp)|*.gif;*.png;*.jpg; *.jpeg; *.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxTopCenter.Image = new Bitmap(dlg.OpenFile());
                pictureBoxTopCenter.Tag = dlg.FileName;

                MemoryStream stream = new MemoryStream();
                pictureBoxTopCenter.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                pic2 = stream.ToArray();
            }
            dlg.Dispose();
        }

        private void uiButtonTopLeft_Click(object sender, EventArgs e)
        {

            dlg.Title = "لطفا یک عکس انتخاب نمایید";
            dlg.Filter = "Image Files(*.gif;*.png;*.jpg; *.jpeg; *.bmp)|*.gif;*.png;*.jpg; *.jpeg; *.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxTopLeft.Image = new Bitmap(dlg.OpenFile());
                pictureBoxTopLeft.Tag = dlg.FileName;

                MemoryStream stream = new MemoryStream();
                pictureBoxTopLeft.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                pic3 = stream.ToArray();
            }
            dlg.Dispose();
        }

        private void uiButtonCenter_Click(object sender, EventArgs e)
        {
            dlg.Title = "لطفا یک عکس انتخاب نمایید";
            dlg.Filter = "Image Files(*.gif;*.png;*.jpg; *.jpeg; *.bmp)|*.gif;*.png;*.jpg; *.jpeg; *.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCenter.Image = new Bitmap(dlg.OpenFile());
                pictureBoxCenter.Tag = dlg.FileName;

                MemoryStream stream = new MemoryStream();
                pictureBoxCenter.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                pic4 = stream.ToArray();
            }
            dlg.Dispose();
        }

        private void uiButtonShowMessage_Click(object sender, EventArgs e)
        {
            dlg.Title = "لطفا یک عکس انتخاب نمایید";
            dlg.Filter = "Image Files(*.gif;*.png;*.jpg; *.jpeg; *.bmp)|*.gif;*.png;*.jpg; *.jpeg; *.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxShowMessage.Image = new Bitmap(dlg.OpenFile());
                pictureBoxShowMessage.Tag = dlg.FileName;

                MemoryStream stream = new MemoryStream();
                pictureBoxShowMessage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                pic5 = stream.ToArray();
            }
            dlg.Dispose();
        }

        private void uiButtonDown_Click(object sender, EventArgs e)
        {
            dlg.Title = "لطفا یک عکس انتخاب نمایید";
            dlg.Filter = "Image Files(*.gif;*.png;*.jpg; *.jpeg; *.bmp)|*.gif;*.png;*.jpg; *.jpeg; *.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxDown.Image = new Bitmap(dlg.OpenFile());
                pictureBoxDown.Tag = dlg.FileName;


                MemoryStream stream = new MemoryStream();
                pictureBoxDown.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                pic6 = stream.ToArray();
            }
            dlg.Dispose();
        }

        private void textBoxShowPatiaentListDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxPrintNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void uiButtonPrintImage_Click(object sender, EventArgs e)
        {
            dlg.Title = "لطفا یک عکس انتخاب نمایید";
            dlg.Filter = "Image Files(*.gif;*.png;*.jpg; *.jpeg; *.bmp)|*.gif;*.png;*.jpg; *.jpeg; *.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPrintImage.Image = new Bitmap(dlg.OpenFile());
                pictureBoxPrintImage.Tag = dlg.FileName;


                MemoryStream stream = new MemoryStream();
                pictureBoxPrintImage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                pic7 = stream.ToArray();
            }
            dlg.Dispose();
        }

        private void uiButtonSuccessPrint_Click(object sender, EventArgs e)
        {

            contextMenuStripPrintList.Show(uiButtonSuccessPrint, new Point(uiButtonSuccessPrint.Height, 0), ToolStripDropDownDirection.Left);

        }

        private void uiButtonFailedPrint_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            FastReport.Report report = new FastReport.Report();
            report.Load(@"Reports\AdamErsal\FactorFXReportAdamErsal.frx");
            report.Design();
            this.TopMost = true;
        }

        private void uiRadioButtonStartMainForm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStripPrintList_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.TopMost = false;
            FastReport.Report report = new FastReport.Report();
            report.Load($@"Reports\{e.ClickedItem.Text}");
            report.Design();
            this.TopMost = true;
        }

        private void UiButtonLoadPath_Click(object sender, EventArgs e)
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

                    IniFile.IniWriteValue("MainSetting", "Path", fbd.SelectedPath,
                    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                    LoadPath();
                }
            }
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

        private void uiCheckBoxActiveAutoBack_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void uiButtonOtherPrintSetting_Click(object sender, EventArgs e)
        {


            contextMenuStrip1.Show(uiButtonOtherPrintSetting, new Point(uiButtonOtherPrintSetting.Height, 0), ToolStripDropDownDirection.Left);
        }

        private void پرینتمشتریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            FastReport.Report report = new FastReport.Report();

            report.Load($@"Reports\OtherPrint\OtherPrintCust.frx");

            report.Design();

            this.TopMost = true;
        }

        private void پرینتمجموعهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = false;

            FastReport.Report report = new FastReport.Report();

            report.Load($@"Reports\OtherPrint\OtherPrintMaj.frx");

            report.Design();

            this.TopMost = true;
        }

        private void contextMenuStripOther_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
