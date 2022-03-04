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
                GetInitialStockPrice(input);
            } while (!InputValidator.ValidateInitialStockPrice(input.InitialStockPrice));
        }

        private void GetInitialStockPrice(Input input)
        {
            Console.WriteLine(InputMessage.InitialStockPrice);
            var amount = Console.ReadLine();
            input.InitialStockPrice = amount.GetDecimal();
        }
    }
}
