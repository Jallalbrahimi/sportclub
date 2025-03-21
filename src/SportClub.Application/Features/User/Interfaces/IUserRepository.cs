using SportClub.Domain.Entities;

namespace SportClub.Application.Features.User.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> CreateUserAsync(ApplicationUser user, CancellationToken cancellationToken);
        Task<IList<ApplicationUser>> GetUsersAsync(CancellationToken cancellationToken);
    }
}
