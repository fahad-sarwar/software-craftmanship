using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumeralsKata
{
    [TestClass]
    public class RomanNumeralsSpec
    {
        [TestMethod]
        [DataRow(0, "")]
        [DataRow(1, "I")]
        [DataRow(2, "II")]
        [DataRow(3, "III")]
        [DataRow(4, "IV")]
        [DataRow(5, "V")]
        [DataRow(6, "VI")]
        [DataRow(7, "VII")]
        [DataRow(8, "VIII")]
        [DataRow(9, "IX")]
        [DataRow(10, "X")]
        [DataRow(11, "XI")]
        [DataRow(14, "XIV")]
        [DataRow(15, "XV")]
        [DataRow(16, "XVI")]
        [DataRow(20, "XX")]
        [DataRow(25, "XXV")]
        [DataRow(49, "XLIX")]
        [DataRow(99, "XCIX")]
        [DataRow(100, "C")]
        [DataRow(490, "CDXC")]
        public void RomanNumeralsConverter(int number, string romanNumeral) =>
            Assert.AreEqual(romanNumeral, new RomanNumeralCalculator().Convert(number));
    }

    public class RomanNumeralCalculator
    {
        private readonly Dictionary<int, string> _lookup = new Dictionary<int, string>
        {
            //{ 1000, "M"},
            //{ 900, "CM"},
            { 500, "D"},
            { 400, "CD"},
            { 100, "C"},
            { 90, "XC"},
            { 50, "L"},
            { 40, "XL"},
            { 10, "X"},
            { 9, "IX"},
            { 5, "V"},
            { 4, "IV"},
            { 1, "I" }
        };

        public string Convert(int number)
        {
            if (number == 0) return string.Empty;

            var result = LookupConversion(number);

            return string.Join("", result.Value, Convert(number - result.Key));
        }

        private KeyValuePair<int, string> LookupConversion(int number) => _lookup.First(n => n.Key <= number);

        //public string Convert(int number)
        //{
        //    var romanNumberal = string.Empty;

        //    while (number > 0)
        //    {
        //        var result = LookupConversion(number);

        //        romanNumberal += result.Value;
        //        number -= result.Key;
        //    }

        //    return romanNumberal;
        //}
    }
}
