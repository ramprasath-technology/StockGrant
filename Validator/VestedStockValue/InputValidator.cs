namespace Validator
{
    public static class InputValidator
    {
        public static bool ValidateGrantBeginningYear(int beginYear)
        {
            if (beginYear < 1900 || beginYear > DateTime.Now.Year)
                return false;
            return true; 
        }

        public static bool ValidateInitialGrantAmount(decimal initialGrantAmount)
        {
            if (initialGrantAmount < 0)
                return false;
            return true;
        }

        public static bool ValidateInitialStockPrice(decimal priceDuringInitialGrant)
        {
            if (priceDuringInitialGrant < 0)
                return false;
            return true;
        }

        public static bool ValidateVestingPeriod(int vestingPeriod)
        {
            if (vestingPeriod < 0)
                return false;
            return true;
        }

        public static bool ValidateExpectedAnnualizedPriceGrowth(decimal annualizedPriceGrowth)
        {
            return true;
        }

        public static bool ValidateGrantEndYear(int endYear, int beginYear)
        {
            if (endYear < beginYear)
                return false;
            return true;
        }

        public static bool ValidateExpectedAnnualGrantChange(decimal annualGrantChange)
        {
            return true;
        }
    }
}
