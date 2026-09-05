
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GeneralKiosk
{
    class AddEditBaseMethods : IDisposable
    {
        #region Initial

        #region DefinitionOfvariables

        //------------------------------Objects---------------------------------------------------------------------
        private bool disposed;

        #endregion

        #region ConstructorDispose

        public AddEditBaseMethods()
        {
        }

        ~AddEditBaseMethods()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// The dispose method that implements IDisposable.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The virtual dispose method that allows
        /// classes inherithed from this one to dispose their resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here.
                }

                // Dispose unmanaged resources here.
            }

            disposed = true;
        }

        #endregion

        #endregion

        //---------------------------------------------------------------------------------------------------------------------------------

        #region Common

        public (int ID, string SelectedName, long TafsilyID) GetListOfObject(string tbl, string srch = "")
        {
            DataTable dt = new DataTable(tbl);
            int ID = -1;
            long TafsilyID = -1;
            string SelectedName = string.Empty;

            switch (tbl)
            {
                case "Color":

                    #region MyRegion

                    dt = new BaseInformation().GetColor(true).Tables[0];
                    break;

                #endregion

                case "Size":

                    #region MyRegion

                    dt = new BaseInformation().GetSize(true).Tables[0];
                    break;

                #endregion

                case "SaloonDefault":

                    #region MyRegion

                    dt = new BaseInformation().GetSaloon().Tables[0];
                    break;

                #endregion

                case "Table":

                    #region MyRegion

                    dt = new BaseInformation().GetTable(true, Shared.Val(srch)).Tables[0];
                    break;

                #endregion

                case "FreeTable":

                    #region MyRegion

                    dt = new BaseInformation().GetFreeTableForReserve(srch).Tables[0];
                    break;

                #endregion

                case "LablePrintPattern":

                    #region MyRegion

                    dt = new BaseInformation().GetBarcodeLablePattern(null).Tables[0];
                    break;

                #endregion

                case "Section":

                    #region MyRegion

                    dt = new BaseInformation().GetSection(true).Tables[0];
                    break;

                #endregion

                case "Unit":

                    #region MyRegion

                    dt = new BaseInformation().GetUnit(true).Tables[0];
                    break;

                #endregion

                case "Group":

                    #region MyRegion

                    dt = new BaseInformation().GetGroup(true).Tables[0];
                    break;

                #endregion

                case "SubGroup":

                    #region MyRegion

                    dt = new BaseInformation().GetSubGroup(true).Tables[0];
                    break;

                #endregion

                case "WareHouse":

                    #region MyRegion

                    dt = new BaseInformation().GetWareHouse(true).Tables[0];
                    break;

                #endregion

                case "Brand":

                    #region MyRegion

                    dt = new BaseInformation().GetBrand(true).Tables[0];
                    break;

                #endregion

                case "Manufacturer":

                    #region MyRegion

                    dt = new BaseInformation().GetManufacturer(true).Tables[0];
                    break;

                #endregion

                case "PackType":

                    #region MyRegion

                    dt = new BaseInformation().GetPackType(true).Tables[0];
                    break;

                #endregion

                case "Province":

                    #region MyRegion

                    dt = new BaseInformation().GetProvince().Tables[0];
                    break;

                #endregion

                case "City":

                    #region MyRegion

                    dt = new BaseInformation().GetCity(srch).Tables[0];
                    break;

                #endregion

                case "FeatureCategory":

                    #region MyRegion

                    dt = new BaseInformation().GetFeatureCategory(null).Tables[0];
                    break;

                #endregion


              

               

                //----------------------------------------------------------------------

                case "Specialty":

                    #region MyRegion

                    dt = new BaseInformation().GetSpecialty(true).Tables[0];
                    break;

                #endregion

                case "Level":

                    #region MyRegion

                    dt = new BaseInformation().GetLevel(true).Tables[0];
                    break;

                #endregion

                case "Shelf":

                    #region MyRegion

                    dt = new BaseInformation().GetShelf(true).Tables[0];
                    break;

                #endregion

                case "Shape":

                    #region MyRegion

                    dt = new BaseInformation().GetShape(true).Tables[0];
                    break;

                #endregion

                case "Information":

                    #region MyRegion

                    dt = new BaseInformation().GetInfo(true).Tables[0];
                    break;

                #endregion

                case "Alert":

                    #region MyRegion

                    dt = new BaseInformation().GetAlert(true).Tables[0];
                    break;

                #endregion

                case "MethodUse":

                    #region MyRegion

                    dt = new BaseInformation().GetMethodUse(true).Tables[0];
                    break;

                    #endregion

            }


            return (ID, SelectedName, TafsilyID);
        }
#endregion


        //---------------------------------------------------------------------------------------------------------------------------------

        #region Unit


        #endregion

        #region Group

        public (int GroupID, string GroupName) AddGroup(bool OneAdd)
        {
            FrmGroupAddEdit form = new FrmGroupAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int GroupID = form.PrimaryKey;
            string GroupName = form.GroupName;

            return (GroupID, GroupName);
        }
        public (int GroupID, string GroupName) EditGroup(int ID, bool OneAdd)
        {
            FrmGroupAddEdit form = new FrmGroupAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int GroupID = form.PrimaryKey;
            string GroupName = form.GroupName;

            return (GroupID, GroupName);
        }

        #endregion

        #region SubGroup

        public (int SubGroupID, string SubGroupName) AddSubGroup(bool OneAdd)
        {
            FrmSubGroupAddEdit form = new FrmSubGroupAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int SubGroupID = form.PrimaryKey;
            string SubGroupName = form.SubGroupName;

            return (SubGroupID, SubGroupName);
        }
        public (int SubGroupID, string SubGroupName) EditSubGroup(int ID, bool OneAdd)
        {
            FrmSubGroupAddEdit form = new FrmSubGroupAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int SubGroupID = form.PrimaryKey;
            string SubGroupName = form.SubGroupName;

            return (SubGroupID, SubGroupName);
        }

        #endregion

        #region WareHouse

        public (int WareHouseID, string WareHouseName, int TafsilyID) AddWareHouse(bool OneAdd)
        {
            FrmWareHouseAddEdit form = new FrmWareHouseAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int WareHouseID = form.PrimaryKey;
            string WareHouseName = form.WareHouseName;
            int TafsilyID = Shared.Val(form.TafsilyID);

            return (WareHouseID, WareHouseName, TafsilyID);
        }
        public (int WareHouseID, string WareHouseName) EditWareHouse(int ID, bool OneAdd)
        {
            FrmWareHouseAddEdit form = new FrmWareHouseAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int WareHouseID = form.PrimaryKey;
            string WareHouseName = form.WareHouseName;

            return (WareHouseID, WareHouseName);
        }
        public DataTable FillWareHouseStatus()
        {
            try
            {
                #region GetData

                DataTable dt = new BaseInformation().GetWareHouseStatus().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }

                #endregion
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return null;
            }
        }

        #endregion





        #region PackType

        public (int PackTypeID, string PackTypeName) AddPackType(bool OneAdd)
        {
            FrmPackTypeAddEdit form = new FrmPackTypeAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int PackTypeID = form.PrimaryKey;
            string PackTypeName = form.PackTypeName;

            return (PackTypeID, PackTypeName);
        }
        public (int PackTypeID, string PackTypeName) EditPackType(int ID, bool OneAdd)
        {
            FrmPackTypeAddEdit form = new FrmPackTypeAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int PackTypeID = form.PrimaryKey;
            string PackTypeName = form.PackTypeName;

            return (PackTypeID, PackTypeName);
        }

        #endregion

        #region Brand

        public (int BrandID, string BrandName) AddBrand(bool OneAdd)
        {
            FrmBrandAddEdit form = new FrmBrandAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int BrandID = form.PrimaryKey;
            string BrandName = form.BrandName;

            return (BrandID, BrandName);
        }
        public (int BrandID, string BrandName) EditBrand(int ID, bool OneAdd)
        {
            FrmBrandAddEdit form = new FrmBrandAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int BrandID = form.PrimaryKey;
            string BrandName = form.BrandName;

            return (BrandID, BrandName);
        }

        #endregion

        #region GroupDiscount

        public long AddGroupDiscount(bool OneAdd)
        {
            FrmGroupDiscountAddEdit form = new FrmGroupDiscountAddEdit
            {
                CaptionDiscountGroup = string.Empty,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            long GroupDiscountID = form.PrimaryKey;

            return (GroupDiscountID);
        }
        public long EditGroupDiscount(string Caption, bool OneAdd)
        {
            FrmGroupDiscountAddEdit form = new FrmGroupDiscountAddEdit
            {
                CaptionDiscountGroup = Caption
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            long GroupDiscountID = form.PrimaryKey;

            return (GroupDiscountID);
        }

        #endregion

        #region Manufacturer

        public (int ManufacturerID, string ManufacturerName) AddManufacturer(bool OneAdd)
        {
            FrmManufacturerAddEdit form = new FrmManufacturerAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int ManufacturerID = form.PrimaryKey;
            string ManufacturerName = form.ManufacturerName;

            return (ManufacturerID, ManufacturerName);
        }
        public (int ManufacturerID, string ManufacturerName) EditManufacturer(int ID, bool OneAdd)
        {
            FrmManufacturerAddEdit form = new FrmManufacturerAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int ManufacturerID = form.PrimaryKey;
            string ManufacturerName = form.ManufacturerName;

            return (ManufacturerID, ManufacturerName);
        }

        #endregion

        #region Specialty

        public (int SpecialtyID, string SpecialtyName) AddSpecialty(bool OneAdd)
        {
            FrmSpecialtyAddEdit form = new FrmSpecialtyAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int SpecialtyID = form.PrimaryKey;
            string SpecialtyName = form.SpecialtyName;

            return (SpecialtyID, SpecialtyName);
        }
        public (int SpecialtyID, string SpecialtyName) EditSpecialty(int ID, bool OneAdd)
        {
            FrmSpecialtyAddEdit form = new FrmSpecialtyAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int SpecialtyID = form.PrimaryKey;
            string SpecialtyName = form.SpecialtyName;

            return (SpecialtyID, SpecialtyName);
        }

        #endregion

        #region Level

        public (int LevelID, string LevelName) AddLevel(bool OneAdd)
        {
            FrmLevelAddEdit form = new FrmLevelAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int LevelID = form.PrimaryKey;
            string LevelName = form.LevelName;

            return (LevelID, LevelName);
        }
        public (int LevelID, string LevelName) EditLevel(int ID, bool OneAdd)
        {
            FrmLevelAddEdit form = new FrmLevelAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int LevelID = form.PrimaryKey;
            string LevelName = form.LevelName;

            return (LevelID, LevelName);
        }

        #endregion

        #region Color

        public (int ColorID, string ColorName) AddColor(bool OneAdd)
        {
            FrmColorAddEdit form = new FrmColorAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int ColorID = form.PrimaryKey;
            string ColorName = form.ColorName;

            return (ColorID, ColorName);
        }
        public (int ColorID, string ColorName) EditColor(int ID, bool OneAdd)
        {
            FrmColorAddEdit form = new FrmColorAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int ColorID = form.PrimaryKey;
            string ColorName = form.ColorName;

            return (ColorID, ColorName);
        }

        #endregion

        #region Size

        public (int SizeID, string SizeName) AddSize(bool OneAdd)
        {
            FrmSizeAddEdit form = new FrmSizeAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int SizeID = form.PrimaryKey;
            string SizeName = form.SizeName;

            return (SizeID, SizeName);
        }
        public (int SizeID, string SizeName) EditSize(int ID, bool OneAdd)
        {
            FrmSizeAddEdit form = new FrmSizeAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int SizeID = form.PrimaryKey;
            string SizeName = form.SizeName;

            return (SizeID, SizeName);
        }

        #endregion

        #region Shape

        public (int ShapeID, string ShapeName) AddShape(bool OneAdd)
        {
            FrmShapeAddEdit form = new FrmShapeAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int ShapeID = form.PrimaryKey;
            string ShapeName = form.ShapeName;

            return (ShapeID, ShapeName);
        }
        public (int ShapeID, string ShapeName) EditShape(int ID, bool OneAdd)
        {
            FrmShapeAddEdit form = new FrmShapeAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int ShapeID = form.PrimaryKey;
            string ShapeName = form.ShapeName;

            return (ShapeID, ShapeName);
        }

        #endregion

        #region Shelf

        public (int ShelfID, string ShelfName) AddShelf(bool OneAdd)
        {
            FrmShelfAddEdit form = new FrmShelfAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int ShelfID = form.PrimaryKey;
            string ShelfName = form.ShelfName;

            return (ShelfID, ShelfName);
        }
        public (int ShelfID, string ShelfName) EditShelf(int ID, bool OneAdd)
        {
            FrmShelfAddEdit form = new FrmShelfAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int ShelfID = form.PrimaryKey;
            string ShelfName = form.ShelfName;

            return (ShelfID, ShelfName);
        }

        #endregion

        #region Alert

        public (int AlertID, string Alert) AddAlert(bool OneAdd)
        {
            FrmAlertAddEdit form = new FrmAlertAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int AlertID = form.PrimaryKey;
            string Alert = form.Alert;

            return (AlertID, Alert);
        }
        public (int AlertID, string Alert) EditAlert(int ID, bool OneAdd)
        {
            FrmAlertAddEdit form = new FrmAlertAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int AlertID = form.PrimaryKey;
            string Alert = form.Alert;

            return (AlertID, Alert);
        }

        #endregion

        #region Info

        public (int InfoID, string Info) AddInfo(bool OneAdd)
        {
            FrmInfoAddEdit form = new FrmInfoAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int InfoID = form.PrimaryKey;
            string Info = form.Info;

            return (InfoID, Info);
        }
        public (int InfoID, string Info) EditInfo(int ID, bool OneAdd)
        {
            FrmInfoAddEdit form = new FrmInfoAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int InfoID = form.PrimaryKey;
            string Info = form.Info;

            return (InfoID, Info);
        }

        #endregion

        #region MethodUse

        public (int MethodUseID, string MethodUse) AddMethodUse(bool OneAdd)
        {
            FrmMethodUseAddEdit form = new FrmMethodUseAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int MethodUseID = form.PrimaryKey;
            string MethodUse = form.MethodUse;

            return (MethodUseID, MethodUse);
        }
        public (int MethodUseID, string MethodUse) EditMethodUse(int ID, bool OneAdd)
        {
            FrmMethodUseAddEdit form = new FrmMethodUseAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int MethodUseID = form.PrimaryKey;
            string MethodUse = form.MethodUse;

            return (MethodUseID, MethodUse);
        }

        #endregion

        #region AdditionsSubtractions

        public (int AdditionsSubtractionsID, string AdditionsSubtractionsName) AddAdditionsSubtractions(bool OneAdd)
        {
            FrmAdditionsSubtractionsAddEdit form = new FrmAdditionsSubtractionsAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int AdditionsSubtractionsID = form.PrimaryKey;
            string AdditionsSubtractionsName = form.AdditionsSubtractionsName;

            return (AdditionsSubtractionsID, AdditionsSubtractionsName);
        }
        public (int AdditionsSubtractionsID, string AdditionsSubtractionsName) EditAdditionsSubtractions(int ID, bool OneAdd)
        {
            FrmAdditionsSubtractionsAddEdit form = new FrmAdditionsSubtractionsAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int AdditionsSubtractionsID = form.PrimaryKey;
            string AdditionsSubtractionsName = form.AdditionsSubtractionsName;

            return (AdditionsSubtractionsID, AdditionsSubtractionsName);
        }

        #endregion

        #region GeneralStatus



        #endregion

        //---------------------------------------------------------------------------------------------------------------------------------

        #region Country

        public DataTable FillCountry()
        {
            try
            {
                #region GetData

                DataTable dt = new BaseInformation().GetCountry().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }

                #endregion
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return null;
            }

        }
        #endregion

        //---------------------------------------------------------------------------------------------------------------------------------

        #region Person

        public (long PersonID, string PersonName, string CompanyName) AddPerson(bool OneAdd, string TypeRole, string MobilePerson = "")
        {
            FrmPersonAddEdit form = new FrmPersonAddEdit
            {
                PrimaryKey = 0,
                ISCustomer = TypeRole == "Customer" ? true : false,
                ISSupplier = TypeRole.Contains("Supplier") ? true : false,
                ISPiek = TypeRole.Contains("Piek") ? true : false,
                ISVisitor = TypeRole.Contains("Visitor") ? true : false,
                ISEmployee = TypeRole.Contains("Employee") ? true : false,
                Mobile = MobilePerson,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            long PersonID = form.PrimaryKey;
            string PersonName = form.PersonName;
            string CompanyName = form.CompanyName;

            return (PersonID, PersonName, CompanyName);
        }
        public (long PersonID, string PersonName, string CompanyName) EditPerson(long ID, bool OneAdd)
        {
            FrmPersonAddEdit form = new FrmPersonAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            long PersonID = form.PrimaryKey;
            string PersonName = form.PersonName;
            string CompanyName = form.CompanyName;

            return (PersonID, PersonName, CompanyName);
        }
        public DataTable FillPersonStatus()
        {
            try
            {
                #region GetData

                DataTable dt = new BaseInformation().GetPersonStatus().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }

                #endregion
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return null;
            }
        }

        #endregion

        //---------------------------------------------------------------------------------------------------------------------------------

        #region Saloon

        public (int SaloonID, string Saloon) AddSaloon(bool OneAdd)
        {
            FrmSaloonAddEdit form = new FrmSaloonAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int SaloonID = form.PrimaryKey;
            string Saloon = form.Saloon;

            return (SaloonID, Saloon);
        }
        public (int SaloonID, string Saloon) EditSaloon(int ID, bool OneAdd)
        {
            FrmSaloonAddEdit form = new FrmSaloonAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int SaloonID = form.PrimaryKey;
            string Saloon = form.Saloon;

            return (SaloonID, Saloon);
        }

        #endregion

        #region Table

        public (int TableID, string Table) AddTable(bool OneAdd, int SaloonID)
        {
            FrmTableAddEdit form = new FrmTableAddEdit
            {
                PrimaryKey = 0,
                SaloonID = SaloonID,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int TableID = form.PrimaryKey;
            string Table = form.Table;

            return (TableID, Table);
        }
        public (int TableID, string Table) EditTable(int ID, int SaloonID, bool OneAdd)
        {
            FrmTableAddEdit form = new FrmTableAddEdit
            {
                PrimaryKey = ID,
                SaloonID = SaloonID,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int TableID = form.PrimaryKey;
            string Table = form.Table;

            return (TableID, Table);
        }

        #endregion

        #region Reserve

        public (int ReserveID, string Reserve) AddReserve(bool OneAdd)
        {
            FrmReserveAddEdit form = new FrmReserveAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int ReserveID = form.PrimaryKey;
            string Reserve = form.Reserve;

            return (ReserveID, Reserve);
        }
        public (int ReserveID, string Reserve) EditReserve(int ID, bool OneAdd)
        {
            FrmReserveAddEdit form = new FrmReserveAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int ReserveID = form.PrimaryKey;
            string Reserve = form.Reserve;

            return (ReserveID, Reserve);
        }

        #endregion

        //---------------------------------------------------------------------------------------------------------------------------------

        #region GeneralType

        public DataTable FillGeneralType(string Type)
        {
            try
            {
                #region GetData

                DataTable dt = new BaseInformation().GetGeneralType(Type).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }

                #endregion
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return null;
            }
        }

        #endregion

        //---------------------------------------------------------------------------------------------------------------------------------

        #region User

        public (int UserID, string UserName) AddUser(bool OneAdd)
        {
            FrmUserAddEdit form = new FrmUserAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int UserID = form.PrimaryKey;
            string UserName = form.UserName;

            return (UserID, UserName);
        }
        public (int UserID, string UserName) EditUser(int ID, bool OneAdd)
        {
            FrmUserAddEdit form = new FrmUserAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int UserID = form.PrimaryKey;
            string UserName = form.UserName;

            return (UserID, UserName);
        }

        #endregion

        #region Role

        public (int RoleID, string RoleName) AddRole(bool OneAdd)
        {
            FrmRoleAddEdit form = new FrmRoleAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int RoleID = form.PrimaryKey;
            string RoleName = form.RoleName;

            return (RoleID, RoleName);
        }
        public (int RoleID, string RoleName) EditRole(int ID, bool OneAdd)
        {
            FrmRoleAddEdit form = new FrmRoleAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int RoleID = form.PrimaryKey;
            string RoleName = form.RoleName;

            return (RoleID, RoleName);
        }
        public DataTable FillRoles()
        {
            try
            {
                #region GetData

                DataTable dt = new BaseInformation().GetRole().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }

                #endregion
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return null;
            }
        }

        #endregion

        #region FeatureCategory

        public (int FeatureCategoryID, string FeatureCategoryCaption) AddFeatureCategory()
        {
            FrmFeatureCategoryAddEdit form = new FrmFeatureCategoryAddEdit
            {
                PrimaryKey = 0,
            };
            form.ShowDialog();

            int FeatureCategoryID = form.PrimaryKey;
            string FeatureCategoryCaption = form.FeatureCategoryCaption;

            return (FeatureCategoryID, FeatureCategoryCaption);
        }
        public (int FeatureCategoryID, string FeatureCategoryCaption) EditFeatureCategory(int ID)
        {
            FrmFeatureCategoryAddEdit form = new FrmFeatureCategoryAddEdit
            {
                PrimaryKey = ID
            };
            form.ShowDialog();

            int FeatureCategoryID = form.PrimaryKey;
            string FeatureCategoryCaption = form.FeatureCategoryCaption;

            return (FeatureCategoryID, FeatureCategoryCaption);
        }

        #endregion

        #region GetUsers

        public DataTable FillUser()
        {
            try
            {
                #region GetData

                DataTable dt = new BaseInformation().GetUserName().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }

                #endregion
            }
            catch (Exception ex)
            {
                Shared.ShowMessage(EnumSendMessage.TryCatchMessage, ex.Message);
                return null;
            }
        }

        #endregion

        //---------------------------------------------------------------------------------------------------------------------------------

        #region LablePatternSetting

        public (int LablePatternID, string LablePattern) AddLablePatternSetting(bool OneAdd)
        {
            FrmLablePatternSettingAddEdit form = new FrmLablePatternSettingAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int LablePatternID = form.PrimaryKey;
            string LablePattern = form.LablePattern;

            return (LablePatternID, LablePattern);
        }
        public (int LablePatternID, string LablePattern) EditLablePatternSetting(int ID, bool OneAdd)
        {
            FrmLablePatternSettingAddEdit form = new FrmLablePatternSettingAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int LablePatternID = form.PrimaryKey;
            string LablePattern = form.LablePattern;

            return (LablePatternID, LablePattern);
        }

        #endregion

        #region BarcodePattern

        public (int BarcodePatternID, string BarcodePatternName) AddBarcodePattern(bool OneAdd)
        {
            FrmBarcodePatternAddEdit form = new FrmBarcodePatternAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int BarcodePatternID = form.PrimaryKey;
            string BarcodePatternName = form.BarcodePatternName;

            return (BarcodePatternID, BarcodePatternName);
        }
        public (int BarcodePatternID, string BarcodePatternName) EditBarcodePattern(int ID, bool OneAdd)
        {
            FrmBarcodePatternAddEdit form = new FrmBarcodePatternAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int BarcodePatternID = form.PrimaryKey;
            string BarcodePatternName = form.BarcodePatternName;

            return (BarcodePatternID, BarcodePatternName);
        }

        #endregion

        //---------------------------------------------------------------------------------------------------------------------------------

        //#region Branch

        //public (int BranchID, string BranchName) AddBranch(bool OneAdd)
        //{
        //    FrmBranchAddEdit form = new FrmBranchAddEdit
        //    {
        //        PrimaryKey = 0,
        //    };
        //    if (OneAdd)
        //        form.UiButtonSaveNew.Enabled = false;
        //    form.ShowDialog();

        //    int BranchID = form.PrimaryKey;
        //    string BranchName = form.BranchName;

        //    return (BranchID, BranchName);
        //}
        //public (int BranchID, string BranchNamee) EditBranch(int ID, bool OneAdd)
        //{
        //    FrmBranchAddEdit form = new FrmBranchAddEdit
        //    {
        //        PrimaryKey = ID
        //    };
        //    if (OneAdd)
        //        form.UiButtonSaveNew.Enabled = false;
        //    form.ShowDialog();

        //    int BranchID = form.PrimaryKey;
        //    string BranchName = form.BranchName;

        //    return (BranchID, BranchName);
        //}

        //#endregion

        #region Section

        public (int SectionID, string SectionName) AddSection(bool OneAdd)
        {
            FrmSectionAddEdit form = new FrmSectionAddEdit
            {
                PrimaryKey = 0,
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int SectionID = form.PrimaryKey;
            string SectionName = form.SectionName;

            return (SectionID, SectionName);
        }
        public (int SectionID, string SectionName) EditSection(int ID, bool OneAdd)
        {
            FrmSectionAddEdit form = new FrmSectionAddEdit
            {
                PrimaryKey = ID
            };
            if (OneAdd)
                form.UiButtonSaveNew.Enabled = false;
            form.ShowDialog();

            int SectionID = form.PrimaryKey;
            string SectionName = form.SectionName;

            return (SectionID, SectionName);
        }

        #endregion



        private void InsertLogPerson(long CheckUnique)
        {
            #region Insert Log

            //if (PrimaryKey <= 0)
            //{
            //    string TempString = "طرف حساب به نام : " + TxtPersonName.Text + " " + TxtPersonFamily.Text;

            //    TempString += " اضافه شد ";

            //    GeneralMethod.InsertLog(Name, Shared.GetCurrentMethod(), TempString, "BS", enumOperationLogType.Insert);
            //}

            #endregion
        }

    }
    
}
