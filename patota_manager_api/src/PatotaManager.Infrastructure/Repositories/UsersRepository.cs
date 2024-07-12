using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Infrastructure.Data;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;

namespace patota_manager_api.src.PatotaManager.Infrastructure.Repositories
{
    public class UsersRepository(ApiDbContext dbContext) : IUsersRepository
    {

        private readonly ApiDbContext _dbContext = dbContext;

        public IEnumerable<User> GetUsers()
        {
            return [.. _dbContext.Users];
        }
    }
}