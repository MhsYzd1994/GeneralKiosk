using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKiosk.Class.GhanunFarmaSendPayInfo
{
    class items
    {
        public string _id { get; set; }
        public string id { get; set; }
        public string serial { get; set; }
        public string user { get; set; }
        public string createUser { get; set; }
        public long kioskDiscount { get; set; }
        public long finalValueFee { get; set; }
        public long paidAmount { get; set; }
        public long payablePrice { get; set; }
        public long discountedPayablePrice { get; set; }

    }
}
