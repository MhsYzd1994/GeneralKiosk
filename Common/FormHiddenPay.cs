using SSP1126.PcPos.BaseClasses;
using SSP1126.PcPos.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralKiosk.Common
{
    public partial class FormHiddenPay : Form
    {
        public PcPosFactory _PcPosFactory;
        public PosResult posResult;
        private CustomOkMsgBox frmCustomOkMsgBox;
        public SerialPort selectedPort;
        private int cnt=0;

        public string ReferenceNo { get; private set; }
        public string TerminalID { get; private set; }
        public string PayInfo { get; private set; }
        public string TransactionSerial { get; private set; }
        public string PayStatusName { get; private set; }
        public string CardNum { get; private set; }
        public string ResponseCode { get; private set; }
        public string TransactionDate { get; private set; }
        public string IssueTracking { get; private set; }
        public string PayDate { get; private set; }
        public string PayTime { get; private set; }
        public string TodayDate { get; }
        public bool IsPayed { get;  set; }
        public PosResult PosResult { get; private set; }
        public long Amnt { get; set; }

        public FormHiddenPay()
        {
            InitializeComponent();
            TodayDate = Shared.M2S(DateTime.Now.Date);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void FormHiddenPay_Load(object sender, EventArgs e)
        {
            _PcPosFactory.CardSwiped += _PosClient_CardSwiped;
            _PcPosFactory.PosResultReceived += _PosClient_PosResultReceived;
            SendToPos();
        }

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
            PayInfo = "پاسخ دریافتی : " + posResult.ResponseCode + " // " + posResult.ResponseDescription;

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
            Program._tracsactionType = _PcPosFactory.GetTransactionType();
            if (Program._tracsactionType == TransactionType.Purchase || Program._tracsactionType == TransactionType.PaymentService)
            {
                PurchaseResultReceived(posResult);
            }
            else if (Program._tracsactionType == TransactionType.Balance)
            {
                //BalanceResultReceived(posResult);
            }
        }

        private void PurchaseResultReceived(PosResult posResult)
        {
            try
            {

                ////ClearGroupBox(grpSrvPay);
                if (posResult == null)
                    return;

                ResponseCode = Shared.Val(posResult.ResponseCode).ToString();

                TransactionDate = posResult.TxnDate;

                IssueTracking = posResult.TraceNumber;

                if (TransactionDate == null)
                {
                    PayDate = TodayDate;
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

                //Successful result
                if (Shared.Val(posResult.ResponseCode).ToString() == "0")
                {
                    IsPayed = true;

                    if (this.InvokeRequired)
                        this.Invoke(new MethodInvoker(async () =>
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                        }));
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }
                else
                {

                    if (this.InvokeRequired)
                        this.Invoke(new MethodInvoker(() =>
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();

                        }));
                    else
                    {
                        this.DialogResult = DialogResult.OK;
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

        private void SendToPos()
        {
            try
            {

                if (PurchaseInitialization())
                {
                    Shared.ShowMessage(EnumSendMessage.PeyghamAzadBaIconError , "تنظیمات پوز نامعتبر است !");
                    this.Close();
                }



                PosResult = new PosResult();

                try
                {

                    posResult = _PcPosFactory.PcStarterPurchase((Program.VahedPool == "ریال" ? Amnt : Amnt * 10).ToString(), string.Empty, "", "", TerminalID, null, null, 0);

                }
                catch
                {

                }

                if (Program._asyncType == AsyncType.Sync && posResult != null)

                    PurchaseResultReceived(posResult);
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

                }
            }



        }

        private void FormHiddenPay_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {

                this._PcPosFactory.Dispose();
                this.selectedPort.Close();

            }
            catch
            {

            }
        }

        private void FormHiddenPay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                prompt frmprompt = new prompt();

                if (frmprompt.ShowDialog() == DialogResult.OK)
                    if (frmprompt.MyPass == Program.MakeAPassword().Substring(0, 6))
                    {
                       
                        this.DialogResult = DialogResult.Abort;
                        this.Close();

                    }
                    else if (frmprompt.MyPass == Program.Pass)
                    {
                        using (FormMainSetting frm = new FormMainSetting())
                        {

                            this.DialogResult = DialogResult.Abort;
                            this.Close();
                        }
                    }

            }
        }

        private void timerPayTime_Tick(object sender, EventArgs e)
        {
            if (cnt >= 30)
                this.Close();
            cnt++;
        }
    }
}
