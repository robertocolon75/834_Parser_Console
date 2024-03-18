using Newtonsoft.Json;

namespace _834FilePareserControl
{
    public static class JsonDumper
    {
        public static void DumpObjectToJsonFile<T>(T obj, string filePath)
        {
            // Convert the object to JSON string
            string jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);

            // Write the JSON string to file
            File.WriteAllText(filePath, jsonString);
        }
    }
}