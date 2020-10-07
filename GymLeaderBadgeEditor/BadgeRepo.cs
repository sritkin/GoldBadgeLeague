using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLeaderBadgeEditor
{
    public class BadgeRepo
    {
        //This dictionary models a badge
        public Dictionary<string, List<int>> leaderAccess = new Dictionary<string, List<int>>();

        public void AddBadge(string cityName, List<int> pokeID)
        {
            leaderAccess.Add(cityName, pokeID);
        }        

        public void RemovePokemonFromBadge(string cityName, int pokeID)
        {
            //get the list of id's for the given cityName
            List<int> pokeIDs = leaderAccess[cityName];
            //remove the items that match the given id
            pokeIDs.RemoveAll(id => id == pokeID);
        }
        public void AddPokemonToBadge (string cityName, int PokeID)
        {
            List<int> pokeIDs = leaderAccess[cityName];
            pokeIDs.Add(PokeID);
        }

        public void ListBadgesAndPokemon()
        {
            Console.WriteLine("Badge City:\tPokemon List\n\n");
            foreach (KeyValuePair<string, List<int>> entry in leaderAccess)
            {
                string combindedString = string.Join(", ", entry.Value.ToArray());
                Console.WriteLine($"{entry.Key} City\t{combindedString}\n\n");
            }
        }

        public void ListPokemonBadgeHasAccessTo(string cityName)
        {
            Console.WriteLine($"{cityName} City Leader has access to:");
            List<int> pokeIDs = leaderAccess[cityName];
            string joinEntries;
            foreach (int entry in pokeIDs)
            {
                Console.Write($"{entry} ");
            }


            //get the list of id's for the given cityName
            string listOfPokemon = string.Join(", ", pokeIDs.ToArray());
            string update = $"{cityName} City Leader has access to {listOfPokemon}.";
            Console.WriteLine(update);
        }
    }
}
