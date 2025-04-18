using MediatR;
using SportClub.Application.Features.User.Interfaces;
using SportClub.Domain.Entities;

namespace SportClub.Application.Features.User.Commands
{
    public class CreateUserProfileHandler : IRequestHandler<CreateUserProfileCommand, Guid>
    {
        private readonly IUserProfileRepository _userRepository;

        public CreateUserProfileHandler(IUserProfileRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = new UserProfile
            {
                Id = Guid.NewGuid()
            };

            return await _userRepository.CreateUserAsync(profile, cancellationToken);
        }
    }
}
