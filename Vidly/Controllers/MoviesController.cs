using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {


        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().FirstOrDefault(i => i.Id == id);
            return View(movie);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            // instance of Movie 
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                //new Customer {Name = "Customer 1"},
                //new Customer {Name = "Customer 2"}, 
                //new Customer {Name = "Customer 3"}
            };

            //create viewmodel object
            var viewModel = new RandomMoviewViewModel()
            {
                // initialize its properties
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            //return Content("Hello world!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortyBy = "name"});

        }

        public ActionResult Edit(int movieId)
        {
            return Content("id=" + movieId);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
             {
                    new Movie{ Id = 1, Name = "Shrek" },
                    new Movie{ Id=2, Name= "Cats and Dogs"},
                    new Movie{ Id = 3, Name="Wall-e"}

                };
        }

    }
}