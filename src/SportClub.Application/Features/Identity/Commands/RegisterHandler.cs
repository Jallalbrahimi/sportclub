using MediatR;
using SportClub.Application.Features.Identity.Interfaces;

namespace SportClub.Application.Features.Identity.Commands
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IIdentityService _identityService;

        public RegisterHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.RegisterAsync(request.email, request.password);
        }
    }

}
