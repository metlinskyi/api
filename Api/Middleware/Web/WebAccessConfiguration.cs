namespace Self.Api.Middleware.Web;
/// <summary>
/// Provides configuration for HTTP access, including CORS policies and OpenAPI settings.
/// </summary>
internal static class WebAccessConfiguration
{
    private static WebAccessOptions Options = new();

    public static void ConfigureWebAccessOptions(this IServiceCollection srvs, Action<WebAccessOptions> options)
    {        
        options.Invoke(Options);

        if (Options.EnabledOpenApi)
        {
            srvs.AddOpenApi();
        }

        if (Options.IsProduction)
        {
            Options.CorsPolicy = WebAccessOptions.ProductionCorsPolicy;
        }
        else
        {
            Options.CorsPolicy = WebAccessOptions.DevelopmentCorsPolicy;
        }

        srvs.AddCors(options =>
        {
            options.AddPolicy(Options.CorsPolicy,
                policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        srvs.AddHttpContextAccessor();
    }

    public static void UseWebAccess(this WebApplication webApp)
    {
        webApp.UseCors(Options.CorsPolicy);
        
        if(Options.EnabledOpenApi)
        {
            webApp.MapOpenApi();
        }
    }
}