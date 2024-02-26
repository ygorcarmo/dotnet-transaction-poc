using donet_transaction_poc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace donet_transaction_poc.Controllers
{
    [ApiController]
    [Route("/clientes/{id}")]
    public class RinhaController : ControllerBase
    {
        [HttpPost("transacoes")]
        public IActionResult Create(TransactionRequest transactionRequest)
        {
            var test = new TransactionResponse();
            HttpStatusCode codeNotDefined = (HttpStatusCode)422;
            return Content("message to be sent in response body");
        }


        [HttpGet("extrato")]
        public ActionResult<Statement> Get()
        {
            var test = new Statement();
            return test;
        }
    }
}
