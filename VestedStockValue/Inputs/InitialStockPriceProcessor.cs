namespace VestedStockValue.Inputs
{
    internal class InitialStockPriceProcessor : IInputProcessor
    {
        public void GetUserInput(Input input)
        {
            var iteration = 0;
            do
            {
                if (++iteration > 1)
                    Console.WriteLine(InputValidationMessage.GetValidationMessage(InputPropertyName.InitialStockPrice));
                GetInitialGrantAmount(input);
            } while (!InputValidator.ValidateInitialGrantAmount(input.InitialStockPrice));
        }

        private void GetInitialGrantAmount(Input input)
        {
            Console.WriteLine(InputMessage.InitialGrantAmount);
            var amount = Console.ReadLine();
            input.InitialGrantAmount = amount.GetDecimal();
        }
    }
}
