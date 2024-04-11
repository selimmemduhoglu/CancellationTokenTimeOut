using System.Data.SqlClient;

namespace CancellationTokenTimeOut;

public class SqlServerManager
{
    public async Task Connect(string connectionString, CancellationToken cancellationToken)
    {
        SqlConnection connection = new(connectionString);
        await connection.OpenAsync(cancellationToken);
    }
}
