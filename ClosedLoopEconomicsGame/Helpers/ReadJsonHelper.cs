using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosedLoopEconomicsGame.Helpers
{
    public class ReadJsonHelper
    {
        public T ReadJsonFromFile<T>(string filePath)
        {
            if (string.IsNullOrEmpty(filePath));
            if (!File.Exists(filePath))
                File.Create(filePath);

            var jsonContent = File.ReadAllText(filePath, Encoding.UTF8);
            var deserializedObject = JsonConvert.DeserializeObject<T>(jsonContent);
            return deserializedObject;
        }
    }
}