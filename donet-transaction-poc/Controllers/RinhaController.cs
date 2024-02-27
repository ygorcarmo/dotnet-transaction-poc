using donet_transaction_poc.Models;
using Microsoft.AspNetCore.Mvc;

namespace donet_transaction_poc.Controllers
{
    [ApiController]
    [Route("/clientes/{id}")]
    public class RinhaController : ControllerBase
    {
        [HttpPost("transacoes")]
        public IActionResult Create(TransactionRequest transactionRequest)
        {
            var test = new TransactionResponse { Limite = 100000, Saldo = -9098 };
            return Ok(test);
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
