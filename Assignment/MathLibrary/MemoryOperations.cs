using System;

namespace MathLibrary
{
    public class MemoryOperations
    {
        private double _memoryValue = 0.0;

        public void SaveToMemory(String result)
        {
            Double.TryParse(result, out _memoryValue);
        }

        public double AddToMemory()
        {
            _memoryValue += _memoryValue;
            return _memoryValue;
        }

        public double SubtractFromMemory()
        {
            _memoryValue -= _memoryValue;
            return _memoryValue;
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
