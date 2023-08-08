using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class MemoryUtility
    {
        private double _memoryValue = 0.0;

        public void AddToMemory(double value)
        {
            _memoryValue += value;
        }

        public void SubtractFromMemory(double value)
        {
            _memoryValue -= value;
        }

        public void ClearMemory()
        {
            _memoryValue = 0.0;
        }

        public double GetMemoryValue()
        {
            return _memoryValue;
        }
    }
}
