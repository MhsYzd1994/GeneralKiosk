namespace GeneralKiosk
{

    /// <summary>
    /// روز هاي هفته
    /// </summary>
    public enum EnumDayOfWeek
    {
        شنبه = 0,
        يکشنبه = 1,
        دوشنبه = 2,
        سه‌شنبه = 3,
        چهارشنبه = 4,
        پنجشنبه = 5,
        جمعه = 6
    }
    /// <summary>
    /// وضعيت فرم 
    /// </summary>
    //internal struct ParaForm
    //{
    //    internal EnumFormMode Formmode;
    //}
    /// <summary>
    /// آيتم هاي وضعيت عمليات
    /// </summary>
    public enum EnumWorkfinish
    {
        JobError = 1,
        JobNoFinish = 2,
        JobDepend = 3,
        JobFinish = 4,
        Unknown = 0
    }
    /// <summary>
    /// آيتم هاي روزهاي هفته
    /// </summary>
    public enum EnumLDayOfWeek
    {
        Saturday = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 3,
        Wednesday = 4,
        Thursday = 5,
        Friday = 6
    }
    /// <summary>
    /// آيتم هاي ماه هاي سال فارسي
    /// </summary>
    public enum EnumYearMonth
    {
        فروردين = 1,
        ارديبهشت = 2,
        خرداد = 3,
        تير = 4,
        مرداد = 5,
        شهريور = 6,
        مهر = 7,
        آبان = 8,
        آذر = 9,
        دي = 10,
        بهمن = 11,
        اسفند = 12
    }
    /// <summary>
    /// آيتم هاي ماه هاي سال لاتين
    /// </summary>
    public enum EnumLYearMonth
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        Auguest = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public enum EnumFormMode
    {
        FormModeEdit = 0,
        FormModeAdd = 1,
        FormModeDel = 2,
        FormModeHasRecord = 3,
        FormModeHasNoRecords = 4
    }

    public enum EnumActionName
    {
        NewSt = 0,
        Save = 1,
        Load = 2,
        Edit = 3,
        View = 4,
        Search = 5,
        ExitSt = 6,
        ReqToGetInfo = 7,
        EndLoad = 8
    }


    public enum EnumLoadStatus
    {
        LoadStatusIsEdit = 1,
        LoadStatusIsNew = 0
    }
    /// <summary>
    /// آيتم هاي مربوط به پيغام هاي سيستم
    /// <para>
    ///  1   ta 100  for  global message
    ///  100 ta 200  for  Account program 
    ///  200 ta 300  for  Inventory program 
    ///  300 ta 400  for  Payroll program 
    ///  400 ta 500  for  Asset program 
    ///  600 ta 700  for  Sales program 
    ///  800 ta 900  for  Cheque program 
    /// </para>
    /// </summary>
    public enum EnumSendMessage
    {
        /// <summary>
        /// عمل ثبت كامل شد
        /// </summary>
        AmaleSabtKamelShod = 0,
        AmaleSabtBaError = 1,
        AiaMikhahidHazfKonid = 2,
        AiaMikhahidKharejShavid = 3,
        AmaleHazfKamelShod = 4,
        AmaleHazfBaError = 5,
        PeyghameAzadBaIconInfo = 6,
        PeyghamehHoshdarehTaghirehEtelaat = 7,
        ListeEntekhabKhaliAst = 8,
        FormatTarikhDorostNist = 9,
        PeyghamAzadBaIconError = 10,
        PeyghamFieldhaieKebaiadPorShavand = 11,
        ItemIsUsedAndCantDelete = 12,
        ShomaBeIenItemDastResiNadarin=14,
        IenItemLockMibashad = 15,
        AmaleSabtCancelShod = 16,
        AmaleHazfCancelShod = 17,
        AmaleHazfEmkanPazirNist = 18,
        ItemPeydaNashod = 19,
        DisabledStatusLog = 20,
        NewRecord = 21,
        tekrari=22,
        MojazBeVirayeshNistid=23,
        khedmatBarayeSooratHesabNist=24,
        AiaMikhahidArshivKonid=25,
        PeyghamAzadBaIconQuestion=26,
        TryCatchMessage = 13,
        AiaMikhahidBaPeyghamehAzad=27,
      

        /// <summary>
        /// پيغام مورد نظر يافت نشد
        /// </summary>
        PeyghameMoredehNazarYaftNashod = 999
    }

    public enum EnumBaseInfoStatus
    {
        Active = 1,
        Deactive = 2,
        All = 3
     }

    public enum EnumCaseStatus
    {
        Nothing=0,
        Lower = 1,
        Upper = 2,
        ToLowerInvariant = 3,
        ToUpperInvariant=4
    }

    public enum EnumBookingStatus
    {
        OperationBegin = 1,
        Deactive = 2,
        All = 3,
        OperationEnd = 4,
        Waiting = 5
    }
    //nemat
    public enum EnumStatusLog
    {
        booking = 1,
        arrived = 2,
        disembarkpassenger = 3,
        passengerreception = 4,
        disembarkcargo = 5,
        embarkpassenger = 6,
        embarkcargo = 7,
        refueling = 8,
        Wasmoved = 9,
        delayed = 10,
        ontime = 12,
        Departed = 11,
        disable = 13
    }

    //nemat
    
    //************SepPay.Common************
    // Modify,Create,Develope
    //nasiri
    //WID:
    //24-3-1391
    //***************************
    public enum EnumDeclarationType
    {
       Discharging  = 0,
        Loading =1
    }

    
  }
