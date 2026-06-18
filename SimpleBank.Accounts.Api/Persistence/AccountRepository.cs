using SimpleBank.Accounts.Api.Domain;

namespace SimpleBank.Accounts.Api.Persistence
{
    public class AccountRepository
    {
        private readonly AccountDbContext _context;

        public AccountRepository(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return _context.Accounts.ToList();
        }

        public async Task<Account> AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }
        public async Task<Account?> GetByIdAsync(Guid id)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == id);
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

    }
}