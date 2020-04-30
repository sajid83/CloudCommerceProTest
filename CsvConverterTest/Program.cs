using CsvConverterTest.BusinessLogic;
using CsvConverterTest.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverterTest
{
    class Program
    {


        static void Main(string[] args)
        {
            string filepath = GetFilenameFromUserInput();
            int conversionType = GetConversionTypeFromUserInput();
            filepath = string.IsNullOrEmpty(filepath) ? ConfigurationManager.AppSettings["dummyCsvFilePath"] : filepath;
            var csvDataAsObjects = ReadCsvFile(filepath);
            
            ConversionType selectedConversionType = (ConversionType)conversionType;            
            object response;

            try
            {
                switch (selectedConversionType)
                {
                    case ConversionType.CsvToJson:
                        response = new ConvertCsvToJson().Convert(csvDataAsObjects);
                        WriteToFile(response.ToString(), ".json");
                        break;
                    case ConversionType.CsvToXml:
                        response = new ConvertCsvToXml().Convert(csvDataAsObjects);
                        WriteToFile(response.ToString(), ".xml");
                        break;
                    default:
                        Console.WriteLine("Invalid input, please re-enter: ");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void WriteToFile(string data, string extension)
        {
            string createFilePath = ConfigurationManager.AppSettings["createFilePath"];
            string createFilename = ConfigurationManager.AppSettings["createFilename"];
            string file = string.Format(@"{0}{1}{2}", createFilePath, createFilename, extension);
       
            if (File.Exists(file))
            {
                File.Delete(file);
            }
  
            using (StreamWriter sw = File.CreateText(file))
            {
                sw.WriteLine(data);
            }
        }

        private static List<CsvDataRow> ReadCsvFile(string filename)
        {
            List<CsvDataRow> values = File.ReadAllLines(filename) //"C:\\Users\\Josh\\Sample.csv")
                                           .Skip(1)
                                           .Select(v => CsvDataRow.FromCsv(v))
                                           .ToList();

            return values;
        }

        private static string GetFilenameFromUserInput()
        {
            Console.WriteLine("Please enter CSV filepath (for example C:\\test\\test.csv) or leave blank to use dummy CSV file (in app config): ");
            string filepath = Console.ReadLine();
            return filepath;
        }

        private static int GetConversionTypeFromUserInput()
        {
            Console.WriteLine("Please type 1 to convert to JSON or 2 to convert to XML: ");
            ConsoleKeyInfo userInput = Console.ReadKey();

            //ConsoleKey.
            //var read = Console.Read();
            //var readline = Console.ReadLine();

            if (char.IsDigit(userInput.KeyChar))
            {
                return int.Parse(userInput.KeyChar.ToString()); // use Parse if it's a Digit
            }
            return 0;
        }
    }
}
