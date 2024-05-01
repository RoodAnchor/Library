using Library.Repositories;
using Library.Utils;

namespace Library
{
    internal class Program
    {
        private static AppContext _context = new AppContext();
        private static GenreRepository _genres = new GenreRepository(_context);
        private static AuthorRepository _authors = new AuthorRepository(_context);
        private static BookRepository _books = new BookRepository(_context);
        private static UserRepository _users = new UserRepository(_context);

        static void Main(string[] args)
        {
            //DummyData dummyData = new DummyData(_authors, _genres, _users, _books);
            //dummyData.InsertData();
        }
    }
}