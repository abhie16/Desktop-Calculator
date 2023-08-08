using System;
using System.Collections.Generic;

namespace MathLibrary
{
    public class OperationMapping
    {
        protected bool IsOperator(string operatorSign)
        {
            return OperatorToBinaryClassMap.ContainsKey(operatorSign) || OperatorToUnaryClassMap.ContainsKey(operatorSign);
        }

        protected Dictionary<string, Type> OperatorToBinaryClassMap = new Dictionary<string, Type>()
        {
            {"+",typeof(AdditionOperation)},
            {"-",typeof(SubtractionOperation)},
            {"/",typeof(DivisionOperation)},
            {"*",typeof(MultiplicationOperation)},
        };

        protected Dictionary<string, Type> OperatorToUnaryClassMap = new Dictionary<string, Type>()
        {
            {"log",typeof(LogarithmicOperation)},
            {"sq",typeof(SquareOperation)},
            {"cube",typeof(CubeOperation)},
            {"reci",typeof(ReciprocalOperation)},
            {"sqrt",typeof(SqrtOperation) },
            {"%",typeof(PercentageOperation)},
            {"neg",typeof(NegationOperation)},
            {"sin",typeof(SineOperation)},
            {"cos",typeof(CosineOperation)},
        };

        public static int OperatorPrecedence(string operatorSign)
        {
            switch (operatorSign)
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

