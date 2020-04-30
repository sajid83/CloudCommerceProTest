using CsvConverterTest.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverterTest.Base
{
    public class ConvertData
    {
        public virtual object Convert(List<CsvDataRow> dataToConvert)
        {
            throw new NotImplementedException();
        }
    }
}
