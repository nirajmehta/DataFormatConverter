using DataFormatConverter.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DataFormatConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //setup DI
            var serviceProvider = new ServiceCollection()
                                    .AddLogging(configure => configure.AddConsole())
                                    .AddScoped<IFileLoaderService, ConsoleFileLoaderService>()
                                    .AddScoped<IConverterService, ConverterService>()
                                    .BuildServiceProvider();

            //configure logging
            serviceProvider.GetService<ILoggerFactory>();
            var logger = serviceProvider.GetService<ILoggerFactory>()
                                        .CreateLogger<Program>();

            //this will get the service and do the conversion
            try
            {
                var converterService = serviceProvider.GetService<IConverterService>();
                converterService.ConvertCsvToJson();

                Console.Read();
            }
            catch(Exception e)
            {
                logger.LogError($"Error: {e.Message}");
            }
        }
    }
}
