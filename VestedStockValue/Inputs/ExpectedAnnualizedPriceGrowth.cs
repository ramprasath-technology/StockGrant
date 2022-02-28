using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestedStockValue.Inputs
{
    internal class ExpectedAnnualizedPriceGrowth : IInputProcessor
    {
        public void GetUserInput(Input input)
        {
            var iteration = 0;
            do
            {
                if (++iteration > 1)
                    Console.WriteLine(InputValidationMessage.GetValidationMessage(InputPropertyName.ExpectedAnnualizedPriceChange));
                GetExpectedAnnualizedPriceGrowth(input);
            } while (!InputValidator.ValidateExpectedAnnualizedPriceGrowth(input.ExpectedAnnualizedPriceChange));
        }

        private void GetExpectedAnnualizedPriceGrowth(Input input)
        {
            Console.WriteLine(InputMessage.ExpectedPriceGrowth);
            var priceGrowth = Console.ReadLine();
            input.ExpectedAnnualizedPriceChange = priceGrowth.GetDecimal();
        }
    }
}
