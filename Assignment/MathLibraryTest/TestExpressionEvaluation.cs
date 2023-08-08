using MathLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathLibraryTest
{
    [TestClass]
    public class TestExpressionEvaluation
    {
        [TestMethod]
        public void TestTokenization()
        {
            String Expression = "sq2+cube0.01";
            String[] ActualTokens = Tokenization.ConvertToTokens(Expression);
            String[] ExpectedTokens = { "sq", "2", "+", "cube", "0.01" };
            CollectionAssert.AreEqual(ExpectedTokens, ActualTokens);
        }

        [TestMethod]
        public void TestPostfixConversion()
        {
            String[] InfixExpression = { "sq", "2", "+", "cube", "2", "+", "sin", "90", "/", "6" };
            String ActualPostfixExpression = PostfixConversion.InfixToPostfixExpression(InfixExpression);
            String ExpectedPostfixEpression = "2 sq 2 cube + 90 sin 6 / +";
            Assert.AreEqual(ExpectedPostfixEpression, ActualPostfixExpression);
        }

        [TestMethod]
        public void TestExpressionEvaluator()
        {
            String Expression = "4+4/2*8";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 20;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
