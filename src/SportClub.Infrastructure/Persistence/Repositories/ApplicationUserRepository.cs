using Microsoft.EntityFrameworkCore;
using SportClub.Application.Features.User.Interfaces;
using SportClub.Domain.Entities;

namespace SportClub.Infrastructure.Persistence.Repositories
{
    public class ApplicationUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateUserAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user.Id;
        }

        public async Task<IList<ApplicationUser>> GetUsersAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Users.ToListAsync(cancellationToken);
        }
    }
}
