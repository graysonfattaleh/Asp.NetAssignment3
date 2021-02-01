using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HiltonBrotherMovieDB.Models;

namespace HiltonBrotherMovieDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                TempStorage.addMovie(movieEntry);
                // go to Movie List
                return View("MovieList");
            }
            else
            {
                return View("MoviePost");
            }
            
        }


        // movie list
        public IActionResult MovieList()
        {
            return View(TempStorage.movieEntries);
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
