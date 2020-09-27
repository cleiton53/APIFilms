using System.Collections.Generic;
using APIFilms.Models;

namespace APIFilms.Interfaces
{
    public interface IVoteService
    {
         void AddVote(int idFilm, Classification classification, string userName, string password);
         List<MediaVote> GetMoviesScoreMedia();
         MediaVote GetMovieScoreMedia(int idFilm);
         List<Vote> GetMovieVote(int idFilm);
    }
}