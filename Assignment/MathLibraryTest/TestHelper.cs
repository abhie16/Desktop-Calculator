
using MathLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLibraryTest
{
    public class TestHelper
    {
        public void TestHelperArrayParam(string[] expressions, double[] expectedResults)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            for (int index = 0; index < expressions.Length; index++)
            {
                double actualResult = evaluator.Evaluate(expressions[index]);
                double expectedResult = expectedResults[index];
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        public void TestHelperConstParam(string expression, double expectedResult)
        {
            ExpressionEvaluator evaluator = new ExpressionEvaluator();

            double actualResult = evaluator.Evaluate(expression);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
