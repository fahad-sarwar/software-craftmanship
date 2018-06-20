using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzzKata
{
    [TestClass]
    public class FizzBuzzSpec
    {
        [TestMethod]
        [DataRow(1, "1")]
        [DataRow(2, "2")]
        [DataRow(3, "Fizz")]
        [DataRow(4, "4")]
        [DataRow(5, "Buzz")]
        [DataRow(7, "Bang")]
        [DataRow(15, "FizzBuzz")]
        [DataRow(21, "FizzBang")]
        [DataRow(35, "BuzzBang")]
        [DataRow(105, "FizzBuzzBang")]
        public void FizzBuzzCalculations(int number, string result) => Assert.AreEqual(result, new FizzBuzzConvertor().Convert(number));
    }

    public class FizzBuzzConvertor
    {
        private readonly Dictionary<int, string> _rules = new Dictionary<int, string>
        {
            { 3, "Fizz"},
            { 5, "Buzz"},
            { 7, "Bang"}
        };

        public string Convert(int number)
        {
            return string.Join("", _rules
                .OrderBy(rule => rule.Key)
                .Where(rule => number % rule.Key == 0)
                .Select(rule => _rules[rule.Key])
                .DefaultIfEmpty(number.ToString()));
        }
    }
}
