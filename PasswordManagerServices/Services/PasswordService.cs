using PasswordManager.Domain.Entities;
using PasswordManager.Domain.Interfaces;
using PasswordManager.Infrastructure.Repositories;

namespace PasswordManager.PasswordManagerServices.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IServiceProvider _serviceProvider;

        public PasswordService(IPasswordRepository passwordRepository, IApplicationRepository applicationRepository, IServiceProvider serviceProvider)
        {
            _passwordRepository = passwordRepository;
            _applicationRepository = applicationRepository;
            _serviceProvider = serviceProvider;
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
            var application = await _applicationRepository.GetApplicationByIdAsync(password.ApplicationId);
            if (application == null)
            {
                throw new ArgumentException("Application not found.");
            }

            // Sélection dynamique de la stratégie de chiffrement
            IEncryptionStrategy encryptionStrategy = application.Type switch
            {
                "Grand public" => _serviceProvider.GetRequiredService<AesEncryptionStrategy>(),
                "Professionnelle" => _serviceProvider.GetRequiredService<RsaEncryptionStrategy>(),
                _ => throw new ArgumentException("Unknown application type.")
            };

            password.EncryptedPassword = encryptionStrategy.Encrypt(password.EncryptedPassword);

            return await _passwordRepository.AddPasswordAsync(password);
        }

        public async Task DeletePasswordAsync(int id)
        {
            await _passwordRepository.DeletePasswordAsync(id);
        }
    }
}
