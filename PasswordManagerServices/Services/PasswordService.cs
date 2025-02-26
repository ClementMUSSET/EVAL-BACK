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
            var passwords = await _passwordRepository.GetAllPasswordsAsync();

            foreach (var password in passwords)
            {
                var encryptionStrategy = GetEncryptionStrategy(password.Application.Type);
                password.EncryptedPassword = encryptionStrategy.Decrypt(password.EncryptedPassword);
            }

            return passwords;
        }

        public async Task<Password?> GetPasswordByIdAsync(int id)
        {
            var password = await _passwordRepository.GetPasswordByIdAsync(id);
            if (password != null)
            {
                var encryptionStrategy = GetEncryptionStrategy(password.Application.Type);
                password.EncryptedPassword = encryptionStrategy.Decrypt(password.EncryptedPassword);
            }
            return password;
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

        private IEncryptionStrategy GetEncryptionStrategy(string applicationType)
        {
            return applicationType switch
            {
                "Grand public" => _serviceProvider.GetRequiredService<AesEncryptionStrategy>(),
                "Professionnelle" => _serviceProvider.GetRequiredService<RsaEncryptionStrategy>(),
                _ => throw new ArgumentException("Unknown application type.")
            };
        }
    }
}
