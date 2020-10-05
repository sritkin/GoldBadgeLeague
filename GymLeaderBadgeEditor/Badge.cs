using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLeaderBadgeEditor
{
    public class Badge
    {
        public string BadgeCity { get; set; }
        public List<int> GymPokemon { get; set; }

        public Badge() { }
        public Badge(string city, Dictionary<string, int> dict)
        {
            BadgeCity = city;
            GymPokemon = dict.Values.ToList<int>();
        }
    }
}
