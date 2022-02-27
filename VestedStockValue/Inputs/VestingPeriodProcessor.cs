namespace VestedStockValue.Inputs
{
    internal class VestingPeriodProcessor : IInputProcessor
    {
        public void GetUserInput(Input input)
        {
            var iteration = 0;
            do
            {
                if (++iteration > 1)
                    Console.WriteLine(InputValidationMessage.GetValidationMessage(InputPropertyName.VestingPeriod));
                GetInitialGrantAmount(input);
            } while (!InputValidator.ValidateVestingPeriod(input.VestingPeriod));
        }

        private void GetInitialGrantAmount(Input input)
        {
            Console.WriteLine(InputMessage.VestingPeriod);
            var vestingPeriod = Console.ReadLine();
            input.VestingPeriod = vestingPeriod.GetInt();
        }
    }
}
