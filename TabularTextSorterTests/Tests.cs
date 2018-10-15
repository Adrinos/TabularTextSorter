using System.Linq;
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
                "Data/TestFile.csv";
            var outputPath =
                "Data/TestFileOutput.csv";
            var delimiter = ",";
            var headerRecord = true;
            var sortRow = 0;
            var type = typeof(string);

            var records = sut.ParseData(inputPath, delimiter, headerRecord).ToList();

            var sortedRecords = sut.SortRecords(records, sortRow, type);

            //sut.WriteRecords(sortedRecords, outputPath);
        }

        [Fact]
        public void Read2()
        {
            var sut = new CsvHelper2();
            var inputPath =
                "Data/TestFile.csv";
            var outputPath =
                "Data/TestFileOutput.csv";
            var delimiter = ",";
            var headerRecord = true;
            var sortRow = 0;
            var type = typeof(string);

            var records = sut.ParseData(inputPath, delimiter, headerRecord).ToList();

            var sortedRecords = sut.SortRecords(records, sortRow, type);

            sut.WriteRecords(sortedRecords, outputPath);
        }
    }
}