using Microsoft.AspNetCore.Mvc;
using PasswordManager.Domain.Entities;
using PasswordManager.PasswordManagerServices.Services;

namespace PasswordManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            var applications = await _applicationService.GetAllApplicationsAsync();
            return Ok(applications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplication(int id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

        [HttpPost]
        public async Task<IActionResult> AddApplication(Application application)
        {
            var newApplication = await _applicationService.AddApplicationAsync(application);
            return CreatedAtAction(nameof(GetApplication), new { id = newApplication.Id }, newApplication);
        }
    }
}
