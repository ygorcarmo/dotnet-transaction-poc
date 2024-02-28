using donet_transaction_poc.Models;

namespace donet_transaction_poc.Services
{
    public interface IClienteService
    {
        Task<int> CreateCliente(Cliente cliente);
        Task<List<Cliente>> GetClienteList();
        Task<Cliente> GetCliente(int id);
        Task<int> UpdateCliente(Cliente cliente);
        Task<int> DeleteCliente(int id);
    }
}
