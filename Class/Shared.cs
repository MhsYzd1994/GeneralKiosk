using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FarsiMessageBox;
using System.IO;
using Janus.Windows.GridEX;
using SepPaySCG;
using System.Text;
using System.Diagnostics;

namespace GeneralKiosk
{

    public static class Shared
    {
        #region Fields
        public static bool local = false;
        public static string MsgCaption = "سیستم RASIS";

        public static int DefaultCityId = 38139;

        public static string SecurityString = "";
        private const string DEF_BASIC_MESSAGEBOX = "BasicMessageBox";
        private const string DEF_ADVBUTTON_MESSAGEBOX = "AdvancedButtonMessageBox";

        [DllImport("user32")]
        public static extern int ActivateKeyboardLayout(int HKL, int flags);
        #endregion

        #region Methods

        //public static void InsertLog(string ClassName, string DoWhat, string MethodName, int IdUser)
        //{
        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            string Dtf;
        //            if (Program.SystemDate.Year != 1)
        //                Dtf = Program.SystemDate.ToString("yyyy/MM/dd HH:mm:ss");
        //            else
        //                Dtf = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Connection = con;
        //            con.Open();
        //            cmd.Parameters.Clear();
        //            cmd.CommandText = @"ISELT";

        //            cmd.Parameters.AddWithValue("@p1", IdUser.ToString());
        //            cmd.Parameters.AddWithValue("@p2", ClassName);
        //            cmd.Parameters.AddWithValue("@p3", MethodName);
        //            cmd.Parameters.AddWithValue("@p4", DoWhat);
        //            cmd.Parameters.AddWithValue("@p5", Dtf);

        //            cmd.ExecuteNonQuery();

        //            con.Close();
        //        }
        //    }
        //}

        //public static DataTable LoadLog(string DateAs, string DateTa)
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection con = new SqlConnection(ConnectionString.Replace("Initial Catalog=EPI", "Initial Catalog=EPILOG")))
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;
        //            con.Open();

        //            cmd.CommandText =
        //                $@"SELECT        TblLog.Id, EPI.Security.TblUser.IdUser, EPI.Base.TblPersonel.IdPersonel, TblLog.DateTimeEvent, TblLog.Source, TblLog.DoWhat, EPI.Security.TblUser.UserName, 
        //            EPI.Base.TblPersonel.PersonelFamily, EPI.Base.TblPersonel.PersonelName
        //            FROM            TblLog INNER JOIN
        //            EPI.Security.TblUser ON TblLog.Iduser = EPI.Security.TblUser.IdUser INNER JOIN
        //            EPI.Base.TblPersonel ON EPI.Security.TblUser.IdPersonel = EPI.Base.TblPersonel.IdPersonel
        //            WHERE  (DateTimeEvent >= CONVERT(DATETIME, '{DateAs}', 102))
        //            AND (DateTimeEvent <= CONVERT(DATETIME, '{DateTa}', 102))";
        //            da.SelectCommand = cmd;
        //            da.Fill(dt);

        //            con.Close();
        //        }
        //    }
        //    return dt;
        //}


        public static string ObjectToTextNull(object value)
        {
            if (value == null) return null;
            if (value.ToString() == "") return null;
            return value.ToString().Trim();
        }

        public static bool IsNumeric(string stringToCheck)
        {
            if (stringToCheck == null) return false;

            Regex _isNumber =
                        new Regex
                        (@"(^[-+]?\d+(,?\d*)*\.?\d*([Ee][-+]\d*)?$)|(^[-+]?\d?(,?\d*)*\.\d+([Ee][-+]\d*)?$)");
            return _isNumber.Match(stringToCheck).Success;
        }

        public static string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        public static string ConvertToFinglish(string persianText)
        {
            Dictionary<string, string> mapping = new Dictionary<string, string>
        {
            {"آ", "a"}, {"ا", "a"}, {"ب", "b"}, {"پ", "p"}, {"ت", "t"},
            {"ث", "s"}, {"ج", "j"}, {"چ", "ch"}, {"ح", "h"}, {"خ", "kh"},
            {"د", "d"}, {"ذ", "z"}, {"ر", "r"}, {"ز", "z"}, {"ژ", "zh"},
            {"س", "s"}, {"ش", "sh"}, {"ص", "s"}, {"ض", "z"}, {"ط", "t"},
            {"ظ", "z"}, {"ع", "a"}, {"غ", "gh"}, {"ف", "f"}, {"ق", "gh"},
            {"ک", "k"}, {"گ", "g"}, {"ل", "l"}, {"م", "m"}, {"ن", "n"},
            {"و", "o"}, {"ه", "h"}, {"ی", "y"},
            {" ", ""},
            {"۰", "0"}, {"۱", "1"}, {"۲", "2"}, {"۳", "3"}, {"۴", "4"},
            {"۵", "5"}, {"۶", "6"}, {"۷", "7"}, {"۸", "8"}, {"۹", "9"}
            // مپینگ برای کاراکترهای دیگر را ادامه دهید
        };

            StringBuilder finglishText = new StringBuilder();

            foreach (char c in persianText)
            {
                string character = c.ToString();

                if (mapping.ContainsKey(character))
                {
                    finglishText.Append(mapping[character]);
                }
                else
                {
                    finglishText.Append(character);
                }
            }

            return finglishText.ToString();
        }

        public static bool CheckMeli(string Meli)
        {
            try
            {
                char[] chArray = Meli.ToCharArray();
                int[] numArray = new int[chArray.Length];
                for (int i = 0; i < chArray.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                }
                int num2 = numArray[9];
                switch (Meli)
                {
                    case "0000000000":
                    case "1111111111":
                    case "22222222222":
                    case "33333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":
                        return false;

                }
                int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                int num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool GetConnectionString()
        {
            //Need Change
            //string temstr;
            Program.ConString = IniFile.IniReadValue("ConnectionSetting", "ConnectionName",
                  AppDomain.CurrentDomain.BaseDirectory + @"\IniFiles\Connection.ini");

            if (string.IsNullOrEmpty(Program.ConString)) return false;

            Program.ConString = EncryptDecryptMyPassword.decryptPassword(Program.ConString);

            return true;
            //Sa in SQL mojganam56
            //string temstr = EncryptDecryptMyPassword.encryptPassword(@"Data Source=NEMAT-PC\SQL2012;Initial Catalog=SepPay;Persist Security Info=True;User ID=seppay;Password=@SepPay$iamak1396~;Connection Timeout=60");
            //string temstr = EncryptDecryptMyPassword.encryptPassword(@"Data Source=46.225.109.214\EPI;Initial Catalog=EPI;Persist Security Info=True;User ID=sa;Password=entbsbntnkkb@EPI;Connection Timeout=40");
        }


        public static bool CheckMobileNum(string input)

        {

            Match m = Regex.Match(input, @"(\+98|0)?9\d{9}");
            if (m.Success)
            {
                return true;
            }
            else
                return false;

        }

        public static DataTable DataTableEnumToDataTable(Type enumType)
        {
            DataTable table = new DataTable();

            //Column that contains the Captions/Keys of Enum        
            table.Columns.Add("Desc", typeof(string));
            //Get the type of ENUM for DataColumn
            table.Columns.Add("Id", Enum.GetUnderlyingType(enumType));
            //Add the items from the enum:
            foreach (string name in Enum.GetNames(enumType))
            {
                //Replace underscores with space from caption/key and add item to collection:
                table.Rows.Add(name.Replace('_', ' '), Enum.Parse(enumType, name));
            }

            return table;
        }

        public static void LoadMyLayOut(string fileName, GridEX gridObj)
        {
            string layoutDir = GetLayoutDirectory() + @"\" + fileName;
            if (FileExists(layoutDir))
            {
                FileStream layoutStream;
                layoutStream = new FileStream(layoutDir, FileMode.Open);
                gridObj.LoadLayoutFile(layoutStream);
                layoutStream.Close();
            }
        }

        public static void LoadDefLayOut(string fileName, GridEX gridObj)
        {
            string layoutDir = GetLayoutDirectory() + @"\" + fileName;
            if (FileExists(layoutDir))
            {
                FileStream layoutStream;
                layoutStream = new FileStream(layoutDir, FileMode.Open);
                gridObj.LoadLayoutFile(layoutStream);
                layoutStream.Close();
            }
        }

        //marbot be save LayOut Grid
        public static bool FileExists(string fileName)
        {
            FileInfo fInfo = new FileInfo(fileName);
            return fInfo.Exists;
        }

        //marbot be save LayOut Grid
        public static string GetLayoutDirectory()
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(Application.ExecutablePath).Parent;
            while (currentDirectory != null)
            {
                DirectoryInfo[] childDirectories = currentDirectory.GetDirectories();
                foreach (DirectoryInfo childDir in childDirectories)
                {

                    if (childDir.Name == "LayoutData")
                    {
                        return childDir.FullName;
                    }

                }
                currentDirectory = currentDirectory.Parent;
            }
            return "";
        }

        /// <summary>
        /// تعیین معتبر بودن کد ملی
        /// </summary>
        /// <param name="nationalCode">کد ملی وارد شده</param>
        /// <returns>
        /// در صورتی که کد ملی صحیح باشد خروجی <c>true</c> و در صورتی که کد ملی اشتباه باشد خروجی <c>false</c> خواهد بود
        /// </returns>
        /// <exception cref="System.Exception"></exception>
        public static bool IsValidNationalCode(String nationalCode)
        {

            if (String.IsNullOrEmpty(nationalCode))
            {
                ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "لطفا کد ملی را صحیح وارد نمایید");
                return false;
            }

            if (nationalCode.Length != 10)
            {
                ShowMessage(EnumSendMessage.PeyghamAzadBaIconError, "طول کد ملی باید ده کاراکتر باشد");
                return false;
            }

            //در صورتی که کد ملی ده رقم عددی نباشد
            var regex = new Regex(@"\d{10}");
            if (!regex.IsMatch(nationalCode))
            {
                ShowMessage(EnumSendMessage.PeyghamAzadBaIconError
                    , "کد ملی تشکیل شده از ده رقم عددی می‌باشد؛ لطفا کد ملی را صحیح وارد نمایید");
                return false;
            }

            //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalCode)) return false;


            //عملیات شرح داده شده در بالا
            var chArray = nationalCode.ToCharArray();
            var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
            var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
            var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
            var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
            var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
            var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
            var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
            var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
            var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
            var a = Convert.ToInt32(chArray[9].ToString());

            var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
            var c = b % 11;

            return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
        }



        public static bool IsValidEmail(string emailAddress)
        {

            // Return true if emailAddress is in valid e-mail format.

            return Regex.IsMatch(emailAddress, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

        }

        public static bool FormatAndCheckDate(string objstr, object obj)
        {

            if (objstr.Length >= 6)
            {
                objstr = FormatDateTwoZeroStyle(objstr);

                if (objstr == "Null")
                {
                    return false;
                }

                if (CheckDate(objstr) == false)
                {
                    return false;
                }

                if (DateTime.Now.ToString("yyyy").CompareTo("1400") < 0)
                {
                    ((TextBox)obj).Text = "13" + objstr;
                }
                else
                {
                    if (Shared.Val(objstr.Substring(0, 2)) >= 0
                        && Shared.Val(objstr.Substring(0, 2)) <= 40)
                    {
                        ((TextBox)obj).Text = "14" + objstr;
                    }
                    else
                    {
                        ((TextBox)obj).Text = "13" + objstr;
                    }
                }

                return true;
            }
            else
            {
                ((TextBox)obj).Text = "";
                return false;
            }
        }

        public static bool FormatAndCheckDateWithoutAssign(string objstr, object obj)
        {

            if (objstr.Length >= 6)
            {
                objstr = FormatDateTwoZeroStyle(objstr);

                if (objstr == "Null")
                {
                    return false;
                }

                if (CheckDate(objstr) == false)
                {
                    return false;
                }


                return true;
            }
            else
            {
                ((TextBox)obj).Text = "";
                return false;
            }
        }

        public static DialogResult ShowMessage(EnumSendMessage NumMassage, String TextMessage)
        {
            DialogResult objDialogres = DialogResult.OK;

            switch (NumMassage)
            {
                case EnumSendMessage.TryCatchMessage:
                    FMessageBox.Show(TextMessage, "خطای نامشخص", FMessageBoxButtons.OK, FMessageBoxIcons.Error, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.AmaleSabtKamelShod:
                    FMessageBox.Show("عمل ثبت با موفقيت انجام شد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Information, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.AmaleSabtBaError:
                    FMessageBox.Show("عمل ثبت با مشكل مواجه شد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Error, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.AmaleSabtCancelShod:
                    FMessageBox.Show("انصراف داده شد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Information, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.AiaMikhahidHazfKonid:
                    objDialogres = FMessageBox.Show("آيا مي خواهيد آيتم مورد نظر را حذف كنيد؟", MsgCaption, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question, FMessageBoxDefaultButtons.Button2);
                    break;
                case EnumSendMessage.AiaMikhahidBaPeyghamehAzad:
                    objDialogres = FMessageBox.Show(TextMessage, MsgCaption, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.AmaleHazfEmkanPazirNist:
                    objDialogres = FMessageBox.Show(".امكان حذف به دليل وجود وابستگي امكان پذير نيست", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Question, FMessageBoxDefaultButtons.Button2);
                    break;

                case EnumSendMessage.AiaMikhahidKharejShavid:
                    objDialogres = FMessageBox.Show("آيا مي خواهيد از فرم خارج شويد؟", MsgCaption, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question, FMessageBoxDefaultButtons.Button2);
                    break;
                case EnumSendMessage.AmaleHazfKamelShod:
                    FMessageBox.Show("عمل حذف با موفقيت انجام شد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Information, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.AmaleHazfBaError:
                    FMessageBox.Show("عمل حذف با مشكل مواجه شد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Error, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.PeyghameAzadBaIconInfo:
                    FMessageBox.Show(TextMessage, MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Information, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.PeyghamehHoshdarehTaghirehEtelaat:
                    objDialogres = FMessageBox.Show("تغييراتي در فرم داده شده.آيا تغييرات را ناديده مي گيريد؟", MsgCaption, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.ListeEntekhabKhaliAst:
                    FMessageBox.Show("ليست انتخاب خالي مي باشد.لطفا موردي را انتخاب نماييد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Information, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.FormatTarikhDorostNist:
                    FMessageBox.Show($@"فرمت تاريخ صحيح نمي باشد
تاریخ را به ترتیب سال , ماه و روز وارد کنید !
مثال : 98/02/05 را به صورت 980205 (بدون ممیز) وارد نمایید !", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Warning, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.PeyghamAzadBaIconError:
                    FMessageBox.Show(TextMessage, MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Error, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.PeyghamAzadBaIconQuestion:
                    objDialogres = FMessageBox.Show(TextMessage, MsgCaption, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.PeyghamFieldhaieKebaiadPorShavand:
                    FMessageBox.Show("فيلدهايي كه با رنگ متمايز پر شده اند حتما بايد وارد شوند", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Warning, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.ItemIsUsedAndCantDelete:
                    FMessageBox.Show("آيتم مورد نظر در سيستم گردش دارد و قابل حذف نيست", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Warning, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.ShomaBeIenItemDastResiNadarin:
                    FMessageBox.Show("شما به اين آيتم دسترسي نداريد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Warning, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.IenItemLockMibashad:
                    FMessageBox.Show("این آیتم توسط شخص دیگری قفل می باشد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Warning, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.AmaleHazfCancelShod:
                    FMessageBox.Show("عمل بايگاني كنسل شد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Warning, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.ItemPeydaNashod:
                    FMessageBox.Show("آيتم مورد نظر وجود ندارد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Warning, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.DisabledStatusLog:
                    objDialogres = FMessageBox.Show("وضعیت انتخاب شده باعث حذف اطلاعات از نمایشگر می شود آیا مطمئن هستید؟", MsgCaption, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question, FMessageBoxDefaultButtons.Button2);
                    break;
                case EnumSendMessage.NewRecord:
                    objDialogres = FMessageBox.Show("آیا می خواهید رکورد جدید وارد کنید؟", MsgCaption, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question, FMessageBoxDefaultButtons.Button2);
                    break;
                case EnumSendMessage.tekrari:
                    FMessageBox.Show("این رکورد وجود دارد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Warning, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.MojazBeVirayeshNistid:
                    FMessageBox.Show("شما مجاز به ویرایش نیستید", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Warning, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.khedmatBarayeSooratHesabNist:
                    FMessageBox.Show("شعبه ای برای محاسبه صورتحساب وجود ندارد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Warning, FMessageBoxDefaultButtons.Button1);
                    break;
                case EnumSendMessage.AiaMikhahidArshivKonid:
                    objDialogres = FMessageBox.Show("آيا مي خواهيد آيتم مورد نظر را آرشیو كنيد؟", MsgCaption, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question, FMessageBoxDefaultButtons.Button2);
                    break;
                default:
                    FMessageBox.Show("پيغام مورد نظر يافت نشد", MsgCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Error, FMessageBoxDefaultButtons.Button1);
                    break;
            }
            return objDialogres;
        }

        public static string GetColumnFriendlyName(GridEXColumn column)
        {
            if (column.Caption.Length == 0)
            {
                if (column.Tag != null)
                {
                    return Convert.ToString(column.Tag);
                }
                else
                {
                    return column.Key;
                }
            }
            else
            {
                return column.Caption;
            }
        }

        //nemat 91
        public static T GetAssemblyAttribute<T>(Assembly assembly) where T : Attribute
        {
            if (assembly == null) return null;

            object[] attributes = assembly.GetCustomAttributes(typeof(T), true);

            if (attributes == null) return null;
            if (attributes.Length == 0) return null;

            return (T)attributes[0];
        }

        public static bool TestEmailRegex(string emailAddress)
        {

            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                                 + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                 + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                 + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                 + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);

            bool isStrictMatch = reStrict.IsMatch(emailAddress);
            return isStrictMatch;

        }

        public static void KeyboardArabic()
        {
            long KeyboardApiResult;
            KeyboardApiResult = ActivateKeyboardLayout(1065, 1); //Farsi
            //KeyboardApiResult = ActivateKeyboardLayout(&H401) 'Arabic
        }

        public static void KeyboardEnglish()
        {
            long KeyboardApiResult;
            KeyboardApiResult = ActivateKeyboardLayout(1033, 1); //English
        }

        public static bool CheckDate(String DateForCheck)
        {
            try
            {
                if (DateForCheck.Length == 8)
                {
                    if (DateForCheck.Contains("/") == false)
                        return false;

                    if (DateTime.Now.ToString("yyyy").CompareTo("1400") < 0)
                    {
                        DateForCheck = "13" + DateForCheck;
                    }
                    else
                    {
                        if (Shared.Val(DateForCheck.Substring(0, 2)) >= 0
                            && Shared.Val(DateForCheck.Substring(0, 2)) <= 40)
                        {
                            DateForCheck = "14" + DateForCheck;
                        }
                        else
                        {
                            DateForCheck = "13" + DateForCheck;
                        }
                    }
                }
                else if (DateForCheck.Length == 10)
                {
                    if (DateForCheck.Contains("/") == false)
                        return false;
                }
                DateTime objDateTime;
                objDateTime = S2M(DateForCheck);

                if (objDateTime.Date == DateTime.Parse("1900/01/01 12:00:00 AM"))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DateTime S2M(String ConvDate)
        {
            DateTime returnValue;
            System.Globalization.PersianCalendar jc = new System.Globalization.PersianCalendar();

            if (ConvDate.Length == 8 & ConvDate.Contains("/"))
                ConvDate = "13" + ConvDate;
            if (ConvDate.Length < 8)
            {
                returnValue = DateTime.Parse("1900/01/01 12:00:00 AM");
                return returnValue;
            }

            try
            {
                returnValue = jc.ToDateTime(int.Parse(ConvDate.Substring(0, 4)),
                    int.Parse(ConvDate.Substring(5, 2)),
                    int.Parse(ConvDate.Substring(8, 2)), 1, 1, 1, 1);
            }
            catch
            {
                returnValue = DateTime.Parse("1900/01/01 12:00:00 AM");
            }
            return returnValue;
        }

        public static String M2S(DateTime ConvDate)
        {
            string returnValue = "";
            System.Globalization.PersianCalendar jc = new System.Globalization.PersianCalendar();
            string FarsiYear;
            string FarsiMonth;
            string FarsiDay;

            if (ConvDate.ToString() == "12:00:00 AM")
            {
                return "1300/01/01";
            }
            try
            {
                FarsiYear = Convert.ToString(jc.GetYear(ConvDate));
                FarsiMonth = Convert.ToString(jc.GetMonth(ConvDate));
                FarsiDay = Convert.ToString(jc.GetDayOfMonth(ConvDate));
                FarsiDay = FarsiDay.PadLeft(2, '0');
                FarsiMonth = FarsiMonth.PadLeft(2, '0');
                returnValue = FarsiYear + "/" + FarsiMonth + "/" + FarsiDay;

                return returnValue;
            }
            catch
            {
                return "1300/01/01";
            }

        }

        public static String FormatDateTwoZeroStyle(String StrDate)
        {
            try
            {
                if (StrDate.Length < 6)
                {
                    return "Null";
                }
                if (StrDate.Length > 8)
                {
                    if (StrDate.StartsWith("13") || StrDate.StartsWith("14"))
                    {
                        StrDate = StrDate.Substring(2);
                    }
                    else return "Null";
                }
                String Strreturn;
                String[] TemStrDate = new String[3];
                StrDate = StrDate.Replace("/", "");
                StrDate = StrDate.Trim();
                if (StrDate.Length != 6)
                {
                    return "Null";
                }
                TemStrDate[0] = StrDate.Substring(0, 2);
                TemStrDate[1] = StrDate.Substring(2, 2);
                TemStrDate[2] = StrDate.Substring(4, 2);
                //if (int.Parse(TemStrDate[0]) < 1) return "Null";

                Strreturn = TemStrDate[0].PadLeft(2, '0') + "/" + TemStrDate[1].PadLeft(2, '0')
                    + "/" + TemStrDate[2].PadLeft(2, '0');
                return Strreturn;
            }
            catch (Exception)
            {
                return "Null";
            }
        }

        public static void SetChangeForBindingAndClass(
            Type ObjTypeofClass,
            DataRowView ObjDataRowView, object ObjClass)
        {
            if (ObjDataRowView == null) return;
            Object FieldValues = null;
            if (ObjDataRowView.IsNew) return;
            for (int i = 0; i < ObjDataRowView.DataView.Table.Columns.Count; i++)
            {
                FieldValues = ObjDataRowView.Row[i];
                if (FieldValues == DBNull.Value)
                {
                    switch (ObjDataRowView.DataView.Table.Columns[i].DataType.Name.ToLower())
                    {
                        case "int16":
                            FieldValues = 0;
                            break;
                        case "int32":
                            FieldValues = 0;
                            break;
                        case "double":
                            FieldValues = 0;
                            break;
                        case "byte":
                            FieldValues = 0;
                            break;
                        case "boolean":
                            FieldValues = true;
                            break;
                        case "bool":
                            FieldValues = true;
                            break;
                        case "byte[]":
                            byte[] objbyte = { 0 };
                            ObjTypeofClass.InvokeMember(ObjDataRowView.DataView.Table.Columns[i].Caption, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, ObjClass, new Object[] { objbyte });
                            objbyte = null;
                            continue;
                        case "string":
                            FieldValues = "";
                            break;
                        case "datetime":
                            FieldValues = "";
                            break;
                    }
                }
                ObjTypeofClass.InvokeMember(ObjDataRowView.DataView.Table.Columns[i].Caption, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, ObjClass, new Object[] { FieldValues });
            }
        }


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public static bool IsRecursive()
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
            // Check whether any method in the call stack is the same as the immediate caller.
            for (int n = 2; n < st.FrameCount; n++)
            {
                if (st.GetFrame(1).GetMethod() == st.GetFrame(n).GetMethod())
                    return true;
            }
            return false;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public static bool IsHasEvent(string objstr)
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
            // Check whether any method in the call stack is the same as the immediate caller.
            for (int n = 2; n < st.FrameCount; n++)
            {
                if (st.GetFrame(n).GetMethod().ToString().IndexOf(objstr, 0) > 0)
                    return true;
            }
            return false;
        }

        public static string GetAssemblyVer()
        {
            int VersionLocation = Assembly.GetExecutingAssembly().FullName.IndexOf("Version=");
            int CultureLocation = Assembly.GetExecutingAssembly().FullName.IndexOf(", Culture");
            return Assembly.GetExecutingAssembly().FullName.Substring(VersionLocation, (CultureLocation - VersionLocation));
        }

        public static int Val(string value)
        {
            string returnVal = string.Empty;

            if (!string.IsNullOrEmpty(value))
                value = value.Replace(",", "");
            else
                return 0;

            MatchCollection collection = Regex.Matches(value.Trim(), @"^[-+]?[0-9]\d*\.?[0]*$");

            foreach (Match match in collection)
            {
                returnVal += match.ToString();
            }

            int.TryParse(returnVal.Split('.')[0], out int tryInt);

            return tryInt;

        }

        public static int Val(object value)
        {
            if (value == null) return 0;

            string returnVal = string.Empty;

            if (value is string && ((string)value) != "") value = value.ToString().Replace(",", "");

            MatchCollection collection = Regex.Matches(value.ToString().Trim(), @"^[-+]?[0-9]\d*\.?[0]*$");

            foreach (Match match in collection)
            {
                returnVal += match.ToString();
            }


            int.TryParse(returnVal.Split('.')[0], out int tryInt);

            return tryInt;

        }

        public static Int64 ValInt64(object value)
        {
            if (value == null) return 0;

            string returnVal = string.Empty;

            if (value is string && ((string)value) != "") value = value.ToString().Replace(",", "");

            MatchCollection collection = Regex.Matches(value.ToString().Trim(), @"^[-+]?[0-9]\d*\.?[0]*$");

            foreach (Match match in collection)
            {
                returnVal += match.ToString();
            }

            Int64.TryParse(returnVal.Split('.')[0], out long tryInt);

            return tryInt;

        }

        public static decimal ValDecimal(object value)
        {
            if (value == null) return 0;

            if (value is string && ((string)value) != "") value = value.ToString().Replace(",", "");
            string returnVal = value.ToString();

            decimal.TryParse(returnVal, out decimal tryInt);

            return tryInt;
        }

        public static string IsNull(string value, string replacevalue)
        {

            string returnVal = string.Empty;

            if (value == null)
                return replacevalue;

            return value;

        }

        public static int BoolToInt(bool? value)
        {
            if (value == null) return 0;
            return value == true ? 1 : 0;
        }

        public static bool ObjectToBool(object value)
        {
            if (value == null) return false;
            if (value.ToString() == "") return false;

            if (IsNumeric(value.ToString()))
            {
                return value.ToString() == "1" ? true : false;
            }
            else if (value.GetType().Name == "String")
            {
                if (value.ToString().Trim().ToLower() == "1")
                    return true;
                else if (value.ToString().Trim().ToLower() == "0")
                    return false;
                else if (value.ToString().Trim().ToLower() == "true")
                    return true;
                else
                    return false;
            }
            else if (value.GetType().Name == "Boolean")
            {
                return (bool)value;
            }

            return false;
        }

        public static string ObjectToText(object value, EnumCaseStatus CaseStatus)
        {
            if (value == null) return "";
            if (value.ToString() == "") return "";
            if (CaseStatus == EnumCaseStatus.Nothing)
                return value.ToString().Trim();
            else if (CaseStatus == EnumCaseStatus.Lower)
                return value.ToString().Trim().ToLower();
            else if (CaseStatus == EnumCaseStatus.Upper)
                return value.ToString().Trim().ToUpper();
            else if (CaseStatus == EnumCaseStatus.ToLowerInvariant)
                return value.ToString().Trim().ToLowerInvariant();
            else if (CaseStatus == EnumCaseStatus.ToUpperInvariant)
                return value.ToString().Trim().ToUpperInvariant();
            else
                return value.ToString().Trim();
        }

        public static string ObjectToText(object value)
        {
            if (value == null) return "";
            if (value.ToString() == "") return "";
            return value.ToString().Trim();

        }

        public static string ObjectToText(object value, string Format)
        {
            if (value == null) return "";
            if (value.ToString() == "") return "";

            string tem = value.ToString().Trim();

            decimal temDec = Shared.ValDecimal(tem);

            if (temDec == 0) return "0";

            return string.Format(Format, temDec);

        }
        public static bool BoolToBool(bool? value)
        {
            if (value == null) return false;
            return value == true ? true : false;
        }

        public static string BoolToString(bool? value)
        {
            if (value == null) return "false";
            return value == true ? "true" : "false";
        }
        public static int BoolToInt(object value)
        {
            if (value == null) return 0;
            return (bool)value == true ? 1 : 0;
        }

        public static InheritableBoolean BoolToInheritableBoolean(bool? value)
        {
            if (value == null) return InheritableBoolean.False;
            return (bool)value == true ? InheritableBoolean.True : InheritableBoolean.False;
        }

        public static string GetConnectionString(string ConString)
        {


            if (string.IsNullOrEmpty(ConString)) return "";

            return EncryptDecryptMyPassword.decryptPassword(ConString);

            //Sa in SQL mojganam56
            //string temstr = EncryptDecryptMyPassword.encryptPassword(@"Data Source=NEMAT-PC\SQL2012;Initial Catalog=SepPay;Persist Security Info=True;User ID=seppay;Password=@SepPay$iamak1396~;Connection Timeout=60");
            //string temstr = EncryptDecryptMyPassword.encryptPassword(@"Data Source=46.225.109.214\EPI;Initial Catalog=EPI;Persist Security Info=True;User ID=sa;Password=entbsbntnkkb@EPI;Connection Timeout=40");
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }


        public static string ConvertNumber(Int64 Number)
        {
            //---------------------------------------------------'
            List<Int64> Num = new List<Int64>();
            List<string> Word = new List<string>();
            string Text = "";
            //---------------------------------------------------'
            Number = Math.Abs(Number);
            if (Number > 0)
            {
                do
                {
                    Int64 A = 0;
                    Int64 B = 0;
                    A = Number / 1000;
                    B = Number % 1000;
                    Num.Add(B);//  .Add(B);
                    if (A >= 1000)
                    {
                        Number = A;
                    }
                    else if (A != 0)
                    {
                        Num.Add(A);
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                    else
                    {
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                }
                while (true);
            }
            else if (Number == 0)
            {
                return "صفر";
            }
            //---------------------------------------------------'
            for (int I = 0; I <= Num.Count - 1; I++)
            {
                Word.Add(ChangingNum(Num[I]));
            }
            //---------------------------------------------------'
            for (int Counter = Word.Count - 1; Counter >= 0; Counter += -1)
            {
                if (Counter == 5)
                {
                    if (!string.IsNullOrEmpty(Word[5]))
                    {
                        if (!string.IsNullOrEmpty(Word[4]) || !string.IsNullOrEmpty(Word[3]) || !string.IsNullOrEmpty(Word[2]) || !string.IsNullOrEmpty(Word[1]) || !string.IsNullOrEmpty(Word[0]))
                        {
                            Text += Word[5] + " بيليارد و ";
                        }
                        else
                        {
                            Text += Word[5] + " بيليارد";
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
                else if (Counter == 4)
                {
                    if (!string.IsNullOrEmpty(Word[4]))
                    {
                        if (!string.IsNullOrEmpty(Word[3]) || !string.IsNullOrEmpty(Word[2]) || !string.IsNullOrEmpty(Word[1]) || !string.IsNullOrEmpty(Word[0]))
                        {
                            Text += Word[4] + " بيليون و ";
                        }
                        else
                        {
                            Text += Word[4] + " بيليون";
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
                else if (Counter == 3)
                {
                    if (!string.IsNullOrEmpty(Word[3]))
                    {
                        if (!string.IsNullOrEmpty(Word[2]) || !string.IsNullOrEmpty(Word[1]) || !string.IsNullOrEmpty(Word[0]))
                        {
                            Text += Word[3] + " ميليارد و ";
                        }
                        else
                        {
                            Text += Word[3] + " ميليارد";
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
                else if (Counter == 2)
                {
                    if (!string.IsNullOrEmpty(Word[2]))
                    {
                        if (!string.IsNullOrEmpty(Word[1]) || !string.IsNullOrEmpty(Word[0]))
                        {
                            Text += Word[2] + " ميليون و ";
                        }
                        else
                        {
                            Text += Word[2] + " ميليون";
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
                else if (Counter == 1)
                {
                    if (!string.IsNullOrEmpty(Word[1]))
                    {
                        if (!string.IsNullOrEmpty(Word[0]))
                        {
                            Text += Word[1] + " هزار و ";
                        }
                        else
                        {
                            Text += Word[1] + " هزار";
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
                else
                {
                    Text += Word[0];
                }
            }
            //---------------------------------------------------'
            //---------------------------------------------------'
            return Text;
        }

        private static string ChangingNum(Int64 Number)
        {
            //---------------------------------------------------'
            List<string> N = new List<string>();
            string Yekan = "";
            string Dahgan = "";
            string Sadgan = "";
            string Value = "";
            //---------------------------------------------------'
            do
            {
                Int64 A = 0;
                Int64 B = 0;
                A = Convert.ToInt64(Number / 10);
                B = Number % 10;
                N.Add(B.ToString());
                if (A >= 10)
                {
                    Number = A;
                }
                else
                {
                    N.Add(A.ToString());
                    break; // TODO: might not be correct. Was : Exit Do
                }
            }
            while (true);
            //---------------------------------------------------'
            if (N.Count == 3)
            {
                switch (N[2])
                {
                    case "0":
                        Sadgan = "";
                        break;
                    case "1":
                        Sadgan = "صد";
                        break;
                    case "2":
                        Sadgan = "دويست";
                        break;
                    case "3":
                        Sadgan = "سيصد";
                        break;
                    case "4":
                        Sadgan = "چهارصد";
                        break;
                    case "5":
                        Sadgan = "پانصد";
                        break;
                    case "6":
                        Sadgan = "ششصد";
                        break;
                    case "7":
                        Sadgan = "هفتصد";
                        break;
                    case "8":
                        Sadgan = "هشتصد";
                        break;
                    case "9":
                        Sadgan = "نهصد";
                        break;
                }
            }
            //---------------------------------------------------'
            switch (N[0])
            {
                case "0":
                    Yekan = "";
                    break;
                case "1":
                    Yekan = "يك";
                    break;
                case "2":
                    Yekan = "دو";
                    break;
                case "3":
                    Yekan = "سه";
                    break;
                case "4":
                    Yekan = "چهار";
                    break;
                case "5":
                    Yekan = "پنج";
                    break;
                case "6":
                    Yekan = "شش";
                    break;
                case "7":
                    Yekan = "هفت";
                    break;
                case "8":
                    Yekan = "هشت";
                    break;
                case "9":
                    Yekan = "نه";
                    break;
            }
            //---------------------------------------------------'
            switch (N[1])
            {
                case "0":
                    Dahgan = "";
                    break;
                case "1":
                    switch (N[0])
                    {
                        case "0":
                            Yekan = "ده";
                            break;
                        case "1":
                            Yekan = "يازده";
                            break;
                        case "2":
                            Yekan = "دوازده";
                            break;
                        case "3":
                            Yekan = "سيزده";
                            break;
                        case "4":
                            Yekan = "چهارده";
                            break;
                        case "5":
                            Yekan = "پانزده";
                            break;
                        case "6":
                            Yekan = "شانزده";
                            break;
                        case "7":
                            Yekan = "هفده";
                            break;
                        case "8":
                            Yekan = "هيجده";
                            break;
                        case "9":
                            Yekan = "نوزده";
                            break;
                    }
                    break;


                case "2":
                    Dahgan = "بيست";
                    break;
                case "3":
                    Dahgan = "سي";
                    break;
                case "4":
                    Dahgan = "چهل";
                    break;
                case "5":
                    Dahgan = "پنجاه";
                    break;
                case "6":
                    Dahgan = "شصت";
                    break;
                case "7":
                    Dahgan = "هفتاد";
                    break;
                case "8":
                    Dahgan = "هشتاد";
                    break;
                case "9":
                    Dahgan = "نود";
                    break;
            }
            //---------------------------------------------------'
            if (!string.IsNullOrEmpty(Sadgan))
            {
                Value += Sadgan;
                if (!string.IsNullOrEmpty(Dahgan))
                {
                    Value += " و " + Dahgan;
                    if (!string.IsNullOrEmpty(Yekan))
                    {
                        Value += " و " + Yekan;
                    }
                }
                else if (!string.IsNullOrEmpty(Yekan))
                {
                    Value += " و " + Yekan;
                }
            }
            else if (!string.IsNullOrEmpty(Dahgan))
            {
                Value += Dahgan;
                if (!string.IsNullOrEmpty(Yekan))
                {
                    Value += " و " + Yekan;
                }
            }
            else
            {
                Value += Yekan;
            }
            //---------------------------------------------------'
            //---------------------------------------------------'
            return Value;
        }

        public static string FormatAndCheckDateForGrid(string objstr)
        {

            if (objstr.Length >= 6)
            {
                objstr = FormatDateTwoZeroStyle(objstr);

                if (objstr == "Null")
                {
                    return "";
                }

                if (CheckDate(objstr) == false)
                {
                    return "";
                }

                if (DateTime.Now.ToString("yyyy").CompareTo("1400") < 0)
                {
                    return "13" + objstr;
                }
                else
                {
                    if (Shared.Val(objstr.Substring(0, 2)) >= 0
                        && Shared.Val(objstr.Substring(0, 2)) <= 40)
                    {
                        return "14" + objstr;
                    }
                    else
                    {
                        return "13" + objstr;
                    }
                }

            }
            else
            {
                return "";
            }
        }

        #endregion

        #region Properties
        public static string GetLastEventUse { get; set; }
        #endregion
    }

    /// <summary>
    /// query Convert to DataTable
    /// </summary>
    public static class IEnumerableExt
    {
        /// <summary>
        /// query to DataTable
        /// </summary>
        /// <typeparam name="T">array</typeparam>
        /// <param name="things">query linq result</param>
        /// <returns>datatable</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> things) where T : class
        {
            DataTable tbl = new DataTable();
            bool buildColumns = false;
            foreach (var item in things)
            {
                Type t = item.GetType();
                var properties = t.GetProperties();
                if (!buildColumns)
                {
                    foreach (var prop in properties)
                    {
                        Type ptype = prop.PropertyType;

                        //nasiri910508
                        if (prop.PropertyType.IsGenericType &&
                               (prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) | prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<int>)))
                        {
                            //nasiri910508
                            // ptype = prop.GetValue(item, null).GetType();
                            ptype = Nullable.GetUnderlyingType(ptype);
                            tbl.Columns.Add(prop.Name, ptype);
                        }
                        else
                        {

                            tbl.Columns.Add(prop.Name, prop.PropertyType);

                        }
                        //DataColumn col = new DataColumn(prop.Name, ptype);
                        //tbl.Columns.Add(col);
                    }
                    buildColumns = true;
                }
                DataRow row = tbl.NewRow();

                foreach (var prop in properties)
                {
                    Type ptype = prop.PropertyType;
                    if (prop.PropertyType.IsGenericType &&
                               (prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) | prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<int>))
                        )
                    {
                        //row[prop.Name] =;
                    }
                    else
                    {
                        row[prop.Name] = prop.GetValue(item, null);
                    }
                }

                tbl.Rows.Add(row);
            }

            return tbl;
        }
    }

    //nemat 91
    public static class UserInfo
    {
        #region Properties

        public static int UserId { get; set; }
        public static int PersonId { get; set; }
        public static string UserPerName { get; set; }
        public static string UserPerFamily { get; set; }
        public static string UserPerEmail { get; set; }
        public static string UserPerMobile { get; set; }
        public static string UserPerCode { get; set; }
        public static string UserPerCodeMeli { get; set; }
        public static string UserName { get; set; }
        public static List<string> UserRole { get; set; }
        public static string ComputerLabel { get; set; }
        public static string MacAddress { get; set; }
        public static string IpAddress { get; set; }

        #endregion
    }




}
