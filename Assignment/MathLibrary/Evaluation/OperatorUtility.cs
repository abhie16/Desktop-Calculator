using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MathLibrary
{
    public class OperatorUtility
    {
        public static Dictionary<string, OperatorInfo>  OperatorInfoDictionary = new Dictionary<string, OperatorInfo>();
        static OperatorUtility() {
			string jsonText = File.ReadAllText(@MessageResource.ConfigFilePath);
			OperatorInfoDictionary = JsonConvert.DeserializeObject<Dictionary<string, OperatorInfo>>(jsonText);
		}
        

        public static bool IsOperator(string operatorSign)
        {
            return OperatorInfoDictionary.ContainsKey(operatorSign);
        }

        public static int OperatorPrecedence(string operatorSign)
        {
            try
            {
                return OperatorInfoDictionary[operatorSign].Precedence;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}

