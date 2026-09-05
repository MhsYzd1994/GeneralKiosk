using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKiosk.Class
{
    public partial class TPYR
    {
        public int TPYRID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Mobile { get; set; }
        public string BirthDate { get; set; }
        public string MarriedDate { get; set; }
        public Nullable<int> Jensiat { get; set; }
        public Nullable<System.DateTime> InsertDate { get; set; }
        public Nullable<System.Guid> BranchID { get; set; }
        public string ShopName { get; set; }
        public Nullable<int> TpyrInterval { get; set; }
        public Nullable<System.DateTime> TpyrLastReceiptTime { get; set; }
    }

}
