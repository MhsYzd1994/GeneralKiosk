using FastReport;
using GeneralKiosk.Class;
using GeneralKiosk.Common;
using MakeRasisToken;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SSP1126.PcPos.BaseClasses;
using SSP1126.PcPos.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GeneralKiosk
{
    public partial class FormPayWithCard : Form
    {


        #region 1125
        public PcPosFactory _PcPosFactory;
        public PosResult PosResult { get; private set; }
        public SerialPort selectedPort;
        #endregion

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        System.Media.SoundPlayer playerLotfanKart = new System.Media.SoundPlayer(@"Sounds/LotfanKart.wav");
        System.Media.SoundPlayer playerLotfanResid = new System.Media.SoundPlayer(@"Sounds/LotfanResid.wav");
        System.Media.SoundPlayer playerAdamPrint = new System.Media.SoundPlayer(@"Sounds/AdamPrint.wav");
        System.Media.SoundPlayer playerAdamSabtDarSamaneh = new System.Media.SoundPlayer(@"Sounds/AdamSabtDarSamaneh.wav");

        private CustomOkMsgBox frmCustomOkMsgBox;

        public string ReferenceNo { get; private set; }
        public string TerminalID { get; private set; }
        public string TransactionSerial { get; private set; }
        public string PayStatusName { get; private set; }
        public string CardNum { get; private set; }
        public string ResponseCode { get; private set; }
        public string TransactionDate { get; private set; }
        public string IssueTracking { get; private set; }
        public string PayDate { get; private set; }
        public string PayTime { get; private set; }
        public string TodayDate { get; }
        public long Amnt { get; set; }
        public string ReceiptCode { get; set; }
        public long FactorID { get; private set; }
        public bool IsPayed { get; private set; } = false;
        public bool IsPrint { get; private set; } = false;
        public bool IsSendToApi { get; private set; } = false;
        public long GhabzNum { get; private set; } = 0;
        public bool IsVadie { get; internal set; }
        public bool IsTarkhis { get; internal set; }
        public bool IsEghdamat { get; set; }
        public bool IsDrug { get; internal set; }
        public string ReceptionCode { get; set; }
        public bool HasPrint { get; private set; }
        public bool IsOtherReq { get; internal set; }
        public int OtherReqID { get; internal set; }

        public FormPayWithCard()
        {
            InitializeComponent();
            TodayDate = Shared.M2S(DateTime.Now.Date);
            _PcPosFactory = new PcPosFactory();
        }



        private async void InsertFactor()
        {
            try
            {
                if (IsOtherReq)
                {
                    await Program.InsertLogToFile("InsertFactor : OtherID : " + OtherReqID.ToString()
+ Shared.GetCurrentMethod() +
" - " + this.Name);
                }
                else
                {
                    await Program.InsertLogToFile("InsertFactor : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
+ Shared.GetCurrentMethod() +
" - " + this.Name);
                }

                var insuranceSupplementaryName = "";
                try
                {
                    insuranceSupplementaryName = Shared.ObjectToText(GetField("insuranceSupplementaryName"));
                }
                catch
                {

                }



                using (SqlConnection con = new SqlConnection(Program.ConString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = @"[OP].[IFactors]";


                        var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        if (IsOtherReq)
                        {
                            cmd.Parameters.AddWithValue("@ParaClinicName", GetOtherField("GroupName") + " - " + GetOtherField("OtherName"));
                            cmd.Parameters.AddWithValue("@ReceptionDate", Shared.M2S(DateTime.Now));
                            cmd.Parameters.AddWithValue("@ReceptionTime", DateTime.Now.ToString("HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@endRate", Shared.ValInt64(GetOtherField("OtherRate")));
                            cmd.Parameters.AddWithValue("@ReceptionCode", 0);
                            cmd.Parameters.AddWithValue("@documentCode", DBNull.Value);
                            cmd.Parameters.AddWithValue("@beneficiaryName", DBNull.Value);
                            cmd.Parameters.AddWithValue("@insuranceName", DBNull.Value);
                            cmd.Parameters.AddWithValue("@nationalNumber", DBNull.Value);
                            cmd.Parameters.AddWithValue("@NationalNo", DBNull.Value);
                            cmd.Parameters.AddWithValue("@patientRate", Shared.ValInt64(GetOtherField("OtherRate")));
                            cmd.Parameters.AddWithValue("@serviceDescription", GetOtherField("OtherDescription"));
                            cmd.Parameters.AddWithValue("@insuranceRate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@insuranceSupplementaryName", DBNull.Value);
                            cmd.Parameters.AddWithValue("@cashInsuranceSupplementaryRate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@firstName", DBNull.Value);
                            cmd.Parameters.AddWithValue("@lastName", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Comment", DBNull.Value);
                            cmd.Parameters.AddWithValue("@DiscountRate", 0);
                            cmd.Parameters.AddWithValue("@FreeRate", Shared.ValInt64(GetOtherField("OtherRate")));
                            cmd.Parameters.AddWithValue("@GhabzNum", GhabzNum);
                            cmd.Parameters.AddWithValue("@NamePazirandeh", Program.Onme);
                            cmd.Parameters.AddWithValue("@ID", 0);
                            cmd.Parameters.AddWithValue("@IsPayed ", IsPayed);
                            cmd.Parameters.AddWithValue("@IsPrint ", IsPrint);
                            cmd.Parameters.AddWithValue("@IsSendToApi", IsSendToApi);
                            cmd.Parameters.AddWithValue("@OtherID", OtherReqID);
                            cmd.Parameters.AddWithValue("@answerDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("@beneficiaryNameReception", DBNull.Value);
                            cmd.Parameters.AddWithValue("@Economiccode", DBNull.Value);
                            cmd.Parameters.AddWithValue("@IsOther", true);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ParaClinicName", IsTarkhis ? "ترخیص" : (IsVadie ? "ودیعه" : (IsEghdamat ? "اقدامات" : Shared.ObjectToText(GetField("ParaClinicName")))));
                            cmd.Parameters.AddWithValue("@ReceptionDate", Shared.ObjectToText(GetField("ReceptionDate")));
                            cmd.Parameters.AddWithValue("@ReceptionTime", Shared.ObjectToText(GetField("ReceptionTime")));
                            cmd.Parameters.AddWithValue("@documentCode", Shared.ObjectToText(GetField("documentCode")));
                            cmd.Parameters.AddWithValue("@ReceptionCode", Shared.ValInt64(GetField("ReceptionCode")));
                            cmd.Parameters.AddWithValue("@beneficiaryName", Shared.ObjectToText(GetField("beneficiaryName")));
                            cmd.Parameters.AddWithValue("@insuranceName", Shared.ObjectToText(GetField("insuranceName")));
                            cmd.Parameters.AddWithValue("@nationalNumber", (Shared.ObjectToText(GetField("nationalNumber")) == "" ? Shared.ObjectToText(GetField("NationalNo")) : Shared.ObjectToText(GetField("nationalNumber"))));
                            cmd.Parameters.AddWithValue("@NationalNo", Shared.ObjectToText(GetField("NationalNo")));
                            cmd.Parameters.AddWithValue("@patientRate", Shared.ValInt64(GetField("patientRate")));
                            cmd.Parameters.AddWithValue("@serviceDescription", IsEghdamat ? (Shared.ObjectToText(GetField("ServiceDescription"))
    + " / " + Shared.ObjectToText(GetField("Description")
    + " / " + Shared.ObjectToText(GetField("BedCompleteName")))) : Shared.ObjectToText(GetField("serviceDescription")));
                            cmd.Parameters.AddWithValue("@insuranceRate", Shared.ValInt64(GetField("insuranceRate")));
                            cmd.Parameters.AddWithValue("@insuranceSupplementaryName", insuranceSupplementaryName);
                            cmd.Parameters.AddWithValue("@cashInsuranceSupplementaryRate", Shared.ValInt64(GetField("cashInsuranceSupplementaryRate")));
                            cmd.Parameters.AddWithValue("@endRate", Shared.ValInt64(GetField("endRate")));
                            cmd.Parameters.AddWithValue("@GhabzNum", GhabzNum);
                            cmd.Parameters.AddWithValue("@firstName", Shared.ObjectToText(GetField("firstName")));
                            cmd.Parameters.AddWithValue("@lastName", Shared.ObjectToText(GetField("lastName")));
                            cmd.Parameters.AddWithValue("@Comment", Shared.ObjectToText(GetField("Comment")));
                            cmd.Parameters.AddWithValue("@DiscountRate", Shared.ValInt64(GetField("DiscountRate")));
                            cmd.Parameters.AddWithValue("@FreeRate", Shared.ValInt64(GetField("FreeRate")));
                            cmd.Parameters.AddWithValue("@NamePazirandeh", Program.Onme);
                            cmd.Parameters.AddWithValue("@ID", 0);
                            cmd.Parameters.AddWithValue("@IsPayed ", IsPayed);
                            cmd.Parameters.AddWithValue("@IsPrint ", IsPrint);
                            cmd.Parameters.AddWithValue("@IsSendToApi", IsSendToApi);
                            cmd.Parameters.AddWithValue("@answerDate", Shared.ObjectToText(GetField("answerDate")));
                            cmd.Parameters.AddWithValue("@beneficiaryNameReception", Shared.ObjectToText(GetField("beneficiaryNameReception")));
                            cmd.Parameters.AddWithValue("@Economiccode", Shared.ObjectToText(GetField("Economiccode")));
                            cmd.Parameters.AddWithValue("@age", Shared.Val(GetField("age")));
                            cmd.Parameters.AddWithValue("@InsuranceCode", Shared.ObjectToText(GetField("InsuranceCode")));
                            cmd.Parameters.AddWithValue("@InsuranceBookNumber", Shared.ObjectToText(GetField("InsuranceBookNumber")));
                            cmd.Parameters.AddWithValue("@BeneficiaryCode", Shared.ObjectToText(GetField("BeneficiaryCode")));
                            cmd.Parameters.AddWithValue("@PatientType", Shared.Val(GetField("PatientType")));
                            cmd.Parameters.AddWithValue("@InquiryType", Shared.Val(GetField("InquiryType")));
                            cmd.Parameters.AddWithValue("@AgeType", Shared.Val(GetField("AgeType")));
                            cmd.Parameters.AddWithValue("@Sex", Shared.ObjectToBool(GetField("Sex")));
                            cmd.Parameters.AddWithValue("@ExternalBeneficiaryName", Shared.ObjectToText(GetField("ExternalBeneficiaryName")));
                            cmd.Parameters.AddWithValue("@SectionID", Shared.Val(GetField("SectionID")));
                            cmd.Parameters.AddWithValue("@ParaclinicChildID", Shared.Val(GetField("ParaclinicChildID")));
                            cmd.Parameters.AddWithValue("@ParaclinicReceptionCode", Shared.ObjectToText(GetField("ParaclinicReceptionCode")));
                            cmd.Parameters.AddWithValue("@SoftwareCode", Shared.Val(GetField("SoftwareCode")));
                            cmd.Parameters.AddWithValue("@ParaclinicChildName", Shared.ObjectToText(GetField("ParaclinicChildName")));
                            cmd.Parameters.AddWithValue("@GiftRate", Shared.ValInt64(GetField("GiftRate")));
                            cmd.Parameters.AddWithValue("@GiftDiscountRate", Shared.ValInt64(GetField("GiftDiscountRate")));
                            cmd.Parameters.AddWithValue("@Pacscode", Shared.ObjectToText(GetField("Pacscode")));
                            cmd.Parameters.AddWithValue("@ISAdvanceMode", Shared.ObjectToBool(GetField("ISAdvanceMode")));
                            cmd.Parameters.AddWithValue("@DifferenceRate", Shared.ValInt64(GetField("DifferenceRate")));
                            cmd.Parameters.AddWithValue("@CalculationForcePayableRate", Shared.ValInt64(GetField("CalculationForcePayableRate")));
                            cmd.Parameters.AddWithValue("@ISCancel", Shared.ObjectToBool(GetField("ISCancel")));
                            cmd.Parameters.AddWithValue("@ISInsuranceReceptionWithoutPrint", Shared.ObjectToBool(GetField("ISInsuranceReceptionWithoutPrint")));
                            cmd.Parameters.AddWithValue("@ReceptionUserCode", Shared.ObjectToText(GetField("ReceptionUserCode")));
                            cmd.Parameters.AddWithValue("@InsuranceSupplementaryCode", Shared.ObjectToText(GetField("InsuranceSupplementaryCode")));
                            cmd.Parameters.AddWithValue("@GlobalReceptionID", Shared.Val(GetField("GlobalReceptionID")));
                            cmd.Parameters.AddWithValue("@RoomId", Shared.Val(GetField("RoomId")));
                            cmd.Parameters.AddWithValue("@FatherName", Shared.ObjectToText(GetField("FatherName")));
                            cmd.Parameters.AddWithValue("@UserAnswer", Shared.ObjectToText(GetField("UserAnswer")));
                            cmd.Parameters.AddWithValue("@_DESC", Shared.Val(GetField("_DESC")));
                            cmd.Parameters.AddWithValue("@Receptionsepratecode", Shared.ObjectToText(GetField("Receptionsepratecode")));
                            cmd.Parameters.AddWithValue("@Totalrate", Shared.ValInt64(GetField("Totalrate")));
                            cmd.Parameters.AddWithValue("@Paymentrate", Shared.ValInt64(GetField("Paymentrate")));
                            cmd.Parameters.AddWithValue("@DrugSumPreferredRate", Shared.ValInt64(GetField("DrugSumPreferredRate")));
                            cmd.Parameters.AddWithValue("@SumPayableRate", Shared.ValInt64(GetField("SumPayableRate")));
                            cmd.Parameters.AddWithValue("@SumOutOfRate", Shared.ValInt64(GetField("SumOutOfRate")));
                            cmd.Parameters.AddWithValue("@SalamatTrackingCode", Shared.ValInt64(GetField("SalamatTrackingCode")));

                        }


                        cmd.ExecuteNonQuery();
                        FactorID = Shared.ValInt64(returnParameter.Value);
                        con.Close();
                    }
                }
                InsertPayment();
            }

            catch (Exception ex)
            {
                await Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
                        " - " + this.Name + " - " + ex.Message);
            }
        }

        private async void InsertPayment()
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

                        cmd.Parameters.AddWithValue("@p1", IsOtherReq ? OtherReqID : Shared.ValInt64(GetField("ReceptionCode")));
                        cmd.Parameters.AddWithValue("@p2", 0);
                        cmd.Parameters.AddWithValue("@p3", (object)PayDate ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p4", (object)PayTime ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p5", 0);
                        cmd.Parameters.AddWithValue("@p6", IsOtherReq ? Shared.ValInt64(GetOtherField("OtherRate")) : Shared.ValInt64(GetField("endRate")));
                        cmd.Parameters.AddWithValue("@p7", "");
                        cmd.Parameters.AddWithValue("@p8", (object)TransactionSerial ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p9", (object)ReferenceNo ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p10", (object)IssueTracking ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p11", 0);
                        cmd.Parameters.AddWithValue("@p12", (object)CardNum ?? DBNull.Value);
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
                        cmd.Parameters.AddWithValue("@p27", FactorID);

                        cmd.ExecuteNonQuery();
                        con.Close();


                    }
                }
            }
            catch (Exception ex)
            {
                await Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
                       " - " + this.Name + " - " + ex.Message);
            }
        }

        private async Task<bool> PrintResidOnPaperAdamErsal()
        {
            try
            {
                await Program.InsertLogToFile("Start PrintResidOnPaperAdamErsal : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
                 + "PrintResidOnPaperAdamErsal" +
                 " - " + this.Name);

                #region GetData
                DataTable TempDt = new DataTable();
                TempDt = ToDataTable(Program.dtPaient.AsEnumerable()
                  .Where(myRow => myRow.Field<string>("ReceptionCode") == ReceptionCode).FirstOrDefault());

                TempDt.Columns.Add("NamePazirandeh");
                TempDt.Rows[0]["NamePazirandeh"] = Program.Onme;

                TempDt.Columns.Add("Adres");
                TempDt.Rows[0]["Adres"] = Program.Adres;

                TempDt.Columns.Add("Rno");
                TempDt.Rows[0]["Rno"] = ReferenceNo;

                Report report = new Report();
                report.Load($@"Reports\AdamErsal\FactorFXReportAdamErsal.frx");

                try
                {
                    PictureObject pic = report.FindObject("MyPicture") as PictureObject;
                    ////Set the image
                    pic.Image = new Bitmap(Program.PrintImagePath);
                }
                catch
                {

                }

                report.RegisterData(TempDt, "OP_Factors");
                report.PrintSettings.Copies = 1;
                report.Prepare();

                report.PrintSettings.ShowDialog = false;
                report.Print();
                await Program.InsertLogToFile("Finish PrintResidOnPaperAdamErsal : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
 + "PrintResidOnPaperAdamErsal" +
 " - " + this.Name);
                #endregion
                return true;
            }
            catch (Exception ex)
            {
                await Program.InsertLogToFile("Error : " + "PrintResidOnPaperAdamErsal" +
                      " - " + this.Name + " - " + ex.Message);
                return false;
            }

        }

        public static DataTable ToDataTable(DataRow items)
        {
            DataTable tb = new DataTable();

            foreach (DataColumn prop in items.Table.Columns)
            {
                tb.Columns.Add(prop.ColumnName, prop.DataType);
            }


            var values = new object[items.Table.Columns.Count];
            for (var i = 0; i < items.Table.Columns.Count; i++)
            {
                values[i] = items[i];
            }

            tb.Rows.Add(values);


            return tb;
        }


        private async Task<bool> PrintResidOnPaper()
        {
            if (IsOtherReq)
            {
                try
                {
                    await Program.InsertLogToFile("Start PrintResidOnPaper : OtherID : " + OtherReqID
+ "PrintResidOnPaper" +
" - " + this.Name);


                    DataTable TempDt = new DataTable();
                    TempDt = ToDataTable(Program.DtOtherReq.AsEnumerable()
                      .Where(myRow => myRow.Field<decimal>("ID") == OtherReqID).FirstOrDefault());

                    TempDt.Columns.Add("NamePazirandeh");
                    TempDt.Rows[0]["NamePazirandeh"] = Program.Onme;

                    TempDt.Columns.Add("Adres");
                    TempDt.Rows[0]["Adres"] = Program.Adres;

                    TempDt.Columns.Add("Rno");
                    TempDt.Rows[0]["Rno"] = ReferenceNo;

                    TempDt.Columns.Add("GhabzNum");
                    TempDt.Rows[0]["GhabzNum"] = GhabzNum;

                    TempDt.Columns.Add("ReceptionDate");
                    TempDt.Rows[0]["ReceptionDate"] = Shared.M2S(DateTime.Now);

                    TempDt.Columns.Add("ReceptionTime");
                    TempDt.Rows[0]["ReceptionTime"] = DateTime.Now.ToString("HH:mm:ss");

                    TempDt.Columns.Add("ParaClinicName");
                    TempDt.Rows[0]["ParaClinicName"] = GetOtherField("GroupName") + " - " + GetOtherField("OtherName");

                    TempDt.Columns.Add("serviceDescription");
                    TempDt.Rows[0]["serviceDescription"] = GetOtherField("OtherDescription");

                    TempDt.Columns["OtherRate"].ColumnName = "endRate";

                    //TempDt.Columns.Add("Adres");
                    TempDt.Columns.Add("ShowReceptionDateTime", typeof(bool));
                    TempDt.Columns.Add("ShowGhabzNum", typeof(bool));
                    TempDt.Columns.Add("ShowReceptionCode", typeof(bool));
                    TempDt.Columns.Add("ShowDocumentCode", typeof(bool));
                    TempDt.Columns.Add("ShowPatientName", typeof(bool));
                    TempDt.Columns.Add("ShowDoctorName", typeof(bool));
                    TempDt.Columns.Add("ShowNationalNumber", typeof(bool));
                    TempDt.Columns.Add("ShowPatientRate", typeof(bool));
                    TempDt.Columns.Add("ShowInsuranceName", typeof(bool));
                    TempDt.Columns.Add("ShowInsuranceRate", typeof(bool));
                    TempDt.Columns.Add("ShowSupplementaryName", typeof(bool));
                    TempDt.Columns.Add("ShowSupplementaryRate", typeof(bool));
                    TempDt.Columns.Add("ShowServiceDescription", typeof(bool));
                    TempDt.Columns.Add("ShowRno", typeof(bool));
                    TempDt.Columns.Add("ShowParaClinicName", typeof(bool));
                    TempDt.Columns.Add("ShowSalamatTrackingCode", typeof(bool));



                    DataRow row = TempDt.Rows[0];

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

                        report.RegisterData(TempDt, "OP_Factors");
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

                        report.RegisterData(TempDt, "OP_Factors");
                        report.PrintSettings.ShowDialog = false;
                        report.Prepare();
                        report.Print();


                    }

                    if (Program.PrintOtherNormal)
                    {

                        report = new Report();

                        report.Load($@"Reports\OtherPrint\OtherPrinNormal.frx");

                        try
                        {
                            PictureObject pic = report.FindObject("MyPicture") as PictureObject;
                            ////Set the image
                            pic.Image = new Bitmap(Program.PrintImagePath);
                        }
                        catch
                        {

                        }

                        report.RegisterData(TempDt, "OP_Factors");
                        report.PrintSettings.ShowDialog = false;
                        report.Prepare();
                        report.Print();


                    }
                    await Program.InsertLogToFile($@"Finish PrintResidOnPaper OtherPrint : OtherID : " + OtherReqID.ToString() +
                      " - " + this.Name);
                    return true;
                }
                catch (Exception ex)
                {
                    await Program.InsertLogToFile("Error : PrintResidOnPaper : " + ex.Message +
       " - " + this.Name);
                    return false;
                }

            }
            else
            {
                await Program.InsertLogToFile("Start PrintResidOnPaper : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
+ "PrintResidOnPaper" +
" - " + this.Name);

                if (Program.PrintList.Where(x => x.PrintChecked == true).Count() == 0)
                {
                    await Program.InsertLogToFile("PrintList Count Is Zero");
                    frmCustomOkMsgBox = new CustomOkMsgBox("هیچ ریپورتی انتخاب نشده است !"
    , global::GeneralKiosk.Properties.Resources.WarningPic, false, 15);
                    frmCustomOkMsgBox.ShowDialog();
                    return false;
                }
                try
                {

                    #region GetData

                    DataTable TempDt = new DataTable();
                    TempDt = ToDataTable(Program.dtPaient.AsEnumerable()
                      .Where(myRow => myRow.Field<string>("ReceptionCode") == ReceptionCode).FirstOrDefault());

                    TempDt.Columns.Add("NamePazirandeh");
                    TempDt.Rows[0]["NamePazirandeh"] = Program.Onme;

                    TempDt.Columns.Add("Adres");
                    TempDt.Columns.Add("ShowReceptionDateTime", typeof(bool));
                    TempDt.Columns.Add("ShowGhabzNum", typeof(bool));
                    TempDt.Columns.Add("ShowReceptionCode", typeof(bool));
                    TempDt.Columns.Add("ShowDocumentCode", typeof(bool));
                    TempDt.Columns.Add("ShowPatientName", typeof(bool));
                    TempDt.Columns.Add("ShowDoctorName", typeof(bool));
                    TempDt.Columns.Add("ShowNationalNumber", typeof(bool));
                    TempDt.Columns.Add("ShowPatientRate", typeof(bool));
                    TempDt.Columns.Add("ShowInsuranceName", typeof(bool));
                    TempDt.Columns.Add("ShowInsuranceRate", typeof(bool));
                    TempDt.Columns.Add("ShowSupplementaryName", typeof(bool));
                    TempDt.Columns.Add("ShowSupplementaryRate", typeof(bool));
                    TempDt.Columns.Add("ShowServiceDescription", typeof(bool));
                    TempDt.Columns.Add("ShowRno", typeof(bool));
                    TempDt.Columns.Add("ShowParaClinicName", typeof(bool));
                    TempDt.Columns.Add("ShowSalamatTrackingCode", typeof(bool));


                    DataRow row = TempDt.Rows[0];

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

                    TempDt.Columns.Add("Rno");
                    TempDt.Rows[0]["Rno"] = ReferenceNo;

                    if (IsEghdamat)
                    {
                        TempDt.Rows[0]["ServiceDescription"] = Shared.ObjectToText(GetField("ServiceDescription"))
    + " / " + Shared.ObjectToText(GetField("Description"))
    + " / " + Shared.ObjectToText(GetField("BedCompleteName"));
                    }


                    TempDt.Columns.Add("GhabzNum");
                    TempDt.Rows[0]["GhabzNum"] = GhabzNum;

                    try
                    {
                        var f = TempDt.Rows[0]["insuranceSupplementaryName"];
                    }
                    catch
                    {
                        TempDt.Columns.Add("insuranceSupplementaryName");

                    }


                    foreach (var item in Program.PrintList)
                    {
                        if (item.PrintChecked)
                        {
                            Report report = new Report();

                            report.Load($@"Reports\{item.PrintCap}");

                            try
                            {
                                PictureObject pic = report.FindObject("MyPicture") as PictureObject;
                                ////Set the image
                                pic.Image = new Bitmap(Program.PrintImagePath);
                            }
                            catch
                            {

                            }
                            for (int i = 0; i < item.PrintNum; i++)
                            {
                                report.RegisterData(TempDt, "OP_Factors");
                                report.PrintSettings.ShowDialog = false;
                                report.Prepare();
                                report.Print();
                            }


                            await Program.InsertLogToFile($@"Finish PrintResidOnPaper {item.PrintCap} : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode")) +
                              " - " + this.Name);
                        }

                    }
                    #endregion
                    return true;
                }
                catch (Exception ex)
                {
                    await Program.InsertLogToFile("Error : PrintResidOnPaper : " + ex.Message +
                           " - " + this.Name);
                    return false;
                }
            }

        }

        private async Task<bool> ReadyForPrint()
        {
            PayInfo.Text = "لطفا رسید خود را بردارید.";
            //pictureBoxMsg.Visible = false;
            textBoxPayTime.Text = "15";
            pictureBoxPayPic.Image = Properties.Resources.Group_6;

            using (FormWaiting Waiting = new FormWaiting())
            {
                Waiting.ShowDialog();
            }
            bool rseault = await PrintResidOnPaper();
            return rseault;
        }


        private async Task UpdateFactorSt(bool IsPrint = false, bool IsPay = false, bool IsSendApi = false, long GhabzNum = 0)
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
                        cmd.Parameters.AddWithValue("@FactorID", FactorID);
                        cmd.Parameters.AddWithValue("@ReceptionCode", Shared.ValInt64(GetField("ReceptionCode")));
                        cmd.ExecuteNonQuery();

                    }
                }
            }

            catch (Exception ex)
            {
                await Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
                      " - " + this.Name + " - " + ex.Message);
            }
        }


        private string GetOtherField(string Field)
        {
            return Program.DtOtherReq.Select($@"ID = {OtherReqID} ").FirstOrDefault()[Field].ToString();
        }
        private async Task SendToPos()
        {
            if (IsOtherReq)
            {
                try
                {
                    await Program.InsertLogToFile("SendToPos : OtherID : " + OtherReqID.ToString()
                        + " - " + Shared.GetCurrentMethod() +
          " - " + this.Name);
                    if (!Program.MuteSound)
                    {
                        playerLotfanKart.Play();
                    }

                    Amnt = Shared.ValInt64(GetOtherField("OtherRate"));

                    try
                    {

                        if (PurchaseInitialization())
                        {
                            Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "تنظیمات پوز نامعتبر است !");
                            this.Close();
                        }



                        PosResult = new PosResult();

                      string  TxtAdditionalData = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                                                                     "<List>" +
                                                                     "<print>" +
                                                                     $@"<item>نام بخش</item>" +
                                                                     $@"<value>{(GetOtherField("OtherName").Length > 20 ? GetOtherField("OtherName").Substring(0, 20) : GetOtherField("OtherName"))}</value>" +
                                                                     "<alignment>0</alignment>" +
                                                                     "<receipttype>2</receipttype>" +
                                                                     "</print>" +
                                                                     "<print>" +
                                                                     $@"<item>UserCode</item>" +
                                                                     $@"<value>{Program.UserCode}</value>" +
                                                                     "<alignment>0</alignment>" +
                                                                     "<receipttype>2</receipttype>" +
                                                                     "</print>" +
                                                                     "</List>";

                        string RefData = ": نام بخش" + Shared.ObjectToText(GetField("ParaClinicName")) + "|" + ": UserCode" + Program.UserCode + "|" + "ارتباطات پیوسته ایرانیان 142";

                        try
                        {
                            //string RefData = "344";

                            posResult = _PcPosFactory.PcStarterPurchase((Program.VahedPool == "ریال" ? Amnt : Amnt * 10).ToString(), string.Empty, TxtAdditionalData, RefData, TerminalID, null, null, 0);

                        }
                        catch
                        {

                        }

                        if (Program._asyncType == AsyncType.Sync && posResult != null)

                            await PurchaseResultReceived(posResult);

                    }
                    catch
                    {
                        try
                        {

                            this._PcPosFactory.Dispose();
                            this.selectedPort.Close();
                            this.Close();
                        }
                        catch
                        {


                            Program.InsertLog("SendToPos",
                            this.Name.Trim(),
                            "Barcodes : " + ReceiptCode +
                            " ResponseCode : " + ResponseCode +
                            " PayDate : " + PayDate +
                            " PayTime : " + PayTime +
                            " ReferenceNo : " + ReferenceNo +
                            " TerminalID : " + TerminalID +
                            " TransactionSerial : " + TransactionSerial);



                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.InsertLog("Error " + ex.Message.ToString(),
                           this.Name.Trim(),
                           "Barcodes : " + ReceiptCode +
                           " ResponseCode : " + ResponseCode +
                           " PayDate : " + PayDate +
                           " PayTime : " + PayTime +
                           " ReferenceNo : " + ReferenceNo +
                           " TerminalID : " + TerminalID +
                           " TransactionSerial : " + TransactionSerial);
                }

            }
            else
            {
                try
                {

                    await Program.InsertLogToFile("SendToPos : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
                        + " - " + Shared.GetCurrentMethod() +
          " - " + this.Name);
                    if (!Program.MuteSound)
                    {
                        playerLotfanKart.Play();
                    }

                    Amnt = Shared.ValInt64(GetField("endRate"));

                    try
                    {

                        if (PurchaseInitialization())
                        {
                            Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "تنظیمات پوز نامعتبر است !");
                            this.Close();
                        }



                        PosResult = new PosResult();

                        try
                        {

                            string Bakhsh = (IsTarkhis ? "ترخیص" : (IsVadie ? "ودیعه" : (IsEghdamat ? "اقدامات" : Shared.ObjectToText(GetField("ParaClinicName")))));
                            Bakhsh=Bakhsh.Length>20 ? Bakhsh.Substring(0,20) : Bakhsh;
                            //Amnt = 10000;
                            string TxtAdditionalData = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" +
                                                                                               "<List>" +
                                                                                               "<print>" +
                                                                                               $@"<item>نام بخش</item>" +
                                                                                               $@"<value>{Bakhsh}</value>" +
                                                                                               "<alignment>0</alignment>" +
                                                                                               "<receipttype>2</receipttype>" +
                                                                                               "</print>" +
                                                                                                "<print>" +
                                                                                                 $@"<item>UserCode</item>" +
                                                                                                 $@"<value>{Program.UserCode}</value>" +
                                                                                                 "<alignment>0</alignment>" +
                                                                                                 "<receipttype>2</receipttype>" +
                                                                                                 "</print>" +
                                                                                               "</List>";

                            string RefData = ": نام بخش"  + Bakhsh + "|" + ": UserCode" + Program.UserCode; 



                            posResult = _PcPosFactory.PcStarterPurchase((Program.VahedPool == "ریال" ? Amnt : Amnt * 10).ToString(), string.Empty,TxtAdditionalData, RefData, TerminalID, null, null, 0);

                        }
                        catch
                        {

                        }

                        if (Program._asyncType == AsyncType.Sync && posResult != null)

                            await PurchaseResultReceived(posResult);

                    }
                    catch
                    {
                        try
                        {

                            this._PcPosFactory.Dispose();
                            this.selectedPort.Close();
                            this.Close();
                        }
                        catch
                        {


                            Program.InsertLog("SendToPos",
                            this.Name.Trim(),
                            "Barcodes : " + ReceiptCode +
                            " ResponseCode : " + ResponseCode +
                            " PayDate : " + PayDate +
                            " PayTime : " + PayTime +
                            " ReferenceNo : " + ReferenceNo +
                            " TerminalID : " + TerminalID +
                            " TransactionSerial : " + TransactionSerial);



                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.InsertLog("Error " + ex.Message.ToString(),
                           this.Name.Trim(),
                           "Barcodes : " + ReceiptCode +
                           " ResponseCode : " + ResponseCode +
                           " PayDate : " + PayDate +
                           " PayTime : " + PayTime +
                           " ReferenceNo : " + ReferenceNo +
                           " TerminalID : " + TerminalID +
                           " TransactionSerial : " + TransactionSerial);
                }
            }

        }

        //private void LoadPosSetting()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(Program.ConString))
        //        {

        //            SqlDataAdapter da = new SqlDataAdapter();
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandType = CommandType.Text;
        //                cmd.CommandTimeout = 300;
        //                cmd.Connection = con;

        //                cmd.CommandText =
        //                $@"SELECT  Ct,  Cpnm,AccSt,IP,  
        //                Lng,
        //                Sync, Terminal 
        //                FROM    BS.TPOS 
        //                WHERE  (ID= {Program.ProcessorId} ) ";

        //                da.SelectCommand = cmd;
        //                da.Fill(dt);

        //            }
        //        }


        //        if (dt.Rows.Count <= 0)
        //        {
        //            Shared.ShowMessage(EnumSendMessage.TryCatchMessage, "تنظیمات دستگاه کارتخوان وارد نشده است !");
        //            Program.ReturnToFirst();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Program.InsertLogToFile("Error : " + Shared.GetCurrentMethod() +
        //              " - " + this.Name);

        //    }
        //}

        private void SetImages()
        {
            pictureBoxTopRight.Image = Program.PictureTopRightImage;
            if (Program.PictureTopCenterImage != null)
                pictureBoxTopCenter.Image = Program.PictureTopCenterImage;
            if (Program.PictureTopLeftImage != null)
                pictureBoxTopLeft.Image = Program.PictureTopLeftImage;

            pictureBoxDown.Image = Program.PictureDownImage;

            pictureBoxTopRight.Visible = Program.PictureTopRightVisible;
            pictureBoxTopCenter.Visible = Program.PictureTopCenterVisible;
            pictureBoxTopLeft.Visible = Program.PictureTopLeftVisible;
            pictureBoxDown.Visible = Program.PictureDownVisible;
            var Tem = (TableLayoutPanelMain.Width / 2) - 320;
            Padding margin = pictureBoxTopRight.Margin;
            margin.Right = Shared.Val(Tem);
            pictureBoxTopRight.Margin = margin;

            margin = pictureBoxTopCenter.Margin;
            margin.Right = Shared.Val(Tem);
            pictureBoxTopCenter.Margin = margin;

        }

        #region 1126

        private void _PosClient_CardSwiped(PosResult posResult)
        {
            Program._tracsactionType = _PcPosFactory.GetTransactionType();

            if (Program._tracsactionType == TransactionType.Purchase)
            {
                #region Purchase

                PurchaseCardSwiped(posResult);

                #endregion
            }
            else if (Program._tracsactionType == TransactionType.PaymentService)
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

        private async void _PosClient_PosResultReceived(PosResult posResult)
        {
            Program._tracsactionType = _PcPosFactory.GetTransactionType();
            if (Program._tracsactionType == TransactionType.Purchase || Program._tracsactionType == TransactionType.PaymentService)
            {
                await PurchaseResultReceived(posResult);
            }
            else if (Program._tracsactionType == TransactionType.Balance)
            {
                //BalanceResultReceived(posResult);
            }
        }

        private async Task PurchaseResultReceived(PosResult posResult)
        {
            try
            {

                ////ClearGroupBox(grpSrvPay);
                if (posResult == null)
                    return;
                //ResponseCode = "0";
                //posResult.ResponseCode = "0";
                //ResponseCode = Shared.Val(posResult.ResponseCode).ToString();

                TransactionDate = Shared.ObjectToText(posResult.TxnDate);

                IssueTracking =Shared.ObjectToText(posResult.TraceNumber);

                if (TransactionDate == "")
                {
                    PayDate = TodayDate;
                    PayTime = DateTime.Now.ToString("HH:mm:ss");

                }
                else
                {
                    PayDate = TransactionDate.Substring(0, 10).Trim();
                    PayTime = TransactionDate.Substring(12).Trim();

                }
                ReferenceNo = Shared.ObjectToText(posResult.RRN);

                TerminalID = Shared.ObjectToText(posResult.TerminalId);

                TransactionSerial = posResult.SerialId;
                PayStatusName = posResult.ResponseDescription;
                CardNum =Shared.ObjectToText(posResult.CardNumberMask);

                timerPayTime.Enabled = false;
                if (IsOtherReq)
                {

                    await Program.InsertLogToFile("GetPosResualt :  " +
"ResponseCode : " + ResponseCode + " - " +
"OtherReqID : " + OtherReqID.ToString()
+ " - " + Shared.GetCurrentMethod() +
" - " + this.Name);

                }
                else
                {
                    await Program.InsertLogToFile("GetPosResualt :  " +
     "ResponseCode : " + ResponseCode + " - " +
     "ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
+ " - " + Shared.GetCurrentMethod() +
" - " + this.Name);
                }


                //Successful result
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(async () =>
                    {
                        textBoxPayTime.Visible = false;
                        InsertFactor();

                        if ((Shared.Val(posResult.ResponseCode).ToString() == "0" && posResult.ResponseDescription.Contains("موفق")) || Program.TestPay)
                        {
                            IsPayed = true;

                            if (IsPayed)
                            {
                                await UpdateFactorSt(false, true);
                                //TableLayoutPanelMain.Enabled = true;
                                PayInfo.Text = "پرداخت موفق" + "\n" + " شماره پیگیری : " + IssueTracking + "\n" +
                                "لطفا کمی صبر کنید ...";
                                pictureBoxPayPic.Image = Properties.Resources.Loading_gif;

                                IsSendToApi = await SendResualtToApi();

                                #region Retry

                                if (!IsSendToApi)
                                {
                                    //await Task.Delay(1000);
                                    IsSendToApi = await SendResualtToApi();
                                }
                                if (!IsSendToApi)
                                {
                                    //await Task.Delay(1000);
                                    IsSendToApi = await SendResualtToApi();
                                }

                                #endregion

                                if (!IsSendToApi)
                                {

                                    await PrintResidOnPaperAdamErsal();
                                    if (IsOtherReq)
                                    {
                                        frmCustomOkMsgBox = new CustomOkMsgBox($@"مراجعه کننده گرامی
پرداخت شما جهت {GetOtherField("GroupName") + " - " + GetOtherField("OtherName")}
به مبلغ {Shared.ValInt64(GetOtherField("OtherRate")).ToString("#,##")} ریال و شماره مرجع {ReferenceNo ?? ""} با موفقیت انجام گردید.
.اما به دلیل قطع ارتباط هنگام ارسال نتیجه به سرور، نیاز به ارائه این رسید به پشتیبان فنی کیوسک می باشد

با سپاس
شرکت نرم افزاری رسیس
021-91010838
                            "
      , global::GeneralKiosk.Properties.Resources.WarningPic, false, 30, playerAdamSabtDarSamaneh);
                                    }
                                    else
                                    {
                                        frmCustomOkMsgBox = new CustomOkMsgBox($@"مراجعه کننده گرامی

{Shared.ObjectToText(GetField("firstName")) + " " + Shared.ObjectToText(GetField("lastName"))}
پرداخت شما جهت {(IsVadie ? "ودیعه" : (IsTarkhis ? "ترخیص" : (IsEghdamat ? "اقدامات" : Shared.ObjectToText(GetField("ParaClinicName")))))}
به مبلغ {Shared.ValInt64(GetField("endRate")).ToString("#,##")} ریال و شماره مرجع {ReferenceNo ?? ""} با موفقیت انجام گردید.
.اما به دلیل قطع ارتباط هنگام ارسال نتیجه به سرور، نیاز به ارائه این رسید به پشتیبان فنی کیوسک می باشد

با سپاس
شرکت نرم افزاری رسیس
021-91010838
                            "
                                         , global::GeneralKiosk.Properties.Resources.WarningPic, false, 30, playerAdamSabtDarSamaneh);
                                    }

                                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                                    {
                                        try
                                        {

                                            _PcPosFactory.Dispose();
                                            Program.ReturnToFirst();
                                            return;
                                        }
                                        catch
                                        {

                                        }

                                    }

                                }
                                else
                                {
                                    if (IsOtherReq)
                                    {
                                        await Program.InsertLogToFile("SuccessFulSendApi : OtherId : " + OtherReqID.ToString()
                  + " - " + "GhabzNum : " + GhabzNum + " - "
                  + Shared.GetCurrentMethod() +
                  " - " + this.Name);
                                        IsSendToApi = true;
                                    }
                                    else
                                    {
                                        await Program.InsertLogToFile("SuccessFulSendApi : ReceptionCode : " + GetField("ReceptionCode")
                  + " - " + "GhabzNum : " + GhabzNum + " - "
                  + Shared.GetCurrentMethod() +
                  " - " + this.Name);
                                        IsSendToApi = true;
                                    }

                                    await UpdateFactorSt(false, false, true, GhabzNum);
                                }

                                HasPrint = await ReadyForPrint();
                                if (IsSendToApi && !HasPrint)
                                {
                                    IsPrint = false;

                                    frmCustomOkMsgBox = new CustomOkMsgBox("پرداخت با موفقیت انجام شد و در سامانه ثبت شد ; اما مشکلی برای چاپ رسید بوجود امده  ! " + "\n" +
                                       "لطفا جهت رفع مشکل ، رسید دستگاه کارتخوان را به بخش پشتیبانی ارائه دهید !"
                  , global::GeneralKiosk.Properties.Resources.WarningPic, false, 30, playerAdamPrint);
                                    if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                                    {
                                        try
                                        {
                                            _PcPosFactory.Dispose();
                                            Program.ReturnToFirst();
                                            return;
                                        }
                                        catch
                                        {

                                        }

                                    }

                                }
                                else
                                {
                                    if (IsOtherReq)
                                    {
                                        await Program.InsertLogToFile("SuccessFulPrint : OtherId : " + OtherReqID.ToString()
                                     + Shared.GetCurrentMethod() +
                                     " - " + this.Name);
                                        await UpdateFactorSt(true, false, false);
                                        IsPrint = true;
                                    }
                                    else
                                    {
                                        await Program.InsertLogToFile("SuccessFulPrint : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
                                     + Shared.GetCurrentMethod() +
                                     " - " + this.Name);
                                        await UpdateFactorSt(true, false, false);
                                        IsPrint = true;
                                    }

                                }

                                _PcPosFactory.Dispose();
                                Program.ReturnToFirst();



                            }

                        }
                        else
                        {
                            PayInfo.Text = string.Format("تراکنش ناموفق");
                            frmCustomOkMsgBox = new CustomOkMsgBox("تراکنش ناموفق " + "\n" + PayStatusName
                , global::GeneralKiosk.Properties.Resources.WarningPic, false, 30);
                            frmCustomOkMsgBox.ShowDialog();
                            this.Close();
                        }


                    }));
                else
                {

                    InsertFactor();

                    textBoxPayTime.Visible = false;
                    if ((Shared.Val(posResult.ResponseCode).ToString() == "0" && posResult.ResponseDescription.Contains("موفق")) || Program.TestPay)
                    {
                        IsPayed = true;

                        if (IsPayed)
                        {
                            await UpdateFactorSt(false, true);
                            //TableLayoutPanelMain.Enabled = true;
                            PayInfo.Text = "پرداخت موفق" + "\n" + " شماره پیگیری : " + IssueTracking + "\n" +
                                "لطفا کمی صبر کنید ...";
                            pictureBoxPayPic.Image = Properties.Resources.Loading_gif;
                            IsSendToApi = await SendResualtToApi();

                            #region Retry

                            if (!IsSendToApi)
                            {
                                //await Task.Delay(1000);
                                IsSendToApi = await SendResualtToApi();
                            }
                            if (!IsSendToApi)
                            {
                                //await Task.Delay(1000);
                                IsSendToApi = await SendResualtToApi();
                            }

                            #endregion

                            if (!IsSendToApi)
                            {

                                await PrintResidOnPaperAdamErsal();
                                if (IsOtherReq)
                                {
                                    frmCustomOkMsgBox = new CustomOkMsgBox($@"مراجعه کننده گرامی
پرداخت شما جهت {GetOtherField("GroupName") + " - " + GetOtherField("OtherName")}
به مبلغ {Shared.ValInt64(GetOtherField("OtherRate")).ToString("#,##")} ریال و شماره مرجع {ReferenceNo} با موفقیت انجام گردید.
.اما به دلیل قطع ارتباط هنگام ارسال نتیجه به سرور، نیاز به ارائه این رسید به پشتیبان فنی کیوسک می باشد

با سپاس
شرکت نرم افزاری رسیس
021-91010838
                            "
                                      , global::GeneralKiosk.Properties.Resources.WarningPic, false, 30, playerAdamSabtDarSamaneh);
                                }
                                else
                                {
                                    frmCustomOkMsgBox = new CustomOkMsgBox($@"مراجعه کننده گرامی

{Shared.ObjectToText(GetField("firstName")) + " " + Shared.ObjectToText(GetField("lastName"))}
پرداخت شما جهت {(IsVadie ? "ودیعه" : (IsTarkhis ? "ترخیص" : (IsEghdamat ? "اقدامات" : Shared.ObjectToText(GetField("ParaClinicName")))))}
به مبلغ {Shared.ValInt64(GetField("endRate")).ToString("#,##")} ریال و شماره مرجع {ReferenceNo} با موفقیت انجام گردید.
.اما به دلیل قطع ارتباط هنگام ارسال نتیجه به سرور، نیاز به ارائه این رسید به پشتیبان فنی کیوسک می باشد

با سپاس
شرکت نرم افزاری رسیس
021-91010838
                            "
                                    , global::GeneralKiosk.Properties.Resources.WarningPic, false, 30, playerAdamSabtDarSamaneh);
                                }
                                if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                                {
                                    try
                                    {

                                        _PcPosFactory.Dispose();
                                        Program.ReturnToFirst();
                                        return;
                                    }
                                    catch
                                    {

                                    }

                                }

                            }
                            else
                            {
                                if (IsOtherReq)
                                {
                                    await Program.InsertLogToFile("SuccessFulSendApi : OtherID : " + OtherReqID.ToString()
             + " - " + "GhabzNum : " + GhabzNum + " - "
             + Shared.GetCurrentMethod() +
             " - " + this.Name);
                                }
                                else
                                {
                                    await Program.InsertLogToFile("SuccessFulSendApi : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
          + " - " + "GhabzNum : " + GhabzNum + " - "
          + Shared.GetCurrentMethod() +
          " - " + this.Name);
                                }

                                IsSendToApi = true;
                                await UpdateFactorSt(false, false, true, GhabzNum);
                            }
                            HasPrint = await ReadyForPrint();
                            if (IsSendToApi && !HasPrint)
                            {
                                IsPrint = false;

                                frmCustomOkMsgBox = new CustomOkMsgBox("پرداخت با موفقیت انجام شد و در سامانه ثبت شد ; اما مشکلی برای چاپ رسید بوجود امده  ! " + "\n" +
                                   "لطفا جهت رفع مشکل ، رسید دستگاه کارتخوان را به بخش پشتیبانی ارائه دهید !"
              , global::GeneralKiosk.Properties.Resources.WarningPic, false, 30, playerAdamPrint);
                                if (frmCustomOkMsgBox.ShowDialog() == DialogResult.OK)
                                {
                                    try
                                    {
                                        _PcPosFactory.Dispose();
                                        Program.ReturnToFirst();
                                        return;
                                    }
                                    catch
                                    {

                                    }

                                }

                            }
                            else
                            {
                                if (IsOtherReq)
                                {
                                    await Program.InsertLogToFile("SuccessFulPrint : OTHERID : " + OtherReqID.ToString()
                                  + Shared.GetCurrentMethod() +
                                  " - " + this.Name);
                                }
                                else
                                {
                                    await Program.InsertLogToFile("SuccessFulPrint : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
                                 + Shared.GetCurrentMethod() +
                                 " - " + this.Name);
                                }
                                await UpdateFactorSt(true, false, false);
                                IsPrint = true;
                            }

                            _PcPosFactory.Dispose();
                            Program.ReturnToFirst();

                        }

                    }
                    else
                    {

                        PayInfo.Text = string.Format("تراکنش ناموفق");
                        frmCustomOkMsgBox = new CustomOkMsgBox("تراکنش ناموفق " + "\n" + PayStatusName
            , global::GeneralKiosk.Properties.Resources.WarningPic, false, 30);
                        frmCustomOkMsgBox.ShowDialog();
                        this.Close();
                    }
                }



            }
            catch
            {
                try
                {
                    this._PcPosFactory.Dispose();
                    this.selectedPort.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch
                {
                }
            }

        }

        private bool PurchaseInitialization()
        {


            if (TransactionMediaInitialization()) return false;
            _PcPosFactory.Initialization(Program._responseLanguage, 10, Program._asyncType);//changed by p.jamali for enhancing time(from 0 to 3)
            return false;

        }

        private bool TransactionMediaInitialization()
        {
            try
            {
                if (Program._mediaType == MediaType.Com)
                {
                    selectedPort = null;

                    if (SerialPort.GetPortNames().Any(p => p == Program.ComPortNum))
                        selectedPort = new SerialPort(Program.ComPortNum);
                    if (selectedPort == null)
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("هیچ پورتی انتخاب نشده است !", global::GeneralKiosk.Properties.Resources.WarningPic);
                        frmCustomOkMsgBox.ShowDialog();
                        Program.ReturnToFirst();
                        return true;
                    }
                    _PcPosFactory.SetCom(selectedPort.PortName);
                }
                if (Program._mediaType == MediaType.Network)
                {
                    if (string.IsNullOrEmpty(Program.PosIP))
                    {
                        frmCustomOkMsgBox = new CustomOkMsgBox("هیچ ای پی تعریف نشده است !", global::GeneralKiosk.Properties.Resources.WarningPic);
                        frmCustomOkMsgBox.ShowDialog();
                        Program.ReturnToFirst();
                        return true;
                    }
                    _PcPosFactory.SetLan(Program.PosIP);
                }

                _PcPosFactory.Initialization(Program._responseLanguage, 0, Program._asyncType);
                return false;
            }
            catch
            {
                try
                {
                    this._PcPosFactory.Dispose();
                    this.selectedPort.Close();
                }
                catch
                {

                }
                return true;
            }

        }
        #endregion


        private async void Form23_Load(object sender, EventArgs e)
        {
            //this.Refresh();
            await Program.InsertLogToFile($@"SoftwareCode : {Shared.ObjectToText(GetField("SoftwareCode"))}");

            if (Shared.Val(GetField("SoftwareCode")) == 1)
            {
                IsVadie = true;
                IsDrug = false;
                IsTarkhis = false;
                IsEghdamat = false;

            }
            else if (Shared.Val(GetField("SoftwareCode")) == 34)
            {
                IsVadie = false;
                IsDrug = false;
                IsTarkhis = false;
                IsEghdamat = false;
            }
            else if (Shared.Val(GetField("SoftwareCode")) == 11)
            {
                IsDrug = true;
                IsVadie = false;
                IsTarkhis = false;
                IsEghdamat = false;
            }
            else if (Shared.Val(GetField("SoftwareCode")) == 16)
            {
                IsTarkhis = true;
                IsEghdamat = false;
                IsVadie = false;
                IsDrug = false;
            }
            else if (Shared.Val(GetField("SoftwareCode")) == 06)
            {
                IsEghdamat = true;
                IsVadie = false;
                IsDrug = false;
                IsTarkhis = false;
            }
            #region 1126
            _PcPosFactory.CardSwiped += _PosClient_CardSwiped;
            _PcPosFactory.PosResultReceived += _PosClient_PosResultReceived;
            #endregion

            SetImages();
            //var Tem = (TableLayoutPanelMain.Width / 2) - 320;
            //Padding margin = pictureBoxTopRight.Margin;
            //margin.Right = Shared.Val(Tem);
            //pictureBoxTopRight.Margin = margin;

            //margin = pictureBoxTopCenter.Margin;
            //margin.Right = Shared.Val(Tem);
            //pictureBoxTopCenter.Margin = margin;
            //LoadPosSetting();
            //using (FormWaiting frm = new FormWaiting())
            //{
            //    frm.ShowDialog();
            //}
            //SetDoubleBuffered(TableLayoutPanelMain);
          await  Task.Run(async () =>
           {
               await SendToPos();  // Running SendToPos in a background thread

           });
            //this.Refresh();

        }

        private string _barcode = "";
        private PosResult posResult;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            char c = (char)keyData;

            if (char.IsNumber(c))
                _barcode += c;

            if (c == (char)Keys.Return)
            {
                //DoSomethingWithBarcode(_barcode);
                //_barcode = "";
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }




        private void FormMainUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                prompt frmprompt = new prompt();

                if (frmprompt.ShowDialog() == DialogResult.OK)
                    if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                    {
                        this.Close();

                    }
                    else if (frmprompt.MyPass == Program.Pass)
                    {
                        using (FormMainSetting frm = new FormMainSetting())
                        {

                            this.Close();
                        }
                    }

            }


        }

        private string GetField(string Field)
        {

            try
            {
                return Program.dtPaient.AsEnumerable()
.Where(myRow => myRow.Field<string>("ReceptionCode") == ReceptionCode).FirstOrDefault()[Field].ToString();
            }
            catch
            {
                return "";
            }



        }

        private async Task<bool> SendResualtToApi()
        {
            try
            {
                string InquiryCode = "";
                var parts = new List<string>();

                if (Program.SendIssueAfterPay)
                    parts.Add(IssueTracking);

                if (Program.SendRefNumAfterPay)
                    parts.Add(ReferenceNo);

                if (Program.SendTerminalAfterPay)
                    parts.Add(TerminalID);

                 InquiryCode = string.Join("/",
      parts.Where(x => !string.IsNullOrWhiteSpace(x)));

                Debug.WriteLine($"InquiryCode: {InquiryCode ?? "NULL"}");
                Debug.WriteLine($"CardNum: {CardNum ?? "NULL"}");
                Debug.WriteLine($"WebServiceAddress: {Program.WebServiceAddres ?? "NULL"}");

                Uri myUri;
                if (IsOtherReq)
                {
                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessOtherAddPayment?OtherID={OtherReqID.ToString()}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? (CardNum).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(GetOtherField("OtherRate")))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");
                }
                else
                {
                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessPatientManagementAddPayment?ReceptionCode={ReceiptCode}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? (CardNum).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(GetField("EndRate")))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");
                }


                if (IsVadie)
                {
                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessAdvanceAddPayment?ReceptionCode={ReceiptCode}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? (CardNum).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(GetField("EndRate")))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");

                }
                else if (IsTarkhis)
                {
                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessReleaseAddPayment?ReceptionCode={ReceiptCode}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? (CardNum).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(GetField("EndRate")))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");
                    //myUri = new Uri($@"https://www.pdd.ir/pdd/PDDWebService2/MainWebServices.asmx/CashLessReleaseAddPayment?ReceptionCode={ReceiptCode}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? (CardNum).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(GetField("EndRate")))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");
                }
                else if (IsEghdamat)
                {
                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessRemedialActivityAddPayment?ReceptionCode={ReceiptCode}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? (CardNum).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(GetField("EndRate")))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");
                }

                else if (IsDrug)
                {
                    myUri = new Uri($@"{Program.WebServiceAddres}/CashLessDrugInventoryAddPayment?ReceptionCode={ReceiptCode}&InquiryCode={InquiryCode}&CardNumber={(Program.SendCardNum ? (CardNum).Replace("-##-", "-") : "")}&PaymentRate={Shared.ObjectToText(Shared.ValInt64(GetField("EndRate")))}{(Program.UserCode == "" ? "" : $@"&UserCode={Program.UserCode}")}");
                }
                 

                if (Program.SenTest)
                {

                    myUri = new Uri($@"http://www.pdd.ir:8090/MainWebServices.asmx/CashLessPatientManagementAddPayment?ReceptionCode=3074976&InquiryCode=454958489&CardNumber={""}&PaymentRate=10000&UserCode=0000102");


                }

                if (IsOtherReq)
                {
                    await Program.InsertLogToFile($@"Start SendResualtToApi {myUri.AbsoluteUri} : OTHERID : " + OtherReqID
+ Shared.GetCurrentMethod() +
" - " + this.Name);
                }
                else
                {
                    await Program.InsertLogToFile($@"Start SendResualtToApi {myUri.AbsoluteUri} : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
+ Shared.GetCurrentMethod() +
" - " + this.Name);
                }


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(myUri);
                request.Timeout = 20000;

                //await Program.InsertLogToFile($@"HttpWebRequest request " + myUri.AbsoluteUri);

                var response = await request.GetResponseAsync();
                StreamReader responseReader = new StreamReader(response.GetResponseStream());

                //await Program.InsertLogToFile($@"responseReader " + myUri.AbsoluteUri);

                String resultmsg = responseReader.ReadToEnd();

                await Program.InsertLogToFile($@"{resultmsg}  >> " + myUri.AbsoluteUri);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(resultmsg);

                //await Program.InsertLogToFile($@"doc.LoadXml(resultmsg) " + myUri.AbsoluteUri);

                var XmlNode = JsonConvert.SerializeXmlNode(doc);
                //await Program.InsertLogToFile($@"XmlNode " + myUri.AbsoluteUri);
                dynamic data = JObject.Parse(XmlNode.ToString());
                //await Program.InsertLogToFile($@"dynamic data " + myUri.AbsoluteUri);
                responseReader.Close();
                //await Program.InsertLogToFile($@"responseReader.Close() " + myUri.AbsoluteUri);
                XmlElement root = doc.DocumentElement;
                //await Program.InsertLogToFile($@"XmlElement root = doc.DocumentElement " + myUri.AbsoluteUri);
                if (Shared.ValInt64(root.InnerText) == 0)
                {
                    if (IsOtherReq)
                    {

                        await Program.InsertLogToFile("UnSuccessFul Finish SendResualtToApi  : Other Id : " + OtherReqID.ToString()
+ Shared.GetCurrentMethod() +
" - " + this.Name);

                    }
                    else
                    {
                        await Program.InsertLogToFile("UnSuccessFul Finish SendResualtToApi  : ReceptionCode : " + Shared.ObjectToText(GetField("ReceptionCode"))
+ Shared.GetCurrentMethod() +
" - " + this.Name);
                    }

                    return false;
                }
                if (IsOtherReq)
                {
                    GhabzNum = Shared.ValInt64(root.InnerText);
                    await Program.InsertLogToFile("SuccessFul Finish SendResualtToApi : OtherID : " + OtherReqID.ToString()
            + Shared.GetCurrentMethod() +
            " - " + this.Name);
                }
                else
                {
                    GhabzNum = Shared.ValInt64(root.InnerText);
                    await Program.InsertLogToFile("SuccessFul Finish SendResualtToApi : ReceptionCode : " + GetField("ReceptionCode") + GhabzNum.ToString()
            + Shared.GetCurrentMethod() +
            " - " + this.Name);
                }

                return true;
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    ex.Response.Dispose();
                }

                await Program.InsertLogToFile("Error : " + ex.Message);

                return false;
            }
            //await Program.InsertLogToFile("SuccessFul Finish SendResualtToApi : ReceptionCode : " + GetField("ReceptionCode") + GhabzNum.ToString()
        }
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        private void تنظیماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prompt frmprompt = new prompt();

            if (frmprompt.ShowDialog() == DialogResult.OK)
                if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                {
                    using (FormMainSetting frm = new FormMainSetting())
                    {
                        frm.UserType = (int)Program.EnumUserType.Backup;
                        frm.ShowDialog();
                    }

                }
                else if (frmprompt.MyPass == Program.Pass)
                {
                    using (FormMainSetting frm = new FormMainSetting())
                    {

                        frm.UserType = (int)Program.EnumUserType.Modir;
                        frm.ShowDialog();
                    }
                }
        }


        private void FormPayWithCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            playerLotfanKart.Stop();
            playerLotfanResid.Stop();
        }


        private void pictureBoxCancelFactor_Click(object sender, EventArgs e)
        {
            try
            {
                _PcPosFactory.Dispose();
                selectedPort.Close();
                Dispose();
                this.Close();
            }
            catch
            {

            }

        }

        private void timerPayTime_Tick(object sender, EventArgs e)
        {
            //this.Refresh();
            if (Shared.Val(textBoxPayTime.Text) == 0)
                this.Close();
            textBoxPayTime.Text = Shared.ObjectToText(Shared.Val(textBoxPayTime.Text) - 1);
        }

      
    }
}