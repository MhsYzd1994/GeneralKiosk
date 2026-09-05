using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using SepPaySCG;
using System.Data.SqlClient;


namespace GeneralKiosk
{
    public partial class FrmSerialActiveCode : Form
    {
        public FrmSerialActiveCode()
        {
            InitializeComponent();
        }

        private void FrmSerialActiveCode_Load(object sender, EventArgs e)
        {
            long serial;
            SecurityManager sm = new SecurityManager();
            serial = sm.GetSerial();
            TextBoxSerial.Text = serial.ToString();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            string key = "";
            if (TextBoxActiveCode.Text.Trim() == "")
            {
                //Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "کد فعال سازی غیر معتبر است");
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                key = TextBoxActiveCode.Text.Trim().ToUpper();
                SecurityManager sm = new SecurityManager();
                if (sm.CheckKey(key, "6cEN*8`2wcU:{d5K", Program.ProcessorId))
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghameAzadBaIconInfo, "فعال سازی موفق");

                    using (SqlConnection myCon = new SqlConnection(Program.ConString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            #region MyRegion
                            cmd.Connection = myCon;
                            cmd.CommandType = CommandType.Text;
                            myCon.Open();

                            cmd.Parameters.Clear();
                            cmd.CommandText = @"UPDATE BS.TPCG
                            SET        Ace = @p1
                            WHERE   (TPCGID = @p2)";
                            cmd.Parameters.AddWithValue("@p1", key);
                            cmd.Parameters.AddWithValue("@p2", Program.ProcessorId);
                            cmd.ExecuteNonQuery();
                            myCon.Close();
                            #endregion
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    //Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "فعال سازی انجام نشد");
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
