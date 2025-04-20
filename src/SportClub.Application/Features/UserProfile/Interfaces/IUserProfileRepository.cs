namespace SportClub.Application.Features.UserProfile.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<Guid> CreateUserAsync(Domain.Entities.UserProfile profile, CancellationToken cancellationToken);
        Task<IList<Domain.Entities.UserProfile>> GetUsersAsync(CancellationToken cancellationToken);
    }
}
