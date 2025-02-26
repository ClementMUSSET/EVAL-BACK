using PasswordManager.Infrastructure.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.PasswordManagerServices.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            return await _applicationRepository.GetAllApplicationsAsync();
        }

        public async Task<Application?> GetApplicationByIdAsync(int id)
        {
            return await _applicationRepository.GetApplicationByIdAsync(id);
        }

        public async Task<Application> AddApplicationAsync(Application application)
        {
            return await _applicationRepository.AddApplicationAsync(application);
        }
    }
}
