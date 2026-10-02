using System.Text.Json.Serialization;

namespace Self.Api.Auth;

public record User(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(User[]))]
internal partial class AuthSerializerContext : JsonSerializerContext
{

}
