using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MathLibrary
{
    public class OperationMapping
    {
        public static Dictionary<String, int> OperatorPrecedenceMap = new Dictionary<String, int>();
        public Dictionary<String, Type> OperatorToBinaryClassMap = new Dictionary<String, Type>();
        public Dictionary<String, Type> OperatorToUnaryClassMap = new Dictionary<String, Type>();

        public void MappingOperators()
        {
            string Json = File.ReadAllText(@MessageResource.ConfigFilePath);
            Console.WriteLine(Json);

        }
        protected bool IsOperator(String expOperator)
        {
            return OperatorToBinaryClassMap.ContainsKey(expOperator) || OperatorToUnaryClassMap.ContainsKey(expOperator);
        }

        


        public static int OperatorPrecedence(String expOperator)
        {
            if (OperatorPrecedenceMap.ContainsKey(expOperator))
            {
                return OperatorPrecedenceMap[expOperator];
            }
            return -1;
        }
    }
}
