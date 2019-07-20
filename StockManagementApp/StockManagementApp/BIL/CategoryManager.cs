
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
    class CategoryManager 
    {
        CategoriesRepository _categoriesRepository = new CategoriesRepository();


        public int Insert(Categories categories)
        {

            return _categoriesRepository.Insert(categories);
        }

        public DataTable View()
        {

            return _categoriesRepository.View();
        }

        public int Update(Categories categories)
        {

            return _categoriesRepository.Update(categories);
        }

    }
}
