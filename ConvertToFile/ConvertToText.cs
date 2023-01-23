using System;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Xml.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace ConvertToFile
{
    public class ConvertToText
    {

        public static void WriteToAndReadFromTxt(string name, string txt)
        {
            var filePath = $@".{Path.DirectorySeparatorChar}{name.ToLower()}.txt";
        
          
            // This text is added only once to the file.
            if (!File.Exists(filePath))
            {
                // Create a file to write to.
                File.WriteAllText(filePath, txt);
            }
            else {
            // This text is always added, making the file longer over time
            // if it is not deleted.
            string appendText = Environment.NewLine + "-----------------------------" + Environment.NewLine + txt;
                File.AppendAllText(filePath, appendText);
            }
            
            // Open the file to read from.
            string readText = File.ReadAllText(filePath);
            Console.WriteLine(readText);

        }
       


    }
}
