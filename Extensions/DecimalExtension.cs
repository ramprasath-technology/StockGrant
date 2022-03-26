namespace Extensions
{
    public static class DecimalExtension
    {
        public static decimal RoundDecimal(this decimal value)
        {
            return decimal.Round(value, 2, MidpointRounding.AwayFromZero);
        }

    }
}