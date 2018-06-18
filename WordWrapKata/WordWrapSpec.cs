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
        [DataRow("The boy stood", "The boy\nstood")]
        [DataRow("The boy stood on the burning deck", "The boy\nstood on\nthe\nburning\ndeck")]
        [DataRow("pneumonoultramicroscopicsilicovolcanoconiosis pneumonoultramicroscopicsilicovolcanoconiosis", "pneumonoultramicroscopicsilicovolcanoconiosis\npneumonoultramicroscopicsilicovolcanoconiosis")]
        public void WrapText(string text, string result) => Assert.AreEqual(result, string.Join("\n", new WordWrapper(8).Process(text)));
    }

    public class WordWrapper
    {
        private readonly int _threshold;
        private readonly List<string> _result;

        public WordWrapper(int threshold)
        {
            _threshold = threshold;
            _result = new List<string>();
        }

        public List<string> Process(string text)
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

            return _result;
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

            if (lastItem.Equals(new KeyValuePair<int, string>(0, string.Empty)))
                _result.Add(value.Trim());
            else
                _result[lastItem.Key] = $"{lastItem.Value} {value}";
        }
    }
}
