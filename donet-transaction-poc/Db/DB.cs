using donet_transaction_poc.Models;
using Npgsql;

namespace donet_transaction_poc.Db
{
    public class DB
    {
        public async static IAsyncEnumerable<Cliente> GetCliente()
        {
            var connectionString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";
            await using var dataSource = NpgsqlDataSource.Create(connectionString);

            await using (var cmd = dataSource.CreateCommand("SELECT valor FROM saldos WHERE cliente_id=1"))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }
            yield return new Cliente();
        }
    }
}
