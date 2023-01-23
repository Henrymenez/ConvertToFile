using DocumentationAttribute.Implementation;
using  ConvertToFile;
namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello, World!");*/
             DocumentedAtrribute.GetDocs();
             //ConvertToText.WriteToAndReadFromTxt("DocumentInfo", DocumentedAtrribute.StringOutput.ToString());
            //ConvertToJSON.WriteToJsonFormat("DocumentInfo.json", DocumentedAtrribute.DataObj);
        }
    }
}