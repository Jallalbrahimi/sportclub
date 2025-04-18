using MediatR;

namespace SportClub.Application.Features.User.Commands
{
    public record CreateUserProfileCommand() : IRequest<Guid>;
}
