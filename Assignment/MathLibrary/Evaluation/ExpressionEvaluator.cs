using System;
using System.Collections.Generic;

namespace MathLibrary
{
    public class ExpressionEvaluator : OperationMapping
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
                    if(OperatorToBinaryClassMap.TryGetValue(token, out Type binaryClassOperation))
                    {
                        if(operandStack.Count < 2)
                        {
                            throw new ExpressionException(MessageResource.InvalidExpression);
                        }

                         double binaryOperand1 = operandStack.Pop();
                         double binaryOperand2 = operandStack.Pop();

                         var binaryOperation = Activator.CreateInstance(binaryClassOperation) as IOperation;
                         double result = binaryOperation.Evaluate(new double[] {binaryOperand1, binaryOperand2});

                         operandStack.Push(result);
                    }
                    else if (OperatorToUnaryClassMap.TryGetValue(token, out Type unaryClassOperation))
                    {
                        if (operandStack.Count < 1)
                        {
                            throw new ExpressionException(MessageResource.InvalidExpression);
                        }

                        double unaryOperand = operandStack.Pop();

                        var unaryOperation = Activator.CreateInstance(unaryClassOperation) as IOperation;
                        double result = unaryOperation.Evaluate(new double[] {unaryOperand});

                        operandStack.Push(result);
                    }
                    else
                    {
                        throw new ExpressionException(MessageResource.InvalidPostfixExpression);
                    }
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
