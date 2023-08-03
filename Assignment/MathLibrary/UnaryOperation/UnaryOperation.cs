using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public abstract class UnaryOperation : IOperation
    {
        private int _count = 1;
        public int OperandCount
        {
            get { return _count; }
        }
        public abstract double Evaluate(double[] operand);

        public double Power(double baseValue, int powerValue)
        {
            if (powerValue == 0) return 1;

            if(powerValue < 0)
            {
                baseValue = 1 / baseValue;
                powerValue = -powerValue;
            }

            return (powerValue%2 == 0) ? Power(baseValue*baseValue, powerValue/2) : baseValue*Power(baseValue*baseValue, powerValue/2);
        }
    }
}
