using PasswordManager.Domain.Entities;

namespace PasswordManager.PasswordManagerServices.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<Application>> GetAllApplicationsAsync();
        Task<Application?> GetApplicationByIdAsync(int id);
        Task<Application> AddApplicationAsync(Application application);
    }
}
