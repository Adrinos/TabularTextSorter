using System;

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
        public DateTime TradeDate { get; set; }
        public string Option { get; set; }
        public string Volume { get; set; }
        public string BuySell { get; set; }
        public float SpotPrice { get; set; }
        public float Strike { get; set; }
        public string CallPut { get; set; }
        public DateTime Maturity { get; set; }
        public int Volatility { get; set; }
        public float TradePrice { get; set; }
        public int Quantity { get; set; }
    }
}