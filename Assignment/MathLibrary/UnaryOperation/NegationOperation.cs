using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class NegationOperation : UnaryOperation
    {
        public override double Evaluate(double[] operand)
        {
            if (operand.Length != 1)
            {
                throw new ExceptionHandling(MessageResource.ArgumentException);
            }

            return -operand[0];
        }
    }
}
