using patota_manager_api.src.PatotaManager.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace patota_manager_api.src.PatotaManager.Api.Models
{
    [Table("tb_team")]
    public record Team
    {
        public Team(string name, string location, string skillLevel, string description, Guid createdBy)
        {
            Name = name;
            Location = location;
            SkillLevel = skillLevel;
            Description = description;
            CreatedBy = createdBy;
        }

        [Key]
        [Column("id")]
        public Guid TeamId { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("location")]
        [Required]
        public string Location { get; set; }

        [Column("skill_level")]
        [Required]
        public string SkillLevel { get; set; }

        [Column("description")]
        [Required]
        public string Description { get; set; }

        [Column("created_by")]
        [ForeignKey(nameof(User))]
        public Guid CreatedBy { get; set; }
        public User User { get; set; }

        [JsonIgnore]
        [Column("created_at")]

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
