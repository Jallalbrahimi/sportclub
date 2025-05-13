using MediatR;
using SportClub.Application.Features.UserProfile.Dtos;

namespace SportClub.Application.Features.UserProfile.Queries
{
    public record GetProfileQuery : IRequest<ProfileDto>
    {
        public Guid ProfileId { get; set; }
    }
}
