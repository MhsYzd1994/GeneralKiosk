using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKiosk.Class.GhanunFarmaSendPayInfo
{
    class SendPayInfo
    {
        public long discount { get; set; }
        public string userId { get; set; }
        public string timestamp { get; set; }
        public DataTable items { get; set; }
        public DataTable payment { get; set; }
    }
}
