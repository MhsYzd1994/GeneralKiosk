using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralKiosk
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void uiButtonSaveSetting_Click(object sender, EventArgs e)
        {


            using (OleDbConnection con = new OleDbConnection(Program.ConString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $@"UPDATE       TOIF
                    SET    Onme = @p1, BranchID = @p2 
                    WHERE  (ID = 1)";

                    cmd.Parameters.AddWithValue("@p1", textBoxNameForoshgah.Text.Trim());
                    cmd.Parameters.AddWithValue("@p2", textBoxBranchID.Text.Trim());


                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $@"UPDATE       TBarcodeInfo
                    SET    Color = @p1, Font = @p2  , Width= @p3 , Height= @p4 , XDis= @p5 , YDis= @p6
                    WHERE  (ID = 1)";

                    cmd.Parameters.AddWithValue("@p1", uiButtonBackColorBarcode.Tag);
                    cmd.Parameters.AddWithValue("@p2", textBoxFontBarcode.Text);
                    cmd.Parameters.AddWithValue("@p3", textBoxArzBarcode.Text);
                    cmd.Parameters.AddWithValue("@p4", textBoxErtefaBarcode.Text);
                    cmd.Parameters.AddWithValue("@p5", textBoxXBarcode.Text);
                    cmd.Parameters.AddWithValue("@p6", textBoxYBarcode.Text);


                    cmd.ExecuteNonQuery();


                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $@"UPDATE       TComFee
                    SET    Color = @p1, Font = @p2  , Width= @p3 , Height= @p4 , XDis= @p5 , YDis= @p6
                    WHERE  (ID = 1)";

                    cmd.Parameters.AddWithValue("@p1", uiButtonBackColorKalaFee.Tag);
                    cmd.Parameters.AddWithValue("@p2", textBoxFontComFee.Text);
                    cmd.Parameters.AddWithValue("@p3", textBoxArzComFee.Text);
                    cmd.Parameters.AddWithValue("@p4", textBoxErtefaComFee.Text);
                    cmd.Parameters.AddWithValue("@p5", textBoxXComFee.Text);
                    cmd.Parameters.AddWithValue("@p6", textBoxYComFee.Text);


                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $@"UPDATE       TComName
                    SET    Color = @p1, Font = @p2  , Width= @p3 , Height= @p4 , XDis= @p5 , YDis= @p6
                    WHERE  (ID = 1)";

                    cmd.Parameters.AddWithValue("@p1", uiButtonBackColorKalaName.Tag);
                    cmd.Parameters.AddWithValue("@p2", textBoxFontComName.Text);
                    cmd.Parameters.AddWithValue("@p3", textBoxArzComName.Text);
                    cmd.Parameters.AddWithValue("@p4", textBoxErtefaComName.Text);
                    cmd.Parameters.AddWithValue("@p5", textBoxXComName.Text);
                    cmd.Parameters.AddWithValue("@p6", textBoxYComName.Text);


                    cmd.ExecuteNonQuery();

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = $@"UPDATE       TMobile
                    SET    Color = @p1, Font = @p2  , Width= @p3 , Height= @p4 , XDis= @p5 , YDis= @p6
                    WHERE  (ID = 1)";

                    cmd.Parameters.AddWithValue("@p1", uiButtonBackColorMobile.Tag);
                    cmd.Parameters.AddWithValue("@p2", textBoxFontMobile.Text);
                    cmd.Parameters.AddWithValue("@p3", textBoxArzMobile.Text);
                    cmd.Parameters.AddWithValue("@p4", textBoxErtefaMobile.Text);
                    cmd.Parameters.AddWithValue("@p5", textBoxXMobile.Text);
                    cmd.Parameters.AddWithValue("@p6", textBoxYMobile.Text);


                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }

            if (UicomboBoxSt.Text == "ثبت مشتری")
            {
                IniFile.IniWriteValue("PubSystemSet", "ModelTpe", "InsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");
            }
            else if (UicomboBoxSt.Text == "جستجوی کالا")
            {
                IniFile.IniWriteValue("PubSystemSet", "ModelTpe", "SearchCom",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");
            }
            else
            {
                IniFile.IniWriteValue("PubSystemSet", "ModelTpe", "All",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");
            }


            IniFile.IniWriteValue("PubSystemSet", "IpInsertCust", textBoxIpInsertCust.Text.Trim(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");


            IniFile.IniWriteValue("PubSystemSet", "PortInsertCust", textBoxPortInsertCust.Text.Trim(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");


            IniFile.IniWriteValue("PubSystemSet", "PortSearchCom", textBoxPortSearchCom.Text.Trim(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

            IniFile.IniWriteValue("PubSystemSet", "IpSearchCom", textBoxIpSearchCom.Text.Trim(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");

            IniFile.IniWriteValue("PubSystemSet", "DefPoint", Shared.Val(textBoxDefPoint.Text.Trim()).ToString(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");


            DialogResult = DialogResult.OK;
            Shared.ShowMessage(EnumSendMessage.AmaleSabtKamelShod, "");
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {

            this.BringToFront();
            this.TopMost = true;



            try
            {

                #region GetData
                DataTable dt = new DataTable();
                DataTable dtBarcodeInfo = new DataTable();
                DataTable dtComFee = new DataTable();
                DataTable dtComName = new DataTable();
                DataTable dtMobile = new DataTable();

                using (OleDbConnection con = new OleDbConnection(Program.ConString))
                {
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 300;
                        cmd.Connection = con;

                        cmd.CommandText =
                            $@"SELECT    * FROM TOIF
                            WHERE        (ID = 1)";

                        da.SelectCommand = cmd;
                        da.Fill(dt);
                        //////////////////////////////////////////////////////////////
                        cmd.Parameters.Clear();

                        cmd.CommandText =
                          $@"SELECT    * FROM TBarcodeInfo
                            WHERE        (ID = 1)";

                        da.SelectCommand = cmd;
                        da.Fill(dtBarcodeInfo);

                        cmd.Parameters.Clear();

                        cmd.CommandText =
                          $@"SELECT    * FROM TComFee
                            WHERE        (ID = 1)";

                        da.SelectCommand = cmd;
                        da.Fill(dtComFee);
                        cmd.Parameters.Clear();

                        cmd.CommandText =
                          $@"SELECT    * FROM TComName
                            WHERE        (ID = 1)";

                        da.SelectCommand = cmd;
                        da.Fill(dtComName);

                        cmd.Parameters.Clear();

                        cmd.CommandText =
                          $@"SELECT    * FROM TMobile
                            WHERE        (ID = 1)";

                        da.SelectCommand = cmd;
                        da.Fill(dtMobile);


                    }
                }
                #endregion

                #region FillData
                if (dt.Rows.Count > 0)
                {
                    textBoxNameForoshgah.Text = Shared.ObjectToText(dt.Rows[0]["Onme"]);
                    textBoxBranchID.Text = Shared.ObjectToText(dt.Rows[0]["BranchID"]);


                }
                //////////////////////////////////////////////

                if (dtBarcodeInfo.Rows.Count > 0)
                {

                    var cvt = new FontConverter();
                    uiButtonBackColorBarcode.Tag = Shared.ObjectToText(dtBarcodeInfo.Rows[0]["Color"]);
                    uiButtonBackColorBarcode.BackColor = Color.FromArgb(Shared.Val(dtBarcodeInfo.Rows[0]["Color"]));
                    textBoxFontBarcode.Text = Shared.ObjectToText(dtBarcodeInfo.Rows[0]["Font"]);
                    //textBoxFontBarcode.Font = cvt.ConvertFromString(Shared.ObjectToText(dtBarcodeInfo.Rows[0]["Font"])) as Font;
                    textBoxArzBarcode.Text = Shared.ObjectToText(dtBarcodeInfo.Rows[0]["Width"]);
                    textBoxErtefaBarcode.Text = Shared.ObjectToText(dtBarcodeInfo.Rows[0]["Height"]);
                    textBoxXBarcode.Text = Shared.ObjectToText(dtBarcodeInfo.Rows[0]["XDis"]);
                    textBoxYBarcode.Text = Shared.ObjectToText(dtBarcodeInfo.Rows[0]["YDis"]);

                }

                if (dtComFee.Rows.Count > 0)
                {
                    var cvt = new FontConverter();
                    uiButtonBackColorKalaFee.Tag = Shared.ObjectToText(dtComFee.Rows[0]["Color"]);
                    uiButtonBackColorKalaFee.BackColor = Color.FromArgb(Shared.Val(dtComFee.Rows[0]["Color"]));
                    textBoxFontComFee.Text = Shared.ObjectToText(dtComFee.Rows[0]["Font"]);
                    //textBoxFontComFee.Font = cvt.ConvertFromString(Shared.ObjectToText(dtComFee.Rows[0]["Font"])) as Font;
                    textBoxArzComFee.Text = Shared.ObjectToText(dtComFee.Rows[0]["Width"]);
                    textBoxErtefaComFee.Text = Shared.ObjectToText(dtComFee.Rows[0]["Height"]);
                    textBoxXComFee.Text = Shared.ObjectToText(dtComFee.Rows[0]["XDis"]);
                    textBoxYComFee.Text = Shared.ObjectToText(dtComFee.Rows[0]["YDis"]);


                }
                if (dtComName.Rows.Count > 0)
                {
                    var cvt = new FontConverter();
                    uiButtonBackColorKalaName.Tag = Shared.ObjectToText(dtComName.Rows[0]["Color"]);
                    uiButtonBackColorKalaName.BackColor = Color.FromArgb(Shared.Val(dtComName.Rows[0]["Color"]));
                    textBoxFontComName.Text = Shared.ObjectToText(dtComName.Rows[0]["Font"]);
                    //textBoxFontComName.Font = cvt.ConvertFromString(Shared.ObjectToText(dtComName.Rows[0]["Font"])) as Font;
                    textBoxArzComName.Text = Shared.ObjectToText(dtComName.Rows[0]["Width"]);
                    textBoxErtefaComName.Text = Shared.ObjectToText(dtComName.Rows[0]["Height"]);
                    textBoxXComName.Text = Shared.ObjectToText(dtComName.Rows[0]["XDis"]);
                    textBoxYComName.Text = Shared.ObjectToText(dtComName.Rows[0]["YDis"]);


                }
                if (dtMobile.Rows.Count > 0)
                {
                    var cvt = new FontConverter();
                    uiButtonBackColorMobile.Tag = Shared.ObjectToText(dtMobile.Rows[0]["Color"]);
                    uiButtonBackColorMobile.BackColor = Color.FromArgb(Shared.Val(dtMobile.Rows[0]["Color"]));
                    textBoxFontMobile.Text = Shared.ObjectToText(dtMobile.Rows[0]["Font"]);
                    //textBoxFontMobile.Font = cvt.ConvertFromString(Shared.ObjectToText(dtMobile.Rows[0]["Font"])) as Font;
                    textBoxArzMobile.Text = Shared.ObjectToText(dtMobile.Rows[0]["Width"]);
                    textBoxErtefaMobile.Text = Shared.ObjectToText(dtMobile.Rows[0]["Height"]);
                    textBoxXMobile.Text = Shared.ObjectToText(dtMobile.Rows[0]["XDis"]);
                    textBoxYMobile.Text = Shared.ObjectToText(dtMobile.Rows[0]["YDis"]);


                }

                #endregion

                if (Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "ModelTpe",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini")) == "SearchCom")
                {
                    UicomboBoxSt.Text = "جستجوی کالا";
                }
                else if (Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "ModelTpe",
    AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini")) == "InsertCust")
                {
                    UicomboBoxSt.Text = "ثبت مشتری";
                }
                else
                {
                    //UicomboBoxSt.Text = "ثبت مشتری";
                }

            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }


            textBoxIpInsertCust.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "IpInsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));


            textBoxPortInsertCust.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "PortInsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            textBoxPortSearchCom.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "PortSearchCom",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            textBoxIpSearchCom.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "IpSearchCom",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            /////////////////////////////////////////
            ///
            textBoxIpInsertCust.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "IpInsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            textBoxPortInsertCust.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "PortInsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            textBoxPortSearchCom.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "PortSearchCom",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            textBoxIpSearchCom.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "IpSearchCom",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            //////////////////////////////////////////

            textBoxDefPoint.Text = Shared.Val(IniFile.IniReadValue("PubSystemSet", "DefPoint",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini")).ToString();


        }

        private void uiButton1_Click(object sender, EventArgs e)
        {


            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                uiButtonBackColorBarcode.BackColor = colorDialog.Color;
                uiButtonBackColorBarcode.Tag = colorDialog.Color.ToArgb();

            }
        }

        private void buttonLoadFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {

                var cvt = new FontConverter();
                textBoxFontBarcode.Text = cvt.ConvertToString(fontDialog.Font);
                //textBoxFontBarcode.Font = fontDialog.Font;

            }
        }

        private void uiButtonBackColorKalaName_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                uiButtonBackColorKalaName.BackColor = colorDialog.Color;
                uiButtonBackColorKalaName.Tag = colorDialog.Color.ToArgb();

            }
        }

        private void uiButtonBackColorKalaFee_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                uiButtonBackColorKalaFee.BackColor = colorDialog.Color;
                uiButtonBackColorKalaFee.Tag = colorDialog.Color.ToArgb();

            }
        }

        private void uiButtonBackColorMobile_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                uiButtonBackColorMobile.BackColor = colorDialog.Color;
                uiButtonBackColorMobile.Tag = colorDialog.Color.ToArgb();

            }
        }

        private void buttonLoadFontComName_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                var cvt = new FontConverter();
                textBoxFontComName.Text = cvt.ConvertToString(fontDialog.Font);

            }
        }

        private void buttonLoadFontComFee_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {

                var cvt = new FontConverter();
                textBoxFontComFee.Text = cvt.ConvertToString(fontDialog.Font);

            }
        }

        private void buttonLoadFontMobile_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                var cvt = new FontConverter();
                textBoxFontMobile.Text = cvt.ConvertToString(fontDialog.Font);
            }
        }

        private void textBoxArzBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void uiButtonexit_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
    }
}
