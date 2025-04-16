using SportClub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Application.Features.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<ApplicationUser?> AuthenticateAsync(string email, string password);
        Task<bool> RegisterAsync(string email, string password);
        Task<string> GenerateJwtTokenAsync(ApplicationUser user);
    }
}
