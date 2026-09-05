using GeneralKiosk.Class.GhanunFarma;
using Janus.Windows.EditControls;
using Janus.Windows.GridEX;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralKiosk
{
    public partial class FormPayFormSetting : Form
    {

        public int UserType { get; internal set; }

        public FormPayFormSetting()
        {
            InitializeComponent();
        }

        private void uiButtonSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(Program.ConString))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.CommandType = CommandType.Text;



                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = $@"UPDATE       Toif
                        SET    FacConStr = @p1, SearchFacBy = @p2  , SearchByDepartment= @p3 ,EnterNumBy=@p4
                        WHERE  (ID = 1)";

                        cmd.Parameters.AddWithValue("@p1", textBoxConstr.Text.Trim());
                        cmd.Parameters.AddWithValue("@p2", UicomboBoxSearchBy.Text);
                        cmd.Parameters.AddWithValue("@p3", uiCheckBoxBakhsh.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@p4", uiRadioButtonEnteByClick.Checked ? 1 : 0);



                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();

                        cmd.CommandText = $@"UPDATE  TSettingGhanunFarma
                        SET    IP = @p1,
                        Port = @p2  ,
                        Name= @p3 ,
                        Pos=@p4,
                        Partner=@p5,
                        kioskDiscount=@p6,
                        PosValue=@p7,
                        PartnerValue=@p8
                        WHERE  (ID = 1)";

                        cmd.Parameters.AddWithValue("@p1", textBoxIP.Text.Trim());
                        cmd.Parameters.AddWithValue("@p2", textBoxPort.Text);
                        cmd.Parameters.AddWithValue("@p3", textBoxdrugstoreName.Text);
                        cmd.Parameters.AddWithValue("@p4", uiComboBoxPos.Text);
                        cmd.Parameters.AddWithValue("@p5", uiComboBoxPartner.Text);
                        cmd.Parameters.AddWithValue("@p6", Shared.Val(textBoxkioskDiscount.Text));
                        cmd.Parameters.AddWithValue("@p7", textBoxPosValue.Text);
                        cmd.Parameters.AddWithValue("@p8", textBoxPartnerValue.Text);

                        cmd.ExecuteNonQuery();


                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = $@"delete from   TDepartment
                        WHERE  (ID >0)";

                        cmd.ExecuteNonQuery();


                        GridEXRow[] rows = gridexDepartments.GetRows();
                        gridexDepartments.MoveFirst();

                        foreach (GridEXRow item in rows)
                        {

                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.Text;

                            cmd.CommandText = $@"insert into  TDepartment
                            (Cap)
                            values
                            (@p1)";


                            cmd.Parameters.AddWithValue("@p1", Shared.ObjectToText(item.Cells["عنوان"].Value));
                            cmd.ExecuteNonQuery();

                            gridexDepartments.MoveNext();
                        }


                    }

                    con.Close();


                }

                IniFile.IniWriteValue("PubSystemSet", "CanSetNFactor", uiCheckBoxCanSetNFactor.Checked.ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");


                IniFile.IniWriteValue("PubSystemSet", "VahedPool", uiRadioButtonRial.Checked ? "R" : "T",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

                IniFile.IniWriteValue("PubSystemSet", "ConTpe", uiRadioButtonByConStr.Checked ? "ByConStr" : "ByWebSer",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, ex.Message);
            }



            DialogResult = DialogResult.OK;
            Shared.ShowMessage(EnumSendMessage.AmaleSabtKamelShod, "");
        }

        private void LoadDepartment()
        {
            DataTable dt = new DataTable();
            #region MyRegion
            try
            {

                using (OleDbConnection con = new OleDbConnection(Program.ConString))
                {
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 300;
                        cmd.Connection = con;

                        cmd.CommandText =
                        $@"SELECT ID,  Cap as [عنوان]
                        FROM      TDepartment 
                        ORDER BY ID desc ";

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

            gridexDepartments.RootTable.Columns["ID"].Visible = false;
            gridexDepartments.AllowAddNew = InheritableBoolean.True;
            gridexDepartments.AllowDelete = InheritableBoolean.True;
            gridexDepartments.RootTable.Columns["عنوان"].Width = 250;
            #endregion
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {

            this.BringToFront();
            this.TopMost = true;
            LoadDepartment();
            LoadInfo();

            uiRadioButtonWebSer_CheckedChanged(sender, e);

            if (UserType == (int)Program.EnumUserType.Modir)
            {

                uiGroupBoxBackupAccess.Enabled = false;
            }
            //LoadCombo();
            //LoadData();
        }



        private void LoadInfo()
        {
            DataTable dt = new DataTable();
            DataTable dTSettingGhanunFarma = new DataTable();

            #region MyRegion
            try
            {

                using (OleDbConnection con = new OleDbConnection(Program.ConString))
                {
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 300;
                        cmd.Connection = con;

                        cmd.CommandText =
                        $@"SELECT *
                        FROM     toif
                        ORDER BY ID desc ";

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        cmd.Parameters.Clear();

                        cmd.CommandText =
                        $@"SELECT *
                        FROM     TSettingGhanunFarma
                        ORDER BY ID desc ";

                        da.SelectCommand = cmd;
                        da.Fill(dTSettingGhanunFarma);


                    }
                }

                textBoxConstr.Text = Shared.ObjectToText(dt.Rows[0]["FacConStr"]);
                UicomboBoxSearchBy.Text = Shared.ObjectToText(dt.Rows[0]["SearchFacBy"]);
                uiCheckBoxBakhsh.Checked = Shared.ObjectToBool(dt.Rows[0]["SearchByDepartment"]);
                uiRadioButtonEnteByClick.Checked = Shared.ObjectToBool(dt.Rows[0]["EnterNumBy"]);
                uiRadioButtonEnterByBarcode.Checked = !Shared.ObjectToBool(dt.Rows[0]["EnterNumBy"]);

                /////////////////////////////


                textBoxIP.Text = Shared.ObjectToText(dTSettingGhanunFarma.Rows[0]["IP"]);
                textBoxPort.Text = Shared.ObjectToText(dTSettingGhanunFarma.Rows[0]["Port"]);
                textBoxdrugstoreName.Text = Shared.ObjectToText(dTSettingGhanunFarma.Rows[0]["Name"]);

                textBoxkioskDiscount.Text = Shared.ObjectToText(dTSettingGhanunFarma.Rows[0]["kioskDiscount"]);
                textBoxPosValue.Text = Shared.ObjectToText(dTSettingGhanunFarma.Rows[0]["PosValue"]);
                textBoxPartnerValue.Text = Shared.ObjectToText(dTSettingGhanunFarma.Rows[0]["PartnerValue"]);

                uiComboBoxPos.SelectedValue = Shared.ObjectToText(dTSettingGhanunFarma.Rows[0]["PosValue"]);
                uiComboBoxPartner.SelectedValue = Shared.ObjectToText(dTSettingGhanunFarma.Rows[0]["PartnerValue"]);

                uiComboBoxPos.Text = Shared.ObjectToText(dTSettingGhanunFarma.Rows[0]["Pos"]);
                uiComboBoxPartner.Text = Shared.ObjectToText(dTSettingGhanunFarma.Rows[0]["Partner"]);

                uiCheckBoxCanSetNFactor.Checked = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "CanSetNFactor",
  AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));


                uiRadioButtonRial.Checked = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "VahedPool",
  AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini")) == "R" ? true : false;

                uiRadioButtonToman.Checked = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "VahedPool",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini")) == "T" ? true : false;


                uiCheckBoxCanSetNFactor.Checked = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "CanSetNFactor",
  AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

                uiRadioButtonByConStr.Checked = Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ConTpe",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini") == "ByConStr" ? true : false);

                uiRadioButtonByWebSer.Checked = !Shared.ObjectToBool(IniFile.IniReadValue("PubSystemSet", "ConTpe",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini") == "ByConStr" ? true : false);



            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
            #endregion
        }


        private void gridEXMain_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (gridEXMain.CurrentRow.RowType != RowType.Record)
                return;
            if (e.Column.Key.ToLower() == "remove")
            {
                if (gridEXMain.RecordCount <= 1)
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "لیست آیتم ها نمیتواند خالی باشد !");
                    return;
                }


                if (Shared.ShowMessage(EnumSendMessage.AiaMikhahidBaPeyghamehAzad,
                           "شما میخواهید یک آیتم حذف کنید" + "\r\n" +
                              "آیا مطمئن هستید؟") == DialogResult.Yes)
                {

                    gridEXMain.CurrentRow.Delete();

                }
            }

            if (e.Column.Key == "رنگ")
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    gridEXMain.CurrentRow.Cells["رنگ"].Text = colorDialog.Color.ToArgb().ToString();


                }
            }

            if (e.Column.Key == "فونت")
            {


                if (fontDialog.ShowDialog() == DialogResult.OK)
                {

                    var cvt = new FontConverter();
                    gridEXMain.CurrentRow.Cells["فونت"].Text = cvt.ConvertToString(fontDialog.Font);


                }

            }




        }

        private void gridEXMain_CellEdited(object sender, ColumnActionEventArgs e)
        {
            gridEXMain.AutoSizeColumns();
        }

        private void uiButtonLoadConStr_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmMakeNewConnection frm = new FrmMakeNewConnection())
                {

                    frm.ShowDialog();
                    textBoxConstr.Text = frm.temstr;
                }
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }

        }

        private void uiButtonLoadPosSetting_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmPosSetting frm = new frmPosSetting())
                {

                    frm.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
        }

        private void gridexDepartments_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridexDepartments.GetRows().Count() <= 0)
                return;
            if (e.KeyCode == Keys.Delete)
                gridexDepartments.CurrentRow.Delete();
        }

        private async void GetKalaInfoAsync()
        {
            this.Enabled = false;

            HttpClient _httpClient = new HttpClient();


            try
            {


                _httpClient.BaseAddress = new Uri($@"{textBoxIP.Text}:{textBoxPort.Text}/settings");



                var response = await _httpClient.GetStringAsync(_httpClient.BaseAddress);


                var data = JsonConvert.DeserializeObject<GetSettings>(response);

                if (data.success)
                {


                    var BS = new BindingSource();
                    BS.DataSource = data.data.poses;


                    uiComboBoxPos.DataSource = BS.DataSource;

                    uiComboBoxPos.DisplayMember = "bank";
                    uiComboBoxPos.ValueMember = "_id";



                    data.data.partners.Columns.Add(
                    "FullName",
                    typeof(string),
                    "name + ' ' + family");

                    BS = new BindingSource();
                    BS.DataSource = data.data.partners;


                    uiComboBoxPartner.DataSource = BS.DataSource;

                    uiComboBoxPartner.DisplayMember = "FullName";
                    uiComboBoxPartner.ValueMember = "_id";

                    textBoxdrugstoreName.Text = data.data.drugstoreName;
                    textBoxkioskDiscount.Text = data.data.kioskDiscount.ToString();
                    this.Enabled = true;
                }


                ////Program.InsertLog("GetKalaInfoAsync", this.Name.Trim(), " Search Barcode : " + TextBoxBarcode.Text.Trim() + " ComName : " + textBoxComName.Text + " ComFee : " + textBoxComFee.Text);

                //CustomOkMsgBox frmCustomOkMsgBox = new CustomOkMsgBox("موردی برای نمایش یافت نشد!", global::GeneralKiosk.Properties.Resources.WarningPic);
                //frmCustomOkMsgBox.ShowDialog();


                ////Program.InsertLog("GetKalaInfoAsync", this.Name.Trim(), " Search Barcode : " + TextBoxBarcode.Text.Trim() + " Not Found");



            }
            catch (Exception ex)
            {


                this.Enabled = true;
                string TempString = " هنگام اتصال به سرور خطا صورت گرفت " + "\r\n" + ex.Message;
                CustomOkMsgBox frmCustomOkMsgBox = new CustomOkMsgBox(TempString, global::GeneralKiosk.Properties.Resources.sabt_namovafagh_png);
                frmCustomOkMsgBox.ShowDialog();

                Program.InsertLog("GetKalaInfoAsync", this.Name.Trim(), "eroor Search Barcode : " + ex.Message);


            }

        }

        private void uiButtonLoadData_Click(object sender, EventArgs e)
        {
            GetKalaInfoAsync();
        }

        private void uiButtonExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiRadioButtonWebSer_CheckedChanged(object sender, EventArgs e)
        {

            uiGroupBoxConstr.Enabled = !uiRadioButtonByWebSer.Checked;
            uiGroupBoxWebSer.Enabled = uiRadioButtonByWebSer.Checked;

        }

        private void uiComboBoxPos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (uiComboBoxPos.Text == "")
            {
                textBoxPosValue.Text = "";
                return;
            }

            textBoxPosValue.Text = uiComboBoxPos.SelectedValue.ToString();


        }

        private void uiComboBoxPartner_TextChanged(object sender, EventArgs e)
        {
            if (uiComboBoxPartner.Text == "")
            {
                textBoxPartnerValue.Text = "";
                return;
            }

            textBoxPartnerValue.Text = uiComboBoxPartner.SelectedValue.ToString();
        }

        private void uiButtonPrintSetting_Click(object sender, EventArgs e)
        {


        }

        private void textBoxkioskDiscount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
