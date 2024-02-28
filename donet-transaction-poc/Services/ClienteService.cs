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

        public async Task<bool> CreateCliente(Cliente cliente)
        {
            try
            {
                await _dbService.EditData("INSERT INTO clientes (nome, limite) VALUES (@Nome, @Limite);", cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCliente(int id)
        {
            await _dbService.EditData("DELETE FROM clientes WHERE id=@id", new { id });
            return true;
        }

        public async Task<Cliente> GetCliente(int id)
        {
            var cliente = await _dbService.GetAsync<Cliente>("SELECT * FROM clientes WHERE id=@id", new { id });
            return cliente;
        }

        public async Task<List<Cliente>> GetClienteList()
        {
            var clienteList = await _dbService.GetAll<Cliente>("SELECT * FROM clientes", new { });
            return clienteList;
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            try
            {

                await _dbService.EditData("UPDATE clientes SET nome=@Nome, limite=@Limite WHERE id=@Id", cliente);
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
