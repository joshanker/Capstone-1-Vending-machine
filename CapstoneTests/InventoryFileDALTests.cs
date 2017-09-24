using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.IO;


namespace CapstoneTests
{
    [TestClass]
    public class InventoryFileDALTests
    {

        


        [TestMethod]
        public void TotalItemsShouldBe16()
        {
            string filePath;
            string currentDirectory = Directory.GetCurrentDirectory();
            filePath = Path.Combine(currentDirectory, "vendingmachineinventory.txt");
            InventoryFileDAL testyThing = new InventoryFileDAL(filePath);
            Assert.AreEqual(16,testyThing.GetInventory().Count);
        }


        [TestMethod]
        public void HasKeyA1()
        {
            string filePath;
            string currentDirectory = Directory.GetCurrentDirectory();
            filePath = Path.Combine(currentDirectory, "vendingmachineinventory.txt");
            InventoryFileDAL testyThing = new InventoryFileDAL(filePath);
            Assert.AreEqual(true, testyThing.GetInventory().ContainsKey("A1"));
        }


    }
}
