using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using Newtonsoft.Json;

namespace TabularTextSorter
{
    public class CsvHelper : IEquatable<object>
    {

        public IEnumerable<Dictionary<string, object>> ParseData(string file, string delimiter, bool headerRecord)
        {
            var records = ExtractCsvData(file, delimiter, headerRecord);

            return records;
        }

        private List<Dictionary<string, object>> ExtractCsvData(string file, string delimiter, bool headerRecord)
        {
            List<dynamic> csvData;

            using (var fileStream = new FileStream(file, FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                reader.DiscardBufferedData();

                csvData = GetRecords(reader, delimiter, headerRecord);
            }

            var json = JsonConvert.SerializeObject(csvData);

            var deserialised = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

            return deserialised;
        }

        //private Dictionary<string, object> BuildRow(Dictionary<string, object> record)
        //{
        //    var row = new Dictionary<string, object>();

        //    foreach (var pair in record)
        //    {
        //        row.Add(pair.Key, pair.Value);
        //    }

        //    return row;
        //}

        private List<dynamic> GetRecords(TextReader reader, string delimiter, bool headerRecord)
        {
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = delimiter;
                csv.Configuration.HasHeaderRecord = headerRecord;
                var records = csv.GetRecords<dynamic>().ToList();

                return records;
            }
        }

        public List<Dictionary<string, object>> SortRecords(List<Dictionary<string, object>> records, int sortRow, Type type)
        {
            var test = records[sortRow];
            var sort = test.ElementAt(sortRow);
            var orderKey = sort.Key;

            var ordered = new List<SortedDictionary<string, object>>();

            var orderedRecords = records.OrderBy(x => x[orderKey])
                .ThenByDescending(x => x.Values)
                .ToList();

            var prdr = from element in records
                orderby element.Keys
                select element;

            var sorter = records.OrderBy(x => x.ContainsKey(orderKey) ? x[orderKey] : string.Empty);

            for (var recordIndex = 0; recordIndex < records.Count; recordIndex++)
            {
                var t = records[recordIndex];
                var t2 = records[recordIndex + 1];


                //if (records[recordIndex].Values)
                //{

                //}
            }

            var order = records.OrderByDescending(x => x.Values).ToList();

            var sorted = records.OrderBy(x => x.Values);



            return orderedRecords;
        }

        public void WriteRecords(List<object> result, string outputPath)
        {

        }

   //     public override bool Equals(object compare)
       // {
            
        //}

        public override int GetHashCode()
        {
            return 2;
        }
    }
}