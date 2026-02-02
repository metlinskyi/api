namespace Api.Services.Web;
public record SettingsRequest([FromRoute] string Key, string Value) : IRequest<SettingsResponse>;