
namespace MathLibrary
{
    public class PercentageOperation : UnaryOperation
    {
        public override double Evaluate(double[] operand)
        {
            if (operand.Length != 1)
            {
                throw new ExpressionException(MessageResource.ArgumentException);
            }
            return operand[0]/100;
        }
    }
}
