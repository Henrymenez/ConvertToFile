using DocumentationAttribute.CustomAttribute;
using System;
using System.Reflection;
using System.Text;

namespace DocumentationAttribute.Implementation
{
    public class DocumentedAtrribute
    {
        public static StringBuilder StringOutput = new StringBuilder();


        public static void GetDocs()
        {
            var assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine("Assembly name: " + assembly.FullName);

            Console.WriteLine();

            Type[] types = assembly.GetTypes();



            foreach (Type type in types)
            {
                DisplayType(type);

                DisplayConstructor(type);

                DisplayProperties(type);

                DisplayMethods(type);

                Console.WriteLine();

            }



        }

        // Display methods

        private static void DisplayMethods(Type type)
        {

            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                var documentattribute = (DescriptionAttribute)method.GetCustomAttribute(typeof(DescriptionAttribute));

                if (documentattribute != null)
                {
                 

                    StringOutput.AppendLine($"\t Method: {method.Name} \n" +
                        $"\t Description: {documentattribute.Description} \n" +
                        $"\t Input: {documentattribute.Input} \n" +
                        $"\t Output: {documentattribute.Output} \n");
                }


            }
        }


        // Display properties

        private static void DisplayProperties(Type type)
        {

            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var documentattribute = (DescriptionAttribute)property.GetCustomAttribute(typeof(DescriptionAttribute));

                if (documentattribute != null)
                {
                 

                    StringOutput.AppendLine($"\t Property: {property.Name} \n" +
                        $"\t Description: {documentattribute.Description} \n");
                }


            }
        }


        //// Display constructors
        private static void DisplayConstructor(Type type)
        {

            var constructors = type.GetConstructors();

            foreach (var constructor in constructors)
            {
                var documentattribute = (DescriptionAttribute)constructor.GetCustomAttribute(typeof(DescriptionAttribute));

                if (documentattribute != null)
                {
                    StringOutput.AppendLine($"\t Constructor: {constructor.Name} \n" +
                        $"\t Description: {documentattribute.Description} \n" +
                        $"\t Input: {documentattribute.Input} \n" +
                        $"\t Output: {documentattribute.Output} \n");
                }

            }
        }

        private static void DisplayType(Type type)
        {
            var documentAttribute = (DescriptionAttribute)type.GetCustomAttribute(typeof(DescriptionAttribute));

            if (documentAttribute != null && type.IsClass)
            {
              

                StringOutput.AppendLine($"Class: {type.Name} \n" +
                    $"Description: {documentAttribute.Description}");
        
            }
            else if (documentAttribute != null && type.IsEnum)
            {

                StringOutput.AppendLine($"Enum: {type.Name} \n" +
                    $"Description: {documentAttribute.Description}");
               
            }
            else if (documentAttribute != null && type.IsInterface)
            {
               

                StringOutput.AppendLine($"Interface: {type.Name} \n" +
                    $"Description: {documentAttribute.Description}");

            }
        }
    }
}
