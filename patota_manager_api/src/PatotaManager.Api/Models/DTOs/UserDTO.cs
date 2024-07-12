
using patota_manager_api.src.PatotaManager.Api.Models;

namespace patota_manager_api.src.PatotaManager.Api.DTOs
{
    public class UserDTO
    {
        public long UserId { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

    }
}