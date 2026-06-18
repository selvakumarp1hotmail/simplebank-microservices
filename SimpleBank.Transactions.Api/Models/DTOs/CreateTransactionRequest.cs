namespace SimpleBank.Transactions.Api.Models
{
    public class CreateTransactionRequest
    {
        public Guid AccountId { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; } = "Deposit";
    }
}