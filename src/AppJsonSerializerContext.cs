
using System.Text.Json.Serialization;
using Api.Services.Images;
using Api.Services.Web;

[
    JsonSerializable(typeof(SettingsRequest)),
    JsonSerializable(typeof(SettingsResponse)),
    JsonSerializable(typeof(ImageOfTheDayRequest)),
    JsonSerializable(typeof(ImageOfTheDayResponse)),
    JsonSerializable(typeof(Dictionary<string, string>)), 
]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
