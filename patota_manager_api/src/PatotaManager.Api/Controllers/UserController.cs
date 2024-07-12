
using Microsoft.AspNetCore.Mvc;
using patota_manager_api.src.PatotaManager.Api.DTOs;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;

namespace patota_manager_api.src.PatotaManager.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController(IUsersRepository usersRepository) : ControllerBase
    {
        private readonly IUsersRepository _usersRepository = usersRepository;

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _usersRepository.GetUsers();

            if (users == null)
            {
                return NotFound();
            }

            var response = new List<UsersDTO>();

            foreach (var user in users)
            {
                response.Add(new UsersDTO(user));
            }

            return Ok(response);
        }
    }
}