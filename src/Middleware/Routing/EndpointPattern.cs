using System.Text.RegularExpressions;

public class EndpointPattern(Func<Type, string?> source, string tag, Regex pattern)
{
    public Func<Type, string?> Source { get; } = source;
    public Regex Pattern { get; } = pattern;
    public string Tag { get; } = tag;

    public bool IsMatch(Type type)
    {
        var value = Source(type);
        if (value == null)
        {
            return false;
        }

        return Pattern.IsMatch(value);
    }

    public string Format(Type type)
    {
        var value = Source(type) ?? "";

        Pattern.Match(value).Groups.TryGetValue(Tag, out var group);
        return group?.Value ?? "";
    }
}