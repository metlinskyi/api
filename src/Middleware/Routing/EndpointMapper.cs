using System.Text.RegularExpressions;

public class EndpointMapper
{
    protected List<EndpointPattern> Patterns { get; private set; } = new List<EndpointPattern>();
    public string UrlPattern { get; set; } = "";
    private ILogger<EndpointMapper> Logger { get; }

    public EndpointMapper(ILogger<EndpointMapper> logger)
    {
        Logger = logger;    
    }

    public void AddPattern(Func<Type, string?> source, string tag, string pattern)
    {
        Patterns.Add(new EndpointPattern(source, tag, new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase)));
    }

    public string BuildPattern(Type type)
    {
        var pattern = UrlPattern;

        foreach (var endpointPattern in Patterns.Where(p => p.IsMatch(type)))
        {
            var value = endpointPattern.Format(type);
            if (value != null)
            {
                var tag = string.Format("{{{0}}}", endpointPattern.Tag);
                pattern = pattern.Replace(tag, value);
            }
        }

        return pattern.ToLower();
    }
}