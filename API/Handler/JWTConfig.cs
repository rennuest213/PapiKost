using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Handler
{
    public class JWTConfig
    {
        private readonly IConfiguration _configuration;
        public JWTConfig(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public string Token(string email, string role, int id, string name)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("id", id.ToString()),
                new Claim("email",email),
                new Claim("Name",name),
                new Claim("role",role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                 _configuration["Jwt:Issuer"],
                 _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn
                );

            var JWT = new JwtSecurityTokenHandler().WriteToken(token);

            return JWT;
        }
    }
}
