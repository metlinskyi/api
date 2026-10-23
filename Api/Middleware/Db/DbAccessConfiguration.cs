namespace Self.Api.Middleware.Db;
/// <summary>
/// 
/// </summary>
internal static class DbAccessConfiguration
{
    private static DbAccessOptions Options = new();
    public static void ConfigureDbAccessOptions<TBuilder>(
        this IServiceCollection services, 
        Action<DbAccessOptions> settings)
        where TBuilder : DbBuilder, new()
    {
        settings.Invoke(Options);

        TBuilder builder = new();

        services.AddDbContext<DbContextPrimary>(options => 
        {
            builder.Primary(options, Options.PrimaryDbConnection);
        }); 

        services.AddDbContext<DbContextReplica>(options => 
        {
            builder.Replica(options, Options.ReplicaDbConnection);
        }); 
    }
}