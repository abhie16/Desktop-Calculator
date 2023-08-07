using MathLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibraryTest
{
    [TestClass]
    public class TestBinaryOperations
    {
        [TestMethod]
        public void TestAddition()
        {
            String Expression = "2+2";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 4;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            String Expression = "2-2";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 0;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            String Expression = "2*2";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 4;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void TestDivision()
        {
            String Expression = "2/2";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 1;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}
