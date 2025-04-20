using Microsoft.EntityFrameworkCore;
using SportClub.Application.Features.UserProfile.Interfaces;
using SportClub.Domain.Entities;

namespace SportClub.Infrastructure.Persistence
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateUserAsync(UserProfile user, CancellationToken cancellationToken)
        {
            _dbContext.UserProfiles.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user.Id;
        }

        public async Task<IList<UserProfile>> GetUsersAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.UserProfiles.ToListAsync(cancellationToken);
        }
    }
}
