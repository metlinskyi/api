using Data.Access;

namespace Api.Routes.Web;
public class SettingsEndpoint : IEndpoint<SettingsResponse>, IHttpGet
{
    private readonly DataContext db;

    public SettingsEndpoint(DataContext db)
    {
        this.db = db;
    }

    public async Task<SettingsResponse> Handler()
    {
        return new SettingsResponse();
    }
}