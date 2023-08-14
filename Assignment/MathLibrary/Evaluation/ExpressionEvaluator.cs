using System;
using System.Collections.Generic;

namespace MathLibrary
{
    public class ExpressionEvaluator
    {
        public double Evaluate(string expression) {

            Stack<double> operandStack = new Stack<double>();

            string postfixExpression = PostfixConvertor.InfixToPostfixConvertor(Tokenizer.ConvertToTokens(expression));

            string[] postfixTokens = postfixExpression.Split();
            

            foreach(string token in postfixTokens)
            {
                if (Double.TryParse(token, out double operand))
                {
                    operandStack.Push(operand);
                }
                else if(OperatorUtility.IsOperator(token))
                {
                    
                        Type operationType =  Type.GetType(OperatorUtility.OperatorInfoDictionary[token].OperationClass);
                        IOperation operationInstance = Activator.CreateInstance(operationType) as IOperation;

                        double[] operands = new double[operationInstance.OperandCount];

                        for (int index = 0; index < operands.Length; index++)
                        {
                            if(operandStack.Count == 0) {
                                throw new ExpressionException(MessageResource.InvalidInput);
                            }

                            operands[index] = operandStack.Pop();
                        }

                        double result = operationInstance.Evaluate(operands);
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
