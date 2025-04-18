using MediatR;
using SportClub.Application.Features.User.Dtos;
using SportClub.Application.Features.User.Interfaces;

namespace SportClub.Application.Features.User.Queries
{
    public class GetUserProfilesQueryHandler : IRequestHandler<GetUserProfilesQuery, List<UserProfileDto>>
    {
        private readonly IUserProfileRepository _userRepository;

        public GetUserProfilesQueryHandler(IUserProfileRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserProfileDto>> Handle(GetUserProfilesQuery request, CancellationToken cancellationToken)
        {
            // Await the repository call to get the list of Users
            var users = await _userRepository.GetUsersAsync(cancellationToken);

            // Map the Users to DTOs
            var userDtos = users
                .Select(p => new UserProfileDto(p.Id))
                .ToList();

            return userDtos;
        }
    }
}
