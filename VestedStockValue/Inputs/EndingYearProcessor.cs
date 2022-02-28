using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VestedStockValue.Inputs
{
    internal class EndingYearProcessor : IInputProcessor
    {
        public void GetUserInput(Input input)
        {
            var iteration = 0;
            do
            {
                if (++iteration > 1)
                    Console.WriteLine(InputValidationMessage.GetValidationMessage(InputPropertyName.EndingYear));
                GetEndingYear(input);
            } while (!InputValidator.ValidateGrantEndYear(input.EndingYear.Year, input.BeginningYear.Year));
        }

        private void GetEndingYear(Input input)
        {
            Console.WriteLine(InputMessage.EndingYear);
            var year = Console.ReadLine();
            input.EndingYear = year.GetYear();
        }
    }
}
