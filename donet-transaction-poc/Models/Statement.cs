using System.ComponentModel.DataAnnotations;

namespace donet_transaction_poc.Models
{
    public class Statement
    {
        public Saldo Saldo { get; set; }
        public List<Transaction> Ultimas_Transacoes { get; set; }

    }

    public class Saldo
    {
        public int Total { get; set; }
        public TimestampAttribute Data_Extato { get; set; }
        public int Limite { get; set; }
    }


}
