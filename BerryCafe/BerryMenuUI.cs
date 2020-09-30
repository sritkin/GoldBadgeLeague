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
                    "4: Close Application");
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
                        Console.WriteLine("Invalid entry.\n\n Press enter to continue:");
                            Console.ReadLine();
                        break;
                }

            }
        }

        private static void CreateNewMenuItem()
        {
            Console.WriteLine("Please enter the name of the new berry:\n");
            var BerryName = Console.ReadLine();
            Console.WriteLine($"Please enter the {BerryName} Berry's item number:\n");
            var ItemNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Please describe the {BerryName} Berry's taste profile:\n");
            var TasteDescription = Console.ReadLine();
            Console.WriteLine($"Please describe the {BerryName} Berry's effect on client pokemon:\n");
            var Effects = Console.ReadLine();
            Console.WriteLine($"Please declare price to charge customer for each {BerryName} Berry sold");
            var Price = int.Parse(Console.ReadLine());
            _itemRepo.AddItemToMenu(ItemNumber, BerryName, TasteDescription, Effects, Price );
        }
        private static void ShowAllItemsInMenu()
        {
            Console.Clear();
            List<MenuItem> listOfItems = _itemRepo.ShowItems();
            foreach (MenuItem item in listOfItems)
            {
                Console.WriteLine($"{item.ItemNumber}:{item.BerryName}, {item.Price}¥; {item.TasteDescription}. Effect on Pokemon: {item.Effects}\n");
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
            _itemRepo.AddItemToMenu(01, "Oran", "Nature's gifts came together as one in this Berry. It has a wondrous mix of flavors that spread in the mouth", "Heals 10HP", 100);
            _itemRepo.AddItemToMenu(02, "Chesto", "This Berry's thick skin and fruit are very tough and dry tasting. However, every bit of it can be eaten.", "Cures Sleep", 50); 
            _itemRepo.AddItemToMenu(03, "Pecha", "Very sweet and delicious. Also very tender - handle with care.", "Cures Poison", 50);
            _itemRepo.AddItemToMenu(04, "Rawst", "If the leaves grow longer and curlier than average, this Berry will have a somewhat-bitter taste.", "Cures Burn", 150);
            _itemRepo.AddItemToMenu(05, "Aspear", "This Berry's peel is hard, but the flesh inside is very juicy. It is distinguished by its bracing sourness.", "Cures Freeze", 250);

        }
    }
}
