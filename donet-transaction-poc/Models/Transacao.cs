using System.Text.Json.Serialization;

namespace donet_transaction_poc.Models
{
    public class Transacao
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int Cliente_Id { get; set; }
        public int Valor { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        [JsonPropertyName("realizada_em")]
        public string RealizadaEm { get; set; }

    }
}
