using SportClub.Domain.Entities;


namespace SportClub.Application.Features.UserProfile.Dtos
{
    public static class ProfileMappingExtensions
    {
        public static ProfileDto ToDto(this Profile profile) => new(
            Id : profile.Id,
            FirstName : profile.FirstName,
            LastName : profile.LastName,
            Email : profile.Email,
            BirthDate : profile.BirthDate,
            PhoneNumber : profile.PhoneNumber
        );
    }
}
