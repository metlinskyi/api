namespace Api.Routes.Web;
/// <summary>
/// Endpoint to get settings by key.
/// </summary>
public class SettingsEndpoint : IEndpoint<string, SettingsResponse>, IHttpGet
{
    private readonly DataContext db;

    public SettingsEndpoint(DataContext db)
    {
        this.db = db;
    }

    public async Task<SettingsResponse> Handler([FromRoute] string key)
    {
        return new SettingsResponse();
    }
}