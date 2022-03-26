using Extensions;
using Microsoft.Extensions.DependencyInjection;
using VestedStockValue.Computation;

try
{
    var input = GetUserInput();
    var yearVestedAmountMap = await GetVestedAmount(input);
    PrintVestedAmount(yearVestedAmountMap);
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

static Input GetUserInput()
{
    Console.WriteLine(InputMessage.WelcomeMessage);
    var input = GetInputValues();
    Console.WriteLine(InputMessage.ComputationInProgressMessage);
    return input; ;
}

static async Task<Dictionary<int, Calculator>> GetVestedAmount(Input input)
{
    var serviceProvider = new ServiceCollection()
       .AddSingleton<IVestedStockValueCalculator, VestedStockValueCalculator>()
       .BuildServiceProvider();
    var calculator = serviceProvider.GetService<IVestedStockValueCalculator>();
    var yearVestedAmountMap = await calculator.GetVestedAmount(input);
    return yearVestedAmountMap;
}

static void PrintVestedAmount(Dictionary<int, Calculator> yearVestedAmountMap)
{
    var optimalSpace = "     ";
    Console.WriteLine($"Year{optimalSpace}Count{optimalSpace}Vested Value");
    foreach (var entry in yearVestedAmountMap)
    {
        Console.WriteLine($"{entry.Key}{optimalSpace}{entry.Value.VestedStockCount.RoundDecimal()}{optimalSpace}{entry.Value.VestedValue.RoundDecimal()}");
    }
    Console.WriteLine($"The total vested amount is {yearVestedAmountMap.Values.Sum(x => x.VestedValue).RoundDecimal()}");
}









