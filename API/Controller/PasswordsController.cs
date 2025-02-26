using Microsoft.AspNetCore.Mvc;
using PasswordManager.PasswordManagerServices.Services;
using PasswordManager.Domain.Entities;

namespace PasswordManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordsController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPasswords()
        {
            var passwords = await _passwordService.GetAllPasswordsAsync();
            return Ok(passwords);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassword(int id)
        {
            var password = await _passwordService.GetPasswordByIdAsync(id);
            if (password == null)
            {
                return NotFound();
            }
            return Ok(password);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassword(Password password)
        {
            var newPassword = await _passwordService.AddPasswordAsync(password);
            return CreatedAtAction(nameof(GetPassword), new { id = newPassword.Id }, newPassword);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassword(int id)
        {
            await _passwordService.DeletePasswordAsync(id);
            return NoContent();
        }
    }
}
