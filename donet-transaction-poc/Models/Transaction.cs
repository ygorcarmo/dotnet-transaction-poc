using System.ComponentModel.DataAnnotations;

namespace donet_transaction_poc.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Ammount { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public TimestampAttribute CreatedAt { get; set; }

    }
}
