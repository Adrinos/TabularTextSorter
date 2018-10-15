using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using CsvHelper;

namespace TabularTextSorter
{
    public class CsvHelper
    {
        public List<ExcelData> ParseData(string file, string delimiter, bool headerRecord)
        {
            var records = ExtractCsvData(file, delimiter, headerRecord);

            return records;
        }

        private List<ExcelData> ExtractCsvData(string file, string delimiter, bool headerRecord)
        {
            List<ExcelData> csvData;

            using (var fileStream = new FileStream(file, FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                reader.DiscardBufferedData();

                csvData = GetRecords(reader, delimiter, headerRecord);
            }

            return csvData;
        }

        private List<ExcelData> GetRecords(TextReader reader, string delimiter, bool headerRecord)
        {
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = delimiter;
                csv.Configuration.HasHeaderRecord = headerRecord;
                csv.Configuration.RegisterClassMap<ExcelDataMap>();
                var records = csv.GetRecords<ExcelData>().ToList();

                return records;
            }
        }

        public List<ExcelData> SortRecords(List<ExcelData> records, int sortRow, Type type)
        {
            var record = records[0];
            var properties = record.GetType().GetProperties();
            var property = properties[sortRow].Name;

            records = records.AsQueryable().OrderBy($"{property} ASC").ToList();

            return records;
        }


        public void WriteRecords(List<ExcelData> sortedRecords, string outputPath)
        {
            using (var streamWriter = File.CreateText(outputPath))
            using (var csv = new CsvWriter(streamWriter))
            {
                csv.WriteRecords(sortedRecords);
            }
        }
    }
}