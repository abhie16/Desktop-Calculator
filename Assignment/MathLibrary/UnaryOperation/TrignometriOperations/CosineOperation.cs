using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class CosineOperation : UnaryOperation
    {
        public override double Evaluate(double[] operand)
        {
            //converting degree to radian;
            double radian = operand[0] * 3.14/180;

            try
            {
                return Math.Round(Math.Cos(radian));
            }
            catch
            {
                throw new ArgumentException("Invalid Input");
            }
        }

    }
}
