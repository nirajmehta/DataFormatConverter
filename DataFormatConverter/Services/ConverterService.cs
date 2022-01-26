using System;
using System.Collections.Generic;
using System.Text;
using ChoETL;
using System.Linq;

namespace DataFormatConverter.Services
{
    public class ConverterService : IConverterService
    {
        private readonly IFileLoaderService _fileLoaderService;

        public ConverterService(IFileLoaderService fileLoaderService)
        {
            //depending on DI, we either get consoleFileLoaderService or dbFileLoaderService
            _fileLoaderService = fileLoaderService;
        }

        //I am using ChoETL.JSON.NETStandard nuget package, that would also work with CSV to XML conversion
        //and vice versa
        //
        public void ConvertCsvToJson()
        {
            string csvString = _fileLoaderService.LoadCSVFile();

            using (var w = new ChoJSONWriter(Console.Out)
                   .Configure(c => c.SupportMultipleContent = true)
                   .SingleElement()
                   .Configure(c => c.DefaultArrayHandling = false)
                  )
            {
                using (var r = ChoCSVReader.LoadText(csvString).WithFirstLineHeader())
                    w.Write(r.Select(i => i.ConvertToNestedObject('_')));
            }
        }

        public void ConvertJsonToCsv()
        {
            string jsonString = _fileLoaderService.LoadJSONFile();
            
            using (var r = ChoJSONReader.LoadText(jsonString))
            {
                using (var w = new ChoCSVWriter(Console.Out).WithFirstLineHeader())
                {
                    w.Write(r);
                }
            }
        }
    }
}
