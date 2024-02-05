namespace PPI_API.Controllers
{
    using System;
    using System.Net;
    using System.Text;
    using PPI_Model.Models;
    using PPI_Core.Services.Auth;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using Swashbuckle.AspNetCore.Annotations;
    using Microsoft.Extensions.Configuration;

    [ApiController]
    [Route("[controller]")]
    public class AuthController : BaseController
    {
        private readonly IConfiguration configuration;
        private readonly IAuthService authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            this.configuration = configuration;
            this.authService = authService;
        }

        [HttpPost("token")]
        [SwaggerOperation("Método que se encarga de generar el token para la aplicación")]
        public IActionResult GetToken()
        {
            if(authService.CheckValidUser(UserName, Password, out int accountId))
            {
                TokenModel response = new()
                {
                    AccessToken = GenerateToken(accountId, out int expiresIn),
                    ExpiresIn = expiresIn
                };

                return CreateResponseHelper(response, HttpStatusCode.OK);
            }

            return Unauthorized();
        }

        private string GenerateToken(int accountId, out int expiresIn)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, accountId.ToString())
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

            DateTime expiration = DateTime.UtcNow.AddHours(2);

            JwtSecurityToken token = new(
                issuer: "PPI-API",
                audience: "PPI-API",
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            expiresIn = (int)(expiration - DateTime.UtcNow).TotalSeconds;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
