using System;
using System.Data;
using System.Data.SqlClient;

namespace GeneralKiosk
{
    public class BaseInformation
    {
        #region Setting

        #region SaveSetting

        public int InsertUpdateSetting(int? TSSTGID, int ApplicationType, int AccountingType, bool RubyClub, decimal SepPortionPercent,
            bool ShowMenuInvoice, bool ShowCommodityProduct, bool ShowBarcodeSearch, bool FixTimeStop, bool NotShowInvoiceCancel, bool ShowInvoiceDevices,
            string TimeStart, string TimeStop, string Currency, 
            bool CorrectPrice, bool QuestionBackup, bool SelectWithOneClick, int? SectionInvoice,
            int? PhoneDigitsNumber, bool SendSMSInvoice, bool SendSMSSubscriptionCode, bool SendSMSAccountsReport, int SendSMSSaveInvoice, 
            string UserName_SMS, string Message_SMS, string Message_SMSSubscriptionCode,
            bool UseCallerID, bool InvoiceNumberManualSales, bool InvoiceNumberManualBuy,
            bool InvoiceDateManualSales, bool InvoiceDateManualBuy,
            bool InvoiceNumberResetSales, int? InvoiceNumberStartSales,
            bool InvoiceNumberResetBuy, int? InvoiceNumberStartBuy,
            bool SameCommoddityInNewRowsSales, bool SameCommoddityInNewRowsBuy,
            bool CommentDetailSales, bool CommentDetailBuy,
            bool ShowStockSales, bool ShowStockBuy,
            bool ShowCommodityCodeSales, bool ShowCommodityCodeBuy,
            bool ShowSupplierSales, bool ShowSupplierBuy,
            bool ShowExpireDateSales, bool ShowExpireDateBuy,
            bool ShowWareHouseSales, bool ShowWareHouseBuy,
            bool DiscountPerItemSales, bool DiscountPerItemBuy,
            bool TaxPerItemSales, bool TaxPerItemBuy,
            bool TollPerItemSales, bool TollPerItemBuy,
            bool TotalDiscountSales, bool TotalDiscountBuy,
            bool TotalTaxSales, bool TotalTaxBuy, int? TaxPercent,
            bool TotalTollSales, bool TotalTollBuy, int? TollPercent,
            bool HasPiek, int? PiekPercent,
            bool AdditionsSubtractionsSales, bool AdditionsSubtractionsBuy,
            int? RoundSales, bool RoundDownSales, int? RoundBuy, bool RoundDownBuy,
            int InvoiceCredit, bool ShowPriceBuyRestaurant, bool ShowExpireDateInvoiceRestaurant,
            bool ShowStockInvoiceRestaurant, bool ShowUnitInvoiceRestaurant, bool ShowLastInvoicesRestaurant, bool FocusCodeRestaurant,
            bool ShowOrderPointRestaurant, int? OrderPointRestaurant, int InvoiceCancelRestaurant, bool WriteablePercentDiscount, bool ShowTabAllTable, int? StartQueue, int? EndQueue, int ResetQueue,
            bool QuestionSaveCommodity, bool BeginSearchSales,
            bool ShowPriceBuySales, bool ShowExpireDateInvoiceSales, bool ShowStockInvoiceSales, bool ColorSizeInSalesInvoice,
            bool ShowBarcodeInvoiceSales, bool ShowCodeInvoiceSales, bool ShowUnitInvoiceSales,
            bool ShowLastInvoicesSales, bool FocusCodeSales, bool CommodityPriceHistorySelect, bool UseScale, int ScaleType,
            bool ShowOrderPointSales, int? OrderPointSales, int InvoiceCancelSales, bool ProductionOrderWithInvoice, int SearchType, int CommoditySearchType,
            bool ShowOtherPricesInvoiceBuy, bool QuestionPrintBarcodeBuyInvoice, bool ShowExpireDateInvoiceBuy, bool SaveExpireDate, bool SelectUnitsCommodity,
            bool SalesPriceByBuyPercent, bool SelectProductBuyInvoice, int CalculatePriceType,
            bool CustomMenu, bool ShowPriceInMenu,
            bool SearchByTag, string InvoiceTag1, string InvoiceTag2, string InvoiceTag3, 
            string InvoiceTag4, string InvoiceTag5,
            bool ChangeWareHouse, int InvoiceSalesDefaultWareHouse, int CalculateRemittancePriceType, 
            bool AutoRemittance, bool AutoRecepit, 
            bool NegativeStock, bool SelectOtherWareHouse, bool CalculateStockNumber, bool CalculateStockRial,
            int? WareHouseSalesID, int? WareHouseBuyID,
            bool ClearingPOS, bool MandatoryForClosingCashierAccount, bool SystemVoucherEdit, bool AddDescriptionInvoiceToDocument, bool ReNumberAtf, int ContraryToNature,
            int BankAccountID, int FiscalYear,
            bool QuestionCreateBarcode, bool HasConvertUnitCommodity, 
            bool NoDigitCommodityCode, bool MultiAmountSales, bool InitailAmountSalesCompulsory, bool AddCommodityColorSize, int UpdatePriceSales,
            int? SalesLessBuyPercent, bool SalesLessBuyInvoiceSales, bool SalesLessBuyInvoiceBuy, bool SalesLessBuyCommodity,
            bool AlarmExpireDate, int? ToExpireDate, int? FromExpireDate, int CommodityCodeStart,
            string SalesLevelsCaption1, string SalesLevelsCaption2, string SalesLevelsCaption3, 
            string SalesLevelsCaption4, string SalesLevelsCaption5,
            bool SalesLevels1, bool SalesLevels2, bool SalesLevels3, bool SalesLevels4, bool SalesLevels5,
            int? SalesLevelsCodingMoien0, int? SalesLevelsCodingMoien1, int? SalesLevelsCodingMoien2,
            int? SalesLevelsCodingMoien3, int? SalesLevelsCodingMoien4, int? SalesLevelsCodingMoien5,
            int SalesLevel, bool ShowOtherPrices, int UpdatePriceLevels,
            bool ShowAmountOrginal, bool UpdateAmountOrginal, int? RoundSalesLevel, bool RoundDownSalesLevel,
            int SubscriptionCode, int CompanyCode, int CompanyCodeStart, int PiekCode, int PiekCodeStart, bool UniqueMobile, bool UniqueAddress,bool UniquePerson,
            int DebtAmountSendSMS, int DebtAmountSendSMSSaveInvoice, int DebtAmountSendSMSPayReceive, bool DebtAmountPrint,
            bool SendSMSPerson, bool SendToServerGetScore, bool IsClubMember, bool NotComputeScoreToDebtor,
            decimal? TotalAmountsInvoice, decimal? DiscountPercentCustomer, int DiscountCustomerType,
            int InvoicesListPeriod, int SalesBuyReportsPeriod,
            string BranchName, string BranchNameLatin, string BranchOwner, string BranchGuild,
            string BranchDateEstablishment, string BranchNationalID, string BranchLicense,
            string BranchEconomical, string BranchRegistration, string BranchInsuranceCode,
            string BranchAddress, string BranchTel1, string BranchTel2,
            string BranchMobile, string BranchPostalCode, string BranchProvince,
            string BranchCity, string BranchTelCode,
            string IPBranch, string PortBranch, string IPBranchMain, string PortBranchMain,
            string IPServer, string PortServer, int WSTimerInterval, string WSTypeOfConnection,
            byte[] BranchLogo, Guid? BranchID, int? BranchTafsilID,
            bool InternalClubDiscount,bool ClubDiscountSave,
            decimal? TotalAmountsInvoiceFromFirst, decimal? TotalAmountsInvoiceToFirst, decimal? DiscountPercentCustomerFirst,
            decimal? TotalAmountsInvoiceFromSecond, decimal? TotalAmountsInvoiceToSecond, decimal? DiscountPercentCustomerSecond,
            decimal? TotalAmountsInvoiceFromThird, decimal? TotalAmountsInvoiceToThird, decimal? DiscountPercentCustomerThird,
            decimal? TotalAmountsInvoiceFromFourth, decimal? TotalAmountsInvoiceToFourth, decimal? DiscountPercentCustomerFourth,
            bool InvoiceCommodityBack, bool SaveCustomerByMobile, int CashPaymentAlert)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTSSTG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    #region General

                    cmd.Parameters.AddWithValue("@TSSTGID", (object)TSSTGID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ApplicationType", (object)ApplicationType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountingType", (object)AccountingType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RubyClub", (object)RubyClub ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SepPortionPercent", (object)SepPortionPercent ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@ShowMenuInvoice", (object)ShowMenuInvoice ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@ShowCommodityProduct", (object)ShowCommodityProduct ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowBarcodeSearch", (object)ShowBarcodeSearch ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FixTimeStop", (object)FixTimeStop ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NotShowInvoiceCancel", (object)NotShowInvoiceCancel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowInvoiceDevices", (object)ShowInvoiceDevices ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@Currency", (object)Currency ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CorrectPrice", (object)CorrectPrice ?? DBNull.Value); ;
                    cmd.Parameters.AddWithValue("@QuestionBackup", (object)QuestionBackup ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SelectWithOneClick", (object)SelectWithOneClick ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SectionInvoice", (object)SectionInvoice ?? DBNull.Value);

                    #endregion

                    #region CallerID

                    cmd.Parameters.AddWithValue("@UseCallerID", (object)UseCallerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneDigitsNumber", (object)PhoneDigitsNumber ?? DBNull.Value);

                    #endregion

                    #region SMS

                    cmd.Parameters.AddWithValue("@Usrnme", (object)UserName_SMS ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mesg", (object)Message_SMS ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MesgSub", (object)Message_SMSSubscriptionCode ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@SendSMSInvoice", (object)SendSMSInvoice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SendSMSAccountsReport", (object)SendSMSAccountsReport ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SendSMSSaveInvoice", (object)SendSMSSaveInvoice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SendSMSSubscriptionCode", (object)SendSMSSubscriptionCode ?? DBNull.Value);
                    
                    #endregion

                    #region Invoice

                    #region Info

                    cmd.Parameters.AddWithValue("@InvNumSales", (object)InvoiceNumberManualSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvNumBuy", (object)InvoiceNumberManualBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@InvDateSales", (object)InvoiceDateManualSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvDateBuy", (object)InvoiceDateManualBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@InvNumResetSales", (object)InvoiceNumberResetSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StartSales", (object)InvoiceNumberStartSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvNumResetBuy", (object)InvoiceNumberResetBuy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@StartBuy", (object)InvoiceNumberStartBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@SameCommoddityInNewRowsSales", (object)SameCommoddityInNewRowsSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SameCommoddityInNewRowsBuy", (object)SameCommoddityInNewRowsBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@CommentDetailSales", (object)CommentDetailSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CommentDetailBuy", (object)CommentDetailBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@InvoiceCommodityBack", (object)InvoiceCommodityBack ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@SaveCustomerByMobile", (object)SaveCustomerByMobile ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    #endregion

                    #region ShowInSearch

                    cmd.Parameters.AddWithValue("@ShowStockSales", (object)ShowStockSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowStockBuy", (object)ShowStockBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------
                    cmd.Parameters.AddWithValue("@ShowCommodityCodeSales", (object)ShowCommodityCodeSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowCommodityCodeBuy", (object)ShowCommodityCodeBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@ShowSupplierSales", (object)ShowSupplierSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowSupplierBuy", (object)ShowSupplierBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@ShowExpireDateSales", (object)ShowExpireDateSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowExpireDateBuy", (object)ShowExpireDateBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@ShowWareHouseSales", (object)ShowWareHouseSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowWareHouseBuy", (object)ShowWareHouseBuy ?? DBNull.Value);

                    #endregion

                    #region Financial

                    cmd.Parameters.AddWithValue("@DiscountSales", (object)DiscountPerItemSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountBuy", (object)DiscountPerItemBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@TaxSales", (object)TaxPerItemSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TaxBuy", (object)TaxPerItemBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@TollSales", (object)TollPerItemSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TollBuy", (object)TollPerItemBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    //cmd.Parameters.AddWithValue("@TaxAfDiscountSales", (object)TaxAfterDiscountSales ?? DBNull.Value);
                    //cmd.Parameters.AddWithValue("@TaxAfDiscountBuy", (object)TaxAfterDiscountBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    //cmd.Parameters.AddWithValue("@TaxAfAdditionSales", (object)TaxAfterAdditionSales ?? DBNull.Value);
                    //cmd.Parameters.AddWithValue("@TaxAfAdditionBuy", (object)TaxAfterAdditionBuy ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@TotalDiscountSales", (object)TotalDiscountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalDiscountBuy", (object)TotalDiscountBuy ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TotalTaxSales", (object)TotalTaxSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalTaxBuy", (object)TotalTaxBuy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TaxPercent", (object)TaxPercent ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TotalTollSales", (object)TotalTollSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalTollBuy", (object)TotalTollBuy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TollPercent", (object)TollPercent ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@HasPiek", (object)HasPiek ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PiekPercent", (object)PiekPercent ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@AdditionsSubtractionsSales", (object)AdditionsSubtractionsSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AdditionsSubtractionsBuy", (object)AdditionsSubtractionsBuy ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@RoundSales", (object)RoundSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RoundDownSales", (object)RoundDownSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RoundBuy", (object)RoundBuy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RoundDownBuy", (object)RoundDownBuy ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@InvoiceCredit", (object)InvoiceCredit ?? DBNull.Value);
                    
                    #endregion

                    #region Restaurant Invoice

                    cmd.Parameters.AddWithValue("@ShowPriceBuyRestaurant", (object)ShowPriceBuyRestaurant ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowExpireDateInvRestaurant", (object)ShowExpireDateInvoiceRestaurant ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowStockInvRestaurant", (object)ShowStockInvoiceRestaurant ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowUnitInvRestaurant", (object)ShowUnitInvoiceRestaurant ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@ShowLastInvoicesRestaurant", (object)ShowLastInvoicesRestaurant ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FocusCodeRestaurant", (object)FocusCodeRestaurant ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@ShowOrderPointRestaurant", (object)ShowOrderPointRestaurant ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OrderPointRestaurant", (object)OrderPointRestaurant ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvCancelRestaurant", (object)InvoiceCancelRestaurant ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@WriteablePercentDiscount", (object)WriteablePercentDiscount ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@ShowTabAllTable", (object)ShowTabAllTable ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@StartQueue", (object)StartQueue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EndQueue", (object)EndQueue ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ResetQueue", (object)ResetQueue ?? DBNull.Value);

                    #endregion

                    #region Sales Invoice

                    cmd.Parameters.AddWithValue("@QuestionSaveCommodity", (object)QuestionSaveCommodity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BeginSearchSales", (object)BeginSearchSales ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@ShowPriceBuySales", (object)ShowPriceBuySales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowExpireDateInvSales", (object)ShowExpireDateInvoiceSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowStockInvSales", (object)ShowStockInvoiceSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ColorSizeInSalesInvoice", (object)ColorSizeInSalesInvoice ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@ShowBarcodeInvSales", (object)ShowBarcodeInvoiceSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowCodeInvSales", (object)ShowCodeInvoiceSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowUnitInvSales", (object)ShowUnitInvoiceSales ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@ShowLastInvoicesSales", (object)ShowLastInvoicesSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FocusCodeSales", (object)FocusCodeSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CommodityPriceHistorySelect", (object)CommodityPriceHistorySelect ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UseScale", (object)UseScale ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ScaleType", (object)ScaleType ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@ShowOrderPointSales", (object)ShowOrderPointSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OrderPointSales", (object)OrderPointSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvCancelSales", (object)InvoiceCancelSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProductionOrderWithInvoice", (object)ProductionOrderWithInvoice ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@SearchType", (object)SearchType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CommoditySearchType", (object)CommoditySearchType ?? DBNull.Value);


                    #endregion

                    #region Buy Invoice

                    cmd.Parameters.AddWithValue("@ShowOtherPricesInvBuy", (object)ShowOtherPricesInvoiceBuy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@QuestionPrintBarcodeBuyInvoice", (object)QuestionPrintBarcodeBuyInvoice ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@ShowExpireDateInvBuy", (object)ShowExpireDateInvoiceBuy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SaveExpireDate", (object)SaveExpireDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SelectUnitsCommodity", (object)SelectUnitsCommodity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesPriceByBuyPercent", (object)SalesPriceByBuyPercent ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SelectProductBuyInvoice", (object)SelectProductBuyInvoice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CalPriceType", (object)CalculatePriceType ?? DBNull.Value);

                    #endregion

                    #region Menu

                    cmd.Parameters.AddWithValue("@CustomMenu", (object)CustomMenu ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowPriceInMenu", (object)ShowPriceInMenu ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@SearchByTag", (object)SearchByTag ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvoiceTag1", (object)InvoiceTag1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvoiceTag2", (object)InvoiceTag2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvoiceTag3", (object)InvoiceTag3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvoiceTag4", (object)InvoiceTag4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvoiceTag5", (object)InvoiceTag5 ?? DBNull.Value);

                    #endregion

                    #endregion

                    #region WareHouse
                    
                    cmd.Parameters.AddWithValue("@ChangeWareHouse", (object)ChangeWareHouse ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvoiceSalesDefaultWareHouse", (object)InvoiceSalesDefaultWareHouse ?? DBNull.Value);
                    
                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@CalRemittancePriceType", (object)CalculateRemittancePriceType ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@AutoRemittance", (object)AutoRemittance ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AutoRecepit", (object)AutoRecepit ?? DBNull.Value);
                    //cmd.Parameters.AddWithValue("@ProductOrderType", (object)ProductOrderType ?? DBNull.Value);
                    
                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@NegativeStock", (object)NegativeStock ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SelectOtherWareHouse", (object)SelectOtherWareHouse ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CalStockNumber", (object)CalculateStockNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CalStockRial", (object)CalculateStockRial ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@TWHIDSales", (object)WareHouseSalesID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TWHIDBuy", (object)WareHouseBuyID ?? DBNull.Value);

                    #endregion

                    #region Accounting

                    cmd.Parameters.AddWithValue("@SystemVoucherEdit", (object)SystemVoucherEdit ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AddDescriptionInvoiceToDocument", (object)AddDescriptionInvoiceToDocument ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@ReNumberAtf", (object)ReNumberAtf ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContraryToNature", (object)ContraryToNature ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClearingPOS", (object)ClearingPOS ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@MandatoryForClosingCashierAccount", (object)MandatoryForClosingCashierAccount ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@CashPaymentAlert", (object)CashPaymentAlert ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@TBATID", (object)BankAccountID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Smyr", (object)FiscalYear ?? DBNull.Value);

                    #endregion

                    #region Commodity

                    #region General Commodity

                    cmd.Parameters.AddWithValue("@QuestionCreateBarcode", (object)QuestionCreateBarcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HasConvertUnitCommodity", (object)HasConvertUnitCommodity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NoDigitCommodityCode", (object)NoDigitCommodityCode ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@MultiAmountSales", (object)MultiAmountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InitailAmountSalesCompulsory", (object)InitailAmountSalesCompulsory ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AddCommodityColorSize", (object)AddCommodityColorSize ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@UpdatePriceSales", (object)UpdatePriceSales ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@SalesLessBuyInvSales", (object)SalesLessBuyInvoiceSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLessBuyInvBuy", (object)SalesLessBuyInvoiceBuy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLessBuyCommodity", (object)SalesLessBuyCommodity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLessBuyPercent", (object)SalesLessBuyPercent ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@AlarmExpireDate", (object)AlarmExpireDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ToExpireDate", (object)ToExpireDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FromExpireDate", (object)FromExpireDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CommodityCodeStart", (object)CommodityCodeStart ?? DBNull.Value);
                    
                    #endregion

                    #region SalesLevels

                    cmd.Parameters.AddWithValue("@SalesLevelsCaption1", (object)SalesLevelsCaption1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevelsCaption2", (object)SalesLevelsCaption2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevelsCaption3", (object)SalesLevelsCaption3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevelsCaption4", (object)SalesLevelsCaption4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevelsCaption5", (object)SalesLevelsCaption5 ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@SalesLevels1", (object)SalesLevels1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevels2", (object)SalesLevels2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevels3", (object)SalesLevels3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevels4", (object)SalesLevels4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevels5", (object)SalesLevels5 ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@SalesLevelsCodingMoien0", (object)SalesLevelsCodingMoien0 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevelsCodingMoien1", (object)SalesLevelsCodingMoien1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevelsCodingMoien2", (object)SalesLevelsCodingMoien2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevelsCodingMoien3", (object)SalesLevelsCodingMoien3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevelsCodingMoien4", (object)SalesLevelsCodingMoien4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevelsCodingMoien5", (object)SalesLevelsCodingMoien5 ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@SalesLevel", (object)SalesLevel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShowOtherPrices", (object)ShowOtherPrices ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdatePriceLevels", (object)UpdatePriceLevels ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@ShowAmountOrginal", (object)ShowAmountOrginal ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UpdateAmountOrginal", (object)UpdateAmountOrginal ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@RoundSalesLevel", (object)RoundSalesLevel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RoundDownSalesLevel", (object)RoundDownSalesLevel ?? DBNull.Value);

                    #endregion

                    #endregion

                    #region AccountSide

                    cmd.Parameters.AddWithValue("@SubscriptionCode", (object)SubscriptionCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompanyCode", (object)CompanyCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CompanyCodeStart", (object)CompanyCodeStart ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PiekCode", (object)PiekCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PiekCodeStart", (object)PiekCodeStart ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@UniqueMobile", (object)UniqueMobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UniqueAddress", (object)UniqueAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UniquePerson", (object)UniquePerson ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@DebtAmountSendSMS", (object)DebtAmountSendSMS ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DebtAmountSendSMSSaveInvoice", (object)DebtAmountSendSMSSaveInvoice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DebtAmountSendSMSPayReceive", (object)DebtAmountSendSMSPayReceive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DebtAmountPrint", (object)DebtAmountPrint ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@SendSMSPerson", (object)SendSMSPerson ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@SendToServerGetScore", (object)SendToServerGetScore ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsClubMember", (object)IsClubMember ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NotComputeScoreToDebtor", (object)NotComputeScoreToDebtor ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@InternalClubDiscount", (object)InternalClubDiscount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClubDiscountSave", (object)ClubDiscountSave ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmountsInvoice", (object)TotalAmountsInvoice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercentCustomer", (object)DiscountPercentCustomer ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmountsInvoiceFromFirst", (object)TotalAmountsInvoiceFromFirst ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmountsInvoiceToFirst", (object)TotalAmountsInvoiceToFirst ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercentCustomerFirst", (object)DiscountPercentCustomerFirst ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmountsInvoiceFromSecond", (object)TotalAmountsInvoiceFromSecond ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmountsInvoiceToSecond", (object)TotalAmountsInvoiceToSecond ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercentCustomerSecond", (object)DiscountPercentCustomerSecond ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmountsInvoiceFromThird", (object)TotalAmountsInvoiceFromThird ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmountsInvoiceToThird", (object)TotalAmountsInvoiceToThird ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercentCustomerThird", (object)DiscountPercentCustomerThird ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmountsInvoiceFromFourth", (object)TotalAmountsInvoiceFromFourth ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmountsInvoiceToFourth", (object)TotalAmountsInvoiceToFourth ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercentCustomerFourth", (object)DiscountPercentCustomerFourth ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@DiscountCustomerType", (object)DiscountCustomerType ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@InvoicesListPeriod", (object)InvoicesListPeriod ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesBuyReportsPeriod", (object)SalesBuyReportsPeriod ?? DBNull.Value);

                    #endregion

                    #region Server

                    cmd.Parameters.AddWithValue("@WSTimerInterval", (object)WSTimerInterval ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@WSTypeOfConnection", (object)WSTypeOfConnection ?? DBNull.Value);

                    #endregion

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    #endregion
                }

                string sqlStringInsertBranch = @"BS.IUTBRCH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsertBranch, con))
                {
                    #region InsertUpdate Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    #region Branch

                    cmd.Parameters.AddWithValue("@TBRCHID", (object)TSSTGID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TimeStart", (object)TimeStart ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TimeStop", (object)TimeStop ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Brchnme", (object)BranchName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Brchnmel", (object)BranchNameLatin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchOnw", (object)BranchOwner ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchGld", (object)BranchGuild ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchDtestbl", (object)BranchDateEstablishment ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchNtlID", (object)BranchNationalID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchLcn", (object)BranchLicense ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchEcal", (object)BranchEconomical ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchReg", (object)BranchRegistration ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchIns", (object)BranchInsuranceCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchAdd", (object)BranchAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchTel1", (object)BranchTel1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchTel2", (object)BranchTel2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchMbe", (object)BranchMobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchPslCde", (object)BranchPostalCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchPvnme", (object)BranchProvince ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchCynme", (object)BranchCity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchTelCode", (object)BranchTelCode ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IPBranch", (object)IPBranch ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PortBranch", (object)PortBranch ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IPBranchMain", (object)IPBranchMain ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PortBranchMain", (object)PortBranchMain ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IPServer", (object)IPServer ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PortServer", (object)PortServer ?? DBNull.Value);

                    //--------------------------------------------------------------------------------------

                    cmd.Parameters.AddWithValue("@BranchID", (object)BranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchtfsID", (object)BranchTafsilID ?? DBNull.Value);

                    cmd.Parameters.Add("@Cpgo", SqlDbType.VarBinary).Value = BranchLogo == null ? DBNull.Value : (object)BranchLogo;


                    #endregion

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        public int CheckRunJobSchedule(int Type, string Date, string Time)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRJS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@Type", (object)Type ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Date", (object)Date ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Time", (object)Time ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

      


        #region GetSetting

        public DataSet GetSetting()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSSTG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UNM", DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }




        #region BackupHistory

        #region SaveBackupHistory

        public int InsertBackupHistory(string LocationFile, string DateBackupHistory)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.ITBH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@LoBH", (object)LocationFile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DtBH", (object)DateBackupHistory ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetBackupHistory

        public DataSet GetBackupHistory()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetBackup

        public void GetBackup(string DataBase, string Path, string DateBackup)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = "Backup database " + DataBase + " to disk=" + "'" + Path + "\\" + DateBackup + ".RasisBak" + "'";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 1200;
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        #endregion

        #endregion
        public DataSet GetBranch()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBRCH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UNM", DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetBranchLight()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBRCHL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UNM", DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #endregion

        #region FeildDynamie

        public void InsertUpdateFeildDynamieValue(long ID,
         string Value1, string Value2, string Value3, string Value4, string Value5,
         string Value6, string Value7, string Value8, string Value9, string Value10)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTCDYFDV";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)ID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Value1", (object)Value1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Value2", (object)Value2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Value3", (object)Value3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Value4", (object)Value4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Value5", (object)Value5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Value6", (object)Value6 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Value7", (object)Value7 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Value8", (object)Value8 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Value9", (object)Value9 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Value10", (object)Value10 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        public DataSet GetCommodityFeildDynamicValue(long ID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYFDV";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)ID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        public void UpdateCommodityFeildDynamic(bool Selected1, bool Selected2, bool Selected3, bool Selected4, bool Selected5,
          bool Selected6, bool Selected7, bool Selected8, bool Selected9, bool Selected10,
          string Caption1, string Caption2, string Caption3, string Caption4, string Caption5,
          string Caption6, string Caption7, string Caption8, string Caption9, string Caption10,
          int FelidType1, int FelidType2, int FelidType3, int FelidType4, int FelidType5,
          int FelidType6, int FelidType7, int FelidType8, int FelidType9, int FelidType10)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTCDYFD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@Selected1", (object)Selected1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Selected2", (object)Selected2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Selected3", (object)Selected3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Selected4", (object)Selected4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Selected5", (object)Selected5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Selected6", (object)Selected6 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Selected7", (object)Selected7 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Selected8", (object)Selected8 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Selected9", (object)Selected9 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Selected10", (object)Selected10 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Caption1", (object)Caption1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Caption2", (object)Caption2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Caption3", (object)Caption3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Caption4", (object)Caption4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Caption5", (object)Caption5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Caption6", (object)Caption6 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Caption7", (object)Caption7 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Caption8", (object)Caption8 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Caption9", (object)Caption9 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Caption10", (object)Caption10 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@FelidType1", (object)FelidType1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FelidType2", (object)FelidType2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FelidType3", (object)FelidType3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FelidType4", (object)FelidType4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FelidType5", (object)FelidType5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FelidType6", (object)FelidType6 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FelidType7", (object)FelidType7 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FelidType8", (object)FelidType8 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FelidType9", (object)FelidType9 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FelidType10", (object)FelidType10 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        public DataSet GetCommodityFeildDynamic()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYFD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region SpecialFacilities

        public void InsertUpdateSpecialFacilities(bool PanelCallerID, bool PanelClubCustomerInternal,
            bool PanelManagementPOS, bool PanelManagementDashboard, bool PanelClubCustomerWeb, bool PanelManagementChain,
            bool PanelAtoPaySaveRadinScale, bool PanelInvoiceNumberYearMounth, bool PanelMonnitoringRestaurant, 
            bool PanelKioskWindows, bool PanelAPPOrdering, bool PanelMonitoringPrint)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTSFS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@PnCD", (object)PanelCallerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnCI", (object)PanelClubCustomerInternal ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@PnMPS", (object)PanelManagementPOS ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnMDB", (object)PanelManagementDashboard ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnCW", (object)PanelClubCustomerWeb ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnMCH", (object)PanelManagementChain ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnAPSRS", (object)PanelAtoPaySaveRadinScale ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnInYM", (object)PanelInvoiceNumberYearMounth ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@PnMN", (object)PanelMonnitoringRestaurant ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@PnKW", (object)PanelKioskWindows ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnAO", (object)PanelAPPOrdering ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnMP", (object)PanelMonitoringPrint ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        public DataSet GetSpecialFacilities()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSFS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        //-----------------------------------------------------------------------------------------------



        #region System

        public string GetDateTimeServer()
        {
            string ReturnValue = string.Empty;

            SqlConnection con = null;
            try
            {
                #region Get Data

                con = new SqlConnection(Program.ConString);

                string SqlString = $@"select getdate()";

                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    cmd.CommandTimeout = 300;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    ReturnValue = Shared.ObjectToText(cmd.ExecuteScalar());

                    con.Close();
                }

                #endregion

            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ReturnValue;
        }
        public void InsertVersion(string Version, string Date)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.ITHV";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Vsn", Version);
                    cmd.Parameters.AddWithValue("@Dt", Date);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #region ActiveSystem

        #region GetActiveSystem

        public DataSet GetProcessorId(long ProcessorId)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"ACC.GetPCGID";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PID", ProcessorId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region UpdateActiveCode

        public void ActiveCode(string Key, long ProcessorId)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"ACC.UPCGAC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ace", Key);
                    cmd.Parameters.AddWithValue("@PID", ProcessorId);
                    cmd.Parameters.AddWithValue("@UserId", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        #endregion

        #region InsertValidConnection

        public void InsertValidConnection(long ProcessorId)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"ACC.IPCGVC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PID", (object)ProcessorId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserId", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        #endregion

        #endregion


        //-----------------------------------------------------------------------------------------------

        #region User

        #region SaveUserUpdatePass

        public int InsertUpdateUser(int? UserID, string UserName,
            string Name, string Family, string PersonalCode, string NationalCode,
            string Tel, string Mobile, int UserStatus, string Email, int RoleID)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.ISETR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@UrD", (object)UserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Unme", (object)UserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Upnme", (object)Name ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Upfmly", (object)Family ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ucper", (object)PersonalCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ucmli", (object)NationalCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Utl", (object)Tel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Umbile", (object)Mobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UstD", (object)UserStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ueil", (object)Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RoeD", (object)RoleID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        public int UpdatePass(int? UserID, string PasswordOld, string PasswordNew)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.UESCURP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@UrD", (object)UserID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Usso", (object)PasswordOld ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ussn", (object)PasswordNew ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetUser&AccessLevel

        public DataSet GetUsersByRole(int UserRoleId)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTURLE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserRoleId", UserRoleId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetUserByID(int UserID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTUR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", (object)UserID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetUsers()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTUR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetUserName()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string SqlString = @"SEC.GetTURN";
                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetUserMax(string UserName)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                #region Get Data

                con = new SqlConnection(Program.ConString);
                string SqlString = @"SEC.GetTURNM";
                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    cmd.CommandTimeout = 300;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Unme", UserName);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }
                }

                #endregion
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetUserAll(string UserName, string Password)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                #region Get Data

                con = new SqlConnection(Program.ConString);
                string SqlString = @"SEC.GetTURNA";
                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    cmd.CommandTimeout = 300;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Unme", UserName);
                    cmd.Parameters.AddWithValue("@Uss", Password);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }
                }

                #endregion
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetUsersaAccessLevel(int UserId, int UserRoleId)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTURAL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@UserRoleId", UserRoleId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetUsersaAccessLevelCategory(int CategoryID, string @FeatureCap)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTURALC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Category", CategoryID);
                    cmd.Parameters.AddWithValue("@FeatureCap", (object)FeatureCap ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteAccessLevelUser(int UserId, int UserRoleId)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.DMSECTAL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p1", (object)UserRoleId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p2", (object)UserId ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }
        public int InsertAccessLevelUser(int UserId, int UserRoleId, int FeatureID,
            bool AllowShow, bool AllowAdd, bool AllowEdit, bool AllowDelete)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.ISETAL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@p1", (object)UserId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p2", (object)UserRoleId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p3", (object)FeatureID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p4", (object)AllowShow ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p5", (object)AllowAdd ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p6", (object)AllowEdit ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p7", (object)AllowDelete ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p8", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        #region AccessLevelNew

        public int InsertAccessLevelUserNew(int UserId, int UserRoleId, int FeatureID,
            bool AllowShow, bool AllowAdd, bool AllowEdit, bool AllowDelete)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.ISETALN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@UserId", (object)UserId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserRoleId", (object)UserRoleId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FeatureID", (object)FeatureID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AllowShow", (object)AllowShow ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AllowAdd", (object)AllowAdd ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AllowEdit", (object)AllowEdit ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AllowDelete", (object)AllowDelete ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p8", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);


                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        public DataSet GetUsersaAccessLevelNew(int FeatureCategory, int UserId, int UserRoleId)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTURALN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FeatureCategory", (object)FeatureCategory ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserId", (object)UserId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserRoleId", (object)UserRoleId ?? DBNull.Value);


                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GiveAndGetAccessLevelUser(int XAccess, int FeatureCategory, int UserId, int UserRoleId)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTGAGALU";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@XAccess", (object)XAccess ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FeatureCategory", (object)FeatureCategory ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserId", (object)UserId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserRoleId", (object)UserRoleId ?? DBNull.Value);


                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        #endregion

        #endregion

        #endregion

        #region Role

        #region SaveRole

        public int InsertUpdateRole(int? RoleID, string RoleName)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.ISETRLE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@RleD", (object)RoleID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Recp", (object)RoleName ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetRole&AccessLevel

        public DataSet GetRoleByID(int RoleID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTRLE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RleD", (object)RoleID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetRole()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTRLE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RleD", DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetRoleAccessLevel(int UserRoleId)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTRLEAL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserRoleId", UserRoleId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #region GetRole&AccessLevel
        public DataSet GetRoleAccessLevelNew(int FeatureCategory, int UserRoleId)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTRLEALN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FeatureCategory", (object)FeatureCategory ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserRoleId", UserRoleId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        public DataSet GiveAndGetAccessLevelRole(int XAccess, int FeatureCategory, int UserRoleId)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTGAGALR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@XAccess", (object)XAccess ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FeatureCategory", (object)FeatureCategory ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserRoleId", UserRoleId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }    
        #endregion
        #endregion

        #region DeleteRole

        public DataSet CheckRelationRole(int RoleID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.CheckRTRLE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RleD", (object)RoleID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteRole(int RoleID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.DTRLE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RleD", (object)RoleID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Feature

        #region SaveFeature

        public int InsertUpdateFeature(int? FeatureID, string FeatureCaption, string FeatureCaptionLatin,
            int FeatureCategory, bool InsertID)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.IUTFTRE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@FatrD", (object)FeatureID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FeatureCap", (object)FeatureCaption ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FeatureCapLtn", (object)FeatureCaptionLatin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FeatureCategory", (object)FeatureCategory ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InsertID", InsertID);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public int InsertUpdateFeatureCategory(int? FeatureCategory, string FeatureCategoryCaption)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.IUTFTREC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@FeatureCategory", (object)FeatureCategory ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FeatureCategoryCaption", (object)FeatureCategoryCaption ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetFeatures

        public DataSet GetFeatures()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTFTRE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetFeaturesLatin()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTFTREL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetFeatureCategory(int? FeatureCategory)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string SqlString = @"SEC.GetTFTREC";
                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FeatureCategory", (object)FeatureCategory ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #endregion

        #region AccessLevel

        public DataSet GetAccessLevelByFeature(int UserID, int FeatureID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                #region Get Data

                con = new SqlConnection(Program.ConString);
                string SqlString = @"SEC.GetTFTREAL";
                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    cmd.CommandTimeout = 300;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", UserID);
                    cmd.Parameters.AddWithValue("@FatrD", FeatureID);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }
                }

                #endregion
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetAccessLevelByLoadCondition(int UserID, int LoadShow)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                #region Get Data

                con = new SqlConnection(Program.ConString);
                string SqlString = @"SEC.GetTFTREALC";
                using (SqlCommand cmd = new SqlCommand(SqlString, con))
                {
                    cmd.CommandTimeout = 300;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", UserID);
                    cmd.Parameters.AddWithValue("@LShw", LoadShow);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }
                }

                #endregion
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region Log

        #region InsertLog

        public void InsertLog(string ClassName, string MethodName, string DoWhat, string Schema,
              int Operation = 0, long ID = 0, long? SanadID = 0, long? RemittanceID = 0)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.ISELT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@UrD", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);
                    cmd.Parameters.AddWithValue("@Cnme", (object)ClassName ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@Mdnme", (object)MethodName ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@Dht", (object)DoWhat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Op", (object)Operation ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ID", (object)ID ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@WorkstationIP", (object)UserInfo.IpAddress ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@Schema", (object)Schema ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SanadID", (object)SanadID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RemittanceID", (object)RemittanceID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }


        #endregion

        #region GetLog

        public DataSet GetLogLoginExit(int? IdUser, string DateFrom, string DateTo)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTLGLE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", (object)IdUser ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateFrom", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTo", (object)DateTo ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        public DataSet GetLoginExitLast(int? IdUser)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTLGLEL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", (object)IdUser ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetLogOperation(int? IdUser, string DateFrom, string DateTo, int? InvoiceType)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTLGOP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", (object)IdUser ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateFrom", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTo", (object)DateTo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InvoiceType", (object)InvoiceType ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetLogOperationDetail(int? IdUser, string DateFrom, string DateTo, long? RowID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTLGOPD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", (object)IdUser ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateFrom", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTo", (object)DateTo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RowID", (object)RowID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetLogAccounting(int? IdUser, string DateFrom, string DateTo, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTLGAC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", (object)IdUser ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateFrom", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTo", (object)DateTo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetLogBase(int? IdUser, string DateFrom, string DateTo, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTLGBS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", (object)IdUser ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateFrom", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTo", (object)DateTo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetLogSetting(int? IdUser, string DateFrom, string DateTo, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTLGST";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", (object)IdUser ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateFrom", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTo", (object)DateTo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetLogWareHouse(int? IdUser, string DateFrom, string DateTo, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.GetTLGWH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UrD", (object)IdUser ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateFrom", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTo", (object)DateTo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteLog

        public void DeleteLog()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SEC.DTLG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region OpeningImportFromExcel

        public bool ImportCommodity(DataTable ds)
        {
            bool ValueRetern = false;

            SqlConnection con = null;
            try
            {
                #region Get Data

                con = new SqlConnection(Program.ConString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 300;
                    con.Open();

                    cmd.CommandText = @"BS.DTCDYExcel";
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.Text;

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                    {
                        bulkCopy.DestinationTableName = "BS.TCDYExcel";
                        bulkCopy.ColumnMappings.Add("ردیف", "TCDYID");
                        bulkCopy.ColumnMappings.Add("بارکد", "Cclr");
                        bulkCopy.ColumnMappings.Add("نام کالا", "Cne");
                        bulkCopy.ColumnMappings.Add("قیمت فروش", "Cfe");
                        bulkCopy.ColumnMappings.Add("قیمت خرید", "Glkhrd");
                        bulkCopy.ColumnMappings.Add("واحد", "UtD");
                        bulkCopy.ColumnMappings.Add("کد کالا", "Ccoe"); 
                        bulkCopy.ColumnMappings.Add("نوع کالا", "Ctye");
                        bulkCopy.ColumnMappings.Add("نقطه سفارش", "Cssh");
                        bulkCopy.WriteToServer(ds);
                    }

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                    {
                        bulkCopy.DestinationTableName = "BS.TCDYTANR";
                        bulkCopy.ColumnMappings.Add("ردیف", "TCDYID");
                        bulkCopy.ColumnMappings.Add("شناسه انبار", "TANRID");
                        bulkCopy.ColumnMappings.Add("موجودی", "CgspyEft");
                        bulkCopy.ColumnMappings.Add("بهای خرید", "BahayeKharid");
                        bulkCopy.ColumnMappings.Add("سال مالی", "FiscalYear");
                        bulkCopy.ColumnMappings.Add("نقطه سفارش", "Cssh");
                        bulkCopy.WriteToServer(ds);
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"BS.InsertINTOTCDYFromTCDYExcel";
                    cmd.ExecuteNonQuery();

                    con.Close();

                    ValueRetern = true;
                }

                #endregion
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ValueRetern;
        }
        public bool ImportPerson(DataSet ds)
        {
            bool ValueRetern = false;

            SqlConnection con = null;
            try
            {
                #region Get Data

                con = new SqlConnection(Program.ConString);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                    {
                        bulkCopy.DestinationTableName = "BS.TPSN";
                        bulkCopy.ColumnMappings.Add("ردیف", "TPSNID");
                        bulkCopy.ColumnMappings.Add("نام", "Psnnme");
                        bulkCopy.ColumnMappings.Add("نام خانوادگی", "Psnfy");
                        bulkCopy.ColumnMappings.Add("نام شرکت", "Cpnme");
                        bulkCopy.ColumnMappings.Add("کد ملی", "Psnncde");
                        bulkCopy.ColumnMappings.Add("کد اشتراک", "Subcde");
                        bulkCopy.ColumnMappings.Add("موبایل", "PsnMbe");
                        bulkCopy.ColumnMappings.Add("کد تلفن", "PsnTelCde");
                        bulkCopy.ColumnMappings.Add("تلفن", "PsnTel");
                        bulkCopy.ColumnMappings.Add("آدرس", "Adrs");
                        bulkCopy.ColumnMappings.Add("پیش فرض", "Dflt");
                        bulkCopy.WriteToServer(ds.Tables[0]);
                    }

                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                    {
                        bulkCopy.DestinationTableName = "BS.TPSNRL";
                        bulkCopy.ColumnMappings.Add("ردیف", "TPSNID");
                        bulkCopy.ColumnMappings.Add("نوع طرف حساب", "TPSNRLID");
                        bulkCopy.ColumnMappings.Add("مانده حساب", "Amrmn");
                        bulkCopy.ColumnMappings.Add("نوع مانده", "Tyrmn");
                        bulkCopy.WriteToServer(ds.Tables[0]);
                    }

                    con.Close();

                    ValueRetern = true;
                }

                string sqlStringInsert = @"BS.ITPSNTFOP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }

                #endregion
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ValueRetern;
        }

        #endregion

        //-----------------------------------------------------------------------------------------------


        #region Unit

        #region SaveUnit

        public int InsertUpdateUnit(int? UnitID, string UnitName, string UnitTitle, int UnitStatus, bool IsDecimal)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTUIT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Untnme", (object)UnitName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Unttnme", (object)UnitTitle ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UntstD", (object)UnitStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsDecimal", (object)IsDecimal ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetUnit

        public DataSet GetUnitByID(int UnitID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTUIT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetUnit(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTUIT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TUITID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteUnit

        public DataSet CheckRelationUnit(int UnitID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTUIT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteUnit(int UnitID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTUIT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Group

        #region SaveGroup

        public int InsertUpdateGroup(int? GroupID, int? GroupCode, string GroupName, int? GroupType, int GroupStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gcde", (object)GroupCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gnme", (object)GroupName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gtye", (object)GroupType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GstD", (object)GroupStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetGroup

        public DataSet GetGroupByID(int GroupID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetGroup(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TGRPID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public int GetGroupCode()
        {
            int CodeReturn = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTGRPCDE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.ExecuteNonQuery();

                    CodeReturn = Shared.Val(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return CodeReturn;
        }

        #endregion

        #region DeleteGroup

        public DataSet CheckRelationGroup(int GroupID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteGroup(int GroupID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region SubGroup

        #region SaveSubGroup

        public int InsertUpdateSubGroup(int? SubGroupID, int? SubGroupCode, string SubGroupName, string SubGroupType, int SubGroupStatus,
            string PrinterName1, string PrintLabel1, string PrinterName2, string PrintLabel2, string PrinterName3, string PrintLabel3)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTSGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sgcde", (object)SubGroupCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sgnme", (object)SubGroupName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sgtye", (object)SubGroupType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SgstD", (object)SubGroupStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Pnme1", (object)PrinterName1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnLabel1", (object)PrintLabel1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Pnme2", (object)PrinterName2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnLabel2", (object)PrintLabel2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Pnme3", (object)PrinterName3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnLabel3", (object)PrintLabel3 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetSubGroup

        public DataSet GetSubGroupByID(int SubGroupID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetSubGroup(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSGRPID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public int GetSubGroupCode()
        {
            int CodeReturn = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSGRPCDE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.ExecuteNonQuery();

                    CodeReturn = Shared.Val(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return CodeReturn;
        }

        #endregion

        #region DeleteSubGroup

        public DataSet CheckRelationSubGroup(int SubGroupID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTSGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteSubGroup(int SubGroupID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTSGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Color

        #region SaveColor

        public int InsertUpdateColor(int? ColorID, string Color)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTColor";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@ColorID", (object)ColorID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ColorName", (object)Color ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetColor

        public DataSet GetColorByID(int ColorID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTColor";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ColorID", (object)ColorID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetColor(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTColor";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ColorID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteColor

        public DataSet CheckRelationColor(int ColorID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTColor";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ColorID", (object)ColorID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteColor(int ColorID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTColor";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ColorID", (object)ColorID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Size

        #region SaveSize

        public int InsertUpdateSize(int? SizeID, string Size)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTSize";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@SizeID", (object)SizeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SizeName", (object)Size ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetSize

        public DataSet GetSizeByID(int SizeID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSize";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SizeID", (object)SizeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetSize(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSize";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SizeID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteSize

        public DataSet CheckRelationSize(int SizeID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTSize";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SizeID", (object)SizeID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteSize(int SizeID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTSize";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SizeID", (object)SizeID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Shape

        #region SaveShape

        public int InsertUpdateShape(int? ShapeID, string ShapeName, int ShapeStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTSHP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TSHPID", (object)ShapeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Shnme", (object)ShapeName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShstD", (object)ShapeStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetShape

        public DataSet GetShapeByID(int ShapeID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSHP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TSHPID", SqlDbType.Int).Value = ShapeID;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = 0;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetShape(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSHP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSHPID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteShape

        public DataSet CheckRelationShape(int ShapeID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTSHP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSHPID", (object)ShapeID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteShape(int ShapeID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTSHP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSHPID", (object)ShapeID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region PackType

        #region SavePackType

        public int InsertUpdatePackType(int? PackTypeID, string PackTypeName, int PackTypeStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTPTE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TPTEID", (object)PackTypeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ptynme", (object)PackTypeName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PtystD", (object)PackTypeStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetPackType

        public DataSet GetPackTypeByID(int PackTypeID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPTE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPTEID", (object)PackTypeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPackType(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPTE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPTEID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeletePackType

        public DataSet CheckRelationPackType(int PackTypeID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTPTE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPTEID", (object)PackTypeID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeletePackType(int PackTypeID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTPTE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPTEID", (object)PackTypeID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Alert

        #region SaveAlert

        public int InsertUpdateAlert(int? AlertID, string Alert, string AlertType, int AlertStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTALT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TALTID", (object)AlertID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Alt", (object)Alert ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Altye", (object)AlertType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AltstD", (object)AlertStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetAlert

        public DataSet GetAlertByID(int AlertID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTALT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TALTID", (object)AlertID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetAlert(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTALT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TALTID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteAlert

        public DataSet CheckRelationAlert(int AlertID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTALT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TALTID", (object)AlertID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteAlert(int AlertID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTALT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TALTID", (object)AlertID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Info

        #region SaveInfo

        public int InsertUpdateInfo(int? InfoID, string Info, string InfoType, int InfoStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTINF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TINFID", (object)InfoID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Inf", (object)Info ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Inftye", (object)InfoType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InfstD", (object)InfoStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetInfo

        public DataSet GetInfoByID(int InfoID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTINF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINFID", (object)InfoID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetInfo(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTINF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINFID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteInfo

        public DataSet CheckRelationInfo(int InfoID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTINF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINFID", (object)InfoID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteInfo(int InfoID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTINF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINFID", (object)InfoID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region MethodUse

        #region SaveMethodUse

        public int InsertUpdateMethodUse(int? MethodUseID, string MethodUse, string MethodUseType, int MethodUseStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTMTU";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TMTUID", (object)MethodUseID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mtu", (object)MethodUse ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mtutye", (object)MethodUseType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MtustD", (object)MethodUseStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetMethodUse

        public DataSet GetMethodUseByID(int MethodUseID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTMTU";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TMTUID", (object)MethodUseID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetMethodUse(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTMTU";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TMTUID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteMethodUse

        public DataSet CheckRelationMethodUse(int MethodUseID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTMTU";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TMTUID", (object)MethodUseID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteMethodUse(int MethodUseID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTMTU";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TMTUID", (object)MethodUseID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Brand

        #region SaveBrand

        public int InsertUpdateBrand(int? BrandID, string BrandName, string BrandCountry, string BrandType,
            int BrandStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTBRND";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TBRNDID", (object)BrandID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Brnd", (object)BrandName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("Brncnt", (object)BrandCountry ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Brntye", (object)BrandType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrnstD", (object)BrandStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetBrand

        public DataSet GetBrandByID(int BrandID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBRND";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBRNDID", (object)BrandID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetBrand(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBRND";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBRNDID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);


                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteBrand

        public DataSet CheckRelationBrand(int BrandID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTBRND";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBRNDID", (object)BrandID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteBrand(int BrandID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTBRND";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBRNDID", (object)BrandID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Manufacturer

        #region SaveManufacturer

        public int InsertUpdateManufacturer(int? ManufacturerID, string ManufacturerName, string ManufacturerCountry, string ManufacturerType,
            int ManufacturerStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTMNF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TMNFID", (object)ManufacturerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mnfnme", (object)ManufacturerName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mnfcnt", (object)ManufacturerCountry ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mnftye", (object)ManufacturerType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MnfstD", (object)ManufacturerStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetManufacturer

        public DataSet GetManufacturerByID(int ManufacturerID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTMNF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TMNFID", (object)ManufacturerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);


                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetManufacturer(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTMNF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TMNFID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteManufacturer

        public DataSet CheckRelationManufacturer(int ManufacturerID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTMNF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TMNFID", (object)ManufacturerID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteManufacturer(int ManufacturerID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTMNF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TMNFID", (object)ManufacturerID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Specialty

        #region SaveSpecialty

        public int InsertUpdateSpecialty(int? SpecialtyID, int? SpecialtyCode, string SpecialtyName, int SpecialtyStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTSPC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TSPCID", (object)SpecialtyID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Spcde", (object)SpecialtyCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Spcnme", (object)SpecialtyName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SpcstD", (object)SpecialtyStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetSpecialty

        public DataSet GetSpecialtyByID(int SpecialtyID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSPC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSPCID", (object)SpecialtyID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetSpecialty(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSPC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSPCID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteSpecialty

        public DataSet CheckRelationSpecialty(int SpecialtyID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTSPC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSPCID", (object)SpecialtyID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteSpecialty(int SpecialtyID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTSPC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSPCID", (object)SpecialtyID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Level

        #region SaveLevel

        public int InsertUpdateLevel(int? LevelID, int? LevelCode, string LevelName, int LevelStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTLVL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TLVLID", (object)LevelID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Lvlcde", (object)LevelCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Lvlnme", (object)LevelName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LvlstD", (object)LevelStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetLevel

        public DataSet GetLevelByID(int LevelID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTLVL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TLVLID", (object)LevelID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetLevel(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTLVL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TLVLID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteLevel

        public DataSet CheckRelationLevel(int LevelID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTLVL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TLVLID", (object)LevelID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteLevel(int LevelID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTLVL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TLVLID", (object)LevelID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region AdditionsSubtractions

        #region SaveAdditionsSubtractions

        public int InsertUpdateAdditionsSubtractions(int? AdditionsSubtractionsID, string AdditionsSubtractionsName, decimal? Price,
            decimal? Percent, bool IsAdditions, int AdditionsStatus, bool Default)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTADNSTN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TADNSTNID", (object)AdditionsSubtractionsID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cptn", (object)AdditionsSubtractionsName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prcnt", (object)Percent ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prc", (object)Price ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsAddtn", (object)IsAdditions ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AddtnstD", (object)AdditionsStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dflt", (object)Default ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetAdditionsSubtractions

        public DataSet GetAdditionsSubtractionsDefault(bool IsAdditions)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTADNSTNDF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IsAddtn", (object)IsAdditions ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetAdditionsSubtractions(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTADNSTN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TADNSTNID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetAdditionsSubtractionsByID(int AdditionsSubtractionsID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTADNSTN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TADNSTNID", (object)AdditionsSubtractionsID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteAdditionsSubtractions

        public void DeleteAdditionsSubtractionsList(int AdditionsSubtractionsID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTADNSTNL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TADNSTNID", (object)AdditionsSubtractionsID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region Person

        #region SavePerson

        public long InsertUpdatePerson(long? PersonID, string PersonName, string PersonFamily, string PersonNationalCode,
            string FatherName, string PersonTelCode, string PersonTel, string PersonMobile, string TafsilyCode,
            string SubscriptionCode, string Birthdate, string MarriageDate, int PersonStatus, string SexType, string MaritalStatus,
            string CompanyName, string CompanyCode, string CompanyTelCode, string CompanyTel, 
            decimal? DiscountPercent, string Comment,
            string ProvinceName, string CityName, string Address, string CodePosti, string FaxCode, string FaxNumber,
            string Email, string RegisterNumber, string EconomicalNumber, string PersonType, decimal? CreditLimit, 
            decimal? AmountRemained, string TypeRemained, decimal? AmountRemainedSup, string TypeRemainedSup,
            decimal? AmountRemainedDoc, string TypeRemainedDoc, decimal? AmountRemainedPiek, string TypeRemainedPiek,
            decimal? AmountRemainedVisitor, string TypeRemainedVisitor, decimal? AmountRemainedEmployee, string TypeRemainedEmployee,
            decimal? AmountRemainedOtherPeople, string TypeRemainedOtherPeople,
            string CEOName, string CEOTelCode, string CEOTel, string CEOMobile,
            string FinancialName, string FinancialTelCode, string FinancialTel, string FinancialMobile,
            bool Default, string Viscde, bool DefaultPiek, string PiekCode, decimal? PiekPercent,
            bool IsCustomer, bool IsSupplier, bool IsPiek, bool IsVisitor, bool IsEmployee, bool IsOtherPeople,
            bool UniqueMobile, bool UniqueAddress, int SubscriptionCodeType, int CompanyCodeType, int PiekCodeType, out long TafsilyID)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTPSN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TPSNID", (object)PersonID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Psnnme", (object)PersonName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Psnfy", (object)PersonFamily ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Psnncde", (object)PersonNationalCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fthnme", (object)FatherName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PsnTelCde", (object)PersonTelCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PsnTel", (object)PersonTel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PsnMbe", (object)PersonMobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tfycde", (object)TafsilyCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Subcde", (object)SubscriptionCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Psnbdt", (object)Birthdate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Margdt", (object)MarriageDate ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@PsnstD", (object)PersonStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sxtye", (object)SexType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Marst", (object)MaritalStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Cpnme", (object)CompanyName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cpcde", (object)CompanyCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CpTelCde", (object)CompanyTelCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CpTel", (object)CompanyTel ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Disprc", (object)DiscountPercent ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cmt", (object)Comment ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Pvnme", (object)ProvinceName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cynme", (object)CityName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Adrs", (object)Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cdpst", (object)CodePosti ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FxCde", (object)FaxCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fxno", (object)FaxNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Eml", (object)Email ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Rgtno", (object)RegisterNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ecocde", (object)EconomicalNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prstye", (object)PersonType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Crtlmt", (object)CreditLimit ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Amrmn", (object)AmountRemained ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tyrmn", (object)TypeRemained ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Amrmnsup", (object)AmountRemainedSup ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tyrmnsup", (object)TypeRemainedSup ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Amrmnpk", (object)AmountRemainedPiek ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tyrmnpk", (object)TypeRemainedPiek ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Amrmnvs", (object)AmountRemainedVisitor ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tyrmnvs", (object)TypeRemainedVisitor ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@Amrmnem", (object)AmountRemainedEmployee ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@Tyrmnem", (object)TypeRemainedEmployee ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Amrmnop", (object)AmountRemainedOtherPeople ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tyrmnop", (object)TypeRemainedOtherPeople ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@CEOnme", (object)CEOName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CEOTelCde", (object)CEOTelCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CEOTel", (object)CEOTel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CEOMbe", (object)CEOMobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fncnme", (object)FinancialName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FncTelCde", (object)FinancialTelCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FncTel", (object)FinancialTel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FncMbe", (object)FinancialMobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dflt", (object)Default ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Viscde", (object)Viscde ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Dfltpk", (object)DefaultPiek ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Pkcde", (object)PiekCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PkPrc", (object)PiekPercent ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    //cmd.Parameters.AddWithValue("@Tfype", enumTafsilyType.TarafHesab);

                    cmd.Parameters.Add("@TafsilyID", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@IsCus", (object)IsCustomer ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsSup", (object)IsSupplier ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsPiek", (object)IsPiek ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsVis", (object)IsVisitor ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsEmp", (object)IsEmployee ?? DBNull.Value); 
                    cmd.Parameters.AddWithValue("@IsOthP", (object)IsOtherPeople ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@UnqMle", (object)UniqueMobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UnqAdss", (object)UniqueAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Subcdetye", (object)SubscriptionCodeType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("Cpcdetye", (object)CompanyCodeType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("Pkcdetye", (object)PiekCodeType ?? DBNull.Value);
                    

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);
                    TafsilyID = Shared.ValInt64(cmd.Parameters["@TafsilyID"].Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }



        public long ImportPersonExcel(long? PersonID, string Name, string Family,
            string CompanyName, string Code, string SubscriptionCode, string Mobile, string TelphoneCode,
            string Telphone, string Address, decimal? AmountRemained, string TypeRemained, bool Default, 
            int Subcdetye, bool UnqAdss, bool UnqMle, bool IsCus, bool IsSup, bool IsPiek, bool IsVis, bool IsEmp
            )
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTPSNEXL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TPSNID", (object)PersonID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Psnnme", (object)Name ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Psnfy", (object)Family ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cpnme", (object)CompanyName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Psnncde", (object)Code ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Subcde", (object)SubscriptionCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PsnMbe", (object)Mobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PsnTelCde", (object)TelphoneCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PsnTel", (object)Telphone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Adrs", (object)Address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Amrmn", (object)AmountRemained ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tyrmn", (object)TypeRemained ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dflt", (object)Default ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UnqMle", (object)UnqMle ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UnqAdss", (object)UnqAdss ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Subcdetye", (object)Subcdetye ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsCus", (object)IsCus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsSup", (object)IsSup ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsEmp", (object)IsEmp ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsVis", (object)IsVis ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsPiek", (object)IsPiek ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);
                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }


        #endregion

        #region GetPerson

        public long GetPersoniDByType(long? PersonID, bool @IsNext)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNIDTYP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ID", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TPSNID", (object)PersonID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsNext", (object)IsNext ?? DBNull.Value);

                    ID = Shared.ValInt64(cmd.ExecuteScalar());

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public DataSet GetPersonByID(long PersonID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPSNID", (object)PersonID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TPSNRLID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPerson(int? TPSNRLID, bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPSNID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@TPSNRLID", (object)TPSNRLID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonLoad(long? TPSNID, int? TPSNRLID, bool IsActive, int? PageIndex, int? PageSize)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNLd";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPSNID", (object)TPSNID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TPSNRLID", (object)TPSNRLID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageIndex", (object)PageIndex ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageSize", (object)PageSize ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonSearch(string MySearch, int? TPSNRLID, int? PageIndex, int? PageSize)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNSCH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MySearch", (object)MySearch ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TPSNRLID", (object)TPSNRLID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageIndex", (object)PageIndex ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageSize", (object)PageSize ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonByNationalCode(string NationalCode)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNBN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Psnncde", (object)NationalCode ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonByInsuranceCardCode(string InsuranceCardCode)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNBI";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Incrcde", (object)InsuranceCardCode ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonByMedicalSystemCode(long MedicalSystemCode)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNBM";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Mdsycde", (object)MedicalSystemCode ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonBySubscriptionCode(string SubscriptionCode)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNSUBC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Subcde", (object)SubscriptionCode ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonByMobile(string Mobile)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNMBL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PsnMbe", (object)Mobile ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonByCompanyCode(string CompanyCode)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNCOCD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Cpcde", (object)CompanyCode ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonByLevel(int LevelID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNLVL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TLVLID", (object)LevelID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetDefaultPerson()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetDfTPSN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonAlarmBirthDate(string Date)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetATPSNBD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Date", (object)Date ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonAlarmMarriageDate(string Date)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetATPSNMD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Date", (object)Date ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetPersonRole

        public DataSet GetPersonRole(long PersonID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNRL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPSNID", (object)PersonID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetPersonStatus

        public DataSet GetPersonStatus()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetLastSubscriptionCode

        public long GetLastSubscriptionCode()
        {
            long SubscriptionCode = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNSUB";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Check Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.Add("@SubscriptionCode", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    SubscriptionCode = Shared.ValInt64(cmd.Parameters["@SubscriptionCode"].Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return SubscriptionCode;
        }

        #endregion

        #region GetLastCompanyCode
        public int GetCompanyCodeCount()
        {
            int IDReturn = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNCPC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.ExecuteNonQuery();

                    IDReturn = Shared.Val(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return IDReturn;
        }
        public long GetLastCompanyCode()
        {
            long SubscriptionCode = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNCOC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Check Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.Add("@CompanyCode", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    SubscriptionCode = Shared.ValInt64(cmd.Parameters["@CompanyCode"].Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return SubscriptionCode;
        }

        #endregion

        #region GetLastPiekCode
        public int GetPiekCodeCount()
        {
            int IDReturn = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNPKC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.ExecuteNonQuery();

                    IDReturn = Shared.Val(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return IDReturn;
        }
        public long GetLastPiekCode()
        {
            long SubscriptionCode = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNPKCO";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Check Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.Add("@PiekCode", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    SubscriptionCode = Shared.ValInt64(cmd.Parameters["@PiekCode"].Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return SubscriptionCode;
        }

        #endregion

        #region CheckIfPersonUsed

        public int CheckIfPersonUsed(int FiscalYear, long PersonID)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.CheckIfPayerUsed";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Check Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@SalMali", (object)FiscalYear ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TPYRID", (object)PersonID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region DeletePerson

        public bool CheckRelationPerson(long PersonID, out string ReturnMessage)
        {
            bool ReturnValue = false;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTPSN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReturnMessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@TPSNID", (object)PersonID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ReturnMessage = Shared.ObjectToText(cmd.Parameters["@ReturnMessage"].Value);

                    con.Close();

                    if (!string.IsNullOrEmpty(ReturnMessage)) ReturnValue = true;

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ReturnValue;
        }
        public void DeletePerson(long PersonID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTPSN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPSNID", (object)PersonID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #region Piek

        public DataSet GetDefaultPiek()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetDfTPSNPK";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPersonByPiekCode(string PiekCode)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNPCOD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Pkcde", (object)PiekCode ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        public DataSet GetPersonByVisCde(string VisCde)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNVCOD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@VisCde", (object)VisCde ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region SaveCredit

        public int InsertCredit(long TPSNID, decimal Credit, string Date)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.ITPSNCRDT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TPSNID", (object)TPSNID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Credit", (object)Credit ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Date", (object)Date ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region DeleteCredit

        public void DeleteCredits(long TPSNID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTPSNCRDT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPSNID", (object)TPSNID ?? DBNull.Value);


                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        #endregion

        #region GetCredit

        public DataSet GetCreditByID(long TPSNID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPSNCRDT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPSNID", (object)TPSNID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region Commodity

        #region SaveCommodity

        public long InsertUpdateCommodity(long? CommodityID, string Barcode, string CommodityCode, string CommodityName,
            int CommodityType, int CommodityStatus, int? GroupID, int? SubGroupID, int? UnitID, 
            int? WareHouseID, long? SubblierID, string ExpireDate,
            decimal? AmountBuy, decimal? AmountSales, decimal? AmountSalesPriority2,
            decimal? AmountSales1, decimal? AmountSales2, decimal? AmountSales3, decimal? AmountSales4, decimal? AmountSales5,
            decimal? Discount, decimal? DiscountPercent, decimal? TaxPercent, decimal? TollPercent,
            int? UnitID2, int? UnitID3, decimal? Coefficient2, decimal? Coefficient3, decimal? AmountSalesUnit2, decimal? AmountSalesUnit3,
            int? UnitIDBuyPack, decimal? CoefficientBuyPack, decimal? AmountBuyPack,
            bool AccountTax, decimal? Stock, bool AccountStock, decimal? OrderPoint,
            string Shortcut, int? BrandID, string Color, string Size, string Model, string Serial, string PropertyNumber, 
            string IranCode, decimal? Length, decimal? Width, decimal? Height, decimal? Weight, string Comment, byte[] Picture)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTCDY";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cbrc", (object)Barcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ccde", (object)CommodityCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cnme", (object)CommodityName ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Ctye", (object)CommodityType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CstD", (object)CommodityStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TWHID", (object)WareHouseID ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@TSUPID", (object)SubblierID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Expdt", (object)ExpireDate ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Camtby", (object)AmountBuy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl", (object)AmountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CamtslPrty2", (object)AmountSalesPriority2 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Camtsl1", (object)AmountSales1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl2", (object)AmountSales2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl3", (object)AmountSales3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl4", (object)AmountSales4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl5", (object)AmountSales5 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Cdis", (object)Discount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cdisprc", (object)DiscountPercent ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctxprc", (object)TaxPercent ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctlprc", (object)TollPercent ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TUITID2", (object)UnitID2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TUITID3", (object)UnitID3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cof2", (object)Coefficient2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cof3", (object)Coefficient3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CamtslU2", (object)AmountSalesUnit2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CamtslU3", (object)AmountSalesUnit3 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TUITIDbypk", (object)UnitIDBuyPack ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cofbypk", (object)CoefficientBuyPack ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtbypk", (object)AmountBuyPack ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Actx", (object)AccountTax ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Stk", (object)Stock ?? DBNull.Value);
                    
                    cmd.Parameters.AddWithValue("@Acstk", (object)AccountStock ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Orpnt", (object)OrderPoint ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Shcut", (object)Shortcut ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TBRNDID", (object)BrandID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Clr", (object)Color ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Siz", (object)Size ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mdl", (object)Model ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Serl", (object)Serial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prop", (object)PropertyNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Irncde", (object)IranCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Lgth", (object)Length ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Wth", (object)Width ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Hth", (object)Height ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Wgth", (object)Weight ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cmt", (object)Comment ?? DBNull.Value);
                    cmd.Parameters.Add("@Pic", SqlDbType.VarBinary).Value = Picture == null ? DBNull.Value : (object)Picture;

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }


        public long ImportCommodityExcel(long? CommodityID, string Barcode, string CommodityCode, string CommodityName,
           int CommodityType, int? UnitID, int? WareHouseID, decimal? PurchasePrice, decimal? AmountBuy, decimal? AmountSales, decimal? Stock, decimal? OrderPoint, int FiscalYear)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTCDYEXL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cbrc", (object)Barcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ccde", (object)CommodityCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cnme", (object)CommodityName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)CommodityType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TWHID", (object)WareHouseID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PurchasePrice", (object)PurchasePrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtby", (object)AmountBuy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl", (object)AmountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Stk", (object)Stock ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Orpnt", (object)OrderPoint ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FiscalYear", (object)FiscalYear ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();
                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }

            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }


        public long UpdateCommodity(long? CommodityID, int? CommodityStatus, int? GroupID,int? SubGroupID, int? UnitID,
            decimal? AmountSales, decimal? Discount, decimal? DiscountPercent, decimal? TaxPercent, string Code,
            int? AccountTax, int? BrandID, int? UnitIDBuyPack, decimal? CoefficientBuyPack, int? AccountStock,
            long? SupplierID, string ExpireDate, int? OrderPoint) 
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTCDYBE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@CstD", (object)CommodityStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Camtsl", (object)AmountSales ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Cdis", (object)Discount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cdisprc", (object)DiscountPercent ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctxprc", (object)TaxPercent ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Ccde", (object)Code ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("Actx", (object)AccountTax ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TBRNDID", (object)BrandID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TUITIDbypk", (object)UnitIDBuyPack ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cofbypk", (object)CoefficientBuyPack ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Acstk", (object)AccountStock ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TSUPID", (object)SupplierID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Expdt", (object)ExpireDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Orpnt", (object)OrderPoint ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        public long UpdateCommoditySalesLevels(long? CommodityID, decimal? AmountSales1, decimal? AmountSales2,
            decimal? AmountSales3, decimal? AmountSales4, decimal? AmountSales5, bool ClearAmmount)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTCDYBESL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Camtsl1", (object)AmountSales1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl2", (object)AmountSales2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl3", (object)AmountSales3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl4", (object)AmountSales4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl5", (object)AmountSales5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClearAmmount", (object)ClearAmmount ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region UpdateCommodity

        public long UpdateCommodityName(long? CommodityID, string CommodityName)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTCDYBEN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cnme", (object)CommodityName ?? DBNull.Value);


                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public long UpdateCommodityBuyAmount(long? CommodityID, decimal? AmountBuy)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTCDYBEB";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtby", (object)AmountBuy ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public long UpdateCommoditySalesAmount(long? CommodityID, decimal? AmountSales,
            decimal? AmountSales1, decimal? AmountSales2, decimal? AmountSales3, decimal? AmountSales4, decimal? AmountSales5)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTCDYBES";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl", (object)AmountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl1", (object)AmountSales1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl2", (object)AmountSales2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl3", (object)AmountSales3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl4", (object)AmountSales4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl5", (object)AmountSales5 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public long UpdateCommodityStock(long? CommodityID, decimal? Stock)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTCDYBESK";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Stk", (object)Stock?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public void UpdateInstantInventory(int FiscalYear)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UpdateInstantInventory";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Update Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SalMali", (object)FiscalYear ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }
        public decimal UpdateInstantInventoryPerKala(long TCDYID, int WareHouseID, int FiscalYear, string Date)
        {
            decimal Stock = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UpdateInstantInventoryPerKala";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Decimal);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@ID", (object)TCDYID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AnbarID", (object)WareHouseID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalMali", (object)FiscalYear ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tarikh", (object)Date ?? DBNull.Value);

                    Stock = Shared.ValDecimal(cmd.ExecuteScalar());

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return Stock;
        }

        #endregion

        #region GetCommodity

        public long GetCommodityiDByType(long? CommodityID, bool @IsNext, int? Type)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYIDTYP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ID", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsNext", (object)IsNext ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    ID = Shared.ValInt64(cmd.ExecuteScalar());

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public DataSet GetCommodity(long? CommodityID, bool IsActive, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDY";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommoditySearch(string MySearch, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYSCH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MySearch", (object)MySearch ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityByID(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYID";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);
                    cmd.Parameters.AddWithValue("@Ctye", DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public int GetIDUserCommodity(long CommodityID)
        {
            int IDReturn = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYIDUser";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    IDReturn = Shared.Val(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return IDReturn;
        }
        public DataSet GetCommodityNOID(long CommodityID, bool IsActive, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYNID";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetService(long? CommodityID, bool IsActive, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYSV";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        //-----------------------------------------------------------------------------------------------
        public DataSet GetCommodityLoadSelect(bool IsActive, int? Type, int? WareHouseID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYLDSLT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TWHID", (object)WareHouseID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityLoadSelectCheckUpdate(bool IsActive, int? Type, int? GroupID, int? SubGroupID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYLDSLTCU";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityCopy(bool IsActive, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYCpy";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityCopyNOID(long CommodityID, bool IsActive, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYCpyNID";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        //-----------------------------------------------------------------------------------------------
        public int GetCommodityCodeCount()
        {
            int IDReturn = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYCMC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.ExecuteNonQuery();

                    IDReturn = Shared.Val(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return IDReturn;
        }
        public string GetCommodityCode(int? GroupID, int? SubGroupID)
        {
            DataSet ds = new DataSet();
            string CodeReturn = string.Empty;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYCDE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion

                    CodeReturn = Shared.ObjectToText(ds.Tables[0].Rows[0][0]);
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return CodeReturn;
        }
        //-----------------------------------------------------------------------------------------------
        public int GetTypeCommodity(long CommodityID)
        {
            int TypeReturn = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYTYP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ID", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    TypeReturn = Shared.Val(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return TypeReturn;
        }
        //-----------------------------------------------------------------------------------------------
        public DataSet GetCommodityUnit(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYUIT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityUnitBuy(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYUITB";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public decimal GetSalesAmountCommodity(long? CommodityID, int SalesLevel)
        {
            decimal SalesAmount = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYSLAM";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ID", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevel", (object)SalesLevel ?? DBNull.Value);

                    SalesAmount = Shared.ValDecimal(cmd.ExecuteScalar());

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return SalesAmount;
        }
        //-----------------------------------------------------------------------------------------------
        public DataSet GetCommodityBatchEdit(bool IsActive, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYBE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetBatchInsertStockOpening(int FiscalYear)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYIBSOP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FiscalYear", (object)FiscalYear ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        //-----------------------------------------------------------------------------------------------
        public DataSet GetCommodityByBarcode(string CommodityBarcode, bool boolBarcode4_13,
            int? Type, int? WareHouseID = null)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"OP.GetTCDYBC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ccde", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cbrc", (object)CommodityBarcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Barcode4_13", (object)boolBarcode4_13 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TWHID", (object)WareHouseID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityByBarcodeInvoice(string CommodityBarcode, long RowID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"OP.GetTCDYBCINV";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ccde", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cbrc", (object)CommodityBarcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RowID", (object)RowID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        //-----------------------------------------------------------------------------------------------
        public DataSet GetCommodityByPersonID(long PersonID, bool IsActive, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"OP.GetTCDYPSN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPSNID", (object)PersonID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        //-----------------------------------------------------------------------------------------------
        public DataSet GetCommodityAlarmExpireDate(int? FromDate, int? ToDate)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetATCDYED";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FromDate", (object)FromDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ToDate", (object)ToDate ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        #endregion

        #region GetCommodityInteractions

        public DataSet GetCommodityInteractions(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYI";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetCommodityRelevant

        public DataSet GetCommodityRelevant(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetCommoditySimilar

        public DataSet GetCommoditySimilar(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetCommodityMethodUse

        public DataSet GetCommodityMethodUse(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYMU";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetCommodityAlert

        public DataSet GetCommodityAlert(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYAL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteCommodity

        public bool CheckRelationCommodity(long CommodityID, out string ReturnMessage)
        {
            bool ReturnValue = false;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTCDY";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReturnMessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ReturnMessage = Shared.ObjectToText(cmd.Parameters["@ReturnMessage"].Value);

                    con.Close();

                    if (!string.IsNullOrEmpty(ReturnMessage)) ReturnValue = true;

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ReturnValue;
        }
        public void DeleteCommodity(long CommodityID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTCDY";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #region CopyCommodity

        public void CopyCommodity(int? UnitID, decimal? AmountSales, decimal? PackageQuantity, DataTable dtCopy)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UCTCDY";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl", (object)AmountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Pkqty", (object)PackageQuantity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Copy", dtCopy);
                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region SaveMultiBarcodes

        public int InsertMultiBarcodes(long CommodityID, string Barcode)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IBTBCD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Bcde", (object)Barcode ?? DBNull.Value);


                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region DeleteMultiBarcodes

        public void DeleteBarcodes(long CommodityID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTBCD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);


                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        #endregion

        #region GetBarcode

        public DataSet GetBarcodeAllNotByID(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBCDA";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetBarcodeByID(long? CommodityID, int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBCD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetCode

        public DataSet CheckUniqueBarcode(string Barcode)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckUTBCD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Barcode", (object)Barcode ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet CheckUniqueCode(string Code)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckUTCDYCD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Code", (object)Code ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region SaveWareHouseCommodity

        public void InsertUpdateWareHouseCommodity(long CommodityID, int WareHouseID, decimal? Stock, decimal? PurchasePrice, decimal? OrderPoint, int FiscalYear)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTCDYTANR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    //WH.IUTWHCDY
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TWHID", (object)WareHouseID ?? DBNull.Value);
              
                    cmd.Parameters.AddWithValue("@StkOpening", (object)Stock ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PurchasePrice", (object)PurchasePrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Orpnt", (object)OrderPoint ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FiscalYear", (object)FiscalYear ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        public void InsertUpdateWareHouseCommodityBatchEdit(long CommodityID, int WareHouseID, long? SupplierID,
            decimal? Stock, decimal? OrderPoint, string ExpireDate)//, int? WareHouseDefault)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.IUTWHCDYBE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TWHID", (object)WareHouseID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TSUPID", (object)SupplierID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Stk", (object)Stock ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Orpnt", (object)OrderPoint ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Expdt", (object)ExpireDate ?? DBNull.Value);
                    //cmd.Parameters.AddWithValue("@Dflt", (object)WareHouseDefault ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        #endregion

        #region DeleteWareHouseCommodity

        public void DeleteWareHouseCommodity(long CommodityID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTCDYTANR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    //WH.DTWHCDY
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }

        #endregion

        #region GetWareHouseCommodity

        public DataSet GetWareHouseCommodityByID(long CommodityID, int FiscalYear)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYTANR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FiscalYear", (object)FiscalYear ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region Product

        #region SaveProduct

        public long InsertProductHead(long ProductID, long CommodityID, decimal ProductionNumber)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUConstructionFormula";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    //BS.ITPDUTO
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@PID", (object)ProductID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TolidiNumber", (object)ProductionNumber ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public long InsertProduct(long ProductID, long CommodityID, decimal Quantity, int ProductStatus, string Method)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTPDUT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@PID", (object)ProductID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cvlue", (object)Quantity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Pists", (object)ProductStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Pidsc", (object)Method ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetProduct

        public DataSet LoadConstructionFormula(long? ProductID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.LoadConstructionFormula";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", (object)ProductID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetProduct(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPDUT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteProduct

        public void DeleteProduct(long CommodityID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTPDUT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PID", (object)CommodityID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }
        public bool CheckRelationProduct(long ProductID, out string ReturnMessage)
        {
            bool ReturnValue = false;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckCanDeleteProduct";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReturnId", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@ID", (object)ProductID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ReturnMessage = Shared.ObjectToText(cmd.Parameters["@ReturnId"].Value);

                    con.Close();

                    if (!string.IsNullOrEmpty(ReturnMessage)) ReturnValue = true;

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ReturnValue;
        }
        public void DeleteConstructionFormula(long ProductID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DeleteConstructionFormula";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PID", (object)ProductID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #region SaveProductOrder

        public long InsertProductOrder(long CommodityID, string ProductOrder)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.ITPDUTO";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prorder", (object)ProductOrder ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #endregion

        #region GetBuyOrdersList

        public DataSet GetBuyOrdersListSupplier(long CommodityID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"OP.GetINVCBLS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetCommodityOpening

        public DataSet GetCommodityOpening(long? CommodityID, int FiscalYear)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYO";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FiscalYear", (object)FiscalYear ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetWareHouseOpening()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetWHOP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityWareHouseOpening()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.GetTWHCDYO";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region BarcodeLablePattern

        #region SaveBarcodeLablePattern

        public int InsertUpdateBarcodeLablePattern(int? TPBSGID, string PatternBarcodeName, int? WidthBarcode,
            int? HeightBarcode, int? WidthPage, int? HeightPage, int? HorizentalGap, int? VerticalGap,
            int? LeftMargins, int? TopMargins, int? Columns, int? Rows, string FileName, string PrinterName,
            int PrinterType, int PrintCount, bool PrintInvoiceOut)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTPBSG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TPBSGID", (object)TPBSGID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TPBSN", (object)PatternBarcodeName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@WdthBcd", (object)WidthBarcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HghtBcd", (object)HeightBarcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HrizGap", (object)HorizentalGap ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VrGap", (object)VerticalGap ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@WdthPg", (object)WidthPage ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HghtPg", (object)HeightPage ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Lmgin", (object)LeftMargins ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tmgin", (object)TopMargins ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Clmn", (object)Columns ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Rws", (object)Rows ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReportFileName", (object)FileName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrinterName", (object)PrinterName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrinterType", (object)PrinterType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrintCount", (object)PrintCount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PrintInvoiceOut", (object)PrintInvoiceOut ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetBarcodeLablePattern

        public DataSet GetBarcodeLablePattern(int? BarcodeLablePatternID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPBSG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPBSGID", (object)BarcodeLablePatternID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetBarcodeLablePattern(bool PrintInvoiceOut)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPBSGLBLOT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PrintInvoiceOut", (object)PrintInvoiceOut ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteBarcodeLablePattern

        public void DeleteBarcodeLablePattern(int TPBSGID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTPBSG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPBSGID", (object)TPBSGID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region CommodityGenerateBarcode&Print

        public void UpdateCommodityBarcodeGenerate(long? CommodityID, int? GroupID, int? SubGroupID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTCDYGB";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }
        public DataSet GetCommodityBarcodeGenerate(int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYBG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityBarcodeInvoice(DataTable dt)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYBGI";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Items",dt);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityBarcodePrint(long? CommodityID, string NameRestaurantShop,
            string Tel1RestaurantShop, string Currency, string LablePrinterName)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYBP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NameRestaurantShop", (object)NameRestaurantShop ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tel1RestaurantShop", (object)Tel1RestaurantShop ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Currency", (object)Currency ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LablePrinterName", (object)LablePrinterName ?? DBNull.Value);
                    
                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GroupDiscount

        #region SaveGroupDiscount

        public long InsertUpdateGroupDiscount(long? CommodityGroupDiscountID, string CaptionGroupDiscount, int GroupID, int SubGroupID,
            long CommodityID, int GroupDiscountStatus, string DateFrom, string DateTo, 
            bool SalesLevel0, bool SalesLevelPriority2, bool SalesLevel1, bool SalesLevel2, bool SalesLevel3, bool SalesLevel4, bool SalesLevel5, 
            decimal? DiscountPercent0, decimal? DiscountPercentPriority2, decimal? DiscountPercent1, decimal? DiscountPercent2,
            decimal? DiscountPercent3,  decimal? DiscountPercent4, decimal? DiscountPercent5,
            decimal? Discount0, decimal? DiscountPriority2, decimal? Discount1, decimal? Discount2,
            decimal? Discount3, decimal? Discount4, decimal? Discount5)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTCDYGD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYGDID", (object)CommodityGroupDiscountID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cpgd", (object)CaptionGroupDiscount ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CgdstD", (object)GroupDiscountStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DtFrm", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DtTo", (object)DateTo ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@SalesLevel0", (object)SalesLevel0 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevelPriority2", (object)SalesLevelPriority2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevel1", (object)SalesLevel1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevel2", (object)SalesLevel2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevel3", (object)SalesLevel3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevel4", (object)SalesLevel4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevel5", (object)SalesLevel5 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@DiscountPercent0", (object)DiscountPercent0 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercentPriority2", (object)DiscountPercentPriority2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercent1", (object)DiscountPercent1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercent2", (object)DiscountPercent2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercent3", (object)DiscountPercent3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercent4", (object)DiscountPercent4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPercent5", (object)DiscountPercent5 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Discount0", (object)Discount0 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiscountPriority2", (object)DiscountPriority2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Discount1", (object)Discount1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Discount2", (object)Discount2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Discount3", (object)Discount3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Discount4", (object)Discount4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Discount5", (object)Discount5 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetGroupDiscount

        public DataSet GetGroupDiscountByID(long? GroupDiscountID, string Caption)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYGD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYGDID", (object)GroupDiscountID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cpgd", (object)Caption ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TGRPID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSGRPID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@TCDYID", DBNull.Value); 
                    cmd.Parameters.AddWithValue("@DtFrm", DBNull.Value);
                    cmd.Parameters.AddWithValue("@DtTo", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetGroupDiscount(bool IsActive, string Captiont, int? GroupID, int? SubGroupID,
            long? CommodityID, string DateFrom, string DateTo)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYGD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYGDID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cpgd", (object)Captiont ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);;
                    cmd.Parameters.AddWithValue("@DtFrm", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DtTo", (object)DateTo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetGroupDiscountInInvoice(int? SalesLevel, int? GroupID, int? SubGroupID,
            long? CommodityID, string Date)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYGDINV";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SalesLevel", (object)SalesLevel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value); ;
                    cmd.Parameters.AddWithValue("@Dt", (object)Date ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCaptionGroupDiscount()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetCGD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteGroupDiscount

        public bool CheckUniqueGroupDiscount(string CaptionGroupDiscount)
        {
            bool IsExist = false;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckUTCDYGD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@Cpgd", (object)CaptionGroupDiscount ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    IsExist = Shared.ObjectToBool(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return IsExist;
        }
        public void DeleteGroupDiscount(long GroupDiscountID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTCDYGD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYGDID", (object)GroupDiscountID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region WareHouse

        #region SaveWareHouse

        public int InsertUpdateWareHouse(int? WareHouseID, int? WareHouseCode, string WareHouseName, int WareHouseStatus,
            string WareHouseComment, bool WareHouseDefaultSales, bool WareHouseDefaultBuy,
            bool WareHouseDefaultBack, int? MoeinID, int? GroupID, int? KolID, int? UserWareHouseID, int? SectionID, out long TafsilyID)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.IUTWH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TWHID", (object)WareHouseID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Whcde", (object)WareHouseCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Whnme", (object)WareHouseName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@WhstD", (object)WareHouseStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Whcmt", (object)WareHouseComment ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Whdftsl", (object)WareHouseDefaultSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Whdftby", (object)WareHouseDefaultBuy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Whdftbk", (object)WareHouseDefaultBack ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MoeinID", (object)MoeinID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GroupID", (object)GroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@KolID", (object)KolID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSECID", (object)SectionID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@UserWHID", (object)UserWareHouseID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    //cmd.Parameters.AddWithValue("@Tfype", enumTafsilyType.Anbar);

                    cmd.Parameters.Add("@TafsilyID", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;
                    TafsilyID = Shared.ValInt64(cmd.Parameters["@TafsilyID"].Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetWareHouseStatus

        public DataSet GetWareHouseStatus()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.GetTWHS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetWareHouse

        public DataSet GetWareHouseByID(int WareHouseID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.GetTWH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TWHID", (object)WareHouseID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetWareHouse(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.GetTWH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TWHID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetDefaultWareHouseSales(int? SectionID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.GetDfTWH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Whdftsl", true);
                    cmd.Parameters.AddWithValue("@Whdftby", false);
                    cmd.Parameters.AddWithValue("@Whdftbk", false);
                    cmd.Parameters.AddWithValue("@TSECID", (object)SectionID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetDefaultWareHouseBuy(int? SectionID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.GetDfTWH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Whdftsl", false);
                    cmd.Parameters.AddWithValue("@Whdftby", true);
                    cmd.Parameters.AddWithValue("@Whdftbk", false);
                    cmd.Parameters.AddWithValue("@TSECID", (object)SectionID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetDefaultWareHouseBack(int? SectionID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.GetDfTWH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Whdftsl", false);
                    cmd.Parameters.AddWithValue("@Whdftby", false);
                    cmd.Parameters.AddWithValue("@Whdftbk", true);
                    cmd.Parameters.AddWithValue("@TSECID", (object)SectionID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public int GetWareHouseCode()
        {
            int CodeReturn = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.GetTWHCDE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.ExecuteNonQuery();

                    CodeReturn = Shared.Val(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return CodeReturn;
        }

        #endregion

        #region DeleteWareHouse

        public bool CheckRelationWareHouse(int WareHouseID, out string ReturnMessage)
        {
            bool ReturnValue = false;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.CheckRTWH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReturnMessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@TWHID", (object)WareHouseID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ReturnMessage = Shared.ObjectToText(cmd.Parameters["@ReturnMessage"].Value);

                    con.Close();

                    if (!string.IsNullOrEmpty(ReturnMessage)) ReturnValue = true;

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ReturnValue;
        }
        public void DeleteWareHouse(int WareHouseID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.DTWH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TWHID", (object)WareHouseID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Shelf

        #region SaveShelf

        public int InsertUpdateShelf(int? ShelfID, string ShelfName, int ShelfStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.IUTSHF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TSHFID", (object)ShelfID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Shfnme", (object)ShelfName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShfstD", (object)ShelfStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetShelf

        public DataSet GetShelfByID(int ShelfID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.GetTSHF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSHFID", (object)ShelfID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetShelf(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.GetTSHF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSHFID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteShelf

        public DataSet CheckRelationShelf(int ShelfID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.CheckRTSHF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSHFID", (object)ShelfID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteShelf(int ShelfID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.DTSHF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSHFID", (object)ShelfID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region GetGeneralType

        public DataSet GetGeneralType(string Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTGT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Insert Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Gttye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetCountryProvinceCity

        public DataSet GetCountry()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCNT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetProvince()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPCP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCity(string Province)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTPCC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Pnme", (object)Province ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion



        //-----------------------------------------------------------------------------------------------

        #region Insurer

        #region SaveInsurer

        public int InsertUpdateInsurer(int? InsurerID, int? InsurerCode, string InsurerName, int InsurerStatus, string CommitmentType,
            bool PriceCompliance, string PriceComplianceCommitment, int? DrugStoreCode, string DrugStoreContractType,
            string SiteAddress, string SiteUser, string SitePass, long? TerminalNumber, string WebServiceUser,
            string WebServisPass, bool SendAfterPrescription, bool ReviewSerialPrescription, bool Pharmacopoeia,
            bool DedicatedConditions)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.IUTINS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TINSID", (object)InsurerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Inscde", (object)InsurerCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Insnme", (object)InsurerName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InsstD", (object)InsurerStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Comtye", (object)CommitmentType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prccom", (object)PriceCompliance ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prccomcp", (object)PriceComplianceCommitment ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Dgstcde", (object)DrugStoreCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dgstcnttye", (object)DrugStoreContractType ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Staddr", (object)SiteAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Stusr", (object)SiteUser ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Stpss", (object)SitePass ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Trmnum", (object)TerminalNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Wbsrvusr", (object)WebServiceUser ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Wbsrvpss", (object)WebServisPass ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Snafprs", (object)SendAfterPrescription ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Rvsrprs", (object)ReviewSerialPrescription ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Pharm", (object)Pharmacopoeia ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dedcon", (object)DedicatedConditions ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetInsurer

        public DataSet GetInsurerByID(int InsurerID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTINS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSID", (object)InsurerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetInsurer(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTINS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteInsurer

        public DataSet CheckRelationInsurer(int InsurerID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.CheckRTINS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSID", (object)InsurerID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteInsurer(int InsurerID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.DTINS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSID", (object)InsurerID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Insurance

        #region SaveInsurance

        public int InsertUpdateInsurance(int? InsuranceID, int? InsurerID, int? InsuranceHIX, int? InsuranceCode,
            int InsuranceStatus, int? DrugStoreCode, string DrugStoreContractType, int? NumberDigitPrescription,
            decimal? GeneralPhysician, decimal? SpecialPhysician, decimal? SubSpecialPhysician, decimal? Dintistry,
            decimal? Obstetrics, int? BankID, string BankAccountNumber, string TelCode, string Tel,
            int? InternalNumber, string Comment)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.IUTINSC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TINSCID", (object)InsuranceID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TINSID", (object)InsurerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TINSHXID", (object)InsuranceHIX ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Inscde", (object)InsuranceCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@InscstD", (object)InsuranceStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Dgstinscde", (object)DrugStoreCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dgstcnttye", (object)DrugStoreContractType ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Numdgpc", (object)NumberDigitPrescription ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Genphy", (object)GeneralPhysician ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Spephy", (object)SpecialPhysician ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Subspephy", (object)SubSpecialPhysician ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dent", (object)Dintistry ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Obst", (object)Obstetrics ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@BkD", (object)BankID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Anm", (object)BankAccountNumber ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TelCde", (object)TelCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tel", (object)Tel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Intnum", (object)InternalNumber ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Cmt", (object)Comment ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetInsurance

        public DataSet GetInsuranceByID(int InsuranceID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTINSC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSCID", (object)InsuranceID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetInsurance(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTINSC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSCID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteInsurance

        public bool CheckRelationInsurance(int InsuranceID, out string ReturnMessage)
        {
            bool ReturnValue = false;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.CheckRTINSC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReturnMessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@TINSCID", (object)InsuranceID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ReturnMessage = Shared.ObjectToText(cmd.Parameters["@ReturnMessage"].Value);

                    con.Close();

                    if (!string.IsNullOrEmpty(ReturnMessage)) ReturnValue = true;

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ReturnValue;
        }

        public void DeleteInsurance(int InsuranceID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.DTINSC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSCID", (object)InsuranceID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Supplementary

        #region SaveSupplementary

        public int InsertUpdateSupplementary(int? SupplementaryID, int? TechnicalRightID, string SupplementaryName,
            bool CustomerShare, decimal? PercentCustomerShare, bool NonInsurance, decimal? PercentNonInsurance,
            bool TechnicalRight, decimal? PercentTechnicalRight, bool Mechanisation, decimal? PercentMechanisation,
            bool DifferenceReplace, decimal? PercentDifferenceReplace, bool DifferenceInsurance, decimal? PercentDifferenceInsurance,
            decimal? GeneralPhysician, decimal? SpecialPhysician, decimal? SubSpecialPhysician, decimal? Dintistry,
            decimal? Obstetrics, decimal? TechnicalRightMaximum, bool DrugCommitment)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.IUTINSUP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TINSUPID", (object)SupplementaryID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TECRID", (object)TechnicalRightID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Insupnme", (object)SupplementaryName ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Cusshr", (object)CustomerShare ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cusshrdis", (object)PercentCustomerShare ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Noins", (object)NonInsurance ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Noinsdis", (object)PercentNonInsurance ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Tecrgh", (object)TechnicalRight ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tecrghdis", (object)PercentTechnicalRight ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Mecrgh", (object)Mechanisation ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mecrghdis", (object)PercentMechanisation ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Difrep", (object)DifferenceReplace ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Difrepdis", (object)PercentDifferenceReplace ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Difins", (object)DifferenceInsurance ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Difinsdis", (object)PercentDifferenceInsurance ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Genphy", (object)GeneralPhysician ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Spephy", (object)SpecialPhysician ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Subspephy", (object)SubSpecialPhysician ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dent", (object)Dintistry ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Obst", (object)Obstetrics ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tecrighmx", (object)TechnicalRightMaximum ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Dgcom", (object)DrugCommitment ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetSupplementary

        public DataSet GetSupplementaryByID(int SupplementaryID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTINSUP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSUPID", (object)SupplementaryID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetSupplementary()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTINSUP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSUPID", DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteSupplementary

        public DataSet CheckRelationSupplementary(int SupplementaryID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.CheckRTINSUP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSUPID", (object)SupplementaryID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteSupplementary(int SupplementaryID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.DTINSUP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSUPID", (object)SupplementaryID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region PrescriptionType

        #region SavePrescriptionType

        public int InsertUpdatePrescriptionType(int? PrescriptionTypeID, int? InsuranceID, string PrescriptionType,
            decimal? PercentShareOrganization, int? VerifyCode, string FileName, int PrescriptionTypeStatus, int? FilePT, int? FileCK,
            int? NumDays, bool Mechanisation, bool TechnicalRightOne, bool TechnicalRightInsurance, bool CalInsuranceTechnicalRight,
            decimal? MaximumTechnicalRight, long? DrugCommodityNameIDDaily, long? DrugCommodityNameIDNightly)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.IUTPT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TPTID", (object)PrescriptionTypeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TINSCID", (object)InsuranceID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tptnme", (object)PrescriptionType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prcshrorg", (object)PercentShareOrganization ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Vercde", (object)VerifyCode ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Flenme", (object)FileName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TptstD", (object)PrescriptionTypeStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@FlePT", (object)FilePT ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FleCK", (object)FileCK ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Numday", (object)NumDays ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Mec", (object)Mechanisation ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tectghone", (object)TechnicalRightOne ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Tecrghins", (object)TechnicalRightInsurance ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Clprce", (object)CalInsuranceTechnicalRight ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Mxtecrght", (object)MaximumTechnicalRight ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TCDYIDD", (object)DrugCommodityNameIDDaily ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TCDYIDN", (object)DrugCommodityNameIDNightly ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetPrescriptionType

        public DataSet GetPrescriptionTypeByID(int PrescriptionTypeID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTPT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPTID", (object)PrescriptionTypeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TINSCID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetPrescriptionType(bool IsActive, int? InsuranceID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTPT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPTID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@TINSCID", (object)InsuranceID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeletePrescriptionType

        public DataSet CheckRelationPrescriptionType(int PrescriptionTypeID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.CheckRTPT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPTID", (object)PrescriptionTypeID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeletePrescriptionType(int PrescriptionTypeID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.DTPT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPTID", (object)PrescriptionTypeID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region HIX

        #region SaveHIXSetting

        public int InsertUpdateHIXSetting(int? HIXSettingID, string WebService, int? DrugStoreID,
            int? HIXID, int SendType)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.IUTHXS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@THXSID", (object)HIXSettingID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Wbsrvusr", (object)WebService ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DgstID", (object)DrugStoreID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HXID", (object)HIXID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Sndtye", (object)SendType ?? DBNull.Value); ;

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetHIXSetting

        public DataSet GetHIXSetting()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTHXS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetSendHIX(bool IsAll, string DateFrom, string DateTo)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetSHX";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SendHIX", 0);
                    cmd.Parameters.AddWithValue("@IsAll", (object)IsAll ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateFrom", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTo", (object)DateTo ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #endregion

        #region TechnicalRight

        #region SaveTechnicalRight

        public int InsertUpdateTechnicalRight(int? TechnicalRightID, string TechnicalRightType,
            decimal? PriceFrom, decimal? PriceTo, decimal? Percent, decimal? Amount, int? NumberItem,
            int? InsurerID, string TimeFrom, string TimeTo, bool IsHoliday, bool Default)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.IUTECR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TECRID", (object)TechnicalRightID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tecrnme", (object)TechnicalRightType ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Prcfrm", (object)PriceFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prcto", (object)PriceTo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Prcnt", (object)Percent ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Amnt", (object)Amount ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Numitm", (object)NumberItem ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@TINSID", (object)InsurerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Timfrm", (object)TimeFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Timto", (object)TimeTo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ishol", (object)IsHoliday ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tecrdft", (object)Default ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetTechnicalRight

        public DataSet GetTechnicalRightByID(int TechnicalRightID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTECR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TECRID", (object)TechnicalRightID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetTechnicalRight()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTECR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TECRID", DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteTechnicalRight

        public bool CheckRelationTechnicalRight(int TechnicalRightID, out string ReturnMessage)
        {
            bool ReturnValue = false;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.CheckRTECR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ReturnMessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("@TECRID", (object)TechnicalRightID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ReturnMessage = Shared.ObjectToText(cmd.Parameters["@ReturnMessage"].Value);

                    con.Close();

                    if (!string.IsNullOrEmpty(ReturnMessage)) ReturnValue = true;

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ReturnValue;
        }

        public void DeleteTechnicalRight(int TechnicalRightID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.DTECR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TECRID", (object)TechnicalRightID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region GetInsurerStatus

        public DataSet GetInsurerStatus()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.GetTINSS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region FGet

        public DataSet FGetSubGroup()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTSGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetCommodity(int? Type)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTCDY";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetGroup()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetLevel()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTLVL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetManufacturer()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTMNF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetPerson(int? TPSNRLID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTPSN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPSNRLID", (object)TPSNRLID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetPackType()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTPTE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetShape()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTSHP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetSpecialty()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTSPC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetUnit()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTUIT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetBrand()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTBRND";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetColor()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTBRND";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetSize()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.FGetTBRND";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetInsurance()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.FGetTINSC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetPrescriptionType(int? InsuranceID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"INS.FGetTPT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TINSCID", (object)InsuranceID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetShelf()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.FGetTSHF";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetWareHouse()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"WH.FGetTWH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet FGetTable(int? SaloonID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.FGetTTBL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSLNID", (object)SaloonID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region Saloon

        #region SaveSaloon

        public int InsertUpdateSaloon(int? SaloonID, string Saloon, string Comment)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.IUTSLN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TSLNID", (object)SaloonID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Slnnme", (object)Saloon ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cmt", (object)Comment ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetSaloon

        public DataSet GetSaloonByID(int SaloonID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.GetTSLN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSLNID", (object)SaloonID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetSaloon()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.GetTSLN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSLNID", DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteSaloon

        public DataSet CheckRelationSaloon(int SaloonID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.CheckRTSLN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSLNID", (object)SaloonID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteSaloon(int SaloonID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.DTSLN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSLNID", (object)SaloonID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Table

        #region SaveTable

        public int InsertUpdateTable(int? TableID, int? HallID, string TableType, string Table,
            int Capacity, int TableStatus, string Comment, byte[] Picture)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.IUTTBL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TTBLID", (object)TableID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSLNID", (object)HallID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TblTy", (object)TableType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tblnme", (object)Table ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Capcty", (object)Capacity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TblstD", (object)TableStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cmt", (object)Comment ?? DBNull.Value);
                    cmd.Parameters.Add("@Pic", SqlDbType.VarBinary).Value = Picture == null ? DBNull.Value : (object)Picture;

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetTable

        public DataSet GetTableByID(int TableID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.GetTTBL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TTBLID", (object)TableID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSLNID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetTable(bool IsActive, int? SaloonID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.GetTTBL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TTBLID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSLNID", (object)SaloonID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetTableBySaloonID(int SaloonID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.GetTTBLSLN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSLNID", (object)SaloonID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteTable

        public void DeleteTable(int TableID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.DTTBL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TTBLID", (object)TableID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #region TableArrangeNumber

        public void UpdateTableArrangeNumber(string Table, int ArrangeNumber)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.UTTBLARG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Tblnme", (object)Table ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Arngnum", (object)ArrangeNumber ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }
        public DataSet GetTableArrangeNumber(int SaloonID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.GetTTBLARG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSLNID", (object)SaloonID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region GetTableInInvoice

        public DataSet GetTableByStatus(string TableStatus, int? TSLNID, string Date, string TimeFrom, string TimeTo)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.GetTTBLST";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TableStatus", (object)TableStatus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSLNID", (object)TSLNID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Date", (object)Date ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TimeFrom", (object)TimeFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TimeTo", (object)TimeTo ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region FreeTableForReserve

        public DataSet GetFreeTableForReserve(string Date)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.GetTTBLFR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Date", (object)Date ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region BusyTableForReserve

        public DataSet GetBusyTable(int? TableID, string Date)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"RST.GetTTBLBSY";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TTBLID", (object)TableID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Date", (object)Date ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region Menu

        //-----------------------------Group----------------------------------------------------------
        //public int UpdateGroupMenu(int GroupID, int ColorButtonMenu, bool ShowMenu)
        //{
        //    int ID = -1;

        //    SqlConnection con = null;
        //    try
        //    {
        //        con = new SqlConnection(Program.ConString);
        //        string sqlStringInsert = @"BS.UTGRPMN";
        //        using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
        //        {
        //            #region InsertUpdate Data
        //            con.Open();

        //            cmd.CommandTimeout = 300;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
        //            returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
        //            cmd.Parameters.Add(returnParameter);

        //            cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
        //            cmd.Parameters.AddWithValue("@Clr", (object)ColorButtonMenu ?? DBNull.Value);
        //            cmd.Parameters.AddWithValue("@ShwMn", (object)ShowMenu ?? DBNull.Value);

        //            cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

        //            cmd.ExecuteNonQuery();

        //            ID = (int)returnParameter.Value;

        //            con.Close();
        //            #endregion
        //        }
        //    }
        //    finally
        //    {
        //        if (con != null)
        //            con.Dispose();
        //    }

        //    return ID;
        //}
        //public void UpdateGroupArrangeNumber(string GroupName, int ArrangeNumber)
        //{
        //    SqlConnection con = null;
        //    try
        //    {
        //        con = new SqlConnection(Program.ConString);
        //        string sqlStringInsert = @"BS.UTGRPARG";
        //        using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
        //        {
        //            #region InsertUpdate Data
        //            con.Open();

        //            cmd.CommandTimeout = 300;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@Gnme", (object)GroupName ?? DBNull.Value);
        //            cmd.Parameters.AddWithValue("@Arngnum", (object)ArrangeNumber ?? DBNull.Value);

        //            cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

        //            cmd.ExecuteNonQuery();

        //            con.Close();
        //            #endregion
        //        }
        //    }
        //    finally
        //    {
        //        if (con != null)
        //            con.Dispose();
        //    }

        //    return;
        //}
        //public DataSet GetGroupArrangeNumber()
        //{
        //    DataSet ds = new DataSet();

        //    SqlConnection con = null;
        //    try
        //    {
        //        con = new SqlConnection(Program.ConString);
        //        string sqlStringInsert = @"BS.GetTGRPARG";
        //        using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
        //        {

        //            #region Get Data

        //            cmd.CommandTimeout = 300;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
        //            {
        //                sqlAdapter.Fill(ds);
        //            }

        //            #endregion
        //        }
        //    }
        //    finally
        //    {
        //        if (con != null)
        //            con.Dispose();
        //    }

        //    return ds;
        //}
        //public DataSet GetGroupMenu(int? GroupID, bool ShowMenu)
        //{
        //    DataSet ds = new DataSet();

        //    SqlConnection con = null;
        //    try
        //    {
        //        con = new SqlConnection(Program.ConString);
        //        string sqlStringInsert = @"BS.GetTGRPMN";
        //        using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
        //        {

        //            #region Get Data

        //            cmd.CommandTimeout = 300;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);
        //            cmd.Parameters.AddWithValue("@ShwMn", (object)ShowMenu ?? DBNull.Value);

        //            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
        //            {
        //                sqlAdapter.Fill(ds);
        //            }

        //            #endregion
        //        }
        //    }
        //    finally
        //    {
        //        if (con != null)
        //            con.Dispose();
        //    }

        //    return ds;
        //}
        //public DataSet GetCommodityByGroupID(int? GroupID)
        //{
        //    DataSet ds = new DataSet();

        //    SqlConnection con = null;
        //    try
        //    {
        //        con = new SqlConnection(Program.ConString);
        //        string sqlStringInsert = @"BS.GetTCDYMN";
        //        using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
        //        {

        //            #region Get Data

        //            cmd.CommandTimeout = 300;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@TGRPID", (object)GroupID ?? DBNull.Value);

        //            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
        //            {
        //                sqlAdapter.Fill(ds);
        //            }

        //            #endregion
        //        }
        //    }
        //    finally
        //    {
        //        if (con != null)
        //            con.Dispose();
        //    }

        //    return ds;
        //}
        //-----------------------------SubGroup----------------------------------------------------------
        public int UpdateSubGroupMenu(int SubGroupID, int ColorButtonMenu, bool ShowMenu)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTSGRPMN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SgClr", (object)ColorButtonMenu ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShwMn", (object)ShowMenu ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public void UpdateSubGroupArrangeNumber(string SubGroupName, int ArrangeNumber)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTSGRPARG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Sgnme", (object)SubGroupName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Arngnum", (object)ArrangeNumber ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }
        public DataSet GetSubGroupArrangeNumber()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSGRPARG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetSubGroupMenu(int? SubGroupID, bool ShowMenu)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSGRPMN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ShwMn", (object)ShowMenu ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityBySubGroupID(int? SubGroupID, string Tag)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYMN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);
                    cmd.Parameters.AddWithValue("@Tag", (object)Tag ?? DBNull.Value);
                    
                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityByArrangeNumberCustomMenu(bool Status, string Tag)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYMNCUS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IsVisInCusMenu", (object)Status ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tag", (object)Tag ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void UpdateCommodityVisibleInCustomerMenu(long CommodityID, bool Status)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTCDYMNV";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", (object)Status ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }
        public void UpdateCommodityArrangeNumber(long CommodityID, bool CustomMenu, int ArrangeNumber)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTCDYMN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CustomMenu", (object)CustomMenu ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Arngnum", (object)ArrangeNumber ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }
        public decimal GetStockCommodityMenu(long? CommodityID)
        {
            decimal Stock = 0;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYSTMN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Decimal);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    Stock = Shared.ValDecimal(cmd.ExecuteScalar());

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return Stock;
        }
        public DataSet GetStockSalesAmountCommodityMenu(long? CommodityID, int SalesLevel)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTCDYSTMNSA";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SalesLevel", (object)SalesLevel ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void InsertMenuCustom(long CommodityID, long ArrangeNumber)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.ITCDYMC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ArngnumCus", (object)ArrangeNumber ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();


                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }
        public void DeleteMenuCustom()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTCDYMC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return;
        }
        public DataSet GetMenuAccessLevel(int UserId)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSGRPMA";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUser", (object)UserId ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteMenuAccessLevel(int UserId)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTCDYMA";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUser", (object)UserId ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }
        public int InsertMenuAccessLevel(int UserId, int SubGroupID, bool AllowShow, string PrinterName, string PrinterLable)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.ITSGRPMA";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@IdUser", (object)UserId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TSGRPID", (object)SubGroupID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsAcc", (object)AllowShow ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Pnme", (object)PrinterName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PnLabel", (object)PrinterLable ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUserInsert", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region CallerID

        #region SaveCallerID

        public long InsertUpdateCallerID(long? CallerID, int? NumberLine, string PhoneSub1, int? PhoneNumLength,
            string PhoneSub2, string Phone, string Date, string Time, string Status, string WorkstationName)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"CLR.IUTLGCID";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TLGCID", (object)CallerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NumLi", (object)NumberLine ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneSub1", (object)PhoneSub1 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@PhoneNumLength", (object)PhoneNumLength ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneSub2", (object)PhoneSub2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phne", (object)Phone ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@DtCa", (object)Date ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TiCa", (object)Time ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClstD", (object)Status ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@WorkstationName", (object)WorkstationName ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetCallerID

        public DataSet GetCallerIDByPerson(long? PersonID, string Phone)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"CLR.GetTLGCIDPSN";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TPSNID", (object)PersonID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", (object)Phone ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCallerID(string Date)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"CLR.GetTLGCID";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Date", (object)Date ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetReportCallerID(string DateFrom, string DateTo, string TimeFrom, string TimeTo, string Phone,
            string SubscriptionCode, long? PersonID, int? NumberLine, string Status, string WorkstationName)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringGet = @"CLR.GetRTLGCID";
                using (SqlCommand cmd = new SqlCommand(sqlStringGet, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DateFrom", (object)DateFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateTo", (object)DateTo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TimeFrom", (object)TimeFrom ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TimeTo", (object)TimeTo ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Phne", (object)Phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Subcde", (object)SubscriptionCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TPSNID", (object)PersonID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@NumLi", (object)NumberLine ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ClstD", (object)Status ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@WorkstationName", (object)WorkstationName ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region SMS

        #region SaveSettingSMS

        public int InsertUpdateSettingSMS(string UserName, string Password, long MessageCenterNumber)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"MSG.IUTSMSTG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@Usrnme", (object)UserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Pass", (object)Password ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@CntNum", (object)MessageCenterNumber ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.Val(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GeteSettingSMS

        public DataSet GetSeSettingSMS()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"MSG.GetTSMSTG";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region Section

        #region SaveSection

        public int InsertUpdateSection(int? SectionID, int? SectionCode, string SectionName, int SectionStatus)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTSEC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TSECID", (object)SectionID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Seccde", (object)SectionCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Secnme", (object)SectionName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SecstD", (object)SectionStatus ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetSection

        public DataSet GetSectionByID(int SectionID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSEC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSECID", (object)SectionID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetSection(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSEC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSECID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetSectionDefault(int SectionID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"ACC.GetDfTSEC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSECID", (object)SectionID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public int GetSectionCode()
        {
            int CodeReturn = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTSECCDE";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.ExecuteNonQuery();

                    CodeReturn = Shared.Val(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return CodeReturn;
        }

        #endregion

        #region DeleteSection

        public DataSet CheckRelationSection(int SectionID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.CheckRTSEC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSECID", (object)SectionID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public void DeleteSection(int SectionID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTSEC";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TSECID", (object)SectionID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region DiscountPercent

        #region SaveDiscountPercent

        public int InsertDiscountPercent(decimal DiscountPercent)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.ITDDNT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@DiscountPercent", (object)DiscountPercent ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetDiscountPercent

        public DataSet GetDiscountPercent(bool Percent)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTDDNT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Percent", (object)Percent ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteDiscountPercent

        public void DeletDiscountPercent()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTDDNT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region BarcodePattern

        #region SaveBarcodePattern

        public int InsertUpdateBarcodePattern(int? BarcodePatternID, string BarcodePatternName, string BarcodeType,
            int? BarcodeLength, string StartNumber, int? StartReadTotalPrice, int? EndReadTotalPrice,
            int? StartReadCode, int? EndReadCode, int? StartReadWeight, int? EndReadWeight,
            int? StartReadTotalPriceRadin, int? EndReadTotalPriceRadin,
            int? StartReadScaleNumber, int? EndReadScaleNumber, int? StartReadReceiptNumber, int? EndReadReceiptNumber)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTBCP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TBCPID", (object)BarcodePatternID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Bcpnme", (object)BarcodePatternName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TyB", (object)BarcodeType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@LB", (object)BarcodeLength ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SrtNum", (object)StartNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SrtTp", (object)StartReadTotalPrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EdTp", (object)EndReadTotalPrice ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SrtCd", (object)StartReadCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EdCd", (object)EndReadCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SrtWt", (object)StartReadWeight ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EdWt", (object)EndReadWeight ?? DBNull.Value);


                    cmd.Parameters.AddWithValue("@SrtTpR", (object)StartReadTotalPriceRadin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EdTpR", (object)EndReadTotalPriceRadin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SrtScR", (object)StartReadScaleNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EdScR", (object)EndReadScaleNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SrtRnR", (object)StartReadReceiptNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EdRnR", (object)EndReadReceiptNumber ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public int InsertUpdateBarcodePatternLengthTenPrint()
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTBCPLT";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetBarcodePattern

        public DataSet GetBarcodePatternByID(int BarcodePatternID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBCP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBCPID", (object)BarcodePatternID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetBarcodePattern()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBCP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBCPID", DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteBarcodePattern

        public void DeleteBarcodePattern(int BarcodePatternID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTBCP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBCPID", (object)BarcodePatternID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Scale

        public int InsertSettingRadinScale()
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"Radin.ITGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public int InsertSettingSadrScale()
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SCL.ITGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public int InsertSettingMahakScale()
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"Mahak.ITGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public int InsertSettingDibalScale()
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"DIBAL.ITGRP";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region RasisSendDataToBranches

        #region Branch

        #region SaveBranch

        public int InsertUpdateBranch(int? TableBranchID, string BranchName, string BranchOwner, string BranchTel1, string BranchMobile,
            string BranchProvince, string BranchCity, string BranchTelCode, int BranchStatus, Guid? BranchID, string IP, string Port,
            string UserName, string Password, string InitialCatalog, string TimeOut, string DataSource)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.IUTBRCHS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TBRCHID", (object)TableBranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Brchnme", (object)BranchName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchOnw", (object)BranchOwner ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchTel1", (object)BranchTel1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchMbe", (object)BranchMobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchPvnme", (object)BranchProvince ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchCynme", (object)BranchCity ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchTelCode", (object)BranchTelCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchstD", (object)BranchStatus ?? DBNull.Value);


                    cmd.Parameters.AddWithValue("@BranchID", (object)BranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchIP", (object)IP ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchPort", (object)Port ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchUnme", (object)UserName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchUss", (object)Password ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchIncatg", (object)InitialCatalog ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchTmot", (object)TimeOut ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchDtsrc", (object)DataSource ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public int UpdateBranchIPPort(int? TableBranchID, string BranchName, string BranchOwner,
          string BranchProvince, string BranchCity, Guid? BranchID, string IPBranchMain, string PortBranchMain,
          string IPServer, string PortServer)
        {
            int ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.UTBRCHI";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int32);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TBRCHID", (object)TableBranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Brchnme", (object)BranchName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchOnw", (object)BranchOwner ?? DBNull.Value); ;
                    cmd.Parameters.AddWithValue("@BrchPvnme", (object)BranchProvince ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchCynme", (object)BranchCity ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@BranchID", (object)BranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IPBranchMain", (object)IPBranchMain ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PortBranchMain", (object)PortBranchMain ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IPServer", (object)IPServer ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PortServer", (object)PortServer ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = (int)returnParameter.Value;

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public DataSet SetBranchID(string ConnectionString, int UpdateCommoditySelectType)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    //SqlConnection con = null;
                    try
                    {
                        //con = new SqlConnection(ConnectionString);
                        string sqlStringInsert = @"SDB.UTBRCHID";
                        using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                        {

                            #region Get Data

                            cmd.CommandTimeout = 300;
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@UpSctTye", (object)UpdateCommoditySelectType ?? DBNull.Value);

                            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                            {
                                sqlAdapter.Fill(ds);
                            }

                            #endregion
                        }
                    }
                    finally
                    {
                        if (con != null)
                            con.Dispose();
                    }
                }

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void SetBranchesID(int TBRCHID, Guid BranchID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.UTBRCHSID";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBRCHID", (object)TBRCHID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BranchID", (object)BranchID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #region GetBranch

        public DataSet GetBranchsByID(int BranchID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBRCHS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBRCHID", (object)BranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", 0);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetBranch(bool IsActive)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBRCHS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBRCHID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetBranchsConnectionString(string BranchID)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.GetTBRCHSCS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BranchID", (object)BranchID ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteBranch

        public void DeleteBranch(int BranchID)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"BS.DTBRCHS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TBRCHID", (object)BranchID ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #region Commodity

        #region SaveCommodityBranch

        public long InsertUpdateCommodityBranch(string ConnectionString, string SelectType, string Barcode, string CommodityCode,
            string CommodityName, int CommoditType, int? UnitID, decimal? AmountSales, decimal? AmountSales1, decimal? AmountSales2,
            decimal? AmountSales3, decimal? AmountSales4, decimal? AmountSales5)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {

                con = new SqlConnection(ConnectionString);
                string sqlStringInsert = @"SDB.IUTCDYBEBR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@SelectType", (object)SelectType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cbrc", (object)Barcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ccde", (object)CommodityCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cnme", (object)CommodityName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)CommoditType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Camtsl", (object)AmountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl1", (object)AmountSales1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl2", (object)AmountSales2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl3", (object)AmountSales3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl4", (object)AmountSales4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl5", (object)AmountSales5 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public long UpdateCommoditySalesLevels(long? CommodityID, decimal? AmountSales, decimal? AmountSales1,
            decimal? AmountSales2, decimal? AmountSales3, decimal? AmountSales4, decimal? AmountSales5)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.UTCDYBESL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Camtsl", (object)AmountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl1", (object)AmountSales1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl2", (object)AmountSales2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl3", (object)AmountSales3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl4", (object)AmountSales4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl5", (object)AmountSales5 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public long InsertCommodity(string SelectType, string Barcode, string CommodityCode, string CommodityName, int CommodityType, int? UnitID,
            decimal? AmountSales, decimal? AmountSales1, decimal? AmountSales2, decimal? AmountSales3, decimal? AmountSales4,
            decimal? AmountSales5, int UserId, string UserName, bool Deleted)
        {
            long ID = -1;

            if (UserId == 0)
                UserId = UserInfo.UserId == 0 ? 777 : UserInfo.UserId;

            if (UserName == null)
                UserName = UserInfo.UserName == null ? "n.ebrahimi" : UserInfo.UserName;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.ICDYBRCHUD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@SelectType", (object)SelectType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cbrc", (object)Barcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ccde", (object)CommodityCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cnme", (object)CommodityName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)CommodityType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Camtsl", (object)AmountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl1", (object)AmountSales1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl2", (object)AmountSales2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl3", (object)AmountSales3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl4", (object)AmountSales4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl5", (object)AmountSales5 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@BranchID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Brchnme", DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchMbe", DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchCynme", DBNull.Value);

                    cmd.Parameters.AddWithValue("@Edited", true);
                    cmd.Parameters.AddWithValue("@Sended", false);
                    cmd.Parameters.AddWithValue("@Received", false);
                    cmd.Parameters.AddWithValue("@EditedDt", DBNull.Value);
                    cmd.Parameters.AddWithValue("@EditedIdUser", UserId);
                    cmd.Parameters.AddWithValue("@EditedUnme", UserName);

                    cmd.Parameters.AddWithValue("@Delete", (object)Deleted ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public long InsertCommodityBranch(string SelectType, string Barcode, string CommodityCode, string CommodityName, int CommodityType,
            int? UnitID, decimal? AmountSales, decimal? AmountSales1, decimal? AmountSales2, decimal? AmountSales3,
            decimal? AmountSales4, decimal? AmountSales5, Guid? BranchID, string BranchName, string BranchMobile, string BranchCity,
            DateTime? EditedDate, int UserId, string UserName, bool Deleted)
        {
            long ID = -1;

            if (UserId == 0)
                UserId = UserInfo.UserId == 0 ? 777 : UserInfo.UserId;

            if (UserName == null)
                UserName = UserInfo.UserName == null ? "n.ebrahimi" : UserInfo.UserName;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.ICDYBRCHUD";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@SelectType", (object)SelectType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cbrc", (object)Barcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ccde", (object)CommodityCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cnme", (object)CommodityName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)CommodityType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Camtsl", (object)AmountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl1", (object)AmountSales1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl2", (object)AmountSales2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl3", (object)AmountSales3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl4", (object)AmountSales4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl5", (object)AmountSales5 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@BranchID", (object)BranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Brchnme", (object)BranchName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchMbe", (object)BranchMobile ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BrchCynme", (object)BranchCity ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Edited", true);
                    cmd.Parameters.AddWithValue("@Sended", false);
                    cmd.Parameters.AddWithValue("@Received", false);
                    cmd.Parameters.AddWithValue("@EditedDt", (object)EditedDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EditedIdUser", UserId);
                    cmd.Parameters.AddWithValue("@EditedUnme", UserName);

                    cmd.Parameters.AddWithValue("@Delete", (object)Deleted ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public long UpdateSendedStatus(Guid? BranchID, bool Sended)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.UCDYBRCHSS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@BranchID", (object)BranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sended", (object)Sended ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@SendedIdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);
                    cmd.Parameters.AddWithValue("@SendedUnme", UserInfo.UserName == null ? "n.ebrahimi" : UserInfo.UserName);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }
        public long UpdateSendedReceviveStatusCommodity(Guid? BranchID, bool SendedReceive)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.UCDYBRCHSRS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data

                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@BranchID", (object)BranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SendReceive", (object)SendedReceive ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@SendReceiveIdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);
                    cmd.Parameters.AddWithValue("@SendReceiveUnme", UserInfo.UserName == null ? "n.ebrahimi" : UserInfo.UserName);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region GetCommodity

        public DataSet GetCommoditySearchLight(string MySearch, int? Type, int? PageIndex, int? PageSize)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.GetTCDYSCHL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MySearch", (object)MySearch ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageIndex", (object)PageIndex ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageSize", (object)PageSize ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityLight(long? CommodityID, bool IsActive, int? Type, int? PageIndex, int? PageSize)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.GetTCDYL";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TCDYID", (object)CommodityID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", (object)IsActive ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ctye", (object)Type ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageIndex", (object)PageIndex ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageSize", (object)PageSize ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityBranch()
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.GetTCDYBRCH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityBranchStatus(string SelectType, string Barcode, string Code, string BranchID, bool? Sended)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.GetTCDYBRCHS";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SelectType", (object)SelectType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cbrc", (object)Barcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ccde", (object)Code ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BranchID", (object)BranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sended", (object)Sended ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }
        public DataSet GetCommodityBranchStatusBranches(string SelectType, string Barcode, string Code, string BranchID, bool? Sended)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.GetTCDYBRCHSB";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SelectType", (object)SelectType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cbrc", (object)Barcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ccde", (object)Code ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@BranchID", (object)BranchID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Sended", (object)Sended ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #region DeleteCommodityBranch

        public void DeleteCommodityBranch()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.DTCDYBRCH";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }
        public void DeleteCommodityBranchTemp()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.DTCDYBRCHTemp";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }

        #endregion

        #endregion

        #endregion

        //-----------------------------------------------------------------------------------------------

        #region RasisSendReceiveData

        #region ReceiveCommodity

        public long InsertUpdateCommodityBranch(string SelectType, string Barcode, string CommodityCode, string CommodityName, int? UnitID,
            decimal? AmountSales, decimal? AmountSales1, decimal? AmountSales2, decimal? AmountSales3, decimal? AmountSales4,
            decimal? AmountSales5)
        {
            long ID = -1;

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SDB.IUTCDYBEBR";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region InsertUpdate Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = new SqlParameter("@ReturnId", DbType.Int64);
                    returnParameter.Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.Parameters.AddWithValue("@SelectType", (object)SelectType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cbrc", (object)Barcode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ccde", (object)CommodityCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Cnme", (object)CommodityName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TUITID", (object)UnitID ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@Camtsl", (object)AmountSales ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl1", (object)AmountSales1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl2", (object)AmountSales2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl3", (object)AmountSales3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl4", (object)AmountSales4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Camtsl5", (object)AmountSales5 ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@IdUser", UserInfo.UserId == 0 ? 777 : UserInfo.UserId);

                    cmd.ExecuteNonQuery();

                    ID = Shared.ValInt64(returnParameter.Value);

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ID;
        }

        #endregion

        #region SendInvoice
        public void UpdateSendToServHistory(int SendToServType)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"UP.UpdateSendToServHistory";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {
                    #region Delete Data
                    con.Open();

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Type", (object)SendToServType ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }
        }
        public DataSet LoadReceiptSendToServHistory(int? InvoiceType, long? RowID, long? ReceiptNumber,
            string ReceiptDateTime, int? ItemNum)
        {
            DataSet ds = new DataSet();

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(Program.ConString);
                string sqlStringInsert = @"SRD.LoadReceiptSendToServHistory";
                using (SqlCommand cmd = new SqlCommand(sqlStringInsert, con))
                {

                    #region Get Data

                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@InvoiceType", (object)InvoiceType ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RowID", (object)RowID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReceiptNumber", (object)ReceiptNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReceiptDateTime", (object)ReceiptDateTime ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ItemNum", (object)ItemNum ?? DBNull.Value);

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);
                    }

                    #endregion
                }
            }
            finally
            {
                if (con != null)
                    con.Dispose();
            }

            return ds;
        }

        #endregion

        #endregion
    }
}