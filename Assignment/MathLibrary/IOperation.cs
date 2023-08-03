using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    internal interface IOperation
    {
        int OperandCount { get; }
        double Evaluate(double[] operands);
    }
}
