
namespace MathLibrary
{
    public class DivisionOperation : BinaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (operands[0] == 0)
            {
                throw new ExpressionException(MessageResource.DividedByZero);
            }

            if (operands.Length != 2)
            {
                throw new ExpressionException(MessageResource.InvalidInput);
            }

            return operands[1] / operands[0];
        }
    }
}
