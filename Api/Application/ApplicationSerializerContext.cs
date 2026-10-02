using System.Text.Json.Serialization;

namespace Api.Application;

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class ApplicationSerializerContext : JsonSerializerContext
{

}
