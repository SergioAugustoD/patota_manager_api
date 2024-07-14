using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace patota_manager_api.src.PatotaManager.Api.Models
{
    [Table("tb_logs")]
    public class Log(string logLevel, string message, string? exception, Guid? userId, string source, string action)
    {

        [Key]
        [Column("id")]
        public Guid LogId { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("log_level")]
        [Required]
        public string LogLevel { get; set; } = logLevel;

        [Column("message")]
        [Required]
        public string Message { get; set; } = message;

        [Column("exception")]
        public string? Exception { get; set; } = exception;

        [Column("user_id")]
        public Guid? UserId { get; set; } = userId;

        [Column("source")]
        [Required]
        public string Source { get; set; } = source;

        [Column("action")]
        [Required]
        public string Action { get; set; } = action;
    }
}