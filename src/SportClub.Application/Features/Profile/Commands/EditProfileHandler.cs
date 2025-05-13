using MediatR;
using SportClub.Application.Features.UserProfile.Interfaces;

namespace SportClub.Application.Features.UserProfile.Commands
{
    public class EditProfileHandler : IRequestHandler<EditProfileCommand, Guid>
    {
        private readonly IProfileRepository _profileRepository;

        public EditProfileHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<Guid> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = new Domain.Entities.Profile
            {
                Id = Guid.NewGuid()
            };

            return await _profileRepository.EditProfileAsync(profile, cancellationToken);
        }
    }
}
