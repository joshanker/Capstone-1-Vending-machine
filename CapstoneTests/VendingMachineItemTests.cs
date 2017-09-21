using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineItemTests
    {

        BeverageItem bevvy = new BeverageItem("testBevItem", 1.00M);
        CandyItem candy = new CandyItem("testCandyItem", 1.00M);
        ChipItem chippy = new ChipItem("testChipItem", 1.00M);
        GumItem gummy = new GumItem("testGumItem", 1.00M);

        [TestMethod]
        public void BeverageItemConsume()
        {
            Assert.AreEqual("Glug Glug, Yum!", bevvy.Consume());
        }
        [TestMethod]
        public void BeverageItemName()
        {
            Assert.AreEqual("testBevItem", bevvy.ItemName);
        }
        [TestMethod]
        public void BeverageItemPrice()
        {
            Assert.AreEqual(1, bevvy.PriceInCents);
        }
        
        [TestMethod]
        public void CandyItemName()
        {
            Assert.AreEqual("Munch Munch, Yum!", candy.Consume());
        }
        [TestMethod]
        public void CandyItemPrice()
        {
            Assert.AreEqual("testCandyItem", candy.ItemName);
        }
        [TestMethod]
        public void CandyItemConsume()
        {
            Assert.AreEqual(1, candy.PriceInCents);
        }

        [TestMethod]
        public void ChipItemConsume()
        {
            Assert.AreEqual("Crunch Crunch, Yum!", chippy.Consume());
        }
        
        [TestMethod]
        public void ChipItemName()
        {
            Assert.AreEqual("testChipItem", chippy.ItemName);
        }

        [TestMethod]
        public void ChipItemPrice()
        {
            Assert.AreEqual(1, chippy.PriceInCents);
        }





        [TestMethod]
        public void GumItemConsume()
        {
            Assert.AreEqual("Chew Chew, Yum!", gummy.Consume());
        }
        [TestMethod]
        public void GumItemName()
        {
            Assert.AreEqual("testGumItem", gummy.ItemName);
        }
        [TestMethod]
        public void GumItemPrice()
        {
            Assert.AreEqual(1, gummy.PriceInCents);
        }




    }
}
