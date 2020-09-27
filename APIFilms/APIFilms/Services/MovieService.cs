using System;
using System.Collections.Generic;
using System.Linq;
using APIFilms.Interfaces;
using APIFilms.Models;

namespace APIFilms.Services
{
    public class MovieService : IMovieService
    {
        private readonly Context _context;

        public MovieService(Context context)
        {
            _context = context;
        }

        public void AddMovie(Film film)
        {

            List<Actor> list = new List<Actor>();
            if (film.Actors.Count == 0)
            {
                Actor actor1 = new Actor()
                {
                    Name = "Jeniffer Lopez"
                };

                Actor actor2 = new Actor()
                {
                    Name = "Leonardo DiCaprio"
                };

                list.Add(actor1);
                list.Add(actor2);
            }

            film.Actors = film.Actors.Count == 0 ? list : film.Actors;
            film.Description = film.Description;

            _context.Add(film);
            _context.SaveChanges();

        }

        public List<Film> GetMovies()
        {
            List<Film> films = new List<Film>();
            var listfilms = _context.Films.ToList();
            _context.Actors.ToList();
            _context.Directors.ToList();
            return listfilms;
        }

        public void PopulateTables()
        {
            Actor actor1 = new Actor()
            {
                Name = "Jeniffer Lopez"
            };

            Actor actor2 = new Actor()
            {
                Name = "Leonardo DiCaprio"
            };
            Actor actor3 = new Actor()
            {
                Name = "Tim Robbins"
            };

            Actor actor4 = new Actor()
            {
                Name = "Morgan Freeman"
            };
            Actor actor5 = new Actor()
            {
                Name = "Bob Gunton"
            };

            Actor actor6 = new Actor()
            {
                Name = "Willian Sadler"
            };

            List<Actor> listActors1 = new List<Actor>();
            listActors1.Add(actor1);
            listActors1.Add(actor2);

            List<Actor> listActors2 = new List<Actor>();
            listActors2.Add(actor3);
            listActors2.Add(actor4);
            listActors2.Add(actor5);
            listActors2.Add(actor6);

            Director director1 = new Director()
            {
                Name = "Steven Spielberg"
            };

            Director director2 = new Director()
            {
                Name = "Frank Darabont"
            };

            Film film1 = new Film();
            film1.Name = "The Dream";
            film1.Genre = Genre.Documentary;
            film1.Director = director1;
            film1.Actors = listActors1;
            film1.Description = "Freddy Krueger returns once again to terrorize the dreams of the remaining Dream Warriors, as well as those of a young woman who may be able to defeat him for good.";

            Film film2 = new Film();
            film2.Name = "The Shawshank Redemption";
            film2.Genre = Genre.Action;
            film2.Director = director2;
            film2.Actors = listActors2;
            film2.Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.";

            if (_context.Films.Count() == 0)
            {
                _context.Films.Add(film1);
                _context.Films.Add(film2);
            }


            Cryptography crip = new Cryptography();
            User user1 = new User()
            {
                UserName = "Jose",
                Password = crip.GenerateHashMd5("Admin1"),
                Role = "Admin",
                DisabledDate = null
            };

            User user2 = new User()
            {
                UserName = "Paulo",
                Password = crip.GenerateHashMd5("Admin2"),
                Role = "Admin",
                DisabledDate = DateTime.Now
            };

            User user3 = new User()
            {
                UserName = "Lucas",
                Password = crip.GenerateHashMd5("Employee1"),
                Role = "Emp",
                DisabledDate = null
            };

            User user4 = new User()
            {
                UserName = "Fernando",
                Password = crip.GenerateHashMd5("Employee2"),
                Role = "Emp",
                DisabledDate = null
            };

            User user5 = new User()
            {
                UserName = "Wesley",
                Password = crip.GenerateHashMd5("Employee2"),
                Role = "Emp",
                DisabledDate = DateTime.Now
            };

            List<User> users = new List<User>();
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
            users.Add(user5);
            _context.Users.AddRange(users);

            Vote vote1 = new Vote()
            {
                Classification = Classification.Good,
                Film = film1,
                User = user2
            };
            Vote vote2 = new Vote()
            {
                Classification = Classification.TooBad,
                Film = film1,
                User = user5
            };
            Vote vote3 = new Vote()
            {
                Classification = Classification.Great,
                Film = film1,
                User = user3
            };
            Vote vote4 = new Vote()
            {
                Classification = Classification.Good,
                Film = film1,
                User = user4
            };
            Vote vote5 = new Vote()
            {
                Classification = Classification.Bad,
                Film = film1,
                User = user1
            };
            Vote vote6 = new Vote()
            {
                Classification = Classification.Great,
                Film = film2,
                User = user1
            };
            Vote vote7 = new Vote()
            {
                Classification = Classification.Great,
                Film = film2,
                User = user3
            };
            List<Vote> votes = new List<Vote>();
            votes.Add(vote1);
            votes.Add(vote2);
            votes.Add(vote3);
            votes.Add(vote4);
            votes.Add(vote5);
            votes.Add(vote6);
            votes.Add(vote7);
            _context.Votes.AddRange(votes);


            _context.SaveChanges();


        }

        public void Clear()
        {
            var removeAllActors = _context.Actors.ToList();
            _context.RemoveRange(removeAllActors);
            var removeAllDirectors = _context.Directors.ToList();
            _context.RemoveRange(removeAllDirectors);
            var removeAllVotes = _context.Votes.ToList();
            _context.RemoveRange(removeAllVotes);
            var removeAllUsers = _context.Users.ToList();
            _context.RemoveRange(removeAllUsers);
            var removeAllFilms = _context.Films.ToList();
            _context.RemoveRange(removeAllFilms);

            _context.SaveChanges();
        }
    }
}