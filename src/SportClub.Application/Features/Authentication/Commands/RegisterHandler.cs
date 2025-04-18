using MediatR;
using SportClub.Application.Features.Authentication.Interfaces;

namespace SportClub.Application.Features.Authentication.Commands
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RegisterAsync(request.email, request.password);
        }
    }

}
