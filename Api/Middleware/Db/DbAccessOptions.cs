namespace Self.Api.Middleware.Db;

public class DbAccessOptions
{
    public string PrimaryDbConnection { get; set; } = default!;
    public string ReplicaDbConnection { get; set; } = default!; 
}