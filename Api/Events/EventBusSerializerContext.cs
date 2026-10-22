using System.Text.Json.Serialization;

namespace Self.Api.Events;


public record Event(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Event[]))]
internal partial class EventBusSerializerContext : JsonSerializerContext
{

}
