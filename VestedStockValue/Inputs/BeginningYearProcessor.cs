namespace VestedStockValue.Inputs
{
    internal class BeginningYearProcessor : IInputProcessor
    {
        public void GetUserInput(Input input)
        {
            var iteration = 0;
            do
            {
                if (++iteration > 1)
                    Console.WriteLine(InputValidationMessage.GetValidationMessage(InputPropertyName.BeginningYear));
                GetGrantBeginingYear(input);
            } while (!InputValidator.ValidateGrantBeginningYear(input.BeginningYear.Year));
        }

        private void GetGrantBeginingYear(Input input)
        {
            Console.WriteLine(InputMessage.BeginningYear);
            var year = Console.ReadLine();
            input.BeginningYear = year.GetYear();
        }
    }
}
