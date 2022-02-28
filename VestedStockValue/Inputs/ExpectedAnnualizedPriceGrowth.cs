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
                    Console.WriteLine(InputValidationMessage.GetValidationMessage(InputPropertyName.ExpectedAnnualizedPriceGrowth));
                GetExpectedAnnualizedPriceGrowth(input);
            } while (!InputValidator.ValidateExpectedAnnualizedPriceGrowth(input.ExpectedAnnualizedPriceGrowth));
        }

        private void GetExpectedAnnualizedPriceGrowth(Input input)
        {
            Console.WriteLine(InputMessage.ExpectedPriceGrowth);
            var priceGrowth = Console.ReadLine();
            input.ExpectedAnnualizedPriceGrowth = priceGrowth.GetDecimal();
        }
    }
}
