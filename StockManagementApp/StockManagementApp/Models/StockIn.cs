using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementApp.Models
{
    public class StockIn
    {
        public int StockInID { get; set; }
        public int StockInQuentity{ get; set;}
        public int StockAvailableQuentity { get; set; }

        public DateTime StockInDate { get; set; }
        public int ItemID { get; set; }
    }
}
