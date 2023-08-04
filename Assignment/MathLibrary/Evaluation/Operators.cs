﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Operators
    {
        protected bool isOperator(String Operator)
        {
            return OperatorToBinaryClassMap.ContainsKey(Operator) || OperatorToUnaryClassMap.ContainsKey(Operator);
        }

        protected static Dictionary<String, Type> OperatorToBinaryClassMap = new Dictionary<String, Type>()
        {
            {"+",typeof(AdditionOperation)},
            {"-",typeof(SubtractionOperation)},
            {"/",typeof(DivisionOperation)},
            {"*",typeof(MultiplicationOperation)},
        };

        protected static Dictionary<String, Type> OperatorToUnaryClassMap = new Dictionary<String, Type>()
        {
            {"log",typeof(LogarithmicOperation)},
            {"sq",typeof(SquareOperation)},
            {"cube",typeof(CubeOperation)},
            {"reci",typeof(ReciprocalOperation)},
            {"%",typeof(PercentageOperation)},
            {"neg",typeof(NegationOperation)},
            {"sin",typeof(SineOperation)},
            {"cos",typeof(CosineOperation)},
        };

        protected static int OperatorPrecedence(String op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;

                case "sq":
                case "cube":
                case "log":
                case "reci":
                case "%":
                case "neg":
                case "sin":
                case "cos":
                    return 3;
            }
            return -1;
        }
    }
}