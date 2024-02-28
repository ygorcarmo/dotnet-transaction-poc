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
        public RinhaController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpPost("transacoes")]
        public async Task<IActionResult> Create(TransactionRequest transactionRequest)
        {

            //var test = new TransactionResponse { Limite = 100000, Saldo = -9098 };
            //return Ok(test);

            var clientes = await _clienteService.GetClienteList();
            return Ok(clientes);
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
