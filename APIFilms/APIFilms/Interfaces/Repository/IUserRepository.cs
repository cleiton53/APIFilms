using APIFilms.Models;

namespace APIFilms.Interfaces
{
    public interface IUserRepository
    {
        User Get(string user, string password);
    }
}