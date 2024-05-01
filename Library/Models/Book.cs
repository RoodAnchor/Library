namespace Library.Models
{
    public class Book
    {
        public Int32 Id { get; set; }
        public String? Title { get; set; }
        public DateTime PublishDate { get; set; }

        public Int32? UserId { get; set; }
        public User? User { get; set; }

        public Int32? GenreId { get; set; }
        public Genre? Genre { get; set; }

        public Int32? AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
