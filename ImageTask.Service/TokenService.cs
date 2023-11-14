using ImageTask.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Talabat.Core.Services;

namespace Talabat.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(AppUser user)
        {
            // private claims
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName , user.DisplayName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            // Security Key
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));

            // Registered Claims
            var token = new JwtSecurityToken(
                                issuer: configuration["JWT:ValidIssuer"],
                                audience: configuration["JWT:ValidAudience"],
                                expires: DateTime.Now.AddDays(double.Parse(configuration["JWT:DurationInDays"])),
                                claims: authClaims,
                                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
