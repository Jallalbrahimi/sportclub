using MediatR;
using SportClub.Domain.Entities;

namespace SportClub.Application.Features.Authentication.Commands
{
    public record LoginCommand(string email, string password) : IRequest<ApplicationUser>;
}
