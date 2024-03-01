using donet_transaction_poc.Models;
using donet_transaction_poc.Services;
using Microsoft.AspNetCore.Mvc;

namespace donet_transaction_poc.Controllers
{
    [ApiController]
    [Route("/clientes/{id}")]
    public class RinhaController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly TransacaoService _transacaoService;
        private readonly SaldoService _saldoService;
        public RinhaController(IClienteService clienteService, TransacaoService transacaoService, SaldoService saldoService)
        {
            _clienteService = clienteService;
            _transacaoService = transacaoService;
            _saldoService = saldoService;
        }
        [HttpPost("transacoes")]
        public async Task<IActionResult> Create(TransactionRequest transactionRequest, int id)
        {
            try
            {
                var response = new TransactionResponse { };

                var cliente = await _clienteService.GetCliente(id);
                if (cliente is null)
                    return NotFound();

                if (transactionRequest.Tipo == "c")
                {
                    var transacao = new Transacao
                    {
                        Cliente_Id = id,
                        Descricao = transactionRequest.Descricao,
                        Tipo = transactionRequest.Tipo,
                        Valor = transactionRequest.Valor
                    };
                    await _transacaoService.CreateTransacao(transacao);

                    var currentSaldo = await _saldoService.GetSaldo(id);
                    currentSaldo.Valor += transacao.Valor;
                    await _saldoService.UpdateSaldo(currentSaldo);

                    response.Saldo = currentSaldo.Valor;
                    response.Limite = cliente.Limite;

                    return Ok(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet("extrato")]
        public ActionResult<Extrato> Get()
        {
            var test = new Extrato
            {
                Saldo = new SaldoExtratual
                {
                    Total = -9098,
                    DataExtato = "2024-01-17T02:34:41.217753Z",
                    Limite = 1000000

                },
                UltimasTransacoes = [
                    new Transacao {
                        Cliente_Id = 1,
                        Descricao = "adasda",
                        Id = 1,
                        RealizadaEm = "asdasdas",
                        Tipo = "d",
                        Valor = 12314124
                    },
                    new Transacao { }
                ]

            };
            return Ok(test);
        }
    }
}
