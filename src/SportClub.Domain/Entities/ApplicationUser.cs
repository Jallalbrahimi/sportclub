namespace SportClub.Domain.Entities
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
    }
}
