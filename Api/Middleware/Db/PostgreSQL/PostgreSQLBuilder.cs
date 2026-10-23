using Microsoft.EntityFrameworkCore;

namespace Self.Api.Middleware.Db.PostgreSQL;
/// <summary>
/// 
/// </summary>
public class PostgreSQLBuilder : DbBuilder
{
    public override void Primary(DbContextOptionsBuilder options, string cs)
    {
        options.UseNpgsql(cs, npgsqlOptions => {
            npgsqlOptions.EnableRetryOnFailure();
        });
    }

    public override void Replica(DbContextOptionsBuilder options, string cs)
    {
        options.UseNpgsql(cs, npgsqlOptions => {
            npgsqlOptions.EnableRetryOnFailure();
        });
    }
}