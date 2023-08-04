using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace TestingConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {

                // testing working of library after all integration;

                /*
                
                    ExpressionEvaluator obj = new ExpressionEvaluator();
                    double result = obj.Evaluate("log10+log10");
                    Console.WriteLine(result);
                */
                

                // testing after implementing convert to token method

                
                String exp = "sq2+cube2+sin90/6";
                    String[] tokens = Tokenization.ConvertToTokens(exp);
                    for(int i = 0; i < tokens.Length; i++) {
                        Console.WriteLine(tokens[i]);
                    }
                    Console.Write( PostfixConversion.InfixToPostfixExpression(tokens));
                
                
                // testing after implementing postfix conversion method
                // String exp = "32^3+10*10/25";
                // Console.WriteLine(PostfixConversion.InfixToPostfixExpression(exp));
                // DivisionOperation obj = new DivisionOperation();
                // Console.WriteLine(obj.Evaluate(new double[] { 0, 10 }));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadKey();
        }
    }
}
