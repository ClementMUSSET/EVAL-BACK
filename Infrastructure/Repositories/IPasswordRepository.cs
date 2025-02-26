using PasswordManager.Domain.Entities;

namespace PasswordManager.Infrastructure.Repositories
{
    public interface IPasswordRepository
    {
        Task<IEnumerable<Password>> GetAllPasswordsAsync();
        Task<Password?> GetPasswordByIdAsync(int id);
        Task<Password> AddPasswordAsync(Password password);
        Task DeletePasswordAsync(int id);
    }
}
