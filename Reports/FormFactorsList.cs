using FastReport;
using FastReport.Utils;
using GeneralKiosk.Class;
using GeneralKiosk.Common;
using Janus.Windows.GridEX;
using MakeRasisToken;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SSP1126.PcPos.BaseClasses;
using SSP1126.PcPos.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GeneralKiosk
{
    public partial class FormFactorList : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        System.Media.SoundPlayer playerLotfanBimar = new System.Media.SoundPlayer(@"Sounds/LotfanBimar.wav");

        public DataTable DtParaClinics { get; private set; }
        public DataRow SelectedRow { get; internal set; }
        public int ParaID { get; private set; }
        public DataTable DtPatients { get; internal set; }
        public long GhabzNum { get; private set; }


        private PcPosFactory _PcPosFactory;
        private MediaType _mediaType;
        private AccountType _accountType;
        private ResponseLanguage _responseLanguage;
        private AsyncType _asyncType;
        private TransactionType _tracsactionType;
        private CustomOkMsgBox frmCustomOkMsgBox;
        private PosResult posResult;
        private Report report;

        public string ReferenceNo { get; private set; }
        public string TerminalID { get; private set; }
        public string TransactionSerial { get; private set; }
        public string PayStatusName { get; private set; }
        public string CardNum { get; private set; }
        public string CardNumHash { get; private set; }
        public string PosIP { get; private set; }
        public string ComPortNum { get; private set; }
        public string ResponseCode { get; private set; }
        public string TransactionDate { get; private set; }
        public string IssueTracking { get; private set; }
        public string PayDate { get; private set; }
        public string PayTime { get; private set; }
        public bool IsPayed { get; private set; }
        public long Amnt { get; private set; }
        public string ReceiptCode { get; private set; }
        public int RowIndex { get; private set; }

        public FormFactorList()
        {
            InitializeComponent();
        }

        void childFormClosed(object sender, EventArgs e)
        {
            ((Form)sender).Closed -= childFormClosed;


        }

        private void Form23_Load(object sender, EventArgs e)
        {
            LoadPosSetting();

            if (_PcPosFactory == null)
                if (_PcPosFactory == null)
                    _PcPosFactory = new PcPosFactory();

            _PcPosFactory.CardSwiped += _PosClient_CardSwiped;
            _PcPosFactory.PosResultReceived += _PosClient_PosResultReceived;
            SetDoubleBuffered(TableLayoutPanelMain);
            userDateTarikhAz.Text = Shared.M2S(DateTime.Now.AddDays(-Program.ShowPatiaentListDay));
            userDateTarikhTa.Text = Shared.M2S(DateTime.Now);
            textBoxName.Text = Program.Onme;
            LoadFactors();

        }

        private void LoadFactors()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(Program.ConString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {


                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 300;
                            cmd.Connection = con;

                            con.Open();
                            cmd.CommandText = @"[OP].[SFactors]";

                            cmd.Parameters.AddWithValue("@DteAz", userDateTarikhAz.Text);
                            cmd.Parameters.AddWithValue("@DteTa", userDateTarikhTa.Text);
                            cmd.Parameters.AddWithValue("@Tpe", uiRadioButtonSuccess.Checked ? 1 : (uiRadioButtonFail.Checked ? -1 : 0));

                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }
                    }
                }

                #region Grid Configuration and Set Data

                gridEXFactors.DataSource = null;
                gridEXFactors.DataSource = dt;
                #endregion
            }

            catch (Exception ex)
            {
                Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
         " - " + this.Name);
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, ex.Message.ToString());
            }
        }

        private void UpdateFactorSt(bool IsPrint = false, bool IsPay = false, bool IsSendApi = false, long GhabzNum = 0)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(Program.ConString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 300;
                        cmd.Connection = con;

                        con.Open();
                        cmd.CommandText = @"[OP].[UFactorSt]";

                        cmd.Parameters.AddWithValue("@IsPrint", IsPrint);
                        cmd.Parameters.AddWithValue("@IsPay", IsPay);
                        cmd.Parameters.AddWithValue("@IsSendApi", IsSendApi);
                        cmd.Parameters.AddWithValue("@GhabzNum", GhabzNum);
                        cmd.Parameters.AddWithValue("@FactorID", Shared.ValInt64(SelectedRow["ID"]));
                        cmd.Parameters.AddWithValue("@ReceptionCode", Shared.ValInt64(SelectedRow["ReceptionCode"]));
                        cmd.ExecuteNonQuery();

                    }
                }
            }

            catch (Exception ex)
            {
                Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
      " - " + this.Name);
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, ex.Message.ToString());
            }
        }


        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }


        private void pictureBoxCancelFactor_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridEXFactors_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {

            if (gridEXFactors.RecordCount <= 0)
                return;

            if (e.Row.Cells.Count <= 0) return;

            if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
            {

                if (e.Row.Cells["IsPayed"].Value != null)
                {
                    if (Shared.ObjectToBool(e.Row.Cells["IsPayed"].Value))
                    {
                        Janus.Windows.GridEX.GridEXFormatStyle fs = new Janus.Windows.GridEX.GridEXFormatStyle
                        {
                            BackColor = Color.Green
                        };
                        e.Row.Cells["Pay"].FormatStyle = fs;
                        e.Row.Cells["IsPayed"].FormatStyle = fs;
                    }
                    else
                    {

                        Janus.Windows.GridEX.GridEXFormatStyle fs = new Janus.Windows.GridEX.GridEXFormatStyle
                        {
                            BackColor = Color.Red
                        };
                        e.Row.Cells["Pay"].FormatStyle = fs;
                        e.Row.Cells["IsPayed"].FormatStyle = fs;
                    }
                }
                if (e.Row.Cells["IsSendToApi"].Value != null)
                {
                    if (Shared.ObjectToBool(e.Row.Cells["IsSendToApi"].Value))
                    {
                        Janus.Windows.GridEX.GridEXFormatStyle fs = new Janus.Windows.GridEX.GridEXFormatStyle
                        {
                            BackColor = Color.Green
                        };
                        e.Row.Cells["SendApi"].FormatStyle = fs;
                        e.Row.Cells["IsSendToApi"].FormatStyle = fs;
                    }
                    else
                    {

                        Janus.Windows.GridEX.GridEXFormatStyle fs = new Janus.Windows.GridEX.GridEXFormatStyle
                        {
                            BackColor = Color.Red
                        };
                        e.Row.Cells["SendApi"].FormatStyle = fs;
                        e.Row.Cells["IsSendToApi"].FormatStyle = fs;
                    }
                }

                if (e.Row.Cells["IsPrint"].Value != null)
                {
                    if (Shared.ObjectToBool(e.Row.Cells["IsPrint"].Value))
                    {
                        Janus.Windows.GridEX.GridEXFormatStyle fs = new Janus.Windows.GridEX.GridEXFormatStyle
                        {
                            BackColor = Color.Green
                        };
                        e.Row.Cells["Print"].FormatStyle = fs;
                        e.Row.Cells["IsPrint"].FormatStyle = fs;
                    }
                    else
                    {

                        Janus.Windows.GridEX.GridEXFormatStyle fs = new Janus.Windows.GridEX.GridEXFormatStyle
                        {
                            BackColor = Color.Red
                        };
                        e.Row.Cells["Print"].FormatStyle = fs;
                        e.Row.Cells["IsPrint"].FormatStyle = fs;
                    }
                }


            }
        }

        //public static DataTable ToDataTable(DataRow items)
        //{
        //    DataTable tb = new DataTable();

        //    foreach (DataColumn prop in items.Table.Columns)
        //    {
        //        tb.Columns.Add(prop.ColumnName, prop.DataType);
        //    }


        //    var values = new object[items.Table.Columns.Count];
        //    for (var i = 0; i < items.Table.Columns.Count; i++)
        //    {
        //        values[i] = items[i];
        //    }

        //    tb.Rows.Add(values);


        //    return tb;
        //}
        public DataTable ToDataTable(DataRow selectedRow)
        {
            DataTable dataTable = new DataTable();

            // اضافه کردن ستون‌ها به DataTable
            foreach (DataColumn column in selectedRow.Table.Columns)
            {
                dataTable.Columns.Add(column.ColumnName, column.DataType);
            }

            // اضافه کردن ردیف انتخاب شده به DataTable
            DataRow newRow = dataTable.NewRow();
            foreach (DataColumn column in selectedRow.Table.Columns)
            {
                newRow[column.ColumnName] = selectedRow[column];
            }
            dataTable.Rows.Add(newRow);

            return dataTable;
        }


        private bool PrintResidOnPaper()
        {
            if (Shared.ObjectToBool(SelectedRow["IsOther"]))
            {
                try
                {
                    Program.InsertLogToFile("Start PrintResidOnPaper : OtherID : " + Shared.ObjectToText(SelectedRow["OtherID"])
+ "PrintResidOnPaper" +
" - " + this.Name);


                    var dt = ToDataTable(SelectedRow);



                    dt.Columns.Add("Adres");
                    dt.Columns.Add("ShowReceptionDateTime", typeof(bool));
                    dt.Columns.Add("ShowGhabzNum", typeof(bool));
                    dt.Columns.Add("ShowReceptionCode", typeof(bool));
                    dt.Columns.Add("ShowDocumentCode", typeof(bool));
                    dt.Columns.Add("ShowPatientName", typeof(bool));
                    dt.Columns.Add("ShowDoctorName", typeof(bool));
                    dt.Columns.Add("ShowNationalNumber", typeof(bool));
                    dt.Columns.Add("ShowPatientRate", typeof(bool));
                    dt.Columns.Add("ShowInsuranceName", typeof(bool));
                    dt.Columns.Add("ShowInsuranceRate", typeof(bool));
                    dt.Columns.Add("ShowSupplementaryName", typeof(bool));
                    dt.Columns.Add("ShowSupplementaryRate", typeof(bool));
                    dt.Columns.Add("ShowServiceDescription", typeof(bool));
                    dt.Columns.Add("ShowRno", typeof(bool));
                    dt.Columns.Add("ShowParaClinicName", typeof(bool));
                    dt.Columns.Add("ShowSalamatTrackingCode", typeof(bool));



                    DataRow row = dt.Rows[0];

                    // مقادیر جدید را به ردیف اضافه کنید (یا به عبارتی آپدیت کنید)
                    row["Adres"] = Program.Adres;
                    row["ShowReceptionDateTime"] = Program.ShowReceptionDateTime;
                    row["ShowGhabzNum"] = Program.ShowGhabzNum;
                    row["ShowReceptionCode"] = Program.ShowReceptionCode;
                    row["ShowDocumentCode"] = Program.ShowDocumentCode;
                    row["ShowPatientName"] = Program.ShowPatientName;  // به عنوان مثال یک فلگ غیر فعال
                    row["ShowDoctorName"] = Program.ShowDoctorName;
                    row["ShowNationalNumber"] = Program.ShowNationalNumber;
                    row["ShowPatientRate"] = Program.ShowPatientRate;
                    row["ShowInsuranceName"] = Program.ShowInsuranceName;
                    row["ShowInsuranceRate"] = Program.ShowInsuranceRate;
                    row["ShowSupplementaryName"] = Program.ShowSupplementaryName;
                    row["ShowSupplementaryRate"] = Program.ShowSupplementaryRate;
                    row["ShowServiceDescription"] = Program.ShowServiceDescription;
                    row["ShowRno"] = Program.ShowRno;
                    row["ShowParaClinicName"] = Program.ShowParaClinicName;
                    row["ShowSalamatTrackingCode"] = Program.ShowSalamatTrackingCode;



                    Report report = new Report();

                    if (Program.PrintOtherMoshtari)
                    {

                        report.Load($@"Reports\OtherPrint\OtherPrintCust.frx");

                        try
                        {
                            PictureObject pic = report.FindObject("MyPicture") as PictureObject;
                            ////Set the image
                            pic.Image = new Bitmap(Program.PrintImagePath);
                        }
                        catch
                        {

                        }

                        report.RegisterData(dt, "OP_Factors");
                        report.PrintSettings.ShowDialog = false;
                        report.Prepare();
                        report.Print();
                    }

                    if (Program.PrintOtherMaj)
                    {

                        report = new Report();

                        report.Load($@"Reports\OtherPrint\OtherPrintMaj.frx");

                        try
                        {
                            PictureObject pic = report.FindObject("MyPicture") as PictureObject;
                            ////Set the image
                            pic.Image = new Bitmap(Program.PrintImagePath);
                        }
                        catch
                        {

                        }

                        report.RegisterData(dt, "OP_Factors");
                        report.PrintSettings.ShowDialog = false;
                        report.Prepare();
                        report.Print();


                    }

                    if (Program.PrintOtherNormal)
                    {
                        report = new Report();

                        report.Load($@"Reports\OtherPrint\OtherPrintNormal.frx");

                        try
                        {
                            PictureObject pic = report.FindObject("OtherPrintMaj") as PictureObject;
                            ////Set the image
                            pic.Image = new Bitmap(Program.PrintImagePath);
                        }
                        catch
                        {

                        }

                        report.RegisterData(dt, "OP_Factors");
                        report.PrintSettings.ShowDialog = false;
                        report.Prepare();
                        report.Print();



                        Program.InsertLogToFile($@"Finish PrintResidOnPaper OtherPrint : OtherID : " + Shared.ObjectToText(SelectedRow["OtherID"]) +
                          " - " + this.Name);
                        return true;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Program.InsertLogToFile("Error : PrintResidOnPaper : " + ex.Message +
      " - " + this.Name);
                    return false;
                }

            }
            else
            {
                try
                {
                    if (Program.PrintList.Where(x => x.PrintChecked == true).Count() == 0)
                    {
                        Program.InsertLogToFile("PrintList Count Is Zero In FactorList");
                        frmCustomOkMsgBox = new CustomOkMsgBox("هیچ ریپورتی انتخاب نشده است !"
    , global::GeneralKiosk.Properties.Resources.WarningPic, false, 15);
                        frmCustomOkMsgBox.ShowDialog();
                        return false;
                    }
                    foreach (var item in Program.PrintList)
                    {
                        if (item.PrintChecked)
                        {
                            Report report = new Report();

                            report.Load($@"Reports\{item.PrintCap}");
                            //report.Load($@"Reports\FishPrint1.frx");
                            try
                            {
                                PictureObject pic = report.FindObject("MyPicture") as PictureObject;
                                ////Set the image
                                pic.Image = new Bitmap(Program.PrintImagePath);
                            }
                            catch
                            {

                            }

                            var dt = ToDataTable(SelectedRow);
                            try

                            {

                                dt.Columns.Add("Adres");
                                dt.Columns.Add("ShowReceptionDateTime", typeof(bool));
                                dt.Columns.Add("ShowGhabzNum", typeof(bool));
                                dt.Columns.Add("ShowReceptionCode", typeof(bool));
                                dt.Columns.Add("ShowDocumentCode", typeof(bool));
                                dt.Columns.Add("ShowPatientName", typeof(bool));
                                dt.Columns.Add("ShowDoctorName", typeof(bool));
                                dt.Columns.Add("ShowNationalNumber", typeof(bool));
                                dt.Columns.Add("ShowPatientRate", typeof(bool));
                                dt.Columns.Add("ShowInsuranceName", typeof(bool));
                                dt.Columns.Add("ShowInsuranceRate", typeof(bool));
                                dt.Columns.Add("ShowSupplementaryName", typeof(bool));
                                dt.Columns.Add("ShowSupplementaryRate", typeof(bool));
                                dt.Columns.Add("ShowServiceDescription", typeof(bool));
                                dt.Columns.Add("ShowRno", typeof(bool));
                                dt.Columns.Add("ShowParaClinicName", typeof(bool));
                                dt.Columns.Add("ShowSalamatTrackingCode", typeof(bool));



                                DataRow row = dt.Rows[0];

                                // مقادیر جدید را به ردیف اضافه کنید (یا به عبارتی آپدیت کنید)
                                row["Adres"] = Program.Adres;
                                row["ShowReceptionDateTime"] = Program.ShowReceptionDateTime;
                                row["ShowGhabzNum"] = Program.ShowGhabzNum;
                                row["ShowReceptionCode"] = Program.ShowReceptionCode;
                                row["ShowDocumentCode"] = Program.ShowDocumentCode;
                                row["ShowPatientName"] = Program.ShowPatientName;  // به عنوان مثال یک فلگ غیر فعال
                                row["ShowDoctorName"] = Program.ShowDoctorName;
                                row["ShowNationalNumber"] = Program.ShowNationalNumber;
                                row["ShowPatientRate"] = Program.ShowPatientRate;
                                row["ShowInsuranceName"] = Program.ShowInsuranceName;
                                row["ShowInsuranceRate"] = Program.ShowInsuranceRate;
                                row["ShowSupplementaryName"] = Program.ShowSupplementaryName;
                                row["ShowSupplementaryRate"] = Program.ShowSupplementaryRate;
                                row["ShowServiceDescription"] = Program.ShowServiceDescription;
                                row["ShowRno"] = Program.ShowRno;
                                row["ShowParaClinicName"] = Program.ShowParaClinicName;
                                row["ShowSalamatTrackingCode"] = Program.ShowSalamatTrackingCode;
                            }
                            catch
                            {

                            }


                            for (int i = 0; i < item.PrintNum; i++)
                            {
                                report.RegisterData(dt, "OP_Factors");
                                report.PrintSettings.ShowDialog = false;
                                report.Prepare();
                                report.Print();
                            }
                        }

                    }
                    return true;

                }

                catch (Exception ex)
                {
                    Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
          " - " + this.Name);
                    Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                    return false;
                }
            }


        }

        private async Task<bool> GetEstelamAsync()
        {
            Uri myUri;
            myUri = new Uri($@"{Program.WebServiceAddres}/CashLessFindCashByInquiryCode?InquiryCode={Shared.ObjectToText(SelectedRow["ReceptionCode"])}");
            string SentResult = String.Empty;

            await Program.InsertLogToFile($@"CashLessFindCashByInquiryCode : {myUri.AbsoluteUri}");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);

            var response = await (Task<WebResponse>)request.GetResponseAsync();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());


            String resultmsg = responseReader.ReadToEnd();

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(resultmsg);


            var XmlNode = JsonConvert.SerializeXmlNode(doc);
            dynamic data = JObject.Parse(XmlNode.ToString());
            responseReader.Close();
            DtPatients = new DataTable();
            XmlElement root = doc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName("PaymentType");
            XmlNodeList elemListDte = root.GetElementsByTagName("CashDate");
            XmlNodeList elemListTme = root.GetElementsByTagName("CashTime");

            try
            {

                DataTable dataTableTPYNT = (DataTable)GridEXTPYNT.DataSource;
                int currentRowTPYNTIndex = GridEXTPYNT.CurrentRow.RowIndex;
                DataRow SelectedRowTPYNT = dataTableTPYNT.Rows[0];
                int i = 0;
                for (i= 0 ; i < elemList.Count;i++ )
                {

                    int result = String.Compare((elemListDte[i].InnerText
                        + elemListTme[i].InnerText), Shared.ObjectToText(SelectedRowTPYNT["تاریخ پرداخت"])
                        + Shared.ObjectToText(SelectedRowTPYNT["ساعت پرداخت"]).Substring(0, 5), StringComparison.Ordinal);

                   
                    if (elemList[i].InnerText == "1" && result>=1)
                    {
                        return true;
                    }
                }
               
            }
            catch
            {

            }

            return false;
        }

        private async Task<bool> SendResualtToApi()
        {

            this.Enabled = false;
            try
            {



                if (await GetEstelamAsync() == true)
                {
                    this.Enabled = true;
                    return true;
                }

                Uri myUri;

                var parts = new List<string>();

                if (Program.SendIssueAfterPay)
                    parts.Add(Shared.ObjectToText(SelectedRow["Rno"]));

                if (Program.SendRefNumAfterPay)
                    parts.Add(Shared.ObjectToText(SelectedRow["Itrng"]));

                if (Program.SendTerminalAfterPay)
                    parts.Add(Shared.ObjectToText(SelectedRow["Strml"]));


                string InquiryCode = string.Join("/",
      parts.Where(x => !string.IsNullOrWhiteSpace(x)));

                if (Shared.ObjectToBool(SelectedRow["IsOther"]))
                {
                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessOtherAddPayment?OtherID={Shared.ObjectToText(SelectedRow["OtherID"])}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? Shared.ObjectToText(SelectedRow["Pwcrnm"]).Replace("-##-", "-").Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(SelectedRow["EndRate"]))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");
                }
                else
                {
                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessPatientManagementAddPayment?ReceptionCode={Shared.ObjectToText(SelectedRow["ReceptionCode"])}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? Shared.ObjectToText(SelectedRow["Pwcrnm"]).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(SelectedRow["EndRate"]))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");

                }


                if (Shared.ObjectToText(SelectedRow["ParaClinicName"]) == "ودیعه")
                {

                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessAdvanceAddPayment?ReceptionCode={Shared.ObjectToText(SelectedRow["ReceptionCode"])}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? Shared.ObjectToText(SelectedRow["Pwcrnm"]).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(SelectedRow["EndRate"]))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");

                }
                else if (Shared.ObjectToText(SelectedRow["ParaClinicName"]) == "ترخیص")
                {

                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessReleaseAddPayment?ReceptionCode={Shared.ObjectToText(SelectedRow["ReceptionCode"])}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? Shared.ObjectToText(SelectedRow["Pwcrnm"]).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(SelectedRow["EndRate"]))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");
                }
                else if (Shared.ObjectToText(SelectedRow["ParaClinicName"]) == "اقدامات")
                {
                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessRemedialActivityAddPayment?ReceptionCode={Shared.ObjectToText(SelectedRow["ReceptionCode"])}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? Shared.ObjectToText(SelectedRow["Pwcrnm"]).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(SelectedRow["EndRate"]))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");
                }

                else if (Shared.ObjectToText(SelectedRow["ParaClinicName"]) == "داروخانه")
                {
                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessDrugInventoryAddPayment?ReceptionCode={Shared.ObjectToText(SelectedRow["ReceptionCode"])}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? Shared.ObjectToText(SelectedRow["Pwcrnm"]).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(SelectedRow["EndRate"]))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");
                }


                if (Program.SenTest)
                {
                    myUri = myUri = new Uri($@"{Program.WebServiceAddres}/CashLessPatientManagementAddPayment?ReceptionCode=3074976&InquiryCode=454958489&CardNumber={(Program.SendCardNum ? Shared.ObjectToText(SelectedRow["Pwcrnm"]).Replace("-##-", "-") : "")}&PaymentRate=10000{(Program.UserCode == "" ? "" : $@"&UserCode=0000102")}");
                }


                await Program.InsertLogToFile($@"Start SendResualtToApi {myUri.AbsoluteUri} : {(Shared.ObjectToBool(SelectedRow["IsOther"]) ? "OtherID : " : "ReceptionCode :")} " + (Shared.ObjectToBool(SelectedRow["IsOther"]) ? Shared.ObjectToText(SelectedRow["OtherID"]) : Shared.ObjectToText(SelectedRow["ReceptionCode"]))
+ Shared.GetCurrentMethod() +
" - " + this.Name);

                string SentResult = String.Empty;


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);
                request.Timeout = 20000;
                var response = await (Task<WebResponse>)request.GetResponseAsync();
                StreamReader responseReader = new StreamReader(response.GetResponseStream());


                String resultmsg = responseReader.ReadToEnd();

                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(resultmsg);


                var XmlNode = JsonConvert.SerializeXmlNode(doc);
                dynamic data = JObject.Parse(XmlNode.ToString());
                responseReader.Close();
                XmlElement root = doc.DocumentElement;

                await Program.InsertLogToFile($@"{resultmsg}  >> " + myUri.AbsoluteUri);

                if (Shared.ValInt64(root.InnerText) == 0)
                {
                    this.Enabled = true;
                    return false;
                }
                GhabzNum = Shared.ValInt64(root.InnerText);
                this.Enabled = true;
                return true;
            }
            catch (Exception ex)
            {
                await Program.InsertLogToFile("Error : " + ex.Message + " - " + Shared.GetCurrentMethod() +
                       " - " + this.Name);
                this.Enabled = true;
                return false;

            }
        }
        private void LoadPosSetting()
        {
            DataTable dt = new DataTable();
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
                        $@"SELECT  Ct,  Cpnm,AccSt,IP,  
                        Lng,
                        Sync, Terminal 
                        FROM    BS.TPOS 
                        WHERE  (ID= {Program.ProcessorId} ) ";

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                    }
                }

                #region SetData

                if (dt.Rows.Count <= 0)
                {

                    Shared.ShowMessage(EnumSendMessage.TryCatchMessage, "تنظیمات دستگاه کارتخوان وارد نشده است !");
                    this.Close();
                }



                if (Shared.ObjectToText(dt.Rows[0]["Lng"]) == "Persian")
                    _responseLanguage = ResponseLanguage.Persian;

                else
                    _responseLanguage = ResponseLanguage.English;

                if (Shared.ObjectToText(dt.Rows[0]["AccSt"]) == "چند حسابی")
                    _accountType = AccountType.Share;
                else if (Shared.ObjectToText(dt.Rows[0]["AccSt"]) == "چند شبایی")
                    _accountType = AccountType.ShareByIban;

                else if (Shared.ObjectToText(dt.Rows[0]["AccSt"]) == "تک حسابی")
                    _accountType = AccountType.Single;

                if (Shared.ObjectToText(dt.Rows[0]["Ct"]) == "COM")
                    _mediaType = MediaType.Com;
                else
                    _mediaType = MediaType.Network;

                if (Shared.ObjectToText(dt.Rows[0]["Sync"]) == "Async")
                    _asyncType = AsyncType.Async;
                else
                    _asyncType = AsyncType.Sync;
                TerminalID = Shared.ObjectToText(dt.Rows[0]["Terminal"]);

                PosIP = Shared.ObjectToText(dt.Rows[0]["IP"]);
                ComPortNum = Shared.ObjectToText(dt.Rows[0]["Cpnm"]);

                #endregion
            }
            catch (Exception ex)
            {
                Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
      " - " + this.Name);
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);

            }
        }

        private void _PosClient_CardSwiped(PosResult posResult)
        {
            _tracsactionType = _PcPosFactory.GetTransactionType();

            if (_tracsactionType == TransactionType.Purchase)
            {
                #region Purchase

                PurchaseCardSwiped(posResult);

                #endregion
            }
            else if (_tracsactionType == TransactionType.PaymentService)
            {
                #region PaymentService

                //PaymentServiceCardSwiped(posResult);

                #endregion
            }
            else
            {
                string maskedPan = posResult.CardNumberMask;
                //if (TxtCardNumberMask.InvokeRequired)
                //    this.Invoke(new MethodInvoker(() =>
                //    {
                //        TxtCardNumberMask.Text = maskedPan;
                //        TxtCardNumberMask.Tag = posResult.CardNumberHash;
                //        TerminalID = posResult.TerminalId;
                //        TextBoxResponseMsg.Text =
                //            string.Format("Card swiped with \"{0}\" card number : ", posResult.CardNumberMask);
                //    }));
                //else
                //{
                //TxtCardNumberMask.Text = maskedPan;
                //TxtCardNumberMask.Text = posResult.CardNumberHash;
                //TerminalID = posResult.TerminalId;
                //TextBoxResponseMsg.Text =
                //    string.Format("Card swiped with \"{0}\" card number : ", posResult.CardNumberMask);
                //}
            }
        }

        private void PurchaseCardSwiped(PosResult posResult)
        {
            if (posResult == null)
                return;
            //if (TxtPANPurchase.InvokeRequired)
            //    this.Invoke(new MethodInvoker(() =>
            //    {
            //        //TxtPANPurchase.Text = "######-**-####";
            //        //TxtPANPurchase.Text = posResult.CardNumberMask;
            //        //TxtPANPurchase.Tag = posResult.CardNumberHash;
            //        //TxtTerminalID1Purchase.Text = posResult.TerminalId;
            //        textBoxResponseCode.Text = posResult.ResponseCode;
            //        textBoxResponseMsg.Text = posResult.ResponseDescription;
            //        AffeAmount = Shared.ValInt64(string.Format("Card swiped with \"{0}\" card number : ", posResult.CardNumberMask));


            //        int y = 17;
            //        if (posResult.PurchaseTypesDictionary != null)
            //        {
            //            foreach (var item in posResult.PurchaseTypesDictionary)
            //            {
            //                var radio = new RadioButton();
            //                radio.Text = item.Value;
            //                radio.Tag = item.Key;
            //                //radio.Location = new Point(5, y);
            //                //radio.CheckedChanged += Radio_CheckedChanged;
            //                y = y + 20;
            //                //GrpPurchaseTypes.Controls.Add(radio);
            //            }
            //        }
            //        //UiButtonPayTwoMarhaleh.Enabled = true;
            //    }));
            //else
            //{
            //TxtPANPurchase.Text = "######-**-####";
            //TxtPANPurchase.Text = posResult.CardNumberMask;
            //TxtPANPurchase.Tag = posResult.CardNumberHash;
            TerminalID = posResult.TerminalId;
            //PayInfo.Text = "پاسخ دریافتی : " + posResult.ResponseCode + " // " + posResult.ResponseDescription;

            //AffeAmount =
            Shared.Val(string.Format("Card swiped with \"{0}\" card number : ", posResult.CardNumberMask));

            int y = 17;
            if (posResult.PurchaseTypesDictionary != null)
            {
                foreach (var item in posResult.PurchaseTypesDictionary)
                {
                    var radio = new RadioButton();
                    radio.Text = item.Value;
                    radio.Tag = item.Key;
                    //radio.Location = new Point(5, y);
                    //radio.CheckedChanged += Radio_CheckedChanged;
                    y = y + 20;
                    //GrpPurchaseTypes.Controls.Add(radio);
                }
            }
            //UiButtonPayTwoMarhaleh.Enabled = true;
        }

        private void _PosClient_PosResultReceived(PosResult posResult)
        {
            _tracsactionType = _PcPosFactory.GetTransactionType();
            if (_tracsactionType == TransactionType.Purchase || _tracsactionType == TransactionType.PaymentService)
            {
                PurchaseResultReceived(posResult);
            }
            else if (_tracsactionType == TransactionType.Balance)
            {
                //BalanceResultReceived(posResult);
            }
        }


        private void InsertPayment()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(Program.ConString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = @"[PY].[IPYTP]";

                        cmd.Parameters.AddWithValue("@p1", Shared.ValInt64(SelectedRow["ReceptionCode"]));
                        cmd.Parameters.AddWithValue("@p2", 0);
                        cmd.Parameters.AddWithValue("@p3", (object)PayDate ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p4", (object)PayTime ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p5", 0);
                        cmd.Parameters.AddWithValue("@p6", Shared.ValInt64(SelectedRow["endRate"]));
                        cmd.Parameters.AddWithValue("@p7", "");
                        cmd.Parameters.AddWithValue("@p8", (object)TransactionSerial ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p9", (object)ReferenceNo ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p10", (object)IssueTracking ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p11", 0);
                        cmd.Parameters.AddWithValue("@p12", Shared.ValInt64(SelectedRow["endRate"]));
                        cmd.Parameters.AddWithValue("@p13", "");
                        cmd.Parameters.AddWithValue("@p14", (object)PayStatusName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p15", (object)ResponseCode ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p16", "");
                        cmd.Parameters.AddWithValue("@p17", (object)Program.VahedPool ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p18", DBNull.Value);
                        cmd.Parameters.AddWithValue("@p19", DBNull.Value);
                        cmd.Parameters.AddWithValue("@p20", DBNull.Value);
                        cmd.Parameters.AddWithValue("@p21", (object)TerminalID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p22", DBNull.Value);
                        cmd.Parameters.AddWithValue("@p23", DBNull.Value);
                        cmd.Parameters.AddWithValue("@p24", UserInfo.UserId == 666 ? 0 : UserInfo.UserId);
                        cmd.Parameters.AddWithValue("@p25", 0);
                        cmd.Parameters.AddWithValue("@p26", 0);
                        cmd.Parameters.AddWithValue("@p27", Shared.ValInt64(SelectedRow["ID"]));

                        cmd.ExecuteNonQuery();
                        con.Close();


                    }
                }
            }
            catch (Exception ex)
            {
                Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
      " - " + this.Name);
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
            }
        }

        private void PurchaseResultReceived(PosResult posResult)
        {

            ////ClearGroupBox(grpSrvPay);
            if (posResult == null)
                return;

            ResponseCode = Shared.Val(posResult.ResponseCode).ToString();

            TransactionDate = posResult.TxnDate;

            IssueTracking = posResult.TraceNumber;

            if (TransactionDate == null)
            {
                PayDate = Shared.M2S(DateTime.Now.Date);
                PayTime = DateTime.Now.ToString("HH:mm:ss");

            }
            else
            {
                PayDate = TransactionDate.Substring(0, 10).Trim();
                PayTime = TransactionDate.Substring(12).Trim();

            }
            ReferenceNo = posResult.RRN;

            TerminalID = posResult.TerminalId;

            TransactionSerial = posResult.SerialId;
            PayStatusName = posResult.ResponseDescription;
            CardNum = posResult.CardNumberMask;


            Program.InsertLog("SendToPos",
                       this.Name.Trim(),
                       "Barcodes : " + ReceiptCode +
                       " ResponseCode : " + ResponseCode +
                       " PayDate : " + PayDate +
                       " PayTime : " + PayTime +
                       " ReferenceNo : " + ReferenceNo +
                       " TerminalID : " + TerminalID +
                       " TransactionSerial : " + TransactionSerial);


            //Successful result
            if (Shared.Val(posResult.ResponseCode).ToString() == "0")
            {


                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(async () =>
                    {
                        IsPayed = true;
                        frmCustomOkMsgBox = new CustomOkMsgBox("تراکنش موفق " + "\n" + PayStatusName
              , global::GeneralKiosk.Properties.Resources.SuccessFulMsg, false, 30);
                        frmCustomOkMsgBox.ShowDialog();

                        UpdateFactorSt(false, true);
                        InsertPayment();
                        SetReadyFormForPay(false);

                        try
                        {
                            gridEXFactors.MoveToRowIndex(RowIndex);
                            LoadTpynt();
                        }
                        catch
                        {

                        }

                    }));
                else
                {
                    IsPayed = true;
                    frmCustomOkMsgBox = new CustomOkMsgBox("تراکنش موفق " + "\n" + PayStatusName
, global::GeneralKiosk.Properties.Resources.SuccessFulMsg, false, 30);
                    frmCustomOkMsgBox.ShowDialog();
                    UpdateFactorSt(false, true);
                    InsertPayment();
                    SetReadyFormForPay(false);
                    try
                    {
                        gridEXFactors.MoveToRowIndex(RowIndex);
                        LoadTpynt();
                    }
                    catch
                    {

                    }
                }

            }
            else
            {
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(() =>
                    {
                        IsPayed = false;
                        frmCustomOkMsgBox = new CustomOkMsgBox("تراکنش ناموفق " + "\n" + PayStatusName
              , global::GeneralKiosk.Properties.Resources.WarningPic, false, 30);
                        frmCustomOkMsgBox.ShowDialog();

                        InsertPayment();
                        SetReadyFormForPay(false);
                        try
                        {
                            gridEXFactors.MoveToRowIndex(RowIndex);
                            LoadTpynt();
                        }
                        catch
                        {

                        }

                    }));
                else
                {
                    IsPayed = false;
                    frmCustomOkMsgBox = new CustomOkMsgBox("تراکنش ناموفق " + "\n" + PayStatusName
, global::GeneralKiosk.Properties.Resources.WarningPic, false, 30);
                    frmCustomOkMsgBox.ShowDialog();
                    InsertPayment();
                    SetReadyFormForPay(false);
                    try
                    {
                        gridEXFactors.MoveToRowIndex(RowIndex);
                        LoadTpynt();
                    }
                    catch
                    {

                    }
                }
            }

        }

        private void SendToPos()
        {

            if (PurchaseInitialization())
            {
                return;
            }


            posResult = new PosResult();

            try
            {
                posResult = _PcPosFactory.PcStarterPurchase((Program.VahedPool == "ریال" ? Amnt : Amnt * 10).ToString(), string.Empty, "", "", TerminalID, null, null, 0);

            }
            catch
            {

            }

            SetReadyFormForPay(true);

            using (FormWaiting Waiting = new FormWaiting())
            {
                Waiting.ShowDialog();
            }

            if (_asyncType == AsyncType.Sync && posResult != null)

                PurchaseResultReceived(posResult);

        }

        private void SetReadyFormForPay(bool IsPaying)
        {
            gridEXFactors.Visible = !IsPaying;
            GridEXTPYNT.Visible = !IsPaying;
            panelFilters.Visible = !IsPaying;
            pictureBoxCancelFactor.Visible = !IsPaying;

            if (IsPaying)
            {
                panelMain.BackgroundImage = GeneralKiosk.Properties.Resources._3_message;
            }
            else
            {
                panelMain.BackgroundImage = null;
            }

            using (FormWaiting Waiting = new FormWaiting())
            {
                Waiting.ShowDialog();
            }

        }


        private bool PurchaseInitialization()
        {
            _tracsactionType = TransactionType.Purchase;


            if (TransactionMediaInitialization()) return false;

            //  if(_mediaType == MediaType.Com)
            //    _PcPosFactory.Initialization(_responseLanguage, 0, _asyncType);//changed by p.jamali for enhancing time(from 0 to 3)
            // else


            _PcPosFactory.Initialization(_responseLanguage, 10, _asyncType);//changed by p.jamali for enhancing time(from 0 to 3)
            return false;

        }

        private bool TransactionMediaInitialization()
        {
            if (_mediaType == MediaType.Com)
            {
                SerialPort selectedPort = null;

                if (SerialPort.GetPortNames().Any(p => p == ComPortNum))
                    selectedPort = new SerialPort((string)ComPortNum);
                if (selectedPort == null)
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("هیچ پورتی انتخاب نشده است !", global::GeneralKiosk.Properties.Resources.WarningPic);
                    frmCustomOkMsgBox.ShowDialog();
                    return true;
                }
                _PcPosFactory.SetCom(selectedPort.PortName);
            }
            if (_mediaType == MediaType.Network)
            {
                if (string.IsNullOrEmpty(PosIP))
                {
                    frmCustomOkMsgBox = new CustomOkMsgBox("هیچ ای پی تعریف نشده است !", global::GeneralKiosk.Properties.Resources.WarningPic);
                    frmCustomOkMsgBox.ShowDialog();
                    return true;
                }
                _PcPosFactory.SetLan(PosIP);
            }

            _PcPosFactory.Initialization(_responseLanguage, 0, _asyncType);
            return false;
        }


        private async void gridEXFactors_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {

                if (gridEXFactors.RecordCount <= 0)
                    return;

                try
                {
                    RowIndex = gridEXFactors.CurrentRow.RowIndex;
                }
                catch
                {

                }
                DataTable dataTable = (DataTable)gridEXFactors.DataSource;
                int currentRowIndex = gridEXFactors.CurrentRow.RowIndex;
                SelectedRow = dataTable.Rows[currentRowIndex];

                if (e.Column.Key == "Print")
                {

                    if (!Shared.ObjectToBool(SelectedRow["IsPayed"]))
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("این مورد پرداخت نشده است ! " + "\n" + "امکان پرینت وجود ندارد"
, global::GeneralKiosk.Properties.Resources.WarningPic, false, 30);
                        frmCustomOkMsgBox.ShowDialog();
                        return;
                    }
                    if (!Shared.ObjectToBool(SelectedRow["IsSendToApi"]))
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("این مورد ارسال نشده است ! " + "\n" + "امکان پرینت وجود ندارد"
, global::GeneralKiosk.Properties.Resources.WarningPic, false, 30);
                        frmCustomOkMsgBox.ShowDialog();
                        return;
                    }
                    //طبق درخواست برداشته شد
//                    if (Shared.ObjectToBool(SelectedRow["IsPrint"]))
//                    {
//                        frmCustomOkMsgBox = new CustomOkMsgBox("از این مورد قبلا پرینت گرفته شده است ! " + "\n" + "امکان پرینت مجدد وجود ندارد"
//, global::GeneralKiosk.Properties.Resources.WarningPic, false, 30);
//                        frmCustomOkMsgBox.ShowDialog();
//                        return;
//                    }
                    if (PrintResidOnPaper())
                    {
                        Program.InsertLogToFile("SuccessFulPrint : ReceptionCode : " + Shared.ObjectToText(SelectedRow["ReceptionCode"])
+ Shared.GetCurrentMethod() +
" - " + this.Name);
                        UpdateFactorSt(true);
                    }

                }
                else if (e.Column.Key == "SendApi")
                {
                    if (!Shared.ObjectToBool(SelectedRow["IsPayed"]))
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("این مورد پرداخت نشده است ! " + "\n" + "امکان ارسال وجود ندارد"
, global::GeneralKiosk.Properties.Resources.WarningPic, false, 20);
                        frmCustomOkMsgBox.ShowDialog();
                        return;
                    }
                    if (Shared.ObjectToBool(SelectedRow["IsSendToApi"]))
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("این مورد قبلا ارسال شده است ! " + "\n" + "امکان ارسال مجدد وجود ندارد"
, global::GeneralKiosk.Properties.Resources.WarningPic, false, 20);
                        frmCustomOkMsgBox.ShowDialog();
                        return;
                    }

                    if (await SendResualtToApi())
                    {
                        Program.InsertLogToFile($@"SuccessFulSendApi : {(Shared.ObjectToBool(SelectedRow["IsOther"]) ? "OtherID: " : "ReceptionCode: ")} " + (Shared.ObjectToBool(SelectedRow["IsOther"]) ? Shared.ObjectToText(SelectedRow["OtherID"]) : Shared.ObjectToText(SelectedRow["ReceptionCode"]))
+ " - " + "GhabzNum : " + GhabzNum + " - "
+ Shared.GetCurrentMethod() +
" - " + this.Name);
                        UpdateFactorSt(false, false, true, GhabzNum);
                    }

                }
                else if (e.Column.Key == "Pay")
                {
                    if (Shared.ObjectToBool(SelectedRow["IsPayed"]))
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("این مورد قبلا پرداخت شده است ! " + "\n" + "امکان پرداخت مجدد وجود ندارد"
, global::GeneralKiosk.Properties.Resources.WarningPic, false, 20);
                        frmCustomOkMsgBox.ShowDialog();
                        return;
                    }

                    Amnt = Shared.ValInt64(gridEXFactors.CurrentRow.Cells["EndRate"].Value);
                    ReceiptCode = Shared.ObjectToText(gridEXFactors.CurrentRow.Cells["ReceptionCode"].Value);
                    RowIndex = 0;

                    SendToPos();

                }
                LoadFactors();

                try
                {
                    gridEXFactors.MoveToRowIndex(RowIndex);
                }
                catch
                {

                }

            }
            catch (Exception exception)
            {
                Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
      " - " + this.Name);
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, exception.Message);
            }
        }

        private void LoadTpynt()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(Program.ConString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {


                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 300;
                            cmd.Connection = con;

                            con.Open();
                            cmd.CommandText = @"[OP].[STPYNT]";
                            cmd.Parameters.AddWithValue("@FactorID", Shared.ValInt64(gridEXFactors.GetValue("ID")));
                            cmd.Parameters.AddWithValue("@ReceptionCode", Shared.ValInt64(gridEXFactors.GetValue("ReceptionCode")));
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }
                    }
                }

                #region Grid Configuration and Set Data

                GridEXTPYNT.DataSource = null;
                GridEXTPYNT.DataSource = dt;
                GridEXTPYNT.RetrieveStructure();

                GridEXTPYNT.RootTable.TotalRow = InheritableBoolean.True;
                GridEXTPYNT.RootTable.TotalRowFormatStyle.BackColor = Color.LightGray;
                GridEXTPYNT.RootTable.TotalRowFormatStyle.ForeColor = Color.Blue;
                GridEXTPYNT.RootTable.TotalRowFormatStyle.FontBold = TriState.True;

                GridEXTPYNT.RootTable.Columns["مبلغ"].FormatString = "#,##";

                GridEXTPYNT.RootTable.Columns["مبلغ"].AggregateFunction = AggregateFunction.Sum;
                GridEXTPYNT.RootTable.Columns["مبلغ"].TotalFormatString = "#,###;(#,###);-";


                #endregion
            }

            catch (Exception ex)
            {
                Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
      " - " + this.Name);
                Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, ex.Message.ToString());
            }
        }

        private void gridEXFactors_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEXFactors.CurrentRow == null)
                return;


            if (gridEXFactors.SelectedItems.Count <= 0)
            {
                return;
            }

            if (gridEXFactors.CurrentRow.RowType != RowType.Record)
                return;

            LoadTpynt();

        }

        private void uiButtonLoadFactors_Click(object sender, EventArgs e)
        {
            LoadFactors();
        }

        private void FormFactorList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this._PcPosFactory.Dispose();

            }
            catch
            {

            }
        }
    }
}