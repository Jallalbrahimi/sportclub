using MediatR;

namespace SportClub.Application.Features.User.Commands
{
    public record CreateUserCommand() : IRequest<Guid>;
}
