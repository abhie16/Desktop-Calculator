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
            string expression = "25%";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = 0.25;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestNegation()
        {
            string expression = "neg25";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = -25;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestLogarithmic()
        {
            string expression = "log10";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = 1;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCube()
        {
            string expression = "cube10";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = 1000;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSquare()
        {
            string expression = "sq10";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = 100;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestReciprocal()
        {
            string expression = "reci10";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = 0.1;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSquareRoot()
        {
            string expression = "sqrt81";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = 9;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestSine()
        {
            string expression = "sin90";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = Math.Sin((3.14/180)*90);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCosine()
        {
            string expression = "cos90";
            ExpressionEvaluator evaluator = new ExpressionEvaluator();
            double actualResult = evaluator.Evaluate(expression);
            double expectedResult = Math.Cos((3.14/180)*90);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
