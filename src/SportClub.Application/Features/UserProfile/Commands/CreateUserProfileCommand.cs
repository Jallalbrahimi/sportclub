using MediatR;

namespace SportClub.Application.Features.UserProfile.Commands
{
    public record CreateUserProfileCommand() : IRequest<Guid>;
}
