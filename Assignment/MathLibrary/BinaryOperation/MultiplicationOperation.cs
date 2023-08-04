using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class MultiplicationOperation : BinaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (operands.Length != 2)
            {
                throw new ExceptionHandling(MessageResource.ArgumentException);
            }

            return operands[1] * operands[0];
        }
    }
}
