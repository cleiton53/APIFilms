using System.Collections.Generic;
using APIFilms.Models;
using APIFilms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIFilms.Controllers
{
    [Route("api/vote")]
    public class VoteController : ControllerBase
    {
        private readonly Context _context;
        private VoteService ServiceVote;

        public VoteController(Context context)
        {
            _context = context;
        }

        [HttpPost("vote")]
        public IActionResult PostVote(string userName, string password, int idFilm, Classification classification)
        {
            ServiceVote = new VoteService(_context);
            ServiceVote.AddVote(idFilm, classification, userName, password);
            return Ok();
        }

        [HttpGet("media-movies")]
        [Authorize]
        public List<MediaVote> GetMediaScoreFilms()
        {
            ServiceVote = new VoteService(_context);
            return ServiceVote.GetMoviesScoreMedia();
        }

        [HttpGet("media-movie")]
        public MediaVote GetMediaFilm(int idFilm)
        {
            ServiceVote = new VoteService(_context);
            MediaVote media = ServiceVote.GetMovieScoreMedia(idFilm);
            return media;
        }

        [HttpGet("movie-votes")]
        [AllowAnonymous]
        public List<Vote> GetVotesFilm(int idFilm)
        {
            ServiceVote = new VoteService(_context);
            List<Vote> votes = ServiceVote.GetMovieVote(idFilm);
            return votes;
        }

        [HttpGet("movie-votes-pagination")]
        [Authorize]
        public List<Vote> GetVotosPaginacao(Pagination pagination)
        {
            PaginationService ServicePagination = new PaginationService(_context);
            return ServicePagination.ReturnVotePagination(pagination);
        }
    }
}