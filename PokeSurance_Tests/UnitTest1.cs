using System;
using PokeSurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokeSurance_Tests
{
    [TestClass]
    public class UnitTest1
    {
        PokeClaimsRepo claimRepo;
        [TestMethod]
        public void MakeNewClaimTest()
        {
            //arrange
            claimRepo = new PokeClaimsRepo();
            bool madeClaim;
            //act
            madeClaim = claimRepo.MakeNewClaim("1", ClaimType.Accident, "word", 2, new DateTime(2020,10,10), new DateTime(2020,10,10));
            //assert
            Assert.IsTrue(madeClaim);
        }

        [TestMethod]
        public void ShowClaimsTest()
        {
            //Arrange
            claimRepo = new PokeClaimsRepo();
            bool madeClaim;
            List<PokeClaims> testList;
            //Act
            madeClaim = claimRepo.MakeNewClaim("1", ClaimType.Accident, "word", 2, new DateTime(2020, 10, 10), new DateTime(2020, 10, 10));
            testList = claimRepo._claimsList;
            //Assert
            Assert.IsNotNull(testList);
        }
    }
}
