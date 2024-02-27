using System.Text.Json.Serialization;

namespace donet_transaction_poc.Models
{
    public class Extrato
    {
        public SaldoExtratual Saldo { get; set; }
        [JsonPropertyName("ultimas_transacoes")]
        public List<Transacao> UltimasTransacoes { get; set; }

    }

    public class SaldoExtratual
    {
        public int Total { get; set; }
        [JsonPropertyName("data_extrato")]
        public string DataExtato { get; set; }
        public int Limite { get; set; }
    }


}
