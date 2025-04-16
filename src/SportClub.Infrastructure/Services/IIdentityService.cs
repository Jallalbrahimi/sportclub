using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SportClub.Application.Features.Identity.Interfaces;
using SportClub.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SportClub.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public IdentityService(UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<ApplicationUser?> AuthenticateAsync(string email, string password)
        {
            var identityUser = await _userManager.FindByEmailAsync(email);
            if (identityUser == null || !await _userManager.CheckPasswordAsync(identityUser, password))
                return null;

            return new ApplicationUser { Id = Guid.Parse(identityUser.Id), Email = identityUser.Email! };
        }
        public async Task<bool> RegisterAsync(string email, string password)
        {
            var user = new IdentityUser { Email = email, UserName = email };
            var result = await _userManager.CreateAsync(user, password);

            //TODO: get the reasons
            return result.Succeeded;
        }
        public Task<string> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) },
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
