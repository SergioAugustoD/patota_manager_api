using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patota_manager_api.src.PatotaManager.Api.Models.DTOs
{
    public class LogDTO
    {


        public LogDTO(string logLevel, string message, string? exception, int? userId, string source, string action)
        {
            LogLevel = logLevel;
            Message = message;
            Exception = exception;
            UserId = userId;
            Source = source;
            Action = action;
        }
        public required string LogLevel { get; set; }
        public required string Message { get; set; }
        public string? Exception { get; set; }
        public int? UserId { get; set; }
        public required string Source { get; set; }
        public required string Action { get; set; }
    }
}