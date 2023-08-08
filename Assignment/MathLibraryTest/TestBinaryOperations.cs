using MathLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLibraryTest
{
    [TestClass]
    public class TestBinaryOperations
    {
        [TestMethod]
        [DataRow(new string[] {"2+2","2+2+2"}, new double[] {4, 6} )]
        public void TestAddition(string[] expressions, double[] expectedResults)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            for(int index=0; index<expressions.Length; index++)
            {
                string exp= expressions[index];
                double actualResult = evaluator.Evaluate(exp);
                double expectedResult = expectedResults[index];

                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        public void TestSubtraction()
        {
            string expression = "2-2-2";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = -2;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            string expression = "2*2";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = 4;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestDivision()
        {
            string expression = "2/2";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = 1;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
