using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryCafe
{
    class ProgramUI
    {
        private static MenuItemRepo _itemRepo = new MenuItemRepo();

        static void Main(string[] args)
        {
            DefaultMenu();
            bool continueToRun = true;
            while (continueToRun is true)
            {


                Console.Clear();
                Console.WriteLine("Enter the number of the choice you would like to select: \n\n" +
                    "1: Show all items in menu.\n" +
                    "2: Add new item to menu\n" +
                    "3: Remove existing item from menu \n" +
                    "4: Close Application\n\n");
                string pokeInput = Console.ReadLine();
                switch (pokeInput)
                {
                    case "1":
                        ShowAllItemsInMenu();
                        break;
                    case "2":
                        CreateNewMenuItem();
                        break;
                    case "3":
                        DeleteSelectedItemInMenu();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid entry.\n\n Press enter to continue:");
                            Console.ReadLine();
                        break;
                }

            }
        }

        private static void CreateNewMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter the name of the new berry:\n");
            var BerryName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Please enter the {BerryName} Berry's item number:\n");
            int result;
            bool convert = Int32.TryParse(Console.ReadLine(), out result);
            int ItemNumber = result;
            if (!convert)
            {
                ItemNumber = 0;
            }
            Console.Clear();
            Console.WriteLine($"Please describe the {BerryName} Berry's taste profile:\n");
            var TasteDescription = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Please describe the {BerryName} Berry's effect on client pokemon:\n");
            var Effects = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Please declare price to charge customer for each {BerryName} Berry sold\n\n CAUTION:If value entered is invalid -{BerryName} will default to free");
            bool convert2 = Int32.TryParse(Console.ReadLine(), out result);
            int Price = result;
            if (!convert2)
            {
                Price = 0;
            }
            Console.Clear();
            Console.WriteLine($"Please add region of soil required for optimal {BerryName} Berry growth:");
            string input = Console.ReadLine();
            List<string> GrowBerry = new List<string>();
               GrowBerry.Add(input);
            Console.Clear();
            Console.WriteLine($"Please describe how often to water {BerryName} Berry:");
            string input2 = Console.ReadLine();
            GrowBerry.Add(input2);
            Console.Clear();
            Console.WriteLine($"Please state when {BerryName} Berry will be ready for Harvest");
            string input3 = Console.ReadLine();
            GrowBerry.Add($"Harvestable in {input3}");
            _itemRepo.AddItemToMenu(ItemNumber, BerryName, TasteDescription, Effects, Price, GrowBerry );
        }
        private static void ShowAllItemsInMenu()
        {
            Console.Clear();
            List<MenuItem> listOfItems = _itemRepo.ShowItems();
            foreach (MenuItem item in listOfItems)
            {
                Console.WriteLine($"{item.ItemNumber}:{item.BerryName}, {item.Price}¥; {item.TasteDescription}. Effect on Pokemon: {item.Effects}\n  {item.GrowBerry[0]}, {item.GrowBerry[1]}, {item.GrowBerry[2]}.\n\n");
            }
            Console.WriteLine("Press enter to continue:");
            Console.ReadLine();
        }
        private static void DeleteSelectedItemInMenu()
        {
            Console.Clear();
            Console.WriteLine("Which menu item would you like to remove?\n");
            List<MenuItem> itemList = _itemRepo.ShowItems();
            int track = 0;
            foreach ( var item in itemList)
            {
                track -= -1;
                Console.WriteLine($"{track}: {item.BerryName}");
            }
            int userInput = int.Parse(Console.ReadLine());
            int listNumber = userInput - 1;
            if (listNumber >= 0 && listNumber < itemList.Count)
            {
                MenuItem selectedItem = itemList[listNumber];
                if (_itemRepo.DeleteItem(selectedItem))
                {
                    Console.WriteLine($"{selectedItem.BerryName} removed from menu.");
                }
                else
                {
                    Console.WriteLine("Unable to complete deletion. Please check current menu and try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Option:");
            }
            Console.WriteLine("Press enter to continue:");
            Console.ReadLine(); 
        }

        public static void DefaultMenu()
        {
            _itemRepo.AddItemToMenu(01, "Oran", "Nature's gifts came together as one in this Berry. It has a wondrous mix of flavors that spread in the mouth", "Heals 10HP", 100, new List<string>(){"Kanto Soil","Water Daily","Harvestable in 2 weeks"});
            _itemRepo.AddItemToMenu(02, "Chesto", "This Berry's thick skin and fruit are very tough and dry tasting. However, every bit of it can be eaten.", "Cures Sleep", 50, new List<string>() { "Johto Soil", "Water Twice Daily", "Harvestable in 1 week" }); 
            _itemRepo.AddItemToMenu(03, "Pecha", "Very sweet and delicious. Also very tender - handle with care.", "Cures Poison", 50, new List<string>() { "Hoenn Soil", "Water Nightly", "Harvestable in 8 weeks" });
            _itemRepo.AddItemToMenu(04, "Rawst", "If the leaves grow longer and curlier than average, this Berry will have a somewhat-bitter taste.", "Cures Burn", 150, new List<string>() { "Johto/Hoenn Soil", "Water Every Other Day", "Harvestable in 20 weeks" });
            _itemRepo.AddItemToMenu(05, "Aspear", "This Berry's peel is hard, but the flesh inside is very juicy. It is distinguished by its bracing sourness.", "Cures Freeze", 250, new List<string>() { "Kanto/Sinnoh Soil", "Mist Twice Daily", "Harvestable in 3 days" });

        }
    }
}
