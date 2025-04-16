using MediatR;
using SportClub.Application.Features.Identity.Interfaces;
using SportClub.Application.Features.User.Commands;
using SportClub.Application.Features.User.Interfaces;
using SportClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Application.Features.Identity.Commands
{
    public class LoginHandler : IRequestHandler<LoginCommand, bool>
    {
        private readonly IIdentityService _identityService;

        public LoginHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _identityService.AuthenticateAsync(request.email, request.password);
            return applicationUser != null;
        }
    }

}
