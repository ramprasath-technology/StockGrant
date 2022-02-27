namespace Model
{
    public class Input
    {
        public DateTime BeginningYear { get; set; }
        public decimal InitialGrantAmount { get; set; }
        public decimal InitialStockPrice { get; set; }
        public int VestingPeriod { get; set; }
        public decimal ExpectedAnnualizedPriceGrowth { get; set; }
        public DateTime EndingYear { get; set; }
        public decimal ExpectedAnnualGrantChange { get; set; }
    }
}