using Microsoft.EntityFrameworkCore;
using SimpleBank.Accounts.Api.Domain;

namespace SimpleBank.Accounts.Api.Persistence
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}