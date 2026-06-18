namespace SimpleBank.Accounts.Api.Domain
{
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }

        public string AccountNumber { get; set; } = string.Empty;

        public decimal Balance { get; set; }

        public string Currency { get; set; } = "SGD";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}