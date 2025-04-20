using MediatR;
using SportClub.Application.Features.UserProfile.Interfaces;

namespace SportClub.Application.Features.UserProfile.Commands
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
            var profile = new Domain.Entities.UserProfile
            {
                Id = Guid.NewGuid()
            };

            return await _userRepository.CreateUserAsync(profile, cancellationToken);
        }
    }
}
