﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class CubeOperation : UnaryOperation
    {
        public override double Evaluate(double[] operand)
        {
            if (operand.Length != 1)
            {
                throw new ArgumentException("Invalid Input");
            }
            return Power(operand[0], 3);
        }
    }
}
