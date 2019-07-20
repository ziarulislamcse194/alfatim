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
    class ItemManager
    {
        Item item = new Item();
        ItemRepository _itemRepository = new ItemRepository();

        public int insert(Item item)
        {

            return _itemRepository.Insert(item);
        }

        public DataTable loadCompany()
        {
            return _itemRepository.LoadCompany();
        }

        public DataTable loadCategory()
        {
            return _itemRepository.LoadCategory();
        }

        public DataTable View()
        {
            return _itemRepository.View();
        }
        public DataTable Category(Company company)
        {
            return _itemRepository.Category(company);
        }

        public DataTable Item(Categories categories)
        {
            return _itemRepository.Item(categories);
        }

        public int ReorderLavel(Item item)
        {
            return _itemRepository.ReorderLavel(item);
        }

        public int Quentity(Item item)
        {
            return _itemRepository.Quentity(item);
        }

        public int AvailableQuentity(Item item)
        {
            return _itemRepository.AvailableQuentity(item);
        }

        public int ItemId(Item item)
        {
            return _itemRepository.ItemId(item);
        }
    }
}
