using patota_manager_api.src.PatotaManager.Api.DTOs;
using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Common.Exceptions;

namespace patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<ApiResponse> GetUsersAsync();

        Task<ApiResponse> CreateUserAsync(User user);
    }
}