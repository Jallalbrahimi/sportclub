namespace SportClub.Domain.Entities
{
    public class Publication : BaseEntity
    {
        /// <summary>
        /// The title of the publication.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// The content of the publication, which can be in Markdown format.
        /// </summary>
        public string Content { get; set; } = default!;

        /// <summary>
        /// The date when the publication was created.
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// The author of the publication.
        /// </summary>
        public ApplicationUser Author { get; set; } = default!;
    }
}
