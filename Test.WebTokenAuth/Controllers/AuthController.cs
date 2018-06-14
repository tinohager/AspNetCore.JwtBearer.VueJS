using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test.WebTokenAuth.Model;

namespace Test.WebTokenAuth.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration configuration)
        {
            this._config = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AuthRequest authUserRequest)
        {
            if (authUserRequest == null)
            {
                return BadRequest("Could not create token");
            }

            if (authUserRequest.UserName != "test" || authUserRequest.Password != "test")
            {
                return BadRequest("Could not create token");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, authUserRequest.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(this._config["Tokens:Issuer"],
            this._config["Tokens:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
