namespace Self.Api.Middleware.Db;

public class DbAccessOptions
{
    public string? PrimaryDbConnection { get; set; }
    public string? ReplicaDbConnection { get; set; }
}