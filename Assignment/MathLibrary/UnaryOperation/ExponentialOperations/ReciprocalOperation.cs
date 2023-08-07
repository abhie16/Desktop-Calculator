using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class ReciprocalOperation : UnaryOperation
    {
        public override double Evaluate(double[] operand)
        {
            if (operand.Length != 1)
            {
                throw new ExpressionExceptions(MessageResource.ArgumentException);
            }

            return Power(operand[0], -1);
        }
    }
}
