using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Tokenization
    {
        

        public static String[] ConvertToTokens(String expression)
        {
            if (expression == null) return null;
                
            List<String> Tokens = new List<String>();

            int index = 0;
            while(index < expression.Length)
            {
                String token = "";
                if (index < expression.Length && expression[index] <= '9' && expression[index] >= '0')
                {
                    while (index < expression.Length && (expression[index] <= '9' && expression[index] >= '0'))
                    {
                        token += expression[index]+"";
                        index++;
                    }

                    Tokens.Add(token);
                }
                else if (((expression[index] >= '%' && expression[index] <= '/') || expression[index] == '^') && index < expression.Length)
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
