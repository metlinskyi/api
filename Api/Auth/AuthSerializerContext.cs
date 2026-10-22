using System.Text.Json.Serialization;

namespace Self.Api.Auth;

[JsonSerializable(typeof(LogIn.Request))]
internal partial class AuthSerializerContext : JsonSerializerContext
{

}
