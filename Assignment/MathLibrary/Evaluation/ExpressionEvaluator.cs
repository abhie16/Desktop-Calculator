using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class ExpressionEvaluator
    {
        private static Dictionary<String, Type> OperatorToBinaryClassMap = new Dictionary<String, Type>()
        {
            {"+",typeof(AdditionOperation)},
            {"-",typeof(SubtractionOperation)},
            {"/",typeof(DivisionOperation)},
            {"*",typeof(MultiplicationOperation)},
        };

        private bool isOperator(String Operator)
        {
            return OperatorToBinaryClassMap.ContainsKey(Operator);
        }
        
        public double Evaluate(String Expression) {
            Stack<double> OperandStack = new Stack<double>();
            String[] Tokens = Tokenization.ConvertToTokens(Expression);

            String PostfixExpression = PostfixConversion.InfixToPostfixExpression(Tokens);

            String[] PostfixTokens = PostfixExpression.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
                            throw new ExceptionHandling(MessageResource.InvalidExpression);
                        }

                        double Operand2 = OperandStack.Pop();
                        double Operand1 = OperandStack.Pop();

                        var BinaryOperation = Activator.CreateInstance(BinaryClassOperation) as IOperation;
                        double result = BinaryOperation.Evaluate(new double[] {Operand2, Operand1});

                        OperandStack.Push(result);
                    }
                    else
                    {
                        throw new ExceptionHandling(MessageResource.InvalidPostfixExpression);
                    }
                }
                else
                {
                    throw new ExceptionHandling(MessageResource.InvalidExpression);
                }
            }

            if(OperandStack.Count != 1)
            {
                 throw new ExceptionHandling(MessageResource.InvalidExpression);
            }

            return OperandStack.Pop();
        }
    }
}
