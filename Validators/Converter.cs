namespace TypeConverter
{
    public static class Converter
    {
        public static DateTime GetYear(this string year)
        {
            if (int.TryParse(year, out int correctYear))
                return new DateTime(correctYear, 01, 01);
            else
                throw new ArgumentNullException("Enter a valid year", new Exception());
        }

        public static decimal GetDecimal(this string amount)
        {
            if (decimal.TryParse(amount, out decimal correctAmount))
                return correctAmount;
            else
                throw new ArgumentNullException("Enter a valid decimal");
        }

        public static int GetInt(this string integer)
        {
            if (int.TryParse(integer, out int correctInteger))
                return correctInteger;
            else
                throw new ArgumentNullException("Enter a valid integer");
        }
    }
}