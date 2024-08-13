using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Common.Exceptions;

namespace patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<ApiResponse> GetTeamsAsync();

        Task<ApiResponse> CreateTeamAsync(Team team);
    }
}