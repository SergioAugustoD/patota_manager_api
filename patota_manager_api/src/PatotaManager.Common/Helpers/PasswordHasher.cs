using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patota_manager_api.src.PatotaManager.Common.Helpers
{
    public class PasswordHasher
    {
        // Método para criar um hash da senha
        public static string HashPassword(string password)
        {
            // Você pode ajustar o WorkFactor para aumentar ou diminuir a complexidade do hash
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        // Método para verificar se a senha corresponde ao hash
        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}