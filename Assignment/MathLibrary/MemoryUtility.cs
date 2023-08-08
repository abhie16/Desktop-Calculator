using System;

namespace MathLibrary
{
    public class MemoryUtility
    {
        private double _memoryValue = 0.0;

        public void SaveToMemory(String result)
        {
            Double.TryParse(result, out _memoryValue);
        }

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
