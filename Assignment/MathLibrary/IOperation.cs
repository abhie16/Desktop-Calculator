
namespace MathLibrary
{
    internal interface IOperation
    {
        int OperandCount { get; }
        double Evaluate(double[] operands);
    }
}
