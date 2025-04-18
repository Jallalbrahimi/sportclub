using SportClub.Domain.Entities;

namespace SportClub.Application.Features.User.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<Guid> CreateUserAsync(UserProfile profile, CancellationToken cancellationToken);
        Task<IList<UserProfile>> GetUsersAsync(CancellationToken cancellationToken);
    }
}
