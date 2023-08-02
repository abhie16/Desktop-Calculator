using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal class UnaryOperation : IOperation
    {
        public void Evaluate()
        {
            Console.WriteLine("this implements unary operations");
        }
    }
}
