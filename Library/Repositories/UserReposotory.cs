using Microsoft.EntityFrameworkCore;

using Library.Exceptions;
using Library.Models;

namespace Library.Repositories
{
    public class UserRepository
    { 
        private AppContext _context;

        public UserRepository(AppContext context) =>
            _context = context;

        public List<User> GetUsers() =>
            _context.Users.Include(x => x.Books).ToList();

        public User GetUser(Int32 id) =>
            _context.Users.Include(x => x.Books).FirstOrDefault(x => x.Id == id);

        public void AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AddUsers(params User[] users)
        {
            try
            {
                _context.Users.AddRange(users);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveUser(User user)
        {
            try
            {
                _context.Remove(user);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUserName(Int32 userId, String newName) 
        {
            try
            {
                var user = GetUser(userId);

                if (user == null) throw new UserNotFoundException();

                user.Name = newName;

                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AssignBook(Int32 userId, Int32 bookId)
        {
            try
            {
                var user = GetUser(userId);
                var book = _context.Books.FirstOrDefault(x => x.Id == bookId);

                if (user == null) throw new UserNotFoundException();
                if (book == null) throw new BookNotFoundException();
                if (book.User != null) throw new BookIsAssignedException();

                user.Books.Add(book);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void ReturnBook(Int32 userId, Int32 bookId)
        {
            try
            {
                var user = GetUser(userId);
                if (user == null) throw new UserNotFoundException();

                var book = user.Books.FirstOrDefault(x => x.Id == bookId);
                if (book == null) throw new BookNotFoundException();

                user.Books.Remove(book);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Int32 GetAssignedBooksCount(Int32 userId)
        {
            var user = GetUser(userId);
            if (user == null) throw new UserNotFoundException();

            return user.Books.Count();
        }
    }
}
