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
    class StockInManager
    {
        StockInRepository _stockInRepository = new StockInRepository();

        public int Insert(StockIn stockIn)
        {
            return _stockInRepository.Insert(stockIn);
        }
        public void Updatequentity(StockIn stockIn)
        {
            _stockInRepository.Updatequentity(stockIn);
        }

        public DataTable LoadStock()
        {
            return _stockInRepository.LoadStock();
        }

       
        public int GetID(Item item)
        {
            return _stockInRepository.GetID(item);
        }
        public void Update(StockIn stockIn)
        {
             _stockInRepository.Update(stockIn);
        }
        public DataTable Search(Company company, Categories categories)
        {
            return _stockInRepository.Search(company, categories);
        }
    }
}
