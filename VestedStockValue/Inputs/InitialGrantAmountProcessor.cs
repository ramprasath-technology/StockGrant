namespace VestedStockValue.Inputs
{
    internal class InitialGrantAmountProcessor : IInputProcessor
    {
        public void GetUserInput(Input input)
        {
            var iteration = 0;
            do
            {
                if (++iteration > 1)
                    Console.WriteLine(InputValidationMessage.GetValidationMessage(InputPropertyName.InitialGrantAmount));
                GetInitialGrantAmount(input);

            } while (!InputValidator.ValidateInitialGrantAmount(input.InitialGrantAmount));
        }

        private void GetInitialGrantAmount(Input input)
        {
            Console.WriteLine(InputMessage.InitialGrantAmount);
            var amount = Console.ReadLine();
            input.InitialGrantAmount = amount.GetDecimal();
        }
    }
}
