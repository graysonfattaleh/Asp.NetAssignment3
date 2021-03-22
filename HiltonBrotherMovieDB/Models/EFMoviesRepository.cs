using System;
using System.Linq;
namespace HiltonBrotherMovieDB.Models
{
    public class EFMoviesRepository : IMoviesRepository
    {
        private MoviesDBContext _context;

        public EFMoviesRepository(MoviesDBContext context)
        {
            _context = context;
        }
        public IQueryable<MovieEntry> Movies => _context.Movies;
    }

}
