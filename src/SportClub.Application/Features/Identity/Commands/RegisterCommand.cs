using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Application.Features.Identity.Commands
{
    public record RegisterCommand(string email, string password) : IRequest<bool>;
}
