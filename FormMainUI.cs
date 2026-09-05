using GeneralKiosk.Class;
using MakeRasisToken;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralKiosk
{
    public partial class FormMainUI : Form
    {
        public FormMainUI()
        {
            InitializeComponent();
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            TimerMain.Stop();

            this.Text = "No typing";
        }

        private void Form23_Resize(object sender, EventArgs e)
        {
            //TextBoxMobile.Left = (TextBoxMobile.Parent.Width - TextBoxMobile.Width) / 2;
            //TextBoxMobile.Top = (TextBoxMobile.Parent.Height - TextBoxMobile.Height) / 2;
        }

        private void TextBoxMobile_TextChanged(object sender, EventArgs e)
        {
            TimerMain.Stop();
            this.Text = "User is typing something,...";

            TimerMain.Start();
        }

        private void PictureBoxTozihat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("click shod");
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadSetting();

        }


        private async Task GetKalaInfoAsync()
        {

            try
            {
                HttpClient client = new HttpClient();

                // Put the following code where you want to initialize the class
                // It can be the static constructor or a one-time initializer


                client.BaseAddress = new Uri($@"http://{Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "IpSearchCom",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"))}:{Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "PortSearchCom",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"))}/api/Menu/GetCommodityByBC");


                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetStringAsync("?BARCODE=" + TextBoxBarcode.Text.Trim());

                var data = JsonConvert.DeserializeObject<List<GetTCDYBCWEBSR_Result>>(response);

                RasisKeyStore rasiskeystor = new RasisKeyStore("RasisSoft Eraeh dahande system narmafzari", "rasis iran kerman", "rasis software developers from kerman");

                string UniqCode = rasiskeystor.MakeToken("windows", Program.ProcessorId.ToString(), "1", "RasisSendReceiveData",
                    "", "", "version1");

                client.DefaultRequestHeaders.Add("UniqCode", UniqCode);




                if (data.Count > 0)
                {
                    textBoxComName.Text =  data[0].Cnme;
                    textBoxComFee.Text =  data[0].Camtsl.ToString();
                }
                else
                {

                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "موردی برای نمایش یافت نشد!");
                    textBoxComFee.Text = "";
                    textBoxComName.Text = "";
                    //richTextBoxKalaInfo.Text = "موردی یافت نشد !";
                }

                TextBoxBarcode.Text = "";


            }
            catch (Exception ex)
            {
                string TempString = " هنگام اتصال به سرور خطا صورت گرفت " + "\r\n" + ex.Message;
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, TempString);
            }


        }
        private void LoadSetting()
        {
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
               
                //////////////////////////////////////////////

                if (dtBarcodeInfo.Rows.Count > 0)
                {

                    var cvt = new FontConverter();
                    TextBoxBarcode.BackColor = Color.FromArgb(Shared.Val(dtBarcodeInfo.Rows[0]["Color"]));
                    TextBoxBarcode.Font = cvt.ConvertFromString(Shared.ObjectToText(dtBarcodeInfo.Rows[0]["Font"])) as Font;
                    TextBoxBarcode.Size = new Size(Shared.Val(dtBarcodeInfo.Rows[0]["Width"]), Shared.Val(dtBarcodeInfo.Rows[0]["Height"]));
                    TextBoxBarcode.Location = new Point(Shared.Val(dtBarcodeInfo.Rows[0]["XDis"]), Shared.Val(dtBarcodeInfo.Rows[0]["YDis"]));


                }

                if (dtComFee.Rows.Count > 0)
                {
                    var cvt = new FontConverter();
                    textBoxComFee.BackColor = Color.FromArgb(Shared.Val(dtComFee.Rows[0]["Color"]));
                    textBoxComFee.Font = cvt.ConvertFromString(Shared.ObjectToText(dtComFee.Rows[0]["Font"])) as Font;
                    textBoxComFee.Size = new Size(Shared.Val(dtComFee.Rows[0]["Width"]), Shared.Val(dtComFee.Rows[0]["Height"]));
                    textBoxComFee.Location = new Point(Shared.Val(dtComFee.Rows[0]["XDis"]), Shared.Val(dtComFee.Rows[0]["YDis"]));


                }
                if (dtComName.Rows.Count > 0)
                {
                    var cvt = new FontConverter();
                    textBoxComName.BackColor = Color.FromArgb(Shared.Val(dtComName.Rows[0]["Color"]));
                    textBoxComName.Font = cvt.ConvertFromString(Shared.ObjectToText(dtComName.Rows[0]["Font"])) as Font;
                    textBoxComName.Size = new Size(Shared.Val(dtComName.Rows[0]["Width"]), Shared.Val(dtComName.Rows[0]["Height"]));
                    textBoxComName.Location = new Point(Shared.Val(dtComName.Rows[0]["XDis"]), Shared.Val(dtComName.Rows[0]["YDis"]));


                }
                if (dtMobile.Rows.Count > 0)
                {
                    var cvt = new FontConverter();
                    TextBoxMobile.BackColor = Color.FromArgb(Shared.Val(dtMobile.Rows[0]["Color"]));
                    TextBoxMobile.Font = cvt.ConvertFromString(Shared.ObjectToText(dtMobile.Rows[0]["Font"])) as Font;
                    TextBoxMobile.Size = new Size(Shared.Val(dtMobile.Rows[0]["Width"]), Shared.Val(dtMobile.Rows[0]["Height"]));
                    TextBoxMobile.Location = new Point(Shared.Val(dtMobile.Rows[0]["XDis"]), Shared.Val(dtMobile.Rows[0]["YDis"]));


                }

                #endregion




            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }

            try
            {

                #region GetData
                DataTable dt = new DataTable();
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


                    }
                }
                #endregion

                #region FillData
                if (dt.Rows.Count > 0)
                {
                    Program.Onme = Shared.ObjectToText(dt.Rows[0]["Onme"]);
                    Program.BranchID = Shared.ObjectToText(dt.Rows[0]["BranchID"]);


                }

                #endregion




            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
        }

        private void FormMainUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                prompt frmprompt = new prompt();

                //if (frmprompt.ShowDialog() == DialogResult.OK)
                    //if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                    //{
                        using (FormSetting frm = new FormSetting())
                        {

                            frm.ShowDialog();
                        }

                //}

                LoadSetting();
            }
        }

        private void TextBoxBarcode_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void FormMainUI_SizeChanged(object sender, EventArgs e)
        {
            //TextBoxBarcode.Location = new Point(this.Width / 4, TextBoxBarcode.Location.Y);
        }

        private void TextBoxBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetKalaInfoAsync();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!Shared.CheckMobileNum(TextBoxMobile.Text.Trim()))
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "شماره موبایل نامعتبر میباشد !");
                TextBoxMobile.Focus();
                TextBoxMobile.SelectAll();
                return;
            }

            SendKalaInfoAsync();

            ClearForm();
        }

        private void ClearForm()
        {
            TextBoxBarcode.Text = "";
            TextBoxMobile.Text = "";
            textBoxComFee.Text = "";
            textBoxComName.Text = "";

            TextBoxBarcode.Focus();
            TextBoxBarcode.SelectAll();

        }

        private async Task SendKalaInfoAsync()
        {

            HttpClient _httpClient = new HttpClient();

            string UniqCode = "";

            RasisKeyStore rasiskeystor = new RasisKeyStore("RasisSoft Eraeh dahande system narmafzari", "rasis iran kerman", "rasis software developers from kerman");

            UniqCode = rasiskeystor.MakeToken("windows", Program.ProcessorId.ToString(), "1", "RasisSendReceiveData",
               "", "", "version1");

            try { _httpClient.DefaultRequestHeaders.Remove("UniqCode"); }
            catch { }
            _httpClient.DefaultRequestHeaders.Add("UniqCode", UniqCode);
            HttpResponseMessage response;
            try
            {


                string Url = $@"http://{Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "IpInsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"))}:{Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "PortInsertCust",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"))}/api/TPYRs/RegisterTpyr";

                //Url = "http://localhost:49670/api/TPYRs/RegisterTpyr";
                /////////////////////////////
                TPYR PYR = new TPYR();
                RegisterTypyrViewModel TypyrViewModelObj = new RegisterTypyrViewModel();


                //PYR.Name = richTextBoxNameCustomer.Text;
                //PYR.Family = richTextBoxFamilyCustomer.Text;
                PYR.Mobile = TextBoxMobile.Text;

                PYR.BranchID = new Guid(Program.BranchID);
                PYR.ShopName = Program.Onme;
                TypyrViewModelObj.TPYR = PYR;
                TypyrViewModelObj.DefaultScore = Shared.Val(IniFile.IniReadValue("PubSystemSet", "DefPoint",
AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini"));




                ///////////////////////////////////////////////
                response = await _httpClient.PostAsync(Url, CreateHttpContent<RegisterTypyrViewModel>(TypyrViewModelObj));
                response.EnsureSuccessStatusCode();


            }
            catch (Exception ex)
            {
                string TempString = " هنگام اتصال به سرور خطا صورت گرفت " + "\r\n" + ex.Message;
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, TempString);

            }

           


                   
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }


        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

    }
}
