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

        public Task<bool> CreateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCliente(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cliente>> GetClienteList()
        {
            var clienteList = await _dbService.GetAll<Cliente>("SELECT * FROM clientes", new { });
            return clienteList;
        }

        public Task<Cliente> UpdateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
