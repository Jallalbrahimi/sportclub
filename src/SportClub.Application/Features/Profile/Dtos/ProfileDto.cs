namespace SportClub.Application.Features.UserProfile.Dtos
{
    public record ProfileDto(Guid Id, string FirstName, string LastName, string Email, DateTime BirthDate, string PhoneNumber);
}
