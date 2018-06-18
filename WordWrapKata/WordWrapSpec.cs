using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrapKata
{
    [TestClass]
    public class WordWrapSpec
    {
        [TestMethod]
        [DataRow("The", "The")]
        [DataRow("The boy stood", "The boy\nstood")]
        public void WrapText(string text, string result) => Assert.AreEqual(result, string.Join("\n", new WordWrapper().Process(text)));
    }

    public class WordWrapper
    {
        public List<string> Process(string text)
        {
            var result = new List<string>();

            var words = text.Split(" ");

            //for (var count = 0; count < words.Length; count++)
            //{

            //    if ($"{temp} {words[count]}".Length > 8)
            //    {
            //        result.Add(temp);
            //        temp = string.Empty;
            //    }
            //    else
            //    {
            //        temp = $"{temp} {word}";
            //    }
            //}

            return result;
        }
    }
}
