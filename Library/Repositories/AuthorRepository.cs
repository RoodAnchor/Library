using Library.Models;
using Library.Exceptions;

namespace Library.Repositories
{
    public class AuthorRepository
    {
        private AppContext _context;

        public AuthorRepository(AppContext context) =>
            _context = context;

        public List<Author> GetAllAuthors() =>
            _context.Authors.ToList();

        public Author GetAuthor(Int32 id) =>
            _context.Authors.FirstOrDefault(x => x.Id == id);

        public void AddAuthor(Author author) 
        {
            try
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
            }   
            catch
            {
                throw;
            }
        }

        public void AddAuthors(params Author[] authors)
        {
            try
            {
                _context.Authors.AddRange(authors);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveAuthor(Author author)
        {
            try
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateAuthorName(Int32 authorId, String newName)
        {
            try
            {
                var author = GetAuthor(authorId);

                if (author == null) throw new UserNotFoundException();

                author.Name = newName;

                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
