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

        public static bool ValidateInitialPrice(decimal priceDuringInitialGrant)
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

        public static bool ValidateGrantEndYear(int endYear)
        {
            if (endYear < DateTime.Now.Year)
                return false;
            return true;
        }

        public static bool ValidateExpectedAnnualGrantIncrease(decimal annualGrantChange)
        {
            return true;
        }
    }
}
