using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using CustomAttribute.Data;

namespace ConvertToFile
{
    public  class ConvertToJSON
    {

        public static void WriteToJsonFormat<T>(string fileName, T obj)
        {
            var filePath = $@".{Path.DirectorySeparatorChar}{fileName}";
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };
            File.WriteAllText(fileName, JsonSerializer.Serialize(obj, options));
            Console.WriteLine("File written to json, click to read file");
            Console.ReadLine();
            var readText = File.ReadAllText(filePath);
            dataObj[] DataObj = JsonSerializer.Deserialize<dataObj[]>(readText);
            foreach(var dataObj in DataObj)
            {
                Console.WriteLine($"Name: {dataObj.Name} \n" +
               $"Description: {dataObj.Description} \n" +
               $"Input: {dataObj?.Input} \n" +
               $"Output: {dataObj?.Output}");
            }
           
            // Console.WriteLine(readText);

        }
    }
}
