using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SportClub.Application.Features.Authentication.Interfaces;
using SportClub.Domain.Entities;
using SportClub.Infrastructure.Identity;

namespace SportClub.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AuthenticationUser> _userManager;
        private readonly IConfiguration _config;

        public AuthenticationService(UserManager<AuthenticationUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var authenticationUser = await _userManager.FindByEmailAsync(email);
            return authenticationUser != null && await _userManager.CheckPasswordAsync(authenticationUser, password);
        }

        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            var authenticationUser = await _userManager.FindByEmailAsync(email);
            if (authenticationUser == null)
            {
                return null;
            }

            var userProfile = new UserProfile();
            return new ApplicationUser
            {
                Id = authenticationUser.Id,
                Email = authenticationUser.Email,
                UserProfile = userProfile,
            };
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            var user = new AuthenticationUser { Email = email, UserName = email };
            var result = await _userManager.CreateAsync(user, password);

            //TODO: get the reasons
            return result.Succeeded;
        }
    }
}
