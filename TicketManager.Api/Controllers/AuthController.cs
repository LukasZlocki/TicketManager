using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketManager.Models.Models;

namespace TicketManager.Api.Controllers
{
    [ApiController]
    public class AuthController(IConfiguration configuration) : Controller
    {

        [HttpPost("api/login")]
        public ActionResult<LoginResponseModel> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel.UserName == "Admin" && loginModel.Password == "Admin")
            {
                var token = GenerateJwtToken(loginModel.UserName);
                return Ok(new LoginResponseModel { Token = token });
            }
            return null;

        }

        private string GenerateJwtToken(string userName)
        { 
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            string secret = configuration.GetValue<string>("Jwt:Secret");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "doseHieu",
                audience: "doseHieu",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}