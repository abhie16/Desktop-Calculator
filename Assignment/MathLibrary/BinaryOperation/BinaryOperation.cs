
namespace MathLibrary
{
    public abstract class BinaryOperation : IOperation
    {
        private int _count = 2;
        public int OperandCount
        {
            get { return _count; }
        }


        public abstract double Evaluate(double[] operands);
    }
}
