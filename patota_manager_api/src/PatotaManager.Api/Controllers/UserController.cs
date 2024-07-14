
using Microsoft.AspNetCore.Mvc;
using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Api.Models.ViewModel;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;

namespace patota_manager_api.src.PatotaManager.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController(IUsersRepository usersRepository) : ControllerBase
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        [HttpGet]
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
    }
}