using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataFormatConverter
{
    //This would convert the example CSV given in the technical test, but this approach uses hard-coded headers,
    //that is not very efficient if in future we get more headers
    //By using Dictionaries it can be made dynamic, however I tried that without success
    public class CsvToJsonAnotherApproach
    {
        public static void CsvToJson()
        {
            Console.WriteLine("Type CSV file name with path e.g C:\\Users\\niraj\\CSVFile.csv then press Enter");
            var filePath = Console.ReadLine();
            var lines = File.ReadAllLines(filePath);

            var headers = lines[0].Split(',');
            var values = lines[1].Split(',');
            var person = new Person();

            for (int i = 0; i < headers.Length; i++)
            {
                switch (headers[i])
                {
                    case "name":
                        person.Name = values[i];
                        break;
                    case "address_line1":
                        person.Address.Line1 = values[i];
                        break;
                    case "address_line2":
                        person.Address.Line2 = values[i];
                        break;
                }
            }

            var json = JsonConvert.SerializeObject(person);
        }
    }

    //I have kept theses classes here for readability
    //They should go to separate files for each of the classes
    public class Person
    {
        public Person()
        {
            Address = new Address();
        }
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
    }
}
