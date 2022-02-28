using Model.Constants;

namespace Validator.VestedStockValue
{
    public static class InputValidationMessage
    {
        public static string GetValidationMessage(string propertyName)
        {
            switch (propertyName)
            {
                case InputPropertyName.BeginningYear:
                    return $"{ErrorPrefix.GetRandomErrorPrefix()} The year should be after 1900 but before {DateTime.Now.AddYears(1).Year} ";
                case InputPropertyName.InitialGrantAmount:
                    return $"{ErrorPrefix.GetRandomErrorPrefix()} The inital grant amount should be greater than 0";
                case InputPropertyName.InitialStockPrice:
                    return $"{ErrorPrefix.GetRandomErrorPrefix()} The stock price should be greater than 0";
                case InputPropertyName.VestingPeriod:
                    return $"{ErrorPrefix.GetRandomErrorPrefix()} The vesting period should be a whole number, greater than 0";
                case InputPropertyName.EndingYear:
                    return $"{ErrorPrefix.GetRandomErrorPrefix()} The year should be greater than the beginning year";
                case InputPropertyName.ExpectedAnnualGrantChange:
                    return $"{ErrorPrefix.GetRandomErrorPrefix()} The amount should be a valid decimal and can be a negative or positive number";
                case InputPropertyName.ExpectedAnnualizedPriceChange:
                    return $"{ErrorPrefix.GetRandomErrorPrefix()} The amount should be a valid decimal and can be a negative or positive number";
                default:
                    return $"{ErrorPrefix.GetRandomErrorPrefix()} Enter a valid value";
            }
        }
    }
}
