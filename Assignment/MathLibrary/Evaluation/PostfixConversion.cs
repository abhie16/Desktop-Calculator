using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class PostfixConversion : OperationMapping
    {
        public static string InfixToPostfixExpression(string[] infixExpression)
        {

            List<String> PostfixExpressionList = new List<String>();

            Stack<String> stack = new Stack<String>();

            for (int i = 0; i < infixExpression.Length; ++i)
            {
                String Token = infixExpression[i];

                if (Double.TryParse(Token,out double TokenValue))
                {
                    PostfixExpressionList.Add(TokenValue.ToString());
                }

                else if (Token == "(")
                {
                    stack.Push(Token);
                }

                else if (Token == ")")
                {
                    while (stack.Count > 0
                           && stack.Peek() != "(")
                    {
                        PostfixExpressionList.Add( stack.Pop());
                    }

                    if (stack.Count > 0
                        && stack.Peek() != "(")
                    {
                        throw new ExpressionExceptions(MessageResource.InvalidExpression);
                    }
                    else
                    {
                        stack.Pop();
                    }
                }

                else
                {
                    while (stack.Count > 0
                           && OperatorPrecedence(Token) <= OperatorPrecedence(stack.Peek()))
                    {
                        PostfixExpressionList.Add(stack.Pop());
                    }
                    stack.Push(Token);
                }
            }

            // Pop all the operators from the stack
            while (stack.Count > 0)
            {
                PostfixExpressionList.Add(stack.Pop());
            }
            String PostfixExpression = "";

            for(int i=0; i<PostfixExpressionList.Count; i++)
            {
                PostfixExpression += PostfixExpressionList[i];
                PostfixExpression += " ";
            }

            return PostfixExpression.Trim();
        }
    }
}
