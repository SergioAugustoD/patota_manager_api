using System.Security.Cryptography;

namespace patota_manager_api.src.PatotaManager.Common.Helpers
{
    public class PasswordHelper
    {

        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit
        private const int Iterations = 10000; // Número de iterações para PBKDF2
        // Método para criar um hash da senha
        public static string HashPassword(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              SaltSize,
              Iterations,
              HashAlgorithmName.SHA256))
            {
                var salt = algorithm.Salt;
                var key = algorithm.GetBytes(KeySize);

                var hashBytes = new byte[SaltSize + KeySize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(key, 0, hashBytes, SaltSize, KeySize);

                return Convert.ToBase64String(hashBytes);
            }
        }

        // Função para validar a senha com a hash armazenada no banco
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashBytes = Convert.FromBase64String(hashedPassword);

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              salt,
              Iterations,
              HashAlgorithmName.SHA256))
            {
                var key = algorithm.GetBytes(KeySize);
                for (int i = 0; i < KeySize; i++)
                {
                    if (hashBytes[i + SaltSize] != key[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }


    }
}