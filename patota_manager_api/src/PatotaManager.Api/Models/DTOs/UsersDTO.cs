
using patota_manager_api.src.PatotaManager.Api.Models;

namespace patota_manager_api.src.PatotaManager.Api.DTOs
{
    public class UsersDTO(User user)
    {
        public long UserId { get; set; } = user.UserId;

        public string Username { get; set; } = user.Username;

        public string Email { get; set; } = user.Email;

    }
}