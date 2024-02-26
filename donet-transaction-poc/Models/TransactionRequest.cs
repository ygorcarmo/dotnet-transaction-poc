namespace donet_transaction_poc.Models
{
    public class TransactionRequest
    {
        public int Ammount { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
