using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestedStockValue.Inputs
{
    internal class ExpectedAnnualGrantChangeProcessor : IInputProcessor
    {
        public void GetUserInput(Input input)
        {
            var iteration = 0;
            do
            {
                if (++iteration > 1)
                    Console.WriteLine(InputValidationMessage.GetValidationMessage(InputPropertyName.ExpectedAnnualGrantChange));
                GetExpectedAnnualGrantChange(input);
            } while (!InputValidator.ValidateExpectedAnnualGrantChange(input.ExpectedAnnualGrantChange));
        }

        private void GetExpectedAnnualGrantChange(Input input)
        {
            Console.WriteLine(InputMessage.ExpectedAnnualGrantChange);
            var grantChange = Console.ReadLine();
            input.ExpectedAnnualGrantChange = grantChange.GetDecimal();
        }
    }
}
