using APIFilms.Interfaces;
using APIFilms.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIFilms.Services
{
    public class VoteService : IVoteService
    {
        private readonly Context _context;

        public VoteService(Context context)
        {
            _context = context;
        }

        public void AddVote(int idFilm, Classification classification, string userName, string password)
        {
            Cryptography crip = new Cryptography();
            var passwordCrip = string.IsNullOrEmpty(password) ? password : crip.GenerateHashMd5(password);
            var film = _context.Films.FirstOrDefault(f => f.Id == idFilm);
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == passwordCrip && x.DisabledDate == null);
            Vote vote = new Vote();
            vote.User = user;
            vote.Film = film;
            vote.Classification = classification;

            if (film != null && user != null)
            {
                _context.Votes.Add(vote);
                _context.SaveChanges();
            }
        }

        public List<MediaVote> GetMoviesScoreMedia()
        {
            var votes = _context.Votes.ToList();
            _context.Actors.ToList();
            _context.Directors.ToList();
            List<MediaVote> listMedia = new List<MediaVote>();
            MediaVote media;
            var films = _context.Films.ToList();
            foreach (var film in films)
            {
                var mediaVotos = votes
                    .Where(x => x.Film.Id == film.Id)
                    .Average(x => (int)x.Classification);
                media = new MediaVote();
                media.Film = film;
                media.Punctuation = Math.Round(mediaVotos);

                listMedia.Add(media);
            }

            var listaOrdenada = listMedia.GroupBy(x => new { x.Film.Name, x.Punctuation })
                                             .Select(group => new
                                             {
                                                 group.Key.Name,
                                                 group.Key.Punctuation
                                             })
                                             .OrderBy(ord => new { ord.Name, ord.Punctuation });
            return listMedia;
        }

        public MediaVote GetMovieScoreMedia(int idFilm)
        {
            var votes = _context.Votes
                .Where(f => f.Film.Id == idFilm).ToList();

            var mediaVotes = votes.Average(x => (int)x.Classification);
            _context.Actors.ToList();
            _context.Directors.ToList();

            MediaVote media = new MediaVote();
            media.Punctuation = Math.Round(mediaVotes);
            media.Film = _context.Films
                .FirstOrDefault(f => f.Id == idFilm);
            return media;
        }

        public List<Vote> GetMovieVote(int idFilm)
        {
            var votes = _context.Votes
                .Where(f => f.Film.Id == idFilm).ToList();
            _context.Films.ToList();
            _context.Actors.ToList();
            _context.Directors.ToList();
            _context.Users.ToList();
            return votes;
        }

    }
}