using Microsoft.EntityFrameworkCore;

using Library.Exceptions;
using Library.Models;

namespace Library.Repositories
{
    public class BookRepository
    {
        private AppContext _context;

        public BookRepository(AppContext context) =>
            _context = context;

        public List<Book> GetBooks() =>
            _context.Books.ToList();

        public List<Book> GetBooks(
            Int32 genreId, 
            Int32 yearFrom, 
            Int32 yearTo) =>
            _context.Books
                .Where(x =>
                    x.GenreId == genreId &&
                    x.PublishDate >= new DateTime(yearFrom, 1, 1) && x.PublishDate <= new DateTime(yearTo, 12, 30))
                .ToList();

        public Book GetBook(Int32 id) =>
            _context.Books.Include(x => x.User).FirstOrDefault(x => x.Id == id);

        public Book GetLatestBook() =>
            _context.Books.OrderByDescending(x => x.PublishDate).FirstOrDefault();

        public List<Book> GetBooksOrderedByTitleAsc() =>
            _context.Books.OrderBy(x => x.Title).ToList();

        public List<Book> GetBooksOrderedByDateDesc() =>
            _context.Books.OrderByDescending(x => x.PublishDate).ToList();

        public Int32 GetBooksCount(Author author) =>
            _context.Books.Where(x => x.AuthorId == author.Id).Count();

        public Int32 GetBooksCount(Genre genre) =>
            _context.Books.Where(x => x.GenreId == genre.Id).Count();

        public Boolean BookExist(Int32 authorId, String title) => 
            _context.Books.Any(x => x.AuthorId == authorId && x.Title.ToLower() == title.ToLower());

        public Boolean IsBookAssignedToUser(Int32 bookId, Int32 userId)
        {
            var book = GetBook(bookId);

            if (book != null &&
                book.UserId != null &&
                book.UserId == userId)
                return true;

            return false;
        }

        public void AddBook(Book book) 
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AddBooks(params Book[] books)
        {
            try
            {
                _context.Books.AddRange(books);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveBook(Book book)
        {
            try
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateBookCreated(Int32 bookId, DateTime newDate) 
        {
            try
            {
                var book = GetBook(bookId);

                if (book == null) throw new BookNotFoundException();

                book.PublishDate = newDate;

                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
