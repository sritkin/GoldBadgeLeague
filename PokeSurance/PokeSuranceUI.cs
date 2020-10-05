using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeSurance
{
    class PokeSuranceUI
    {
        private static PokeClaimsRepo _claimsRepo = new PokeClaimsRepo();
        static void Main(string[] args)
        {
            DefaultClaims();
            bool continueToRun = true;
            while (continueToRun is true)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the choice you would like to select: \n\n" +
                    "1: See all claims.\n" +
                    "2: Take care of next claim.\n" +
                    "3: Enter a new claim. \n" +
                    "4: Close Application.\n\n");
                string pokeInput = Console.ReadLine();
                switch (pokeInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        HandleNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
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
        private static void ShowAllClaims()
        {
            Console.Clear();
            Console.WriteLine("ClaimID,\tType,\tDescription,\tAmount,\tDate of Accident,\tDate of Claim,\tValid\n\n");
            List<PokeClaims> listOfClaims = _claimsRepo.ShowClaims();
            foreach (PokeClaims claim in listOfClaims)
            {
                Console.WriteLine($"{claim.ClaimNumber}:\t {claim.ClaimType},\t{claim.Description},\t{claim.ClaimAmount}¥,\t{claim.DateOfIncident},\t{claim.DateOfClaim},\t{claim.IsValid} \n\n");
            }
            Console.WriteLine("Press enter to continue:");
            Console.ReadLine();
        }
        private static void HandleNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details for the next claim to be handled:");
            _claimsRepo.WriteClaimHelper();
            
        }
        private static void EnterNewClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter the claim number:\n");
            string claimNumber = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please select claim type by number:\n\n" +
                "1: Accident\n" +
                "2: PokeDmg\n" +
                "3: PokeInjury\n" +
                "4: TeamRocket\n\n");
            string userInput = Console.ReadLine();
            ClaimType typeOfClaim;
            switch (userInput)
            {
                case "1":
                    typeOfClaim = ClaimType.Accident;
                    break;
                case "2":
                    typeOfClaim = ClaimType.PokeDmg;
                    break;
                case "3":
                    typeOfClaim = ClaimType.PokeInjury;
                    break;
                case "4":
                    typeOfClaim = ClaimType.TeamRocket;
                    break;
                default:
                    typeOfClaim = ClaimType.Accident;
                    break;
            }
            Console.Clear();
            Console.WriteLine("Please describe the incident that caused the insurance claim");
            var description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter amount of claim");
            int result;
            bool convert = Int32.TryParse(Console.ReadLine(), out result);
            double amount = result;
            if (!convert)
            {
                amount = 0;
            }
            Console.Clear();
            Console.WriteLine("Please enter the date of incident (yyyy, MM, dd):");
            string incidentInput = Console.ReadLine();
            DateTime incident;
            bool isIncident = DateTime.TryParse(incidentInput, out incident);
            if (!isIncident)
            {
                incident = new DateTime(01 / 01 / 9001);
            }
            Console.Clear();
            Console.WriteLine("Please enter the date claim was filed (Year, Month, Day):");
            string claimInput = Console.ReadLine();
            DateTime claimDate;
            bool isClaimDate = DateTime.TryParse(claimInput, out claimDate);
            if (!isClaimDate)
            {
                claimDate = new DateTime(01 / 01 / 9001);
            }
            Console.Clear();
            if ((claimDate - incident).TotalDays <= 30)
            {
                Console.WriteLine("This claim is valid. You may proceed.");
            }
            else
            {
                Console.WriteLine("This claim is invalid. Don't give them a single PokeYen");
            }
            _claimsRepo.MakeNewClaim(claimNumber, typeOfClaim, description, amount, incident, claimDate);
        }
        private static void DefaultClaims()
        {
            _claimsRepo.MakeNewClaim("01", ClaimType.Accident, "Dropped voltorb, damaged patrons", 125000.25, new DateTime(2020, 8, 30), new DateTime(2020, 10, 1));
            _claimsRepo.MakeNewClaim("02", ClaimType.TeamRocket, "Stole 28, pokemon from storage Alpha Charlie 19", 22183000, new DateTime(2020, 7, 30), new DateTime(2020, 8, 1));
            _claimsRepo.MakeNewClaim("03", ClaimType.PokeDmg, "Caterpie evolved inside, string everywhere. Room Inaccessable for 2 weeks.", 18500, new DateTime(2020, 4, 15), new DateTime(2020, 5, 15));
            _claimsRepo.MakeNewClaim("04", ClaimType.PokeInjury, "Employee accidentally kicked skitty across room. Hit voltorb's owner. Caused claim 1.", 500, new DateTime(2020, 10, 1), new DateTime(2020, 10, 1));
        }
    }
}
