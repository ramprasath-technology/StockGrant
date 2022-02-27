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
        default:
            throw new NotImplementedException();
    }
}




