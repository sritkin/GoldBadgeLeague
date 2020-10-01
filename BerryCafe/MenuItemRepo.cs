using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryCafe
{
    public class MenuItemRepo
    {
        protected readonly List<MenuItem> _itemList = new List<MenuItem>();
        //create
        public bool AddItemToMenu(int number, string name, string taste, string effects, int price, List<string> grow)
        {
            MenuItem item = new MenuItem(number, name, taste, effects, price, grow);
            int startCount = _itemList.Count;
            _itemList.Add(item);
            bool isAdded = (_itemList.Count > startCount) ? true : false;
            return isAdded;
        }
        //read
        public List<MenuItem> ShowItems()
        {
            return _itemList;
        }
        //delete
        public bool DeleteItem(MenuItem currentItem)
        {
            bool deleteItem = _itemList.Remove(currentItem);
            return deleteItem;
        }
    }
}
