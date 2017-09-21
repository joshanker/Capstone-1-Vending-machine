using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        Change testChange = new Change(2.15M);

        [TestMethod]
        public void Two15ShouldBe8Quarters()
        {
            Assert.AreEqual(8, testChange.Quarters);
        }

        [TestMethod]
        public void Two15ShouldBe1Dime()
        {
            Assert.AreEqual(1, testChange.Dimes);
        }

        [TestMethod]
        public void Two15ShouldBe1Nickel()
        {
            Assert.AreEqual(1, testChange.Nickels);
        }

       
    }

    [TestClass]
    public class ChangeTestsInCents
    {
        Change testChange = new Change(215);

        [TestMethod]
        public void Two15ShouldBe8Quarters()
        {
            Assert.AreEqual(8, testChange.Quarters);
        }

        [TestMethod]
        public void Two15ShouldBe1Dime()
        {
            Assert.AreEqual(1, testChange.Dimes);
        }

        [TestMethod]
        public void Two15ShouldBe1Nickel()
        {
            Assert.AreEqual(1, testChange.Nickels);
        }


    }


}
