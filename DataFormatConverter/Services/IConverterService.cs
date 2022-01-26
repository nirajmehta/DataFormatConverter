using System;
using System.Collections.Generic;
using System.Text;

namespace DataFormatConverter.Services
{
    public interface IConverterService
    {
        public void ConvertCsvToJson();
        public void ConvertJsonToCsv();
    }
}
