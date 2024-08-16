using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Api.Models.ViewModel;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;

namespace patota_manager_api.src.PatotaManager.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TeamController(ITeamRepository teamsRepository) : ControllerBase
    {
        private readonly ITeamRepository _teamsRepository = teamsRepository;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTeams()
        {
            var response = await _teamsRepository.GetTeamsAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("team-details/{id}")]
        [Authorize]
        public async Task<IActionResult> GetTeamDetails(Guid id)
        {
            var response = await _teamsRepository.GetTeamDetailsAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTeam(TeamViewModel teamViewModel)
        {
            var team = new Team(
                teamViewModel.Name,
                teamViewModel.City,
                teamViewModel.Uf,
                teamViewModel.Address,
                teamViewModel.AddressNumber,
                teamViewModel.SkillLevel,
                teamViewModel.Description,
                teamViewModel.CreatedBy
            );

            var response = await _teamsRepository.CreateTeamAsync(team);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}