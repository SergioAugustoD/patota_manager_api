
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
        public Task<IActionResult> GetAllUsers()
        {
            var users = _usersRepository.GetUsers();

            return Task.FromResult<IActionResult>(Ok(users));
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel userViewModel)
        {
            var user = new User(
                userViewModel.Name,
                userViewModel.Username,
                userViewModel.Email,
                userViewModel.Password
            );


            _usersRepository.CreateUser(user);

            return Ok(new { status = 200, error = false, message = "Cadastro realizado com sucesso!" });


        }
    }
}