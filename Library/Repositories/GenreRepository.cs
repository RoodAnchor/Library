using Library.Models;
using Library.Exceptions;

namespace Library.Repositories
{
    public class GenreRepository
    {
        private AppContext _context;

        public GenreRepository(AppContext context) =>
            _context = context;

        public List<Genre> GetAllGenres() =>
            _context.Genres.ToList();

        public Genre GetGenre(Int32 id) =>
            _context.Genres.FirstOrDefault(x => x.Id == id);

        public void AddGenre(Genre genre)
        {
            try
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AddGenres(params Genre[] genres)
        {
            try
            {
                _context.Genres.AddRange(genres);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveGenre(Genre genre)
        {
            try
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateGenreName(Int32 genreId)
        {
            try
            {
                var genre = GetGenre(genreId);

                if (genre == null) throw new GenreNotFoundException();

                genre.Name = genre.Name;

                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
