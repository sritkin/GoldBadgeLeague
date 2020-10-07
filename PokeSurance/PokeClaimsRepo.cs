using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokeSurance
{
    public class PokeClaimsRepo
    {
       public Queue<PokeClaims> toDoList = new Queue<PokeClaims>();
        public List<PokeClaims> _claimsList = new List<PokeClaims>();
        //Create
        public bool MakeNewClaim(string number, ClaimType type, string description, double amount, DateTime incident, DateTime claim)
        {
            PokeClaims newClaim = new PokeClaims(number, type, description, amount, incident, claim);
            int startCount = _claimsList.Count;
            _claimsList.Add(newClaim);
            toDoList.Enqueue(newClaim);
            bool isAdded = (_claimsList.Count > startCount) ? true : false;
            return isAdded;
        }
        //Read
        public List<PokeClaims> ShowClaims()
        {
            return _claimsList;
        }
        
        
    }
}
