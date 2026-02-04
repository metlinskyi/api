namespace Api.Services.Bot;

public class BotService : IBotService
{
    public async Task<IDictionary<string, string>> GetSettings(string name)
    {
        return new Dictionary<string, string>
        {
            { "BotName", "ApiBot" },
            { "Version", "1.0.0" }
        };
    }   // Bot service implementation
}