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

        [TestMethod]
        public void ReturnChangeSets0Balance()
        {
            VendingMachine testMachine = new VendingMachine();
            testMachine.FeedMoney(20);
            testMachine.ReturnChange();
            Assert.AreEqual(0, testMachine.CurrentBalance);
        }

        [TestMethod]
        public void ReturnChange80Quarters()
        {
            VendingMachine testMachine = new VendingMachine();
            testMachine.FeedMoney(20);
            Assert.AreEqual(80, testMachine.ReturnChange().Quarters);
        }

        [TestMethod]
        public void WhenInput5DollarsPurchase3Dollar5CentsChipsReturnDollarNinetyFiveChangeWhichis7Quarts()
        {
            VendingMachine testMachine = new VendingMachine();
            testMachine.FeedMoney(5);
            testMachine.Purchase("A1");
            Assert.AreEqual(7, testMachine.ReturnChange().Quarters);
        }

        [TestMethod]
        public void WhenInput5DollarsPurchase3Dollar5CentsChipsReturnDollarNinetyFiveChangeWhichis2Dimes()
        {
            VendingMachine testMachine = new VendingMachine();
            testMachine.FeedMoney(5);
            testMachine.Purchase("A1");
            Assert.AreEqual(2, testMachine.ReturnChange().Dimes);
        }

        [TestMethod]
        public void TestIfPurchaseReturnsTheItem()
        {
            VendingMachine testMachine = new VendingMachine();
            testMachine.FeedMoney(5);
            Assert.AreEqual("Potato Crisps", testMachine.Purchase("A1").ItemName);
        }

        [TestMethod]
        public void TestIfPurchaseAttemptIsNaughty()
        {
            VendingMachine testMachine = new VendingMachine();
            testMachine.FeedMoney(5);
            Assert.AreEqual(null, testMachine.Purchase("Q1"));
        }


    }
}
