
using Microsoft.AspNetCore.Mvc;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;

namespace patota_manager_api.src.PatotaManager.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController(IUsersRepository usersRepository) : ControllerBase
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        [HttpGet]
        public Task<IActionResult> GetAllUsers()
        {
            var users = _usersRepository.GetUsers();

            return Task.FromResult<IActionResult>(Ok(users));
        }
    }
}