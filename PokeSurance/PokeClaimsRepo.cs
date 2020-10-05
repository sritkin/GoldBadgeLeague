using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokeSurance
{
    class PokeClaimsRepo
    {
        public Queue<PokeClaims> toDoList = new Queue<PokeClaims>();
        protected readonly List<PokeClaims> _claimsList = new List<PokeClaims>();
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
        //Helper Method to read from Queue
        /*This was originally going to be a helper method i called on multiple times
         * but then i realized i could just toss the whole ting in a while loop and keep
         * it cleaner. So i did that. It would probably make more sense for this to be in my UI but I wrote it here and it doesn't want to move.
         */
        public void WriteClaimHelper()
        {
            bool continueClaimHelper = true;
            while (continueClaimHelper)
            {


                PokeClaims nextClaim = toDoList.Peek();
                Console.WriteLine($"Claim Number: {nextClaim.ClaimNumber}.\n\n" +
                    $"Type: {nextClaim.ClaimType}.\n\n" +
                    $"Description: {nextClaim.Description}.\n\n" +
                    $"Amount: {nextClaim.ClaimAmount}¥.\n\n" +
                    $"Date of Incident: {nextClaim.DateOfIncident}.\n\n" +
                    $"Date of Claim: {nextClaim.DateOfClaim}.\n\n" +
                    $"Is this claim valid: {nextClaim.IsValid}.\n\n" +
                    $"Do you want to deal with this claim now (y/n)?"); ;

                string input = Console.ReadLine();
                if (input is "y")
                {
                    Console.Clear();
                    toDoList.Dequeue();
                    Console.WriteLine("Press enter for next claim:");
                    Console.ReadLine();
                    Console.Clear();

                }
                else if (input is "n") 
                {
                    Console.Clear();
                    Console.WriteLine("Press enter to return to main menu");
                    Console.ReadLine();
                    continueClaimHelper = false;
                }
            }


        }
    }
}
