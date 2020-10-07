using System;
using System.Collections.Generic;
using BerryCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerryCafeTests
{
    [TestClass]
    public class UnitTest1
    {
        MenuItemRepo itemRepo;

        [TestMethod]
        public void AddItemToMenuTest()
        {
            //Arrange
            itemRepo = new MenuItemRepo();
            bool itemAdded;
            //Act
            itemAdded = itemRepo.AddItemToMenu(2, "yellow", "yellow", "yellow", 2, new List<string> { "word", "two" });
            //Assert
            Assert.IsTrue(itemAdded);
        }

        [TestMethod]
        public void ShowItemsTest()
        {
            //Arrange
            itemRepo = new MenuItemRepo();
            bool itemAdded;
            //Act
            itemAdded = itemRepo.AddItemToMenu(2, "yellow", "yellow", "yellow", 2, new List<string> { "word", "two" });
            List<MenuItem> testList = itemRepo.ShowItems();
            //Assert
            Assert.IsNotNull(testList);
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            //Arrange
            itemRepo = new MenuItemRepo();
            itemRepo.AddItemToMenu(2, "yellow", "yellow", "yellow", 2, new List<string> { "word", "two" });
            bool itemRemoved;
            //Act
            MenuItem selectedItem = itemRepo._itemList[0];
            itemRemoved = itemRepo.DeleteItem(selectedItem);

            //Assert
            Assert.IsTrue(itemRemoved);


        }
    }
}
