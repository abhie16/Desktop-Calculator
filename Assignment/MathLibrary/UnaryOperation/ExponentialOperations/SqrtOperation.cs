using System;

namespace MathLibrary
{
    public class  SqrtOperation : UnaryOperation
    {
        public override double Evaluate(double[] operand)
        {
            try
            {
                return Math.Sqrt(operand[0]);
            }
            catch
            {
                throw new ExpressionException(MessageResource.ArgumentException);
            }
        }
    }
}
