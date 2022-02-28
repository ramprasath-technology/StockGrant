try
{
    Console.WriteLine(InputMessage.WelcomeMessage);
    var input = new Input();
    var inputProperties = typeof(Input).GetProperties();
    foreach (var property in inputProperties)
    {
        var currentPropertyProcessor = GetProcessor(property.Name);
        currentPropertyProcessor.GetUserInput(input);
    }    
    Console.WriteLine(InputMessage.ComputationInProgressMessage);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
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
        case InputPropertyName.ExpectedAnnualizedPriceGrowth:
            return new ExpectedAnnualizedPriceGrowth();
        default:
            throw new NotImplementedException();
    }
}




