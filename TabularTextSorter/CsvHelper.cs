using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;

namespace TabularTextSorter
{
    public class CsvHelper
    {
        public IEnumerable<dynamic> GetRecords(string inputPath, string delimiter, bool headerRecord)
        {
            using (var reader = new StreamReader(inputPath))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = delimiter;
                csv.Configuration.HasHeaderRecord = headerRecord;
                var records = csv.GetRecords<dynamic>();

                return records;
            }
        }

        public IEnumerable<dynamic> SortRecords(IEnumerable<object> records, int sortRow, Type type)
        {
            var list = records.ToList();

            foreach (var o in list)
            {
                
            }

            return records;
        }

        public void WriteRecords(IEnumerable<object> result, string outputPath)
        {

        }
    }
}