namespace SportClub.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;

        public DateTime BirthDate { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}
