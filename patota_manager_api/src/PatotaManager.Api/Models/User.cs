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
        public Guid UserId { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("username")]
        [Required]
        public string Username { get; set; }


        [Column("email")]
        [Required]
        public string Email { get; set; }

        [JsonIgnore]
        [Column("password_hash")]
        [Required]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

