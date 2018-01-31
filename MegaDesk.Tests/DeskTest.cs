using NUnit.Framework;
using System;
namespace MegaDesk.Tests
{
    [TestFixture()]
    public class DeskTest
    {
        [Test()]
        public void Test_ValidateDepth_AdjustsSmallNumbersWithoutThrowingException()
        {   // when you pass in a positive value that is smaller than minumum, it should adjust it for you but not blow up
            Assert.AreEqual(Desk.MIN_DEPTH, MegaDesk.Desk.ValidateDepth(2));
            Assert.AreEqual(Desk.MIN_DEPTH, MegaDesk.Desk.ValidateDepth(8));
            Assert.AreEqual(Desk.MIN_DEPTH, MegaDesk.Desk.ValidateDepth(3));
        }
        [Test()]
        public void Test_ValidateDepth_AdjustsLargeNumbersWithoutThrowingException()
        {    // when you pass in a positive value taht is above max, it should adjust and not blow up
            Assert.AreEqual(Desk.MAX_DEPTH, MegaDesk.Desk.ValidateDepth(2001));
            Assert.AreEqual(Desk.MAX_DEPTH, MegaDesk.Desk.ValidateDepth(Desk.MAX_DEPTH+1));
            Assert.AreEqual(Desk.MAX_DEPTH, MegaDesk.Desk.ValidateDepth(921));
        }
        [Test()]
        public void Test_ValidateDepth_NumbersInCorrectRangeAreUnmodified()
        {   // when you pass in a value in the allowable range, it should return that value and not blow up
            Assert.AreEqual(Desk.MAX_DEPTH, MegaDesk.Desk.ValidateDepth(Desk.MAX_DEPTH));
            Assert.AreEqual(Desk.MIN_DEPTH, MegaDesk.Desk.ValidateDepth(Desk.MIN_DEPTH));
            Assert.AreEqual(49, MegaDesk.Desk.ValidateDepth(49));
            Assert.AreEqual(25, MegaDesk.Desk.ValidateDepth(25));
            Assert.AreEqual(80, MegaDesk.Desk.ValidateDepth(80));
        }
        [Test()]
        public void Test_ValidateDepth_IsRequired()
        {   // when you pass in an empty value, it should blow up
            Assert.Throws<Exception>(() => MegaDesk.Desk.ValidateDepth(null));
            Assert.Throws<Exception>(() => MegaDesk.Desk.ValidateDepth(0));
        }
        [Test()]
        public void Test_ValidateDepth_NegativeNumbersAreNotAllowed()
        {   // when you pass in a negative value, it should blow up
            Assert.Throws<Exception>(() => MegaDesk.Desk.ValidateDepth(-1));
            Assert.Throws<Exception>(() => MegaDesk.Desk.ValidateDepth(-123));
        }    

        [Test()]
        public void TestValidateWidth()
        {
            // make some rules
        }

    }
}
