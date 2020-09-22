using System.Collections.Generic;
using APIFilms.Models;
using APIFilms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIFilms.Controllers
{
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private MovieService serviceMovie;
        private readonly Context _context;

        public MovieController(Context context)
        {
            _context = context;
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult PostCadastrar(Film movie)
        {
            if (movie != null)
            {
                serviceMovie = new MovieService(_context);
                serviceMovie.AddMovie(movie);
            }
            return Accepted();
        }

        [HttpGet]
        [Route("get-movies")]
        [Authorize]
        public List<Film> GetMovies()
        {
            serviceMovie = new MovieService(_context);
            var movies = serviceMovie.GetMovies();
            return movies;

        }

        [HttpPost("populate-table")]
        public IActionResult PostPopulateTable()
        {
            serviceMovie = new MovieService(_context);
            serviceMovie.PopulateTables();

            return Ok();
        }

        [HttpDelete("delete-data")]
        public IActionResult DeleteData()
        {
            serviceMovie = new MovieService(_context);
            serviceMovie.Clear();

            return Ok();
        }

    }
}