using Data.Access;

namespace Api.Routes.Web;
public class SettingsEndpoint : Endpoint<GetRequest, SettingsResponse>
{
    private readonly DataContext db;

    public SettingsEndpoint(DataContext db)
    {
        this.db = db;
    }

    public override async Task<SettingsResponse> HandleAsync(GetRequest request)
    {
        return new SettingsResponse
        {
            SiteName = "Default Site",
            AdminEmail = "  "
        };
    }
}