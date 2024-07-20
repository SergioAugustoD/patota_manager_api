using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using patota_manager_api.src.PatotaManager.Api.Models.DTOs;
using patota_manager_api.src.PatotaManager.Api.Services;
using patota_manager_api.src.PatotaManager.Common.Exceptions;
using patota_manager_api.src.PatotaManager.Common.Helpers;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;

namespace patota_manager_api.src.PatotaManager.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        private readonly LogService _logger;

        public AuthController(IUsersRepository usersRepository, LogService logger)
        {
            _usersRepository = usersRepository;
            _logger = logger;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse>> Login([FromBody] LoginDTO model)
        {
            try
            {
                var user = await _usersRepository.GetUserByEmail(model.Email);

                if (user == null)
                {
                    return Ok(new ApiResponse(false, "Email não encontrado.", null, ["Usuário inválido."]));
                }

                bool isPasswordValid = PasswordHelper.VerifyPassword(model.Password, user.PasswordHash);

                if (!isPasswordValid)
                {
                    return Ok(new ApiResponse(false, "Senha incorreta.", null, ["Email ou senha inválidos."]));
                }

                var newToken = JwtService.GetJWTToken(user.Email, user.Role);
                return Ok(new ApiResponse(true, "Login realizado com sucesso.", new { Token = newToken, User = user }));
            }
            catch (Exception ex)
            {
                // Log do erro
                _ = _logger.InsertLogAsync("Error", "Falha ao realizar login: " + ex.Message, ex.ToString(), null, "AuthController", "Login");
                return StatusCode(500, new ApiResponse(false, "Erro interno do servidor.", null, [ex.Message]));
            }
        }

        [HttpGet("verify-token")]
        public IActionResult VerifyToken([FromHeader(Name = "Authorization")] string authorizationHeader)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
                {
                    return Ok(new ApiResponse(false, "Cabeçalho de autorização ausente ou inválido."));
                }

                var token = authorizationHeader.Replace("Bearer ", "");
                var isValidToken = JwtService.ValidateJWTToken(token);

                if (isValidToken)
                {
                    return Ok(new ApiResponse(true, "Token válido."));
                }
                else
                {
                    return Unauthorized(new ApiResponse(false, "Token inválido. Logue novamente.", null, ["Token inválido ou expirado."]));
                }
            }
            catch (Exception ex)
            {
                // Log do erro
                _ = _logger.InsertLogAsync("Error", "Falha ao verificar token: " + ex.Message, ex.ToString(), null, "AuthController", "VerifyToken");
                return StatusCode(500, new ApiResponse(false, "Erro interno do servidor.", null, [ex.Message]));
            }
        }
    }
}
