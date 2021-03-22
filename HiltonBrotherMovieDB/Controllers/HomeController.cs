using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HiltonBrotherMovieDB.Models;
using HiltonBrotherMovieDB.Models.ViewModels;

namespace HiltonBrotherMovieDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMoviesRepository _repository;
        private MoviesDBContext _context;

        public HomeController(ILogger<HomeController> logger, IMoviesRepository repository,MoviesDBContext context)
        {
            _logger = logger;
            _repository = repository;
            _context = context;
            
        }

        public IActionResult Index()
        {
            return View();
        }
    
        [HttpGet("MoviePost")]

        public IActionResult MoviePost()
        {
            return View();
        }

        [HttpPost("MoviePost")]
        public IActionResult MoviePost(MovieEntry movieEntry)
        {
            if (ModelState.IsValid)
            {
                // save movie
                //TempStorage.addMovie(movieEntry);

                _context.Movies.Add(movieEntry);
                _context.SaveChanges();
                MovieList movies = new MovieList { Movies = _context.Movies.Where(m => m.Title != "Independance Day") };
                // go to Movie List
                return Redirect("/Home/EditMovie");
            }
            else
            {
                return View("MoviePost");
            }
            
        }


        // movie list
        public IActionResult MovieList()
        {
            //TempStorage.movieEntries.Where(movie => movie.Title != "Independance Day");
            return View(new MovieList { Movies = _context.Movies.Where(m => m.Title != "Independance Day") }) ;
        }

        // edit stuff
        [HttpGet]
        public IActionResult EditMovie()
        {
            return View(new MovieEditList { Movies = _context.Movies.Where(m => m.Title != "Independance Day"), Edit_ID = -1, Editing = false });
        }

        // for when its edited 
        [HttpPost]
        public IActionResult EditMovie(int movie_id)
        {
            return View(new MovieEditList { Movies = _context.Movies.Where(m => m.Title != "Independance Day"), Edit_ID = movie_id, Editing = true});
        }

        // save edited movie
        public IActionResult SaveEdit(int movie_id, string title, string rating, string year,bool edited,string director, string lentto, string notes)
        {
            // get edited movies
            MovieEntry movie = _context.Movies.Where(m => m.MovieEntryID == movie_id).FirstOrDefault();
            //update values
            movie.Title = title;
            movie.Rating = rating;
            movie.Year = year;
            movie.Edited = edited;
            movie.Director = director;
            movie.LentTo = lentto;
            movie.Notes = notes;

            _context.SaveChanges();

            return Redirect("/Home/EditMovie");
        }

        // delete movie
        public IActionResult DeleteMovie(int movie_id)
        {
            MovieEntry movie = _context.Movies.Where(m => m.MovieEntryID == movie_id).FirstOrDefault();
            _context.Remove(movie);
            _context.SaveChanges();
            return Redirect("/Home/EditMovie");
        }


        public IActionResult Podcasts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
