using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordHistorgramKata
{
    [TestClass]
    public class WordHistogramSpec
    {
        [TestMethod]
        public void CalculateFrequncy()
        {
            const string text = "There's a hole in the bucket, dear Liza, dear Liza,\nThere's a hole in the bucket, dear Liza, a hole.";

            var result = new Dictionary<string, int>
            {
                {"There's", 2},
                {"a", 3},
                {"hole", 3},
                {"in", 2},
                {"the", 2},
                {"bucket", 2},
                {"dear", 3},
                {"Liza", 3}
            };

            CollectionAssert.AreEqual(result, WordHistogram.Calculate(text));
        }
    }

    public class WordHistogram
    {
        public static Dictionary<string, int> Calculate(string text)
        {
            return text
                .Replace("\n", " ")
                .Replace(".", " ")
                .Replace(",", " ")
                .Split(" ")
                .Where(word => !string.IsNullOrWhiteSpace(word))
                .GroupBy(word => word)
                .ToDictionary(gbd => gbd.Key, gbc => gbc.Count());
        }
    }
}
