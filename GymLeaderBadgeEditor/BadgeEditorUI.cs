using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GymLeaderBadgeEditor
{
    class BadgeEditorUI
    {
        private static BadgeRepo _badgeRepo = new BadgeRepo();
        static void Main(string[] args)
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Pokemon League Admin. What would you like to do: \n\n" +
                    "1: Add a Badge.\n" +
                    "2: Edit a Badge\n" +
                    "3: List all Bagdges\n" +
                    "4: Close Application\n\n");
                string leagueInput = Console.ReadLine();
                switch (leagueInput)
                {
                    case "1":
                        AddBadgeUI();
                        break;
                    case "2":
                        EditBadgeUI();
                        break;
                    case "3":
                        ListBadgeUI();
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
            //create badge
            //provide dictionry of pokemen

            //add badge 
            // - give cityname
            // - collect pokeId's then pass as list
        }

        private static void AddBadgeUI()
        {
            List<int> leaderList = new List<int>();
            Console.Clear();
            Console.WriteLine("Please enter the name of the new badge city:\n");
            string cityName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter the National Pokedex entry number for primary allowed pokemon:\n");
            int result;
            bool convert = Int32.TryParse(Console.ReadLine(), out result);
            int dexNumberOne = result;
            if (!convert)
            {
                dexNumberOne = 0;
            }
            leaderList.Add(dexNumberOne);
            Console.Clear();
            Console.WriteLine("Does the gym leader need access to another pokemon (y/n)?");
            bool anotherPokemon;
            string input = Console.ReadLine();
            if (input.ToLower() is "y")
            {
                anotherPokemon = true;
            }
            else if (input.ToLower() is "n")
            {
                Console.Clear();
                Console.WriteLine("Press enter to return to main menu");
                Console.ReadLine();
                anotherPokemon = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid entry:\n");
                Console.WriteLine("Press enter to return to main menu");
                Console.ReadLine();
                anotherPokemon = false;
            }

            while (anotherPokemon)
            {
                Console.Clear();
                Console.WriteLine("Please enter the National Pokedex entry number for primary allowed pokemon:\n");
                int resultTwo;
                bool convertTwo = Int32.TryParse(Console.ReadLine(), out result);
                int dexNumberTwo = result;
                if (!convertTwo)
                {
                    dexNumberTwo = 0;
                }
                leaderList.Add(dexNumberTwo);
                Console.Clear();
                Console.WriteLine($"{dexNumberTwo} added. Would you like to add another pokemon (y/n)?");
                var continueInput = Console.ReadLine().ToLower();
                if (continueInput is "y")
                {
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Press enter to return to main menu.");
                    Console.ReadLine();
                    anotherPokemon = false;
                }
            }
            _badgeRepo.AddBadge(cityName, leaderList);
        }

        private static void EditBadgeUI()
        {
            Console.Clear();
            Console.WriteLine("Welcome to badge editor.");
            Console.WriteLine("\n\nWhat would you like to do?\n\n1. Remove a pokemon\n2. Add a pokemon\n");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Remove();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter the name of the city whose pokemon roster you would like to increase.\n");
                    var cityName = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Please enter the National Pokedex entry number for new allowed pokemon:\n ");
                    int inputTwo;
                    bool convert = Int32.TryParse(Console.ReadLine(), out inputTwo);
                    int pokeID = inputTwo;
                    if (!convert)
                    {
                        pokeID = 0;
                    }
                    _badgeRepo.AddPokemonToBadge(cityName, pokeID);
                    Console.Clear();
                    Console.WriteLine($"Pokemon {pokeID} added to {cityName} City Gym Leader's roster.\n\n" +
                        $"Press enter to return to main menu.");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        private static void ListBadgeUI()
        {
            Console.Clear();
            _badgeRepo.ListBadgesAndPokemon();
            Console.WriteLine("Press enter to return to main menu:");
            Console.ReadLine();
        }

        private static void Remove()
        {
            Console.Clear();
            Console.WriteLine("Please enter the name of the city whose badge you would like to edit:\n");
            var cityName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Please enter the National Dex Number of the pokemon you would like to remove from {cityName} City Gym Leader's Roster:\n");
            int pokeId;
            bool convert = Int32.TryParse(Console.ReadLine(), out pokeId);
            if (!convert) { pokeId = 0; }
            _badgeRepo.RemovePokemonFromBadge(cityName, pokeId);
            Console.Clear();
            Console.WriteLine($"Pokemon with Dex Entry: {pokeId} removed from roster.\n\n");
            Console.WriteLine("Press enter to return to main menu:");
            Console.ReadLine();
        }
    }
}
