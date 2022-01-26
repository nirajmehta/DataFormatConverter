using System;
using System.Collections.Generic;
using System.Text;

namespace DataFormatConverter.Services
{
    public class DBFileLoaderService : IFileLoaderService
    {
        public string LoadCSVFile()
        {
            //here we can load CSV file from database
            //and then DI can be modified to use this service
            throw new NotImplementedException();
        }

        public string LoadJSONFile()
        {
            throw new NotImplementedException();
        }
    }
}
