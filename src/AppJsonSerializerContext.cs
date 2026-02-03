
using System.Text.Json.Serialization;
using Api.Services.Images;
using Api.Services.Web;

[
    JsonSerializable(typeof(SettingsRequest)),
    JsonSerializable(typeof(SettingsResponse)),
    JsonSerializable(typeof(ImageOfTheDayRequest)),
    JsonSerializable(typeof(ImageOfTheDayResponse))
]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
