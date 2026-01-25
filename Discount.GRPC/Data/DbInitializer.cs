using Dapper;
using Discount.GRPC.Data;

public sealed class DbInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DbInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public void Initialize()
    {
        using var connection = _connectionFactory.CreateConnection();

        connection.Execute("""
                               CREATE TABLE IF NOT EXISTS Coupons (
                                   Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                   ProductId TEXT NOT NULL UNIQUE,
                                   Description TEXT,
                                   Percentage INTEGER NOT NULL
                               );
                           """);
    }
}