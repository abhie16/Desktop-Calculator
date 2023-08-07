using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class ExpressionEvaluator : Operators
    {
        
        public double Evaluate(String Expression) {
            Stack<double> OperandStack = new Stack<double>();
            String[] Tokens = Tokenization.ConvertToTokens(Expression);

            String PostfixExpression = PostfixConversion.InfixToPostfixExpression(Tokens);

            String[] PostfixTokens = PostfixExpression.Split(" ".ToCharArray());
            

            foreach(String Token in PostfixTokens )
            {
                if (double.TryParse(Token, out double operand))
                {
                    OperandStack.Push(operand);
                }
                else if(isOperator(Token))
                {
                    if(OperatorToBinaryClassMap.TryGetValue(Token, out Type BinaryClassOperation))
                    {
                        if(OperandStack.Count < 2)
                        {
                            throw new ExpressionExceptions(MessageResource.InvalidExpression);
                        }

                        double Operand2 = OperandStack.Pop();
                        double Operand1 = OperandStack.Pop();

                        var BinaryOperation = Activator.CreateInstance(BinaryClassOperation) as IOperation;
                        double result = BinaryOperation.Evaluate(new double[] {Operand2, Operand1});

                        OperandStack.Push(result);
                    }
                    else if (OperatorToUnaryClassMap.TryGetValue(Token, out Type UnaryClassOperation))
                    {
                        if (OperandStack.Count < 1)
                        {
                            throw new ExpressionExceptions(MessageResource.InvalidExpression);
                        }

                        double Operand = OperandStack.Pop();

                        var UnaryOperation = Activator.CreateInstance(UnaryClassOperation) as IOperation;
                        double result = UnaryOperation.Evaluate(new double[] { Operand });

                        OperandStack.Push(result);
                    }
                    else
                    {
                        throw new ExpressionExceptions(MessageResource.InvalidPostfixExpression);
                    }
                }
                else
                {
                    throw new ExpressionExceptions(MessageResource.InvalidExpression);
                }
            }

            if(OperandStack.Count != 1)
            {
                 throw new ExpressionExceptions(MessageResource.InvalidExpression);
            }

            return OperandStack.Pop();
        }
    }
}
