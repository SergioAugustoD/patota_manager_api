using patota_manager_api.src.PatotaManager.Api.DTOs;
using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Common.Exceptions;

namespace patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<ApiResponse> GetUsersAsync();

        Task<User> GetUserByEmail(string email);

        Task<ApiResponse> CreateUserAsync(User user);

        Task<ApiResponse> UpdateUserPasswordAsync(string email, string oldPassword, string newPassword);
    }
}