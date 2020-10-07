using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeSurance
{
    public enum ClaimType { Accident, PokeDmg, PokeInjury, TeamRocket}
    public class PokeClaims
    {
        public string ClaimNumber { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if ((DateOfClaim -DateOfIncident).TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public PokeClaims() { }
        public PokeClaims(string number, ClaimType type, string description, double amount, DateTime incident, DateTime claim )
        {
            ClaimNumber = number;
            ClaimType = type;
            Description = description;
            ClaimAmount = amount;
            DateOfIncident = incident;
            DateOfClaim = claim;
           
        }

        
    }
}
