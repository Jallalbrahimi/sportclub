using MediatR;
using SportClub.Application.Features.UserProfile.Dtos;
using SportClub.Application.Features.UserProfile.Interfaces;

namespace SportClub.Application.Features.UserProfile.Queries
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ProfileDto>
    {
        private readonly IProfileRepository _profileRepository;

        public GetProfileQueryHandler(IProfileRepository userRepository)
        {
            _profileRepository = userRepository;
        }

        public async Task<ProfileDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            // Await the repository call to get the list of Users
            var profile = await _profileRepository.GetProfileByIdAsync(request.ProfileId, cancellationToken);

            // Map the Users to DTOs
            if (profile == null)
            {
                throw new Exception("Profile not found");
            }
            var profileDto = profile.ToDto();

            return profileDto;
        }
    }
}
