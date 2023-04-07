using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCode;

namespace UnitTests
{
    [TestClass]
    public class FibonacciTest
    {
        private FibonacciNumbers fn = new FibonacciNumbers();

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        [DataRow(2, 3)]
        public void TestFibonacci(int expected, int index)
        {
            Assert.AreEqual(expected, fn.GetFibonacci(index));
            Assert.AreEqual(expected, fn.fibDynamic(index));
        }
    }
}