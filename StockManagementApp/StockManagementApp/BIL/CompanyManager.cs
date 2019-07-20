using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementApp.Models;
using StockManagementApp.Repository;
using System.Data;

namespace StockManagementApp.BIL
{
    public class CompanyManager
    {

        CompanyRepository _companyRepository= new CompanyRepository();

        public int CompanyIn(Company company)
        {
            return _companyRepository.Insert(company);
        }

        public int CompanyUpdate(Company company)
        {
            return _companyRepository.Update(company);
        }

        public DataTable View()
        {
            return _companyRepository.View();
        }

    }
}
