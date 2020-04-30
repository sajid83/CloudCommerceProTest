using CsvConverterTest.Base;
using CsvConverterTest.Model;
using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverterTest.BusinessLogic
{
    public class ConvertCsvToJson : ConvertData
    {
        public override object Convert(List<CsvDataRow> dataToConvert)
        {
            return new JavaScriptSerializer().Serialize(dataToConvert);
        }
    }
}
