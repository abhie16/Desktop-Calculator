using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLibraryTest
{
    [TestClass]
    public class TestBinaryOperations : TestHelper
    {

        [TestMethod]
        [DataRow(new string[] {"2+2","2+2+2"}, new double[] {4, 6} )]
        public void TestAddition(string[] expressions, double[] expectedResults)
        {
            TestHelperArrayParam(expressions, expectedResults);
        }

        [TestMethod]
        [DataRow(new string[] { "2-2", "2-2-2" }, new double[] { 0, -2 })]
        public void TestSubtraction(string[] expressions, double[] expectedResults)
        {
            TestHelperArrayParam(expressions, expectedResults);
        }

        [TestMethod]
        [DataRow(new string[] { "2*2", "2*2*2" }, new double[] { 4, 8 })]
        public void TestMultiplication(string[] expressions, double[] expectedResults)
        {
            TestHelperArrayParam(expressions, expectedResults);
        }

        [TestMethod]
        [DataRow(new string[] { "24/2", "24/2/2" }, new double[] { 12, 6 })]
        public void TestDivision(string[] expressions, double[] expectedResults)
        {
            TestHelperArrayParam(expressions, expectedResults);
        }
    }
}
