using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKiosk.Class.GhanunFarma
{
    class data
    {
        public string drugstoreName { get; set; }
        public int kioskDiscount { get; set; }
        public DataTable bankAccounts { get; set; }
        public DataTable poses { get; set; }
        public DataTable partners { get; set; }
        public DataTable tags { get; set; }
        public DataTable warehouses { get; set; }
    }
}
