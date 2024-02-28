using donet_transaction_poc.Models;

namespace donet_transaction_poc.Services
{
    public interface IClienteService
    {
        Task<bool> CreateCliente(Cliente cliente);
        Task<List<Cliente>> GetClienteList();
        Task<Cliente> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(int key);
    }
}
