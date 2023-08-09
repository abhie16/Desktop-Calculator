using System.Collections.Generic;

namespace MathLibrary
{
    public class Tokenization : OperationMapping
    {
        

        public static string[] ConvertToTokens(string expression)
        {
            bool decimalFlag = true;

            if (expression == null) return null;
                
            List<string> tokens = new List<string>();

            int index = 0;
            while(index < expression.Length)
            {
                string token = "";
                if (index < expression.Length && expression[index] <= '9' && expression[index] >= '0')
                {
                    while (index < expression.Length && ((expression[index] <= '9' && expression[index] >= '0') || expression[index] == '.'))
                    {
                        if(expression[index] == '.' && decimalFlag == false)
                        {
                            throw new ExpressionException(MessageResource.InvalidDecimal);
                        }
                        if (expression[index] == '.')
                        {
                            decimalFlag = false;
                        }
                        token += expression[index]+"";
                        index++;
                    }

                    tokens.Add(token);
                }
                else if ((expression[index] < 'a' || expression[index] > 'z') && (expression[index] < 'A' || expression[index] > 'Z') && (expression[index] < '0' || expression[index] > '9') && index < expression.Length)
                {
                    token = expression[index].ToString();
                    tokens.Add(token);
                    index++;
                }
                else
                {
                    while ((expression[index] < '0' || expression[index] > '9') && (expression[index] >= 'a' && expression[index] <= 'z') || (expression[index] >= 'A' && expression[index] <= 'Z') && index < expression.Length)
                    {
                        token += expression[index];
                        index++;
                    }

                    tokens.Add(token);
                }
                
            }
            
            return tokens.ToArray();
        }

    }
}
