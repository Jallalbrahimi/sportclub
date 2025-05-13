namespace SportClub.Domain.Entities
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;

        public Guid UserProfileId { get; set; }

        // Optional: Navigation property
        public required Profile UserProfile { get; set; }
    }
}
