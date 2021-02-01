using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace HiltonBrotherMovieDB.Models
{
    public static class TempStorage
    {
        private static List<MovieEntry> movie_entries = new List<MovieEntry>();

        // iteratable list
        public static IEnumerable<MovieEntry> movieEntries => movie_entries;

        public static void addMovie(MovieEntry movie)
        {
            movie_entries.Add(movie);
        }
    }
}
