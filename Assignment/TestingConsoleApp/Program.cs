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
                UnaryOperation obj = new SquareOperation();
                double[] arr = { 4 ,12};
                double ans = obj.Evaluate(arr);
                Console.WriteLine(ans);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadKey();
        }
    }
}
