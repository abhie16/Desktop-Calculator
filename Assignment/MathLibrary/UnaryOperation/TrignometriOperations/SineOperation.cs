using System;

namespace MathLibrary
{
    public class SineOperation : UnaryOperation
    {
        public override double Evaluate (double[] operand)
        {
            //converting degree to radian;
            double radian = operand[0] * 3.14 / 180;

            try
            {
                return Math.Sin(radian);
            }
            catch
            {
                throw new ExpressionException(MessageResource.InvalidInput);
            }
        }

    }
}
