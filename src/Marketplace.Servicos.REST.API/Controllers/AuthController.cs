using Marketplace.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Marketplace.Servicos.REST.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login request)
        {
            if (request.Email == "admin@admin.com" && request.Senha == "123456")
            {
                var token = GerarToken(request.Email);
                return Ok(new { token });
            }

            return Unauthorized("Usuário ou senha inválidos");
        }
        private string GerarToken(string email)
        {
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, email),
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
