using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class ExpressionEvaluator
    {
        private String[] PostfixConversion(String[] tokens)
        {
            return new String[] { };
        }
        public double Evaluate() {
            double result;
            double[] operands= { 180 };
           UnaryOperation operation = new SineOperation();
            result = operation.Evaluate(operands);
            return result;
        }
    }
}
