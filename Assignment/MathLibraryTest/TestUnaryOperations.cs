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
    public class TestUnaryOperations
    {
        [TestMethod]
        public void TestPercentage()
        {
            String Expression = "25%";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 0.25;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void TestNegation()
        {
            String Expression = "neg25";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = -25;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void TestLogarithmic()
        {
            String Expression = "log10";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 1;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void TestCube()
        {
            String Expression = "cube10";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 1000;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void TestSquare()
        {
            String Expression = "sq10";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 100;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void TestReciprocal()
        {
            String Expression = "reci10";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 0.1;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void TestSquareRoot()
        {
            String Expression = "sqrt81";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 9;
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void TestSine()
        {
            String Expression = "sin90";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 1;
            Assert.AreEqual(ExpectedResult, Math.Round(ActualResult));
        }

        [TestMethod]
        public void TestCosine()
        {
            String Expression = "cos90";
            ExpressionEvaluator Evaluator = new ExpressionEvaluator();
            double ActualResult = Evaluator.Evaluate(Expression);
            double ExpectedResult = 0;
            Assert.AreEqual(ExpectedResult, Math.Round(ActualResult));
        }
    }
}
