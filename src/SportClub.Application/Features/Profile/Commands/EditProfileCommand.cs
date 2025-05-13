using MediatR;

namespace SportClub.Application.Features.UserProfile.Commands
{
    public record EditProfileCommand() : IRequest<Guid>;
}
