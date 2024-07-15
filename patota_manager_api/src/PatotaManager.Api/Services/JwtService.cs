using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace patota_manager_api.src.PatotaManager.Api.Services
{
    public class JwtService
    {
        public static string GetJWTToken(string email)
        {
            var handler = new JwtSecurityTokenHandler();
            var secretKey = Environment.GetEnvironmentVariable("SECRET_JWT_TOKEN");
            var keyBytes = Encoding.ASCII.GetBytes(secretKey);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(email),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(5),
            };

            var token = handler.CreateToken(tokenDescriptor);

            var strToken = handler.WriteToken(token);

            return strToken;
        }

        private static ClaimsIdentity GenerateClaims(string email)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, email));
            return ci;
        }

        public static bool ValidateJWTToken(string token)
        {
            var secretKey = Environment.GetEnvironmentVariable("SECRET_JWT_TOKEN");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}