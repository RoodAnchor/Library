namespace Library.Models
{
    public class User
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public String? Email { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
