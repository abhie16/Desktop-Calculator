using System;

namespace MathLibrary
{
    public class MemoryOperations
    {
        private double _memoryValue = 0.0;
        private double _totalMemoryValue = 0.0;

        public void SaveToMemory(String result)
        {
            Double.TryParse(result, out _memoryValue);
            Double.TryParse(result, out _totalMemoryValue);
        }

        public double AddToMemory()
        {
            _totalMemoryValue += _memoryValue;
            return _totalMemoryValue;
        }

        public double SubtractFromMemory()
        {
            _totalMemoryValue -= _memoryValue;
            return _totalMemoryValue;
        }

        public void ClearMemory()
        {
            _memoryValue = 0.0;
            _totalMemoryValue = 0.0;
        }

        public double GetMemoryValue()
        {
            return _totalMemoryValue;
        }
    }
}
