using AutoMapper;

using Microsoft.EntityFrameworkCore;


namespace Api.Services.Web;
/// <summary>
/// Endpoint to get settings by key.
/// Api/Web/Settings/{Key}/?Value={Value}
/// </summary>
public class SettingsHandler : IRequestHandler<SettingsRequest, SettingsResponse>
{
    private readonly DataContext db;
    private readonly IMapper mapper;

    public SettingsHandler(DataContext db, IMapper mapper)
    {
        this.db = db;
        this.mapper = mapper;
    }

    public async Task<SettingsResponse> Handle(SettingsRequest request, CancellationToken cancellationToken)
    {
        var settings = await db.Settings.Where(s => s.Key == request.Key).ToDictionaryAsync(s => s.Key, s => s.Value);
        if (settings == null || settings.Count == 0)
            throw new NotFoundException("Settings not found");

        return mapper.Map<SettingsResponse>(settings);
    }
}