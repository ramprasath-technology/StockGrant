using Microsoft.Extensions.DependencyInjection;
using VestedStockValue.Computation;

try
{
    var serviceProvider = new ServiceCollection()
        .AddSingleton<IVestedStockValueCalculator, VestedStockValueCalculator>()
        .BuildServiceProvider();

    Console.WriteLine(InputMessage.WelcomeMessage);
    var input = GetInputValues();  
    Console.WriteLine(InputMessage.ComputationInProgressMessage);

    var calculator = serviceProvider.GetService<IVestedStockValueCalculator>();
    var vestedValue = await calculator.GetVestedAmount(input);
    Console.WriteLine(vestedValue);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static Input GetInputValues()
{
    var input = new Input();
    var inputProperties = typeof(Input).GetProperties();
    foreach (var property in inputProperties)
    {
        var currentPropertyProcessor = GetProcessor(property.Name);
        currentPropertyProcessor.GetUserInput(input);
    }
    return input;
}

static IInputProcessor GetProcessor(string property)
{
    switch (property)
    {
        case InputPropertyName.BeginningYear:
            return new BeginningYearProcessor();
        case InputPropertyName.InitialGrantAmount:
            return new InitialGrantAmountProcessor();
        case InputPropertyName.InitialStockPrice:
            return new InitialStockPriceProcessor();
        case InputPropertyName.VestingPeriod:
            return new VestingPeriodProcessor();
        case InputPropertyName.EndingYear:
            return new EndingYearProcessor();
        case InputPropertyName.ExpectedAnnualGrantChange:
            return new ExpectedAnnualGrantChangeProcessor();
        case InputPropertyName.ExpectedAnnualizedPriceChange:
            return new ExpectedAnnualizedPriceGrowth();
        default:
            throw new NotImplementedException();
    }
}





