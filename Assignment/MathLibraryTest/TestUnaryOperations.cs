using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathLibraryTest
{
    [TestClass]
    public class TestUnaryOperations : TestHelper
    {

        [TestMethod]
        [DataRow(new string[] {"25%","25%%"}, new double[] {0.25, 0.0025})]
        public void TestPercentage(string[] expressions, double[] expectedResults)
        {
            TestHelperArrayParam(expressions, expectedResults);
        }

        [TestMethod]
        [DataRow("neg(25)", -25)]
        public void TestNegation(string expression, double expectedResult)
        {
            TestHelperConstParam(expression, expectedResult);
        }

        [TestMethod]
        [DataRow(new string[] {"log(10)", "log(log(10))"}, new double[] {1, 0})]
        public void TestLogarithmic(string[] expressions, double[] expectedResults)
        {
            TestHelperArrayParam(expressions, expectedResults);
        }

        [TestMethod]
        [DataRow("cube(3)", 27)]
        public void TestCube(string expression, double expectedResult)
        {
            TestHelperConstParam(expression, expectedResult);
        }

        [TestMethod]
        [DataRow(new string[] {"sq(25)", "sq(sq(3))"}, new double[] {625, 81})]
        public void TestSquare(string[] expressions, double[] expectedResults)
        {
            TestHelperArrayParam(expressions, expectedResults);
        }

        [TestMethod]
        [DataRow(new string[] {"reci(10)", "reci(1/10)"}, new double[] {0.1, 10})]
        public void TestReciprocal(string[] expressions, double[] expectedResults)
        {
            TestHelperArrayParam(expressions, expectedResults);
        }

        [TestMethod]
        [DataRow(new string[] {"sqrt(25)"}, new double[] {5})]
        public void TestSquareRoot(string[] expressions, double[] expectedResults)
        {
            TestHelperArrayParam(expressions, expectedResults);
        }

        [TestMethod]
        [DataRow("sin(90)", 90)]
        public void TestSine(string expression, double angle)
        {
            double expectedResult = Math.Sin((3.14 / 180) * angle);
            TestHelperConstParam(expression, expectedResult);
        }

        [TestMethod]
        [DataRow("cos(0)", 0)]
        public void TestCosine(string expression, double angle)
        {
            double expectedResult = Math.Cos((3.14 / 180) * angle);
            TestHelperConstParam(expression, expectedResult);
        }
    }
}
