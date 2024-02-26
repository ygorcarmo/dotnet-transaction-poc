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
            var transacao = new Transacao
            {
                Cliente_Id = 1,
                Descricao = "adasda",
                Id = 1,
                Realizada_Em = "asdasdas",
                Tipo = "d",
                Valor = 12314124
            };

            var test = new Extrato
            {
                Saldo =
                {
                    Total = -9098,
                    Data_Extato ="2024-01-17T02:34:41.217753Z",
                    Limite = 1000000

                },
                Ultimas_Transacoes = []

            };
            return Ok(test);
        }
    }
}
