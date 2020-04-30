using CsvConverterTest.Base;
using CsvConverterTest.Model;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverterTest.BusinessLogic
{
    public class ConvertCsvToXml : ConvertData
    {
        public override object Convert(List<CsvDataRow> dataToConvert)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(dataToConvert.GetType());
            StringWriter Writer = new StringWriter();
            xmlSerializer.Serialize(Writer, dataToConvert);
            return Writer.ToString();
        }
    }
}
