using Microsoft.EntityFrameworkCore;
using Self.Data.Access;

namespace Self.Api.Middleware.Db;

internal static class DbAccessConfiguration
{
    private static DbAccessOptions Options = new DbAccessOptions();
    public static void ConfigureDbAccessOptions(this IServiceCollection services, Action<DbAccessOptions> options)
    {
        options.Invoke(Options);

       services.AddDbContext<DataContext>(options => 
       {
            options.UseNpgsql(Options.PrimaryDbConnection, npgsqlOptions => {
                npgsqlOptions.EnableRetryOnFailure();
            });
        }); 
    }
}