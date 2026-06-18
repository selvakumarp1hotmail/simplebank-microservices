using Microsoft.EntityFrameworkCore;
using SimpleBank.Customers.Api.Domain;

namespace SimpleBank.Customers.Api.Persistence
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
