using System.Collections.Generic;
using APIFilms.Models;

namespace APIFilms.Interfaces
{
    public interface IMovieService
    {
        void AddMovie(Film film);
        List<Film> GetMovies();
        void PopulateTables();
        void Clear();
    }
}