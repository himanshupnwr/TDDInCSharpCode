using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDCode;

namespace UnitTests
{
    /*
     * If divisible by 3       -> return "Fizz"
     * If divisible by 5       -> return "Buzz"
     * If divisible by 3 and 5 -> return "FizzBuzz"
     * Otherwise               -> return "" 
     */
    [TestClass]
    public class FizzBuzzTest
    {
        readonly FizzBuzz fizzBuzz = new FizzBuzz();

        [TestMethod]
        [DataRow("Fizz", 3)]
        [DataRow("Fizz", 6)]
        [DataRow("Buzz", 5)]
        [DataRow("Buzz", 10)]
        [DataRow("FizzBuzz", 15)]
        [DataRow("FizzBuzz", 30)]
        [DataRow("", 7)]
        public void TestFizzBuzz(string expected, int number)
        {
            Assert.AreEqual(expected, fizzBuzz.FizzBuzzProgram(number));
        }
    }
}
