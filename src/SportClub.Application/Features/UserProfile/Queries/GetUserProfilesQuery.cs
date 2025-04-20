using MediatR;
using SportClub.Application.Features.UserProfile.Dtos;

namespace SportClub.Application.Features.UserProfile.Queries
{
    public record GetUserProfilesQuery : IRequest<List<UserProfileDto>>;
}
