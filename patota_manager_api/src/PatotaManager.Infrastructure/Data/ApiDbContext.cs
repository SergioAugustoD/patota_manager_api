
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
            optionsBuilder.UseNpgsql(
                "Server=aws-0-sa-east-1.pooler.supabase.com;" +
                "Port=6543;" +
                "Database=postgres;" +
                "User Id=postgres.igskknqmtqipydbqyypq;" +
                "Password=bfShmidj86fmNgfj;"
            );
        }
    }
}