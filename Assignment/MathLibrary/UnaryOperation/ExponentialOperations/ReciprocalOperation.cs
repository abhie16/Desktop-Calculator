
namespace MathLibrary
{
    public class ReciprocalOperation : UnaryOperation
    {
        public override double Evaluate(double[] operand)
        {
            if (operand.Length != 1)
            {
                throw new ExpressionException(MessageResource.ArgumentException);
            }

            return Power(operand[0], -1);
        }
    }
}
