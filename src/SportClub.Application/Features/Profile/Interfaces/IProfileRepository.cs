using MediatR;
using SportClub.Domain.Entities;

namespace SportClub.Application.Features.UserProfile.Interfaces
{
    public interface IProfileRepository
    {
        Task<Guid> CreateProfileAsync(Profile profile, CancellationToken cancellationToken);
        Task<Guid> EditProfileAsync(Profile profile, CancellationToken cancellationToken);
        Task<Profile?> GetProfileByIdAsync(Guid profileId, CancellationToken cancellationToken);
    }
}
