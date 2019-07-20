using StockManagementApp.Models;
using StockManagementApp.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementApp.BIL
{
    class StockOutManager
    {
        StockOutRepository _stockOutRepository = new StockOutRepository();

        public int Insert(StockOut stockOut)
        {
            return _stockOutRepository.Insert(stockOut);
        }
        public DataTable StockOut()
        {
            return _stockOutRepository.LoadStockout();
        }
        public DataTable GetRiport(StockOut stockOut)
        {
            return _stockOutRepository.GetRiport(stockOut);
        }
    }
}
