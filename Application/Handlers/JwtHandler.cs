using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Handlers
{
    public class JwtHandler
    {
        private readonly string? _key;

        public JwtHandler(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"];
        }

        public object GenerateToken(string username)
        {
            if (string.IsNullOrEmpty(_key))
            {
                throw new NullReferenceException();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Role, "generic")
            }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            var result = new
            {
                Token = tokenString,
                Type = "Bearer",
                Created =   DateTime.Now
            };

            return result;
        }
    }
}

