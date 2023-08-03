using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public abstract class BinaryOperation : IOperation
    {
        private int _count = 2;
        public int OperandCount
        {
            get { return _count; }
        }


        public abstract double Evaluate(double[] operands);
    }
}
