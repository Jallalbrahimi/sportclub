using SportClub.Domain.Entities;

namespace SportClub.Application.Features.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> RegisterAsync(string email, string password);

        Task<ApplicationUser?> GetUserByEmailAsync(string email);
    }
}
