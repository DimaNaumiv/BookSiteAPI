namespace APIBooks.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublisherYear { get; set; }
        public int Price { get; set; }
        public string Cover { get; set; }
        public int authorId { get; set; }
        public AuthorDTO Author { get; set; }
    }
}
