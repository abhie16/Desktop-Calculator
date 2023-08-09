using System;
using System.Collections.Generic;
using System.Reflection;

namespace MathLibrary
{
    public class ExpressionEvaluator : OperatorUtility
    {
        public double Evaluate(string expression) {

            Stack<double> operandStack = new Stack<double>();

            string postfixExpression = PostfixConversion.InfixToPostfixExpression(Tokenization.ConvertToTokens(expression));

            string[] postfixTokens = postfixExpression.Split();
            

            foreach(string token in postfixTokens )
            {
                if (Double.TryParse(token, out double operand))
                {
                    operandStack.Push(operand);
                }
                else if(IsOperator(token))
                {
                    
                        Type operationType =  Type.GetType(OperatorInfoDictionary[token].OperationClass);
                        IOperation operationObject = Activator.CreateInstance(operationType) as IOperation;

                        double[] operands = new double[operationObject.OperandCount];

                        for (int index = 0; index < operands.Length; index++)
                        {
                            operands[index] = operandStack.Pop();
                        }

                        double result = operationObject.Evaluate(operands);
                        operandStack.Push(result);
                    
                }
                else
                {
                    throw new ExpressionException(MessageResource.InvalidExpression);
                }
            }

            if(operandStack.Count != 1)
            {
                 throw new ExpressionException(MessageResource.InvalidExpression);
            }

            return operandStack.Pop();
        }
    }
}
