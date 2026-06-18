namespace SimpleBank.Transactions.Api.Domain
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AccountId { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; } = "Deposit";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}