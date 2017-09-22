using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Linq;


namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineCLITests
    {
        [TestMethod]
        public void ValidateEntrySlotIsValid()
        {
            VendingMachine vm = new VendingMachine();
            
            string itemToVend = "A1";
            vm.Slots.Contains(itemToVend);
            Assert.AreEqual(true, vm.Slots.Contains(itemToVend));
        }

    }
}

