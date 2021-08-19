using APIFilms.Models;

namespace APIFilms.Interfaces
{
    public interface IUserService
    {
         void AddUser(User user);
         void EditUser(User user, string userActual, string passwordActual);
         void Disabled(string userName);
    }
}