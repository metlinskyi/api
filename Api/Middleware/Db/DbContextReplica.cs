using Microsoft.EntityFrameworkCore;
using Self.Data.Access;

namespace Self.Api.Middleware.Db;
/// <summary>
///  
/// </summary>
public sealed class DbContextReplica(
    DbContextOptions<DataContext> options)
    : DataContext(options);