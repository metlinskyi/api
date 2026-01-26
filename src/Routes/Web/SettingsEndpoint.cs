using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Routes.Web;
/// <summary>
/// Endpoint to get settings by key.
/// </summary>
public class SettingsEndpoint : IEndpoint<string, SettingsResponse>, IHttpGet
{
    private readonly DataContext db;
    private readonly IMapper mapper;

    public SettingsEndpoint(DataContext db, IMapper mapper)
    {
        this.db = db;
        this.mapper = mapper;
    }

    public async Task<SettingsResponse> Handler([FromRoute] string key)
    {
        var settings = await db.Settings.Where(s => s.Key == key).ToDictionaryAsync(s => s.Key, s => s.Value);
        if (settings == null || settings.Count == 0)
            throw new NotFoundException("Settings not found");

        return mapper.Map<SettingsResponse>(settings);
    }
}