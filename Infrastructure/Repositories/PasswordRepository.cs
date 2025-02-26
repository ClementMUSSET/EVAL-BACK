using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Entities;
using PasswordManager.Infrastructure.Data;

namespace PasswordManager.Infrastructure.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly AppDbContext _context;

        public PasswordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Password>> GetAllPasswordsAsync()
        {
            return await _context.Passwords.ToListAsync();
        }

        public async Task<Password?> GetPasswordByIdAsync(int id)
        {
            return await _context.Passwords.FindAsync(id);
        }

        public async Task<Password> AddPasswordAsync(Password password)
        {
            _context.Passwords.Add(password);
            await _context.SaveChangesAsync();
            return password;
        }

        public async Task DeletePasswordAsync(int id)
        {
            var password = await _context.Passwords.FindAsync(id);
            if (password != null)
            {
                _context.Passwords.Remove(password);
                await _context.SaveChangesAsync();
            }
        }
    }
}
