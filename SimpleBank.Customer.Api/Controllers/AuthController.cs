using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleBank.Customers.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            if (request == null)
                return BadRequest("Invalid request");

            if (request.Username != "admin" || request.Password != "password")
                return Unauthorized();

            var token = GenerateToken(request.Username);

            return Ok(new { token });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"ERROR: {ex.Message}");
        }
    }

    private string GenerateToken(string username)
    {
        var keyString = "THIS_IS_A_LONG_SUPER_SECRET_KEY_123456"; // 🔥 IMPORTANT (LONG KEY)
        var key = Encoding.UTF8.GetBytes(keyString);

        var securityKey = new SymmetricSecurityKey(key);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var tokenDescriptor = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}