using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Api.Models.DTOs;
using patota_manager_api.src.PatotaManager.Api.Services;
using patota_manager_api.src.PatotaManager.Common.Exceptions;
using patota_manager_api.src.PatotaManager.Infrastructure.Data;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;

namespace patota_manager_api.src.PatotaManager.Infrastructure.Repositories
{
    public class TeamRepository(LogService logger, ApiDbContext dbContext) : ITeamRepository
    {
        private readonly LogService _logger = logger;
        private readonly ApiDbContext _dbContext = dbContext;


        public async Task<ApiResponse> GetTeamsAsync()
        {
            try
            {
                var teams = await _dbContext.Teams.Select(team => new TeamDTO()
                {
                    TeamId = team.TeamId,
                    Name = team.Name,
                    City = team.City,
                    Uf = team.Uf,
                    Address = team.Address,
                    AddressNumber = team.AddressNumber,
                    SkillLevel = team.SkillLevel,
                    Description = team.Description,
                    CreatedBy = team.CreatedBy
                }).ToArrayAsync();

                return new ApiResponse(true, "Patotas recuperadas com sucesso.", teams);
            }
            catch (Exception ex)
            {
                _ = _logger.InsertLogAsync("Error", "Erro ao recuperar patotas: " + ex.Message, ex.ToString(), null, "TeamsRepository", "GetTeamsAsync");
                return new ApiResponse(false, "Erro ao recuperar patotas.", null, new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse> CreateTeamAsync(Team team)
        {
            try
            {
                using (var context = new ApiDbContext())
                {
                    await context.Teams.AddAsync(team);
                    await context.SaveChangesAsync();
                }
                return new ApiResponse(true, "Patota criada com sucesso.", team);
            }
            catch (Exception ex)
            {
                _ = _logger.InsertLogAsync("Error", "Erro ao criar patota: " + ex.Message, ex.ToString(), null, "TeamsRepository", "CreateTeamAsync");
                return new ApiResponse(false, "Erro ao criar patota.", null, new List<string> { ex.Message });
            }

        }
    }
}