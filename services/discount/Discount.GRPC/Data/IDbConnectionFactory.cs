using System.Data;

namespace Discount.GRPC.Data;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}