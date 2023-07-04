using System;
using System.Collections.Generic;
using System.IO;

namespace Calc.Data
{
    public class CalculationRepository : ICalculationRepository
    {
        private DataRepository _dataRepository;
        const string FILE_NAME = "logFile";
        public string PathFile => Environment.CurrentDirectory + "/" + FILE_NAME;

        public CalculationRepository()
        {
            _dataRepository = new DataRepository();
        }

        public void ChangeInputField(string input)
        {
            _dataRepository.InputField = input;
            SaveFile();
        }

        public void SaveResult(string result)
        {
            _dataRepository.History.Add(result);
            SaveFile();
        }

        public List<string> GetHistory()
        {
            LoadFile();

            return _dataRepository.History;
        }
        
        public string GetInput()
        {
            return _dataRepository.InputField;
        }

        public void SaveFile()
        {
            using (FileStream fileStream = File.Create(PathFile))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(fileStream, _dataRepository);
            }
        }

        private void LoadFile()
        {
            if (File.Exists(PathFile))
            {
                using (FileStream fileStream = File.OpenRead(PathFile))
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    _dataRepository = (DataRepository)formatter.Deserialize(fileStream);
                }
            }
            else
            {
                _dataRepository = new DataRepository();
            }
        }
    }
}