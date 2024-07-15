using Microsoft.EntityFrameworkCore;
using Npgsql;
using patota_manager_api.src.PatotaManager.Api.DTOs;
using patota_manager_api.src.PatotaManager.Api.Models;
using patota_manager_api.src.PatotaManager.Api.Services;
using patota_manager_api.src.PatotaManager.Common.Exceptions;
using patota_manager_api.src.PatotaManager.Common.Helpers;
using patota_manager_api.src.PatotaManager.Infrastructure.Data;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;

namespace patota_manager_api.src.PatotaManager.Infrastructure.Repositories
{
    public class UsersRepository(LogService logger, ApiDbContext dbContext) : IUsersRepository
    {

        private readonly LogService _logger = logger;
        private readonly ApiDbContext _dbContext = dbContext;

        public async Task<ApiResponse> GetUsersAsync()
        {
            try
            {
                var users = await _dbContext.Users.Select(user => new UserDTO()
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    Email = user.Email,
                }).ToListAsync();

                return new ApiResponse(true, "Usuários recuperados com sucesso.", users);
            }
            catch (Exception ex)
            {
                _ = _logger.InsertLogAsync("Error", "Erro ao recuperar usuários: " + ex.Message, ex.ToString(), null, "UsersRepository", "GetUsersAsync");
                return new ApiResponse(false, "Erro ao recuperar usuários.", null, new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse> CreateUserAsync(User user)
        {
            try
            {
                // Validação de dados
                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    return new ApiResponse(false, "O endereço de e-mail é obrigatório.");
                }

                if (!IsValidEmail(user.Email))
                {
                    return new ApiResponse(false, "O endereço de e-mail é inválido.");
                }

                if (string.IsNullOrWhiteSpace(user.Username))
                {
                    return new ApiResponse(false, "O nome de usuário é obrigatório.");
                }

                if (user.Username.Length > 50)
                {
                    return new ApiResponse(false, "O nome de usuário não pode ter mais de 50 caracteres.");
                }

                if (user.PasswordHash.Length < 8)
                {
                    return new ApiResponse(false, "A senha deve ter pelo menos 8 caracteres.");
                }

                if (string.IsNullOrWhiteSpace(user.PasswordHash))
                {
                    return new ApiResponse(false, "A senha é obrigatória.");
                }

                using (var context = new ApiDbContext())
                {
                    user.PasswordHash = PasswordHelper.HashPassword(user.PasswordHash);
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();
                }

                return new ApiResponse(true, "Usuário criado com sucesso.");
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
            {
                _ = _logger.InsertLogAsync("Error", "Ocorreu um erro ao adicionar um usuário ao banco de dados: " + ex.Message, ex.ToString(), user.UserId, "UsersRepository", "CreateUserAsync");

                if (pgEx.ConstraintName.Contains("email"))
                {
                    return new ApiResponse(false, "Este endereço de e-mail já está sendo usado. Por favor, escolha outro.");
                }
                else if (pgEx.ConstraintName.Contains("username"))
                {
                    return new ApiResponse(false, "Este nome de usuário já está em uso. Por favor, escolha outro.");
                }
                else
                {
                    return new ApiResponse(false, "Ocorreu um erro ao criar o usuário. Por favor, tente novamente mais tarde.");
                }
            }
            catch (PostgresException ex) when (ex.SqlState == "23503")
            {
                _ = _logger.InsertLogAsync("Error", "Ocorreu um erro ao adicionar um usuário ao banco de dados: " + ex.Message, ex.ToString(), user.UserId, "UsersRepository", "CreateUserAsync");
                return new ApiResponse(false, "Ocorreu um erro de integridade referencial. Verifique se todos os dados relacionados existem e são válidos.");
            }
            catch (PostgresException ex) when (ex.SqlState == "08006" || ex.SqlState == "08001")
            {
                _ = _logger.InsertLogAsync("Error", "Erro de conexão com o banco de dados: " + ex.Message, ex.ToString(), user.UserId, "UsersRepository", "CreateUserAsync");
                return new ApiResponse(false, "Erro de conexão com o banco de dados. Por favor, tente novamente mais tarde.");
            }
            catch (Exception ex)
            {
                _ = _logger.InsertLogAsync("Error", "Erro interno do servidor: " + ex.Message, ex.ToString(), user.UserId, "UsersRepository", "CreateUserAsync");
                return new ApiResponse(false, "Erro interno do servidor.");
            }
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ApiResponse> UpdateUserPasswordAsync(string email, string oldPassword, string newPassword)
        {
            try
            {

                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    return new ApiResponse(false, "Usuário não encontrado.");
                }
                if (!PasswordHelper.VerifyPassword(oldPassword, user.PasswordHash))
                {
                    return new ApiResponse(false, "Senha antiga nao corresponde.");
                }

                user.PasswordHash = PasswordHelper.HashPassword(newPassword); // Use um método para hash da senha em um cenário real

                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();

                return new ApiResponse(true, "Senha atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                _ = _logger.InsertLogAsync("Error", "Erro ao atualizar a senha do usuário: " + ex.Message, ex.ToString(), null, "UsersRepository", "UpdateUserPasswordAsync");
                return new ApiResponse(false, "Erro ao atualizar a senha do usuário.", null, [ex.Message]);
            }
        }
        public Task<User> GetUserByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

    }
}