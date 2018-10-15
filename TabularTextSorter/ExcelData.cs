using CsvHelper.Configuration;

namespace TabularTextSorter
{
    public class ExcelData
    {
        public string Entity { get; set; }
        public string Counterparty { get; set; }
        public string Book { get; set; }
        public string Underlying { get; set; }
        public string OptionType { get; set; }
        public string Currency { get; set; }
        public string TradeDate { get; set; }
        public string Option { get; set; }
        public int Volume { get; set; }
        public string BuySell { get; set; }
        public float SpotPrice { get; set; }
        public float Strike { get; set; }
        public string CallPut { get; set; }
        public string Maturity { get; set; }
        public int Volatility { get; set; }
        public float TradePrice { get; set; }
        public int Quantity { get; set; }
    }

    public sealed class ExcelDataMap : ClassMap<ExcelData>
    {
        public ExcelDataMap()
        {
            Map(m => m.Entity);
            Map(m => m.Counterparty);
            Map(m => m.Book);
            Map(m => m.Underlying);
            Map(m => m.OptionType).Name("Option Type");
            Map(m => m.Currency);
            Map(m => m.TradeDate).Name("Trade Date");
            Map(m => m.Option);
            Map(m => m.Volume);
            Map(m => m.BuySell).Name("Buy / Sell");
            Map(m => m.SpotPrice).Name("Spot Price");
            Map(m => m.Strike);
            Map(m => m.CallPut).Name("Call / Put");
            Map(m => m.Maturity);
            Map(m => m.Volatility);
            Map(m => m.TradePrice).Name("Trade Price (per option)");
            Map(m => m.Quantity).Name("Buy/Sell Quantity");
        }
    }
}