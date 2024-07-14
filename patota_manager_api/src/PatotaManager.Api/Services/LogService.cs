using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Api.Models.DTOs;
using patota_manager_api.src.PatotaManager.Infrastructure.Data;

namespace patota_manager_api.src.PatotaManager.Api.Services
{
    public class LogService(ApiDbContext dbContext)
    {
        private readonly ApiDbContext _dbContext = dbContext;

        public async Task InsertLogAsync(string logLevel, string message, string? exception, Guid? userId, string source, string action)
        {
            using (var context = new ApiDbContext())
            {
                var log = new Log(logLevel, message, exception, userId, source, action);

                context.Logs.Add(log);
                await context.SaveChangesAsync();
            }
        }

    }
}
