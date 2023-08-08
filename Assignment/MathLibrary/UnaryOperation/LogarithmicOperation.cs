using System;

namespace MathLibrary
{
    public class LogarithmicOperation : UnaryOperation
    {
        public override double Evaluate(double[] operand)
        {

            if (operand[0] == 0 || operand.Length != 1)
            {
                throw new ExpressionException(MessageResource.InvalidInput);
            }

            return Math.Log10(operand[0]);
        }
    }
}
