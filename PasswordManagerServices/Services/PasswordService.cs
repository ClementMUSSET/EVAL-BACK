using PasswordManager.Domain.Entities;
using PasswordManager.Infrastructure.Repositories;

namespace PasswordManager.PasswordManagerServices.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;

        public PasswordService(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }

        public async Task<IEnumerable<Password>> GetAllPasswordsAsync()
        {
            return await _passwordRepository.GetAllPasswordsAsync();
        }

        public async Task<Password?> GetPasswordByIdAsync(int id)
        {
            return await _passwordRepository.GetPasswordByIdAsync(id);
        }

        public async Task<Password> AddPasswordAsync(Password password)
        {
            return await _passwordRepository.AddPasswordAsync(password);
        }

        public async Task DeletePasswordAsync(int id)
        {
            await _passwordRepository.DeletePasswordAsync(id);
        }
    }
}
