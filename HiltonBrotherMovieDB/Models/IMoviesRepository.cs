using System;
using System.Linq;
namespace HiltonBrotherMovieDB.Models
{
    public interface IMoviesRepository
    {
        IQueryable<MovieEntry> Movies { get; }

    }
}
