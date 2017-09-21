using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void GetQtyRemaingOnNewInventoryShouldReturn5()
        {
            string filePath;
            string currentDirectory = Directory.GetCurrentDirectory();
            filePath = Path.Combine(currentDirectory, "vendingmachineinventory.txt");

            InventoryFileDAL testyThing = new InventoryFileDAL(filePath);

            VendingMachine testMachine = new VendingMachine();
            
            Assert.AreEqual(5, testMachine.GetQuantityRemaining("A1"));
        }

        [TestMethod]
        public void PurchaseTestSHouldBe4ChipsLeft()
        {
            //string filePath;
          //  string currentDirectory = Directory.GetCurrentDirectory();
            //filePath = Path.Combine(currentDirectory, "vendingmachineinventory.txt");

            //InventoryFileDAL testyThing = new InventoryFileDAL(filePath);

            VendingMachine testMachine = new VendingMachine();

            Assert.AreEqual(5, testMachine.GetQuantityRemaining("A1"));

            testMachine.FeedMoney(20);

            testMachine.Purchase("A1");
            Assert.AreEqual(4, testMachine.GetQuantityRemaining("A1"));
        }


        [TestMethod]
        public void FeedMoney()
        {
            
            VendingMachine testMachine = new VendingMachine();
            
            testMachine.FeedMoney(20);
            Assert.AreEqual(20, testMachine.CurrentBalance);
        }




    }
}
