
using System.Text.Json.Serialization;
using Api.Routes.Bot;
using Api.Routes.Web;

[
    JsonSerializable(typeof(SettingsRequest)),
    JsonSerializable(typeof(SettingsResponse)),
    JsonSerializable(typeof(ImageOfTheDayRequest)),
    JsonSerializable(typeof(ImageOfTheDayResponse))
]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
