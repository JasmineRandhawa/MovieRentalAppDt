
using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Models;
using System.Linq;
using MovieRentalApp.ViewModels;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using MovieRentalApp.Data;

namespace MovieRentalApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        List<Genre> dbGenreList = new List<Genre>();

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
            dbGenreList.AddRange(_context.Genres.ToList());
        }


        public ViewResult Index()
        {
            //List<Movie> moviesList = _context.Movies.Include(m => m.Genre).ToList();
            //return View("Index", moviesList);
            return View();
        }

        public ViewResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                 Genres = dbGenreList
             
            };
            return View("AddUpdateMovie",viewModel);
        }

        public ViewResult Edit(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = dbGenreList
            };
            return View("AddUpdateMovie",viewModel);
        }

        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = dbGenreList
                };

                return View("AddUpdateMovie", viewModel);
            }
            if (movie.Id == 0)
            {
                var maxid = 1;
                if (_context.Movies.ToList().Count > 0)
                maxid = _context.Movies.Select(c => c.Id).Max() + 1;
                movie.Id = maxid;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberOfStock = movie.NumberOfStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

        public IActionResult Remove(int id)
        {
           List<Movie> movies = _context.Movies.Where(c => c.Id == id).ToList();

            if (movies==null || movies.Count == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            foreach(Movie movie in movies)
            _context.Movies.Remove(movie);

            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

    }
}
