﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class ExpressionExceptions : Exception
    {
        public ExpressionExceptions(String message) : base(message) { }
    }
}
