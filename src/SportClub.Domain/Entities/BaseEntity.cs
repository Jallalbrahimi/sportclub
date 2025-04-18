namespace SportClub.Domain.Entities
{
    public abstract class BaseEntity
    {
        // EF Core primary key
        public Guid Id { get; set; } = Guid.NewGuid();

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Soft delete support
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

    }

}
