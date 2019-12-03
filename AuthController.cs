using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MovieCruiserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        // GET: api/Auth
        [HttpGet(Name = "AuthGet")]
        public string Get()
        {
            return GenerateJSONWebToken(1234, "Admin");
        }

        public static string GenerateJSONWebToken(long UsId, string userRole)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UsId", UsId.ToString())
            };

            var token = new JwtSecurityToken(
                        issuer: "mySystem",
                        audience: "myUsers",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
