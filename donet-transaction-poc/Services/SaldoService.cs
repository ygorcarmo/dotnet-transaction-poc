using donet_transaction_poc.Models;

namespace donet_transaction_poc.Services
{
    public class SaldoService
    {
        private readonly IDbService _dbService;

        public SaldoService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateSaldo(Saldo saldo)
        {
            await _dbService.EditData("INSERT INTO saldos (cliente_id, valor) VALUES (@Cliente_Id, @Valor)", saldo);
            return true;
        }

        public async Task<Saldo> GetSaldo(int clienteId)
        {
            var saldo = await _dbService.GetAsync<Saldo>("SELECT * FROM saldos WHERE cliente_id=@clienteId", new { clienteId });
            return saldo;
        }

        public async Task<List<Saldo>> GetSaldoList()
        {
            var saldos = await _dbService.GetAll<Saldo>("SELECT * FROM saldos", new { });
            return saldos;
        }
        public async Task<Saldo> UpdateSaldo(Saldo saldo)
        {
            await _dbService.EditData("UPDATE saldos SET valor=@Valor WHERE id=@Id AND cliente_id=@Cliente_Id", saldo);
            return saldo;
        }
        public async Task<bool> DeleteSaldo(int id)
        {
            await _dbService.EditData("DELETE FROM saldos WHERE id=@id", new { id });
            return true;
        }
    }
}
