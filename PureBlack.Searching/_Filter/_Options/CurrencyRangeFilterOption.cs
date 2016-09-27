namespace PureBlack.Searching
{
    public class CurrencyRangeFilterOption : FilterOptionBase
    {
        public double Start { get; set; }

        public double End { get; set; }

        public string NumberFormat { get; set; } = "C0";

        public override string DisplayText => $"{Start.ToString(NumberFormat)} - {End.ToString(NumberFormat)}";
    }
}
