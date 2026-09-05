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
    public partial class FormInsertCustSetting : Form
    {
        public FormInsertCustSetting()
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

         


            IniFile.IniWriteValue("PubSystemSet", "IpInsertCust", textBoxIpInsertCust.Text.Trim(),
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini");


            IniFile.IniWriteValue("PubSystemSet", "PortInsertCust", textBoxPortInsertCust.Text.Trim(),
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



            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }


            textBoxIpInsertCust.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "IpInsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));


            textBoxPortInsertCust.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "PortInsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));


            /////////////////////////////////////////
            ///
            textBoxIpInsertCust.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "IpInsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));

            textBoxPortInsertCust.Text = Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "PortInsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));


            //////////////////////////////////////////

            textBoxDefPoint.Text = Shared.Val(IniFile.IniReadValue("PubSystemSet", "DefPoint",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini")).ToString();


        }


        private void uiButtonBackColorMobile_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                uiButtonBackColorMobile.BackColor = colorDialog.Color;
                uiButtonBackColorMobile.Tag = colorDialog.Color.ToArgb();

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
