using MediatR;
using SportClub.Application.Features.Authentication.Interfaces;
using SportClub.Domain.Entities;

namespace SportClub.Application.Features.Authentication.Commands
{
    public class LoginHandler : IRequestHandler<LoginCommand, ApplicationUser?>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<ApplicationUser?> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var isAuthenticated = await _authenticationService.AuthenticateAsync(request.email, request.password);
            ApplicationUser? user = null;

            if (isAuthenticated)
            {
                user = await _authenticationService.GetUserByEmailAsync(request.email);
            }
            return user;
        }
    }

}
