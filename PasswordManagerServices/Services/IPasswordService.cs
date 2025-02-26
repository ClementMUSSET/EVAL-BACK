using PasswordManager.Domain.Entities;

namespace PasswordManager.PasswordManagerServices.Services
{
    public interface IPasswordService
    {
        Task<IEnumerable<Password>> GetAllPasswordsAsync();
        Task<Password?> GetPasswordByIdAsync(int id);
        Task<Password> AddPasswordAsync(Password password);
        Task DeletePasswordAsync(int id);
    }
}
