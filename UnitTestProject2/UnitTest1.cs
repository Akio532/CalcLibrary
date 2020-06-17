using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab6;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateTestMethod()
        {
            String[] a = Calc.GetOperands("23+4,5");
            Assert.AreEqual("23", a[0]);
            Assert.AreEqual("4,5", a[1]);
        }
        [TestMethod]
        public void ResultTestMethod()
        {
            Assert.AreEqual("27,5", Calc.GetOperation("23+4,5").ToString());
            string result = Calc.GetOperation("23+4,5");
            Assert.AreEqual("27,5", result);
        }

    }
}
