using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishCalculator;

namespace PolishCalculator.Tests
{
    [TestClass]
    class CalcTests : Calc
    {
        [TestMethod]
        public void ResultTests()
        {
            string a = $"/,*,-,+,4,4,6,8,2";

            double b = 8;

            var res = base.Result(a);

            Assert.AreEqual(b, res);
        }
    }
}
