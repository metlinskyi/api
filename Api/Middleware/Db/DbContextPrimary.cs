using Microsoft.EntityFrameworkCore;
using Self.Data.Access;

namespace Self.Api.Middleware.Db;
/// <summary>
///  
/// </summary>
public sealed class DbContextPrimary(
    DbContextOptions<DataContext> options)
    : DataContext(options);