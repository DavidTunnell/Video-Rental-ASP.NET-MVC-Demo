using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Video_Rental.Models;
using Video_Rental.ViewModels;

namespace Video_Rental.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Star Wars" },
                new Movie { Id = 2, Name = "Billy Madison" }
            };
        }

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
                Movie = movie,
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