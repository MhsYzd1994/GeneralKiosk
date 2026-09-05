using SepPay;
using SepPaySCG;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GeneralKiosk
{
    public partial class FrmMakeNewConnection : Form
    {
        public string temstr;

        public bool InsertIntoIniFile { get; set; }

        public FrmMakeNewConnection()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            temstr = EncryptDecryptMyPassword.encryptPassword($@"Data Source={TextBoxDataSource.Text};Initial Catalog={TextBoxInitialCatalog.Text};Persist Security Info=True;User ID={TextBoxUserID.Text};Password={TextBoxPassword.Text};Connection Timeout={TextBoxConnectionTimeout.Text}");
            TextBoxResult.Text = temstr;

            //Clipboard.SetText(temstr);

            if (InsertIntoIniFile == false) return;

            if (!string.IsNullOrEmpty(temstr))
            {
                Program.ConString = EncryptDecryptMyPassword.decryptPassword(temstr);

            }
            IniFile.IniWriteValue("ConnectionSetting", "ConnectionName", temstr,
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Connection.ini");
            this.Close();
            
        }

        private void FrmMakeNewConnection_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.TopMost = true;
            //TextBoxID.Text = Program.ProcessorId.ToString();
        }
    }
}
