
namespace MathLibrary
{
    public class MultiplicationOperation : BinaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (operands.Length != 2)
            {
                throw new ExpressionException(MessageResource.ArgumentException);
            }

            return operands[1] * operands[0];
        }
    }
}
