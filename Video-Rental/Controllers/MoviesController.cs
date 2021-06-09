using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Video_Rental.Models;
using Video_Rental.ViewModels;
using System.Data.Entity;

namespace Video_Rental.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(c => c.Genre).SingleOrDefault(m => m.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);

        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        //private List<Movies> GetMovies()
        //{
        //    return new List<Movies>
        //    {
        //        new Movie { Id = 1, Name = "Star Wars" },
        //        new Movie { Id = 2, Name = "Billy Madison" }
        //    };
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("Id=" + id);
        //}

        //// Will be called when navigated to /movies
        ////if pageIndex is not passed, pick 1, if sortBy isn't picked, sort by name. 
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (String.IsNullOrWhiteSpace(sortBy)) {
        //        sortBy = "Name";
        //    }
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        //}

        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        //public ActionResult ByReleaseDate(int year, byte month)
        //{

        //    return Content(year + "/" + month);
        //}

        // GET: Movies/Random
        public ActionResult Random()
        {

            var movie = new Movie() { Name = "Shrek!" };

            // two other ways to pass data to views instead of return View(movie);
            //View Data Dictonary
            //ViewData["Movie"] = movie;
            //View Bag
            //ViewBag.Movie = movie;
            //return View();


            var customers = new List<Customer> {
                new Customer { Name = "Scuppy 55" },
                new Customer { Name = "Driddle 66"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movies = movie,
                Customers = customers
            };

            //preferable approach
            //return View(movie);

            return View(viewModel);

            //return new EmptyResult(); //returns empty
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); //redirects to the home page and passes parameters to the URL
        }

    }
}