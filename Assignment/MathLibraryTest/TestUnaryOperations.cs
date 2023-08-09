using MathLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathLibraryTest
{
    [TestClass]
    public class TestUnaryOperations
    {
        [TestMethod]
        [DataRow(new string[] {"25%","25%%"}, new double[] {0.25, 0.0025})]
        public void TestPercentage(string[] expressions, double[] expectedResults)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            for(int index=0; index<expressions.Length; index++)
            {
                double actualResult = evaluator.Evaluate(expressions[index]);
                double expectedResult = expectedResults[index];
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        [DataRow("neg(25)", -25)]
        public void TestNegation(string expression, double expectedResult)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            double actualResult = evaluator.Evaluate(expression);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(new string[] {"log(10)", "log(log(10))"}, new double[] {1, 0})]
        public void TestLogarithmic(string[] expressions, double[] expectedResults)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            for (int index = 0; index < expressions.Length; index++)
            {
                double actualResult = evaluator.Evaluate(expressions[index]);
                double expectedResult = expectedResults[index];
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        [DataRow("cube(3)", 27)]
        public void TestCube(string expression, double expectedResult)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            double actualResult = evaluator.Evaluate(expression);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [DataRow(new string[] {"sq(25)", "sq(sq(3))"}, new double[] {625, 81})]
        public void TestSquare(string[] expressions, double[] expectedResults)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            for (int index = 0; index < expressions.Length; index++)
            {
                double actualResult = evaluator.Evaluate(expressions[index]);
                double expectedResult = expectedResults[index];
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        [DataRow(new string[] {"reci(10)", "reci(1/10)"}, new double[] {0.1, 10})]
        public void TestReciprocal(string[] expressions, double[] expectedResults)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            for (int index = 0; index < expressions.Length; index++)
            {
                double actualResult = evaluator.Evaluate(expressions[index]);
                double expectedResult = expectedResults[index];
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        [DataRow(new string[] {"sqrt(25)"}, new double[] {5})]
        public void TestSquareRoot(string[] expressions, double[] expectedResults)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            for (int index = 0; index < expressions.Length; index++)
            {
                double actualResult = evaluator.Evaluate(expressions[index]);
                double expectedResult = expectedResults[index];
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        public void TestSine()
        {
            string expression = "sin(90)";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = Math.Sin((3.14/180)*90);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCosine()
        {
            string expression = "cos(0)";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = Math.Cos((3.14/180)*0);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
