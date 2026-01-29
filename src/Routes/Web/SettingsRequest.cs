namespace Api.Routes.Web;
public record SettingsRequest([FromRoute] string Key, string Value) : IRequest<SettingsResponse>;