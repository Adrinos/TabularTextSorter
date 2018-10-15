using System.Linq;
using Shouldly;
using TabularTextSorter;
using Xunit;

namespace TabularTextSorterTests
{
    public class Tests
    {
        [Fact]
        public void Read()
        {
            var sut = new CsvHelper();
            var inputPath =
                "Data/Test1-Unsorted.csv";
            var outputPath =
                "Data/TestFileOutput.csv";
            var delimiter = ",";
            var headerRecord = true;
            var sortRow = 8;
            var type = typeof(string);

            var records = sut.ParseData(inputPath, delimiter, headerRecord).ToList();

            var sortedRecords = sut.SortRecords(records, sortRow, type);

            sut.WriteRecords(sortedRecords, outputPath);

        }
    }
}