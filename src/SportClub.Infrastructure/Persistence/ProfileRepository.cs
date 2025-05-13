using Microsoft.EntityFrameworkCore;
using SportClub.Application.Features.UserProfile.Interfaces;
using SportClub.Domain.Entities;

namespace SportClub.Infrastructure.Persistence
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateProfileAsync(Profile profile, CancellationToken cancellationToken)
        {
            _dbContext.Profiles.Add(profile);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return profile.Id;
        }

        public async Task<Guid> EditProfileAsync(Profile profile, CancellationToken cancellationToken)
        {
            // Get the current profile
            var currentProfile = await GetProfileByIdAsync(profile.Id, cancellationToken);
            if (currentProfile == null)
            {
                throw new ApplicationException("Profile not found");
            }

            // Update the current profile with the new values
            currentProfile.FirstName = profile.FirstName;
            currentProfile.LastName = profile.LastName;
            currentProfile.Email = profile.Email;
            currentProfile.BirthDate = profile.BirthDate;
            currentProfile.PhoneNumber = profile.PhoneNumber;

            // Save changes to the database
            await _dbContext.SaveChangesAsync(cancellationToken);
            return profile.Id;
        }

        public async Task<Profile?> GetProfileByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Profiles.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
