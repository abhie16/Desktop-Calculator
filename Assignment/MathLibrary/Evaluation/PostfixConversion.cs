using System;
using System.Collections.Generic;

namespace MathLibrary
{
    public class PostfixConversion : OperatorUtility
    {
        public static string InfixToPostfixExpression(string[] infixExpression)
        {

            List<string> postfixExpressionList = new List<string>();
            string postfixExpression = String.Empty;

            Stack<string> operatorStack = new Stack<string>();

            for (int i = 0; i < infixExpression.Length; ++i)
            {
                string token = infixExpression[i];

                if (Double.TryParse(token,out double tokenValue))
                {
                    postfixExpressionList.Add(tokenValue.ToString());
                }

                else if (token == "(")
                {
                    operatorStack.Push(token);
                }

                else if (token == ")")
                {
                    while (operatorStack.Count > 0
                           && operatorStack.Peek() != "(")
                    {
                        postfixExpressionList.Add(operatorStack.Pop());
                    }

                    if (operatorStack.Count > 0
                        && operatorStack.Peek() != "(")
                    {
                        throw new ExpressionException(MessageResource.InvalidExpression);
                    }
                    else
                    {
                        operatorStack.Pop();
                    }
                }

                else
                {
                    while (operatorStack.Count > 0
                           && OperatorPrecedence(token) <= OperatorPrecedence(operatorStack.Peek()))
                    {
                        postfixExpressionList.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }

            // Pop all the operators from the stack
            while (operatorStack.Count > 0)
            {
                postfixExpressionList.Add(operatorStack.Pop());
            }

            for(int i=0; i<postfixExpressionList.Count; i++)
            {
                postfixExpression += postfixExpressionList[i];
                postfixExpression += " ";
            }

            return postfixExpression.Trim();
        }
    }
}
