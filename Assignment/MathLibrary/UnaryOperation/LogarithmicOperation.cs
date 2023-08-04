using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class LogarithmicOperation : UnaryOperation
    {
        public override double Evaluate(double[] operand)
        {

            if (operand[0] == 0 || operand.Length != 1)
            {
                throw new ExceptionHandling(MessageResource.InvalidInput);
            }

            return Math.Log10(operand[0]);
        }
    }
}
