using APIFilms.Interfaces;
using APIFilms.Models;
using APIFilms.Services;
// using APIFilms.Services;
using System.Linq;

namespace APIFilms.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public User Get(string user, string password)
        {
            var users = _context.Users.ToList();
            Cryptography crip = new Cryptography();
            var encriptPassword = string.IsNullOrEmpty(password) ? password : crip.GenerateHashMd5(password);

            return users.Where(x => x.UserName.ToLower() == user.ToLower() && x.Password == encriptPassword).FirstOrDefault();

        }
    }
}