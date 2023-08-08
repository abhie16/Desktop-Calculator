using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Tokenization : OperationMapping
    {
        

        public static String[] ConvertToTokens(String expression)
        {
            bool DecimalFlag = true;

            if (expression == null) return null;
                
            List<String> Tokens = new List<String>();

            int index = 0;
            while(index < expression.Length)
            {
                String token = "";
                if (index < expression.Length && expression[index] <= '9' && expression[index] >= '0')
                {
                    while (index < expression.Length && ((expression[index] <= '9' && expression[index] >= '0') || expression[index] == '.'))
                    {
                        if(expression[index] == '.' && DecimalFlag == false)
                        {
                            throw new ExpressionExceptions(MessageResource.InvalidDecimal);
                        }
                        if (expression[index] == '.')
                        {
                            DecimalFlag = false;
                        }
                        token += expression[index]+"";
                        index++;
                    }

                    Tokens.Add(token);
                }
                else if ((expression[index] < 'a' || expression[index] > 'z') && (expression[index] < 'A' || expression[index] > 'Z') && (expression[index] < '0' || expression[index] > '9') && index < expression.Length)
                {
                    token = expression[index].ToString();
                    Tokens.Add(token);
                    index++;
                }
                else
                {
                    while (expression[index] < '0' || expression[index] > '9' && index < expression.Length)
                    {
                        token += expression[index];
                        index++;
                    }

                    Tokens.Add(token);
                }
                
            }
            
            return Tokens.ToArray();
        }

    }
}
