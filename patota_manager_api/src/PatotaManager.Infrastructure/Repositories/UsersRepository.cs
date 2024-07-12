using patota_manager_api.src.PatotaManager.Api.DTOs;
using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Common.Helpers;
using patota_manager_api.src.PatotaManager.Infrastructure.Data;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;

namespace patota_manager_api.src.PatotaManager.Infrastructure.Repositories
{
    public class UsersRepository(ApiDbContext dbContext) : IUsersRepository
    {

        private readonly ApiDbContext _dbContext = dbContext;

        public List<UserDTO> GetUsers()
        {
            return [.. _dbContext.Users.Select(user => new UserDTO()
            {
                UserId = user.UserId,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
            }
            )];
        }

        public void CreateUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}