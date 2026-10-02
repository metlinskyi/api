namespace Self.Api.Middleware.Web;

public class WebAccessOptions
{
    public const string ProductionCorsPolicy = "ProductionCorsPolicy";
    public const string DevelopmentCorsPolicy = "DevelopmentCorsPolicy";
    public bool EnabledOpenApi { get; set; }
    public bool IsProduction { get; set; }
    public string CorsPolicy { get; set; } = DevelopmentCorsPolicy;  
 }