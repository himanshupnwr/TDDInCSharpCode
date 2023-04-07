using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDCode;

namespace UnitTests
{
    [TestClass]
    public class RomanNumeralsTest
    {
        public readonly RomanNumerals RomanNumerals = new RomanNumerals();

        [TestMethod]
        [DataRow(1, "I")]
        [DataRow(4, "IV")]
        public void Parse(int expected, string roman)
        {
            Assert.AreEqual(expected, RomanNumerals.Parse(roman));
        }
    }
}
