using SSP1126.PcPos.BaseClasses;
using SSP1126.PcPos.Infrastructure;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace GeneralKiosk
{
    public partial class frmPosSetting : Form
    {
        private TransactionType _tracsactionType;
        private PcPosFactory _PcPosFactory;
        private MediaType _mediaType;
        private ResponseLanguage _responseLanguage;
        private AsyncType _asyncType;

        public int MyprimaryKey { get; set; }


        public frmPosSetting()
        {
            InitializeComponent();
        }

        private void FrmPosSetting_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.TopMost = true;
            LoadFields();

        }


        private void LoadFields()
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

                        //cmd.Parameters.AddWithValue("@p1", MyprimaryKey);

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                    }
                }

                #region SetData

                if (dt.Rows.Count <= 0) return;

                UiComboBoxCommuicationType.Text = Shared.ObjectToText(dt.Rows[0]["Ct"]);
                TextBoxComPortNum.Text = Shared.ObjectToText(dt.Rows[0]["Cpnm"]);
                UiComboBoxVaziatTashim.Text = Shared.ObjectToText(dt.Rows[0]["AccSt"]);
                TextBoxPosIP.Text = Shared.ObjectToText(dt.Rows[0]["IP"]);
                UiComboBoxRespLanguage.Text = Shared.ObjectToText(dt.Rows[0]["Lng"]);
                UiComboBoxSyncOrNot.Text = Shared.ObjectToText(dt.Rows[0]["Sync"]);
                TextBoxTerminalID.Text = Shared.ObjectToText(dt.Rows[0]["Terminal"]);


                #endregion
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);

            }
        }



        private void FrmPosSetting_KeyDown(object sender, KeyEventArgs e)
        {
            #region MyRegion
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                ExitForm();
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            #endregion
        }

        private void Save()
        {

            #region MyRegion
            try
            {
                using (SqlConnection con = new SqlConnection(Program.ConString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        cmd.CommandText = $@"SELECT  ID FROM  BS.TPOS WHERE  (ID = {Program.ProcessorId})";

                        var temOBJ = cmd.ExecuteScalar();
                        #endregion
                        #region MyRegion

                        cmd.Parameters.Clear();

                        if (Shared.ValInt64(temOBJ) > 0)
                        {
                            cmd.CommandText =
                                $@"UPDATE [BS].[TPOS]
                                   SET [Ct] = @p1
                                  ,[Cpnm] = @p2
                                  ,[AccSt] = @p3
                                  ,[IP] = @p4
                                  ,[Lng] = @p5
                                  ,[Sync] = @p6
                                  ,[Terminal] = @p7
                                   WHERE ID={Program.ProcessorId}";
                        }
                        else
                        {

                            cmd.CommandText =
                           $@"INSERT INTO [BS].[TPOS]
                           ([Ct]
                           ,[Cpnm]
                           ,[AccSt]
                           ,[IP]
                           ,[Lng]
                           ,[Sync]
                           ,[Terminal]
                           ,[ID])
                            VALUES
                           (@p1
                           ,@p2
                           ,@p3
                           ,@p4
                           ,@p5
                           ,@p6
                           ,@p7
                           ,{Program.ProcessorId})";
                        }




                        cmd.Parameters.AddWithValue("@p1", (object)UiComboBoxCommuicationType.Text ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p2", (object)TextBoxComPortNum.Text ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p3", (object)UiComboBoxVaziatTashim.Text ?? "");
                        cmd.Parameters.AddWithValue("@p4", (object)TextBoxPosIP.Text ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p5", (object)UiComboBoxRespLanguage.Text ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p6", (object)UiComboBoxSyncOrNot.Text ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@p7", (object)TextBoxTerminalID.Text ?? DBNull.Value);

                        cmd.ExecuteNonQuery();

                    }
                    con.Close();
                }

                Shared.ShowMessage(EnumSendMessage.AmaleSabtKamelShod, "");
                this.DialogResult = DialogResult.OK;

            }

            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                this.DialogResult = DialogResult.None;
            }
            #endregion
        }

        private bool CheckPishNiazSabt()
        {
            if (UiComboBoxCommuicationType.Text != ""
                & UiComboBoxVaziatTashim.Text != ""
                & UiComboBoxRespLanguage.Text != ""
                & UiComboBoxSyncOrNot.Text != "") return true;

            return false;
        }

        private void ExitForm()
        {
            this.Close();
        }

        private void TextBoxBoudRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void UiButtonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void UiButtonExit_Click(object sender, EventArgs e)
        {
            ExitForm();
        }

        private void UiComboBoxCommuicationType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Shared.ObjectToText(UiComboBoxCommuicationType.SelectedValue) == "COM")
            {
                TextBoxComPortNum.Enabled = true;
                TextBoxPosIP.Enabled = false;
                TextBoxPosIP.Clear();
            }
            else
            {
                TextBoxComPortNum.Enabled = false;
                TextBoxPosIP.Enabled = true;
                TextBoxComPortNum.Clear();
            }
        }

        private void BtnGetAuthorizedOperations_Click(object sender, EventArgs e)
        {

            if (_PcPosFactory == null)
                _PcPosFactory = new PcPosFactory();

            //Assign Events
            _PcPosFactory.PosResultReceived += _PosClient_PosResultReceived;

            _tracsactionType = TransactionType.GetAuthorizedOperations;

            if (TransactionMediaInitialization()) return;


            PosResult posResult = _PcPosFactory.GetAuthorizedOperations();
            //it means that _transactionMode is sync
            if (posResult != null && _asyncType == AsyncType.Sync)
            {
                GetAuthorizedOperationsResultReceived(posResult);
            }
        }

        private void _PosClient_PosResultReceived(PosResult posResult)
        {
            _tracsactionType = _PcPosFactory.GetTransactionType();
            if (_tracsactionType == TransactionType.GetAuthorizedOperations)
            {
                GetAuthorizedOperationsResultReceived(posResult);
            }

        }

        private void GetAuthorizedOperationsResultReceived(PosResult posResult)
        {
            if (posResult == null)
                return;
            //Successful result
            if (posResult.ResponseCode == "00")
            {
                //picResult.Image = Resource.Successful;
                //if (this.InvokeRequired)
                //    this.Invoke(new MethodInvoker(() =>
                //    {
                //        txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"", posResult.TraceNumber);
                //    }));
                //else
                //{
                //    txtStatus.Text = string.Format("Successful Transaction. Trace#: \"{0}\"", posResult.TraceNumber);
                //}

            }
            else
            {
                //picResult.Image = Resource.Error;
                //if (this.InvokeRequired)
                //    this.Invoke(new MethodInvoker(() =>
                //    {
                //        txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                //    }));
                //else
                //{
                //    txtStatus.Text = string.Format("Transaction Error. Serial ID: \"{0}\"", posResult.SerialId);
                //}
            }

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() =>
                {
                    chkBill.Checked = posResult.IsBillValidOperation;
                    chkMCIBill.Checked = posResult.IsMCIBillValidOperation;
                    chkPinCharge.Checked = posResult.IsPinChargeValidOperation;
                    chkTopup.Checked = posResult.IsTopupChargeValidOperation;
                    chkPurchase.Checked = posResult.IsPurchaseValidOperation;
                    chkReport.Checked = posResult.IsGetReportValidOperation;
                    chkBalance.Checked = posResult.IsBalanceValidOperation;
                    chkTCIBill.Checked = posResult.IsTCIBillValidOperation;
                    chkSrvPayment.Checked = posResult.IsPaymentServiceOperation;


                }));
            else
            {
                chkBill.Checked = posResult.IsBillValidOperation;
                chkMCIBill.Checked = posResult.IsMCIBillValidOperation;
                chkPinCharge.Checked = posResult.IsPinChargeValidOperation;
                chkTopup.Checked = posResult.IsTopupChargeValidOperation;
                chkPurchase.Checked = posResult.IsPurchaseValidOperation;
                chkReport.Checked = posResult.IsGetReportValidOperation;
                chkBalance.Checked = posResult.IsBalanceValidOperation;
                chkTCIBill.Checked = posResult.IsTCIBillValidOperation;
                chkSrvPayment.Checked = posResult.IsPaymentServiceOperation;

            }
        }

        private bool TransactionMediaInitialization()
        {
            if (UiComboBoxRespLanguage.Text == "Persian")
                _responseLanguage = ResponseLanguage.Persian;
            else
                _responseLanguage = ResponseLanguage.English;

            if (UiComboBoxSyncOrNot.Text == "Async")
                _asyncType = AsyncType.Async;
            else
                _asyncType = AsyncType.Sync;

            if (UiComboBoxCommuicationType.Text == "COM")
                _mediaType = MediaType.Com;
            else
                _mediaType = MediaType.Network;

            if (_mediaType == MediaType.Com)
            {
                SerialPort selectedPort = null;

                if (SerialPort.GetPortNames().Any(p => p == TextBoxComPortNum.Text))
                    selectedPort = new SerialPort(TextBoxComPortNum.Text);
                if (selectedPort == null)
                {
                    MessageBox.Show("There is no selected Port in configurations.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return true;
                }
                _PcPosFactory.SetCom(selectedPort.PortName);
            }
            if (_mediaType == MediaType.Network)
            {
                if (string.IsNullOrEmpty(TextBoxPosIP.Text))
                {
                    MessageBox.Show("There is no value for Pos IP in configurations.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return true;
                }
                _PcPosFactory.SetLan(TextBoxPosIP.Text);
            }

            _PcPosFactory.Initialization(_responseLanguage, 0, _asyncType);
            return false;
        }



        private void UiComboBoxVaziatTashim_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (UiComboBoxVaziatTashim.Text == "ShareByIban")
            //{
            //    uiRadioButtonMultiPur.Enabled = false;
            //    uiRadioButtonTakPur.Checked = true;
            //}
        }
    }
}
