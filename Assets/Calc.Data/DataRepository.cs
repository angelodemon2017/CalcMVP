using System;
using System.Collections.Generic;

namespace Calc.Data
{
    [Serializable]
    public class DataRepository
    {
        public List<string> History;
        public string InputField;

        public DataRepository()
        {
            History = new List<string>();
            InputField = string.Empty;
        }
    }
}
