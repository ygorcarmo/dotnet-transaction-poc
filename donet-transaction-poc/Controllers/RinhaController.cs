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

        public class Respose
        {
            public string message { get; set; }
        }
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

                var currentSaldo = await _saldoService.GetSaldo(id);

                if (transactionRequest.Descricao.Length > 10 || transactionRequest.Descricao.Length < 1)
                    return BadRequest(new Respose { message = "A descricao nao pode ser nula ou com mais de 10 characters." });


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

                    currentSaldo.Valor += transacao.Valor;
                    await _saldoService.UpdateSaldo(currentSaldo);

                    response.Saldo = currentSaldo.Valor;
                    response.Limite = cliente.Limite;

                    return Ok(response);
                }

                if (transactionRequest.Tipo == "d")
                {
                    var totalCredit = currentSaldo.Valor + cliente.Limite;

                    if (transactionRequest.Valor > totalCredit)
                        return UnprocessableEntity(new Respose { message = "Saldo Insuficiente" });

                    var transacao = new Transacao
                    {
                        Cliente_Id = id,
                        Descricao = transactionRequest.Descricao,
                        Tipo = transactionRequest.Tipo,
                        Valor = transactionRequest.Valor
                    };
                    await _transacaoService.CreateTransacao(transacao);

                    currentSaldo.Valor -= transacao.Valor;
                    await _saldoService.UpdateSaldo(currentSaldo);

                    response.Saldo = currentSaldo.Valor;
                    response.Limite = cliente.Limite;

                    return Ok(response);
                }

                return BadRequest(new Respose { message = "Tipo the transacao nao supportada." });

            }
            catch (Exception ex)
            {
                return BadRequest(new Respose { message = ex.Message });
            }
        }


        [HttpGet("extrato")]
        public async Task<ActionResult<Extrato>> Get(int id)
        {
            try
            {

                var cliente = await _clienteService.GetCliente(id);
                if (cliente is null)
                    return NotFound(new Respose { message = "Cliente nao encontrado" });

                var currentSaldo = await _saldoService.GetSaldo(id);

                var transacoes = await _transacaoService.GetTransacoesByClienteId(id);

                var extrato = new Extrato
                {
                    Saldo = new SaldoExtratual
                    {
                        Total = currentSaldo.Valor,
                        DataExtato = DateTime.UtcNow.ToString(),
                        Limite = cliente.Limite

                    },
                    UltimasTransacoes = transacoes

                };
                return Ok(extrato);
            }
            catch (Exception ex)
            {
                return BadRequest(new Respose { message = ex.Message });
            }
        }
    }
}
