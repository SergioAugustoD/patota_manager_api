
using Microsoft.EntityFrameworkCore;
using patota_manager_api.src.PatotaManager.Api.DTOs;
using patota_manager_api.src.PatotaManager.Api.Models;

namespace patota_manager_api.src.PatotaManager.Infrastructure.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var portDb = Environment.GetEnvironmentVariable("PORT_DB");
            var serverDb = Environment.GetEnvironmentVariable("SERVER_DB");
            var userDb = Environment.GetEnvironmentVariable("USER_DB");
            var passwordDb = Environment.GetEnvironmentVariable("PASSWORD_DB");

            optionsBuilder.UseNpgsql(
                $"Server={serverDb};" +
                $"Port={portDb};" +
                $"Database=postgres;" +
                $"User Id={userDb};" +
                $"Password={passwordDb};"
            );
        }
    }
}