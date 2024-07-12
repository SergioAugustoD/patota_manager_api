using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using patota_manager_api.src.PatotaManager.Common.Helpers;


namespace patota_manager_api.src.PatotaManager.Api.Models
{
    [Table("tb_user")]
    public record User
    {
        public User(string name, string username, string email, string passwordHash)
        {
            Name = name;
            Username = username;
            Email = email;
            PasswordHash = PasswordHasher.HashPassword(passwordHash);
        }

        [Key]
        [Column("id")]
        public int UserId { get; private set; }

        [Column("name")]
        public string Name { get; private set; }

        [Column("username")]
        public string Username { get; private set; }


        [Column("email")]
        public string Email { get; private set; }

        [JsonIgnore]
        [Column("password_hash")]
        public string PasswordHash { get; private set; }

        [JsonIgnore]
        [Column("created_at")]
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}

