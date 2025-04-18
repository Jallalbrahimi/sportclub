using MediatR;

namespace SportClub.Application.Features.Authentication.Commands
{
    public record RegisterCommand(string email, string password) : IRequest<bool>;
}
