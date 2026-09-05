using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using Nancy.Json;
using Newtonsoft.Json;
using GeneralKiosk.Class;
using MakeRasisToken;
using NPOI.SS.Formula.Functions;
using Newtonsoft.Json.Linq;
using System.Data.OleDb;

namespace GeneralKiosk
{
    public partial class FormMain : Form
    {
        public object TodayDate { get; }

        public FormMain()
        {
            TodayDate = Shared.M2S(DateTime.Now);
            InitializeComponent();
        }


        private string GetAssemblyVer()
        {
            int VersionLocation = Assembly.GetExecutingAssembly().FullName.IndexOf("Version=");
            int CultureLocation = Assembly.GetExecutingAssembly().FullName.IndexOf(", Culture");
            return Assembly.GetExecutingAssembly().FullName.Substring(VersionLocation, (CultureLocation - VersionLocation));
        }


        private void LoadSeting()
        {
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

        private void FormMain_Load(object sender, EventArgs e)
        {

            //           if (Shared.ObjectToText(IniFile.IniReadValue("PubSystemSet", "ModelTpe"),
            //AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Setting.ini")) == "")

            LoadSeting();

            toolStripStatusLabelDate.Text = "تقویم روز : " + TodayDate;
            toolStripStatusLabelTime.Text = DateTime.Now.ToString("HH:mm");
            toolStripStatusLabelVer.Text = @"نسخه برنامه : " + GetAssemblyVer();

            uiButtonExitToMainFromCustomer.Enabled = false;
            ResizeFormObjects();


        }

        private void ResizeFormObjects()
        {
            splitContainer1.Size = new Size(this.Size.Width / 2, this.Size.Height / 5);


            splitContainer1.Location = new Point(this.Width / 4, splitContainer1.Location.Y);


            splitContainer2.Size = new Size(this.Size.Width / 2, this.Size.Height / 2);


            splitContainer2.Location = new Point(this.Width / 4, splitContainer2.Location.Y);


            splitContainer6.Size = new Size(this.Size.Width / 2, this.Size.Height - 200);


            splitContainer6.Location = new Point(this.Width / 4, splitContainer6.Location.Y);


            ///////////////////////////////
            uiButtonSearchCom.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 100, FontStyle.Bold);
            uiButtonEnterCustomer.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 100, FontStyle.Bold);
            //////////////////////////////////
            uiButtonSaveCustomer.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 100, FontStyle.Bold);
            textBoxNameCap.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 130, FontStyle.Bold);
            textBoxMobCap.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 130, FontStyle.Bold);
            richTextBoxMobile.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 60, FontStyle.Bold);
            richTextBoxNameCustomer.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 80, FontStyle.Bold);
            richTextBoxFamilyCustomer.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 80, FontStyle.Bold);
            //////////////////////////////////
            uiButtonSearch.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 100, FontStyle.Bold);
            textBoxBarcodeLabel.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 80, FontStyle.Bold);
            richTextBoxBarcode.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 60, FontStyle.Bold);
            richTextBoxKalaInfo.Font = new Font("Tahoma", (this.Size.Width + this.Size.Height) / 60, FontStyle.Bold);

        }

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            ResizeFormObjects();
        }

        private void uiButtonEnterCustomer_Click(object sender, EventArgs e)
        {

            richTextBoxNameCustomer.Text = "";
            richTextBoxFamilyCustomer.Text = "";
            richTextBoxMobile.Text = "";
            richTextBoxMobile.Select();
            uiTab1.SelectedIndex = 1;
            uiButtonExitToMainFromCustomer.Enabled = true;
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            ResizeFormObjects();
        }

        private void uiButtonExitToMainFromCustomer_Click(object sender, EventArgs e)
        {
            uiTab1.SelectedIndex = 0;
            uiButtonExitToMainFromCustomer.Enabled = false;
        }

        private void uiButtonSearchCom_Click(object sender, EventArgs e)
        {
            uiTab1.SelectedIndex = 2;
            richTextBoxBarcode.Text = "";
            richTextBoxBarcode.Select();
            uiButtonExitToMainFromCustomer.Enabled = true;
        }


        private void uiButtonSearch_Click(object sender, EventArgs e)
        {
            GetKalaInfoAsync();
        }

        private async void GetKalaInfoAsync()
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

                var response = await client.GetStringAsync("?BARCODE=" + richTextBoxBarcode.Text.Trim());

                //var data = JsonConvert.DeserializeObject<List<GetTCDYBCWBSR_Result>>(response);

                RasisKeyStore rasiskeystor = new RasisKeyStore("RasisSoft Eraeh dahande system narmafzari", "rasis iran kerman", "rasis software developers from kerman");

                string UniqCode = rasiskeystor.MakeToken("windows", Program.ProcessorId.ToString(), "1", "RasisSendReceiveData",
                    "", "", "version1");

                client.DefaultRequestHeaders.Add("UniqCode", UniqCode);

               


                //if (data.Count>0)
                //{
                //    richTextBoxKalaInfo.Text = "نام کالا : " + data[0].Cnme;
                //    richTextBoxKalaInfo.Text += "\n قیمت : " + data[0].Camtsl;
                //}
                //else
                //{
                //    richTextBoxKalaInfo.Text = "موردی یافت نشد !";
                //}

                richTextBoxBarcode.Text = "";
              
            }
            catch(Exception ex)
            {
                string TempString = " هنگام اتصال به سرور خطا صورت گرفت " + "\r\n" + ex.Message;
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, TempString);
            }
        

        }

        private void richTextBoxBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                GetKalaInfoAsync();
            }
        }

        private void uiButtonSaveCustomer_Click(object sender, EventArgs e)
        {

            if(!Shared.CheckMobileNum(richTextBoxMobile.Text.Trim()))
            {
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "شماره موبایل نامعتبر میباشد !");
                richTextBoxMobile.Focus();
                richTextBoxMobile.SelectAll();
                return;
            }
            
            SendKalaInfoAsync();
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
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

        private async void SendKalaInfoAsync()
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


                PYR.Name = richTextBoxNameCustomer.Text;
                PYR.Family = richTextBoxFamilyCustomer.Text;
                PYR.Mobile = richTextBoxMobile.Text;

                PYR.BranchID = new Guid(Program.BranchID);
                PYR.ShopName = Program.Onme;
                TypyrViewModelObj.TPYR = PYR;
                TypyrViewModelObj.DefaultScore= Shared.Val(IniFile.IniReadValue("PubSystemSet", "DefPoint",
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


        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                prompt frmprompt = new prompt();

                if (frmprompt.ShowDialog() == DialogResult.OK)
                    if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6) )
                    {
                        using (FormSetting frm = new FormSetting())
                        {
                           
                            frm.ShowDialog();
                        }

                    }
            }

            LoadSeting();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            prompt frmprompt = new prompt();

            if (frmprompt.ShowDialog() == DialogResult.OK)
                if (frmprompt.MyPass == "sephastam")
                {
                    Application.Exit();

                }
        }

        private void richTextBoxMobile_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void richTextBoxMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void uiTab1_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if(e.Page.Index==1)
            {
                richTextBoxMobile.Select();
            }
            else if(e.Page.Index == 2)
            {
                richTextBoxBarcode.Select();
            }
        }
    }
}
