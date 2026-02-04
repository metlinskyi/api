namespace Api.Services.Bot;


public interface IBotService    
{
    public Task<IDictionary<string, string>> GetSettings(string name);
}