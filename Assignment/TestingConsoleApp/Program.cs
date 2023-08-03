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
                ExpressionEvaluator obj = new ExpressionEvaluator();
                Console.WriteLine(obj.Evaluate());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadKey();
        }
    }
}
