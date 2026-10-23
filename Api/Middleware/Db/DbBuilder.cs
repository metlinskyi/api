using Microsoft.EntityFrameworkCore;

namespace Self.Api.Middleware.Db;
/// <summary>
/// 
/// </summary>
public abstract class DbBuilder
{
    public abstract void Primary(DbContextOptionsBuilder options, string cs);
    public abstract void Replica(DbContextOptionsBuilder options, string cs);
}