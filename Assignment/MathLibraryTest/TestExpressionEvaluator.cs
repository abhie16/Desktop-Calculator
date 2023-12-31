﻿using MathLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLibraryTest
{
    [TestClass]
    public class TestExpressionEvaluator
    {
        [TestMethod]
        public void TestTokenizer()
        {
            string expression = "sq2+cube0.01";
            string[] actualTokens = Tokenizer.ConvertToTokens(expression);
            string[] expectedTokens = { "sq", "2", "+", "cube", "0.01" };
            CollectionAssert.AreEqual(expectedTokens, actualTokens);
        }

        [TestMethod]
        public void TestPostfixConvertor()
        {
            string[] infixExpression = { "sq", "2", "+", "cube", "2", "+", "sin", "90", "/", "6" };
            string actualPostfixExpression = PostfixConvertor.InfixToPostfixConvertor(infixExpression);
            string expectedPostfixEpression = "2 sq 2 cube + 90 sin 6 / +";
            Assert.AreEqual(expectedPostfixEpression, actualPostfixExpression);
        }

        [TestMethod]
        public void ExpressionEvaluatorTest()
        {
            string expression = "sq(sq(3))";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = 81;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
