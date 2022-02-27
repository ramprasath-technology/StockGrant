using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestedStockValue.Messages
{
    internal static class InputMessage
    {
        internal const string WelcomeMessage = "Let's find out what your stock grants would be worth in the future. " + 
            "Please answer the following questions";
        internal const string BeginningYear = "In which year did you receive your first grant";
        internal const string InitialGrantAmount = "What was the grant amount in your first year?";
        internal const string InitialStockPrice = "What was the stock price during the first year of grant?";
        internal const string VestingPeriod = "How long does it take for the grant amount to vest?";
        internal const string EndingYear = "Till what year do you expect to receive grants?";
        internal const string ExpectedAnnualGrantChange = "Do you expect any annual change in the value of the grant? If so enter the percentage change. " +
            "If not, enter 0";
        internal const string ExpectedPriceGrowth = "How much annualized change do you expect in the stock price? " +
            "Though this is only an assumption, annualized EPS change is a good gauge to determine the direction of the stock price";
        internal const string ComputationInProgressMessage = "Crunching the numbers...";
    }
}
