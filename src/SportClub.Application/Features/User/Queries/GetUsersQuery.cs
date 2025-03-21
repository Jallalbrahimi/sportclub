using MediatR;
using SportClub.Application.Features.User.Dtos;

namespace SportClub.Application.Features.User.Queries
{
    public record GetUsersQuery : IRequest<List<UserDto>>;
}
