using MediatR;

namespace SportClub.Application.Features.User.Commands
{
    public record CreateUserCommand(
        string title,
        Uri? sourceUrl) : IRequest<Guid>;
}
