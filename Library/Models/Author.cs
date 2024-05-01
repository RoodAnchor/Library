namespace Library.Models
{
    public class Author
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
