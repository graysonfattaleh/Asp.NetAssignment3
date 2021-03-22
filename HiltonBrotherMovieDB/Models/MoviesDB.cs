using System;
using Microsoft.EntityFrameworkCore;
namespace HiltonBrotherMovieDB.Models
{
    public class MoviesDBContext : DbContext
    {
        public MoviesDBContext(DbContextOptions<MoviesDBContext> options) : base(options)
        {

        }

        public DbSet<MovieEntry> Movies { get; set; }
    }

}
