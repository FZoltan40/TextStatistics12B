using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextStatistics;

namespace TextStatisticsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountWords_NormalText_ReturnsCorrect()
        {
            var ts = new TextStatisticsLib("Hello this is a test");
            Assert.AreEqual(5, ts.CountWords());
        }

        [TestMethod]
        public void CountWords_WithExtraSpaces_ReturnsCorrect()
        {
            var ts = new TextStatisticsLib("Hello   world   test");
            Assert.AreEqual(3, ts.CountWords());
        }

        [TestMethod]
        public void CountWords_EmptyString_Returns0()
        {
            var ts = new TextStatisticsLib("");
            Assert.AreEqual(0, ts.CountWords());
        }

        [TestMethod]
        public void CountWords_Whitespace_Returns0()
        {
            var ts = new TextStatisticsLib("     ");
            Assert.AreEqual(0, ts.CountWords());
        }

        [TestMethod]
        public void CountSentences_Normal_ReturnsCorrect()
        {
            var ts = new TextStatisticsLib("Szia. Jó napot! Hogy vagy?");
            Assert.AreEqual(3, ts.CountSentences());
        }

        [TestMethod]
        public void CountSentences_MultipleMarks_ReturnsCorrect()
        {
            var ts = new TextStatisticsLib("Hello??? Itt vagy!!");
            Assert.AreEqual(2, ts.CountSentences());
        }

        [TestMethod]
        public void CountSentences_NoMarks_Returns0()
        {
            var ts = new TextStatisticsLib("Ez egy mondat jel nélkül");
            Assert.AreEqual(0, ts.CountSentences());
        }

        [TestMethod]
        public void MostCommonWord_ReturnsCorrect()
        {
            var ts = new TextStatisticsLib("alma körte alma szilva");
            Assert.AreEqual("alma", ts.MostCommonWord());
        }

        [TestMethod]
        public void MostCommonWord_Tie_ReturnsFirst()
        {
            var ts = new TextStatisticsLib("alma körte alma körte");
            Assert.AreEqual("alma", ts.MostCommonWord());
        }

        [TestMethod]
        public void MostCommonWord_WithPunctuation_ReturnsCorrect()
        {
            var ts = new TextStatisticsLib("Alma! körte, alma? szilva.");
            Assert.AreEqual("alma", ts.MostCommonWord());
        }

        [TestMethod]
        public void MostCommonWord_EmptyText_ReturnsEmpty()
        {
            var ts = new TextStatisticsLib("");
            Assert.AreEqual(string.Empty, ts.MostCommonWord());
        }

        public static void Main(string[] args)
        {

        }
    }
}
