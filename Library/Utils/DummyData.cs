using Library.Models;
using Library.Repositories;

namespace Library.Utils
{
    internal class DummyData
    {
        private AuthorRepository _authors;
        private GenreRepository _genres;
        private UserRepository _users;
        private BookRepository _books;

        public DummyData(
            AuthorRepository authorRepository,
            GenreRepository genreRepository,
            UserRepository userRepository,
            BookRepository bookRepository)
        {
            _authors = authorRepository;
            _genres = genreRepository;
            _users = userRepository;
            _books = bookRepository;
        }

        internal void InsertData()
        {
            var genre1 = new Genre() { Name = "Detective" };
            var genre2 = new Genre() { Name = "Thriller" };
            var genre3 = new Genre() { Name = "Horror" };
            var genre4 = new Genre() { Name = "SciFi" };

            _genres.AddGenres(genre1, genre2, genre3, genre4);

            var author1 = new Author() { Name = "Guy Lambardo" };
            var author2 = new Author() { Name = "Steve Bushemy" };
            var author3 = new Author() { Name = "Motley Screw" };
            var author4 = new Author() { Name = "Brian Griffin" };

            _authors.AddAuthors(author1, author2, author3, author4);

            var user1 = new User() { Name = "Alex Squibee", Email = "alex.squibee@gmail.com" };
            var user2 = new User() { Name = "Don Carlionte", Email = "don.carlionte@gmail.com" };
            var user3 = new User() { Name = "Wind Isle", Email = "wind.isle@gmail.com" };
            var user4 = new User() { Name = "Mark Whaleberg", Email = "mark.whaleberg@gmail.com" };

            _users.AddUsers(user1, user2, user3, user4);

            var book1 = new Book() { Title = "Aliens", Author = author1, PublishDate = new DateTime(2020, 10, 12), Genre = genre3 };
            var book2 = new Book() { Title = "Witcher", Author = author2, PublishDate = new DateTime(2011, 5, 21), Genre = genre1 };
            var book3 = new Book() { Title = "Stalker", Author = author3, PublishDate = new DateTime(2001, 11, 6), Genre = genre4 };
            var book4 = new Book() { Title = "Home alone", Author = author4, PublishDate = new DateTime(1997, 10, 1), Genre = genre2 };
            var book5 = new Book() { Title = "Deliverence", Author = author2, PublishDate = new DateTime(2005, 6, 4), Genre = genre1 };
            var book6 = new Book() { Title = "Start wars", Author = author1, PublishDate = new DateTime(1996, 1, 5), Genre = genre4 };
            var book7 = new Book() { Title = "Fats and furious", Author = author4, PublishDate = new DateTime(2003, 7, 25), Genre = genre1 };

            _books.AddBooks(book1, book2, book3, book4, book5, book6, book7);
        }
    }
}
