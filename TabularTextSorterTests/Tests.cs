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
                "C:\\Users\\Gareth\\source\\repos\\TabularTextSorter\\TabularTextSorter\\bin\\Debug\\Test1-sorted-Col0.csv";
            var outputPath =
                "C:\\Users\\Gareth\\source\\repos\\TabularTextSorter\\TabularTextSorter\\bin\\Debug\\Test1.csv";
            var delimiter = ",";
            var headerRecord = true;
            var sortRow = 0;
            var type = typeof(string);

            var records = sut.GetRecords(inputPath, delimiter, headerRecord);

            var sortedRecords = sut.SortRecords(records, sortRow, type);

            sut.WriteRecords(sortedRecords, outputPath);
        }
    }
}