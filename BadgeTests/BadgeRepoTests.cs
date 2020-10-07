using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymLeaderBadgeEditor;
using System.Collections.Generic;

namespace BadgeTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        BadgeRepo badgeRepo;

        [TestMethod]
        public void AddBadgeTest()
        {
            //Arrange
            badgeRepo = new BadgeRepo();
            //Act
            badgeRepo.AddBadge("city", new List<int> { 01 });
            //Assert
            Assert.IsNotNull(badgeRepo.leaderAccess);
        }

        [TestMethod]
        public void RemovePokemonFromBadgeTest()
        {
            //Arrange
            badgeRepo = new BadgeRepo();
            badgeRepo.AddBadge("city", new List<int> { 01 });
            //Act
            badgeRepo.RemovePokemonFromBadge("city", 01);
            List<int> pokeIDs = badgeRepo.leaderAccess["city"];
            int actual = pokeIDs.Count;
            int expected = 0;
            //Assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void AddPokemonToBadgeTest()
        {
            //Arrange
            badgeRepo = new BadgeRepo();
            badgeRepo.AddBadge("city", new List<int> { 01 });
            //Act
            badgeRepo.AddPokemonToBadge("city", 02);
            List<int> pokeIDs = badgeRepo.leaderAccess["city"];
            int actualID = pokeIDs[1];
            int expectedID = 2;
            //Assert
            Assert.AreEqual<int>(expectedID, actualID);
        }

        [TestMethod]
        public void ListBadgesAndPokemonTest()
        {
            //Arrange
            badgeRepo = new BadgeRepo();

            //Act
            //Assert
        }

        [TestMethod]
        public void ListPokemonBadgeHasAccessToTest()
        {
            //Arrange
            badgeRepo = new BadgeRepo();

            //Act
            //Assert
        }
    }
}
