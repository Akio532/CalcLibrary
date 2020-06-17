using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace UnitTestProject1
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

    }
}
