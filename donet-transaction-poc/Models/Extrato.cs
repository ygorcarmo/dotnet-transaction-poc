namespace donet_transaction_poc.Models
{
    public class Extrato
    {
        public SaldoExtratual Saldo { get; set; }
        public List<Transacao> Ultimas_Transacoes { get; set; }

    }

    public class SaldoExtratual
    {
        public int Total { get; set; }
        public string Data_Extato { get; set; }
        public int Limite { get; set; }
    }


}
