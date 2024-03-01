using donet_transaction_poc.Models;

namespace donet_transaction_poc.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IDbService _dbService;

        public ClienteService(IDbService dbService)
        {
            _dbService = dbService;
        }

        //  How am I going to handle the errors?

        public async Task<int> CreateCliente(Cliente cliente)
        {
            var affectedRows = await _dbService.EditData("INSERT INTO clientes (nome, limite) VALUES (@Nome, @Limite);", cliente);
            return affectedRows;
        }

        public async Task<int> DeleteCliente(int id)
        {
            var affectedRows = await _dbService.EditData("DELETE FROM clientes WHERE id=@id;", new { id });
            return affectedRows;
        }

        public async Task<Cliente> GetCliente(int id)
        {
            var cliente = await _dbService.GetAsync<Cliente>("SELECT * FROM clientes WHERE id=1;", new { id });
            return cliente;
        }

        public async Task<List<Cliente>> GetClienteList()
        {
            var clienteList = await _dbService.GetAll<Cliente>("SELECT * FROM clientes;", new { });
            return clienteList;
        }

        public async Task<int> UpdateCliente(Cliente cliente)
        {
            var affectedRows = await _dbService.EditData("UPDATE clientes SET nome=@Nome, limite=@Limite WHERE id=@Id;", cliente);
            return affectedRows;
        }
    }
}
