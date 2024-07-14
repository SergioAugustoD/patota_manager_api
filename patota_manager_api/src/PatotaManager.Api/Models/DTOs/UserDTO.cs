
using patota_manager_api.src.PatotaManager.Api.Models;

namespace patota_manager_api.src.PatotaManager.Api.DTOs
{
    public class UserDTO
    {
        public Guid UserId { get; set; }

        public required string Name { get; set; }

        public required string Username { get; set; }

        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

    }
}