using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryCafe
{
    public class MenuItem
    {


        public int ItemNumber { get; set; }
        public string BerryName { get; set; }
        public string TasteDescription { get; set; }
        public string Effects { get; set; }
        public int Price { get; set; }
        public List<string> GrowBerry { get; set; }


        public MenuItem() { }
        public MenuItem(int number, string name, string taste, string effects, int price, List<string> grow)
        {
            ItemNumber = number;
            BerryName = name;
            TasteDescription = taste;
            Effects = effects;
            Price = price;
            GrowBerry = grow;
        }
    }
}
