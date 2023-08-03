using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class DivisionOperation : BinaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (operands[0] == 0)
            {
                throw new ArithmeticException("Denominator Should be non-zero");
            }

            if (operands.Length != 2)
            {
                throw new ArgumentException("Not Correct Number of Inputs");
            }

            return operands[1] / operands[0];
        }
    }
}
