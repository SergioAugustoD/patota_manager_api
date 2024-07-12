using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace patota_manager_api.src.PatotaManager.Api.Models
{
    [Table("tb_user")]
    public class User
    {

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; private set; }

        [Column("username")]
        public string Username { get; private set; } = string.Empty;

        [Column("email")]
        public string Email { get; private set; } = string.Empty;

        [JsonIgnore]
        [Column("password_hash")]
        public string PasswordHash { get; private set; } = string.Empty;

        [JsonIgnore]
        [Column("created_at")]
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    }
}
