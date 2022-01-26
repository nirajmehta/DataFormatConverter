using ChoETL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace DataFormatConverter.Services
{
    public class ConsoleFileLoaderService : IFileLoaderService
    {
        //I have separated csv loading from conversion, so in future if we want to load it from DB,
        //we just need to swap this service.
        public string LoadCSVFile()
        {
            Console.WriteLine("Type CSV file name with path e.g C:\\Users\\niraj\\CSVFile.csv then press Enter");
            Console.WriteLine("that will display JSON here");

            var filePath = Console.ReadLine();
            var csvString = File.ReadAllText(filePath);

            return csvString;
        }

        public string LoadJSONFile()
        {
            Console.WriteLine("Type JSON file name with path e.g C:\\Users\\niraj\\JSONFile.json then press Enter");
            Console.WriteLine("that will display CSV here");

            var filePath = Console.ReadLine();
            var jsonString = File.ReadAllText(filePath);


            return jsonString;
        }
    }
}
