using MediatR;
using SportClub.Application.Features.User.Dtos;
using SportClub.Application.Features.User.Interfaces;

namespace SportClub.Application.Features.User.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IUserService _userRepository;

        public GetUsersQueryHandler(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            // Await the repository call to get the list of Users
            var users = await _userRepository.GetUsersAsync(cancellationToken);

            // Map the Users to DTOs
            var userDtos = users
                .Select(p => new UserDto(p.Id))
                .ToList();

            return userDtos;
        }
    }
}
