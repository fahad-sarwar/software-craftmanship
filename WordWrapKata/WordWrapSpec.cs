using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrapKata
{
    [TestClass]
    public class WordWrapSpec
    {
        [TestMethod]
        [DataRow("The", "The")]
        public void WrapText(string text, string result)
        {
            Assert.AreEqual(result, text);
        }
    }
}
