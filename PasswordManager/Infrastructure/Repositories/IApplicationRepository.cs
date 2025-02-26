using PasswordManager.Domain.Entities;

namespace PasswordManager.Infrastructure.Repositories
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetAllApplicationsAsync();
        Task<Application?> GetApplicationByIdAsync(int id);
        Task<Application> AddApplicationAsync(Application application);
    }
}
