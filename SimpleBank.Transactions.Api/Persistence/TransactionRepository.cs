using SimpleBank.Transactions.Api.Domain;

namespace SimpleBank.Transactions.Api.Persistence
{
    public class TransactionRepository
    {
        private readonly TransactionDbContext _context;

        public TransactionRepository(TransactionDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return _context.Transactions.ToList();
        }

        public async Task<Transaction> AddAsync(Transaction tx)
        {
            _context.Transactions.Add(tx);
            await _context.SaveChangesAsync();
            return tx;
        }
    }
}