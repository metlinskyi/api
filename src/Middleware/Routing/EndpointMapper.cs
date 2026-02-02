using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

public class   EndpointMapper
{
    public string[] NamespacePattern { get; set; }
    public string[] ClassnamePattern { get; set; }
    public string UrlPattern { get; set; }


    public void AddNamespacePattern(string pattern, string dotto =  "/")
    {
        // Implementation goes here
    }

        public void AddClassnamePattern(string pattern)
    {
        // Implementation goes here
    }
}