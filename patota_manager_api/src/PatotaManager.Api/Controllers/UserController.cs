
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using patota_manager_api.src.PatotaManager.Api.Configurations;
using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Api.Models.ViewModel;
using patota_manager_api.src.PatotaManager.Common.Exceptions;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;

namespace patota_manager_api.src.PatotaManager.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController(IUsersRepository usersRepository) : ControllerBase
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _usersRepository.GetUsersAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(UserViewModel userViewModel)
        {

            var user = new User(
                userViewModel.Name,
                userViewModel.Username,
                userViewModel.Email,
                userViewModel.Password
            );

            var response = await _usersRepository.CreateUserAsync(user);
            return Ok(response);

        }

        [HttpPut("update-password")]
        [Authorize]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdatePasswordRequest request)
        {
            var response = await _usersRepository.UpdateUserPasswordAsync(request.Email, request.OldPassword, request.NewPassword);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}