using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrapKata
{
    [TestClass]
    public class WordWrapSpec
    {
        [TestMethod]
        [DataRow("The", "The")]
        [DataRow("The boy", "The boy")]
        [DataRow("Burning Burning", "Burning\nBurning")]
        [DataRow("The boy stood", "The boy\nstood")]
        [DataRow("The boy stood on", "The boy\nstood on")]
        [DataRow("The boy stood on the burning deck", "The boy\nstood on\nthe\nburning\ndeck")]
        [DataRow("pneumonoultramicroscopicsilicovolcanoconiosis pneumonoultramicroscopicsilicovolcanoconiosis", "pneumonoultramicroscopicsilicovolcanoconiosis\npneumonoultramicroscopicsilicovolcanoconiosis")]
        [DataRow("I me you", "I me you")]
        [DataRow("A B C D E F", "A B C D\nE F")]
        public void WrapText(string text, string result) => Assert.AreEqual(result, new WordWrapper(8).Wrap(text));
    }

    public class WordWrapper
    {
        private readonly int _threshold;
        private readonly List<string> _result;

        public WordWrapper(int threshold)
        {
            _threshold = threshold;
            _result = new List<string> { string.Empty };
        }

        public string Wrap(string text)
        {
            var words = text.Split(" ");

            foreach (var word in words)
            {
                if (IsMoreThanThreshold($"{GetLastItem().Value} {word}"))
                {
                    AddNewItem(word);
                    continue;
                }

                UpdateLastItem(word);
            }

            return string.Join("\n", _result.Where(i => !string.IsNullOrWhiteSpace(i)));
        }

        private bool IsMoreThanThreshold(string value) => value.Trim().Length > _threshold;

        private KeyValuePair<int, string> GetLastItem() => _result
            .Select((value, index) => new KeyValuePair<int, string>(index, value))
            .OrderByDescending(kvp => kvp.Key)
            .DefaultIfEmpty(new KeyValuePair<int, string>(0, string.Empty))
            .FirstOrDefault();

        private void AddNewItem(string value) => _result.Add(value.Trim());

        private void UpdateLastItem(string value)
        {
            var lastItem = GetLastItem();

            _result[lastItem.Key] = $"{lastItem.Value} {value}".Trim();
        }
    }
}
