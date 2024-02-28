using donet_transaction_poc.Models;

namespace donet_transaction_poc.Services
{
    public class TransacaoService
    {
        private readonly IDbService _dbService;
        public TransacaoService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<int> CreateTransacao(Transacao transacao)
        {
            var affectedRows = await _dbService.EditData("INSERT INTO transacoes (cliente_id, valor, tipo, descricao) VALUES (@Cliente_Id, @Valor, @Tipo, @Descricao);", transacao);
            return affectedRows;
        }
        public async Task<Transacao> GetTransacao(int clienteId)
        {
            var transacao = await _dbService.GetAsync<Transacao>("SELECT * FROM transacoes WHERE cliente_id=@clienteId;", new { clienteId });
            return transacao;
        }

        public async Task<List<Transacao>> GetTrasacaoList()
        {
            var transacoes = await _dbService.GetAll<Transacao>("SELECT * FROM transacoes", new { });
            return transacoes;
        }

        public async Task<List<Transacao>> GetTransacoesByClienteId(int clienteId)
        {
            var transacoes = await _dbService.GetAll<Transacao>("SELECT * FROM transacoes WHERE cliente_id=@clienteId ORDER BY realizada_em DESC LIMIT 10;", new { clienteId });
            return transacoes;
        }
        public async Task<int> UpdateTransacao(Transacao transacao)
        {
            var affectedRows = await _dbService.EditData("UPDATE transacoes SET valor=@Valor, tipo=@Tipo, descricao=@Descricao;", transacao);
            return affectedRows;
        }
        public async Task<int> DeleteTransacao(int id)
        {
            var affectedRows = await _dbService.EditData("DELETE * FROM transacoes WHERE id=@id;", new { id });
            return affectedRows;
        }
    }
}
