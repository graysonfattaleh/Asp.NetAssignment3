using System;
using System.Collections.Generic;

namespace HiltonBrotherMovieDB.Models.ViewModels
{
    public class MovieEditList
    {
        public IEnumerable<MovieEntry> Movies { get; set; }
        public int Edit_ID { get; set; }
        public bool Editing { get; set; }
    }
}
