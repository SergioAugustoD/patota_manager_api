using patota_manager_api.src.PatotaManager.Api.DTOs;
using patota_manager_api.src.PatotaManager.Api.Models;

namespace patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        public IEnumerable<User> GetUsers();
    }
}