using SimpleBank.Customers.Api.Domain;

namespace SimpleBank.Customers.Api.Persistence
{
    public class CustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return _context.Customers.ToList();
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }
    }
}