using System;
using System.Collections.Generic;
using System.Text;

namespace DataFormatConverter.Services
{
    public interface IFileLoaderService
    {
        public string LoadCSVFile();

        public string LoadJSONFile();
    }
}
