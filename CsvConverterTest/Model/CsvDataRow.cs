using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvConverterTest.Model
{
    public class CsvDataRow
    {
        public string name { get; set; }
        public Address address { get; set; }

        public static CsvDataRow FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            CsvDataRow csvDataRow = new CsvDataRow();
            csvDataRow.name = values[0];
            csvDataRow.address = new Address()
            {
                line1 = values[1],
                line2 = values[2]
            };
            
            return csvDataRow;
        }
    }
}
