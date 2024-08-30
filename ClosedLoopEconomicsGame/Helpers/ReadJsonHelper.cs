using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace ClosedLoopEconomicsGame.Helpers
{
    public class ReadJsonHelper
    {
        public T ReadJsonFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
                File.Create(filePath);

            var jsonContent = File.ReadAllText(filePath, Encoding.UTF8);
            var deserializedObject = JsonConvert.DeserializeObject<T>(jsonContent);
            return deserializedObject;
        }
    }
}