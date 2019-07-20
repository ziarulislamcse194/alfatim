using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementApp.Models
{
    class StockOut
    {
        public int StockOutID { get; set; }

        public int StockOutQuentity { get; set; }
        public string StockOutStatus { get; set; }
        public DateTime StockOutDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ItemID { get; set; }

    }
}
