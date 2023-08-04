﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class SquareOperation : UnaryOperation
    {
        public override double Evaluate(double[] operand)
        {
            if (operand.Length != 1)
            {
                throw new ExceptionHandling(MessageResource.ArgumentException);
            }

            return Power(operand[0], 2);
        }
    }
}
