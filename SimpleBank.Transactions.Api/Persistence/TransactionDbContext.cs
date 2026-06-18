using Microsoft.EntityFrameworkCore;
using SimpleBank.Transactions.Api.Domain;

namespace SimpleBank.Transactions.Api.Persistence
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
