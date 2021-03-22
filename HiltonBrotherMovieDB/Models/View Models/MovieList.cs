using System;
using System.Collections.Generic;
namespace HiltonBrotherMovieDB.Models.ViewModels
{
    public class MovieList
    {
           public IEnumerable<MovieEntry> Movies { get; set; }
    }
}
