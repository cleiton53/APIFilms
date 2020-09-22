using System;
using System.Linq;
using APIFilms.Models;

namespace APIFilms.Services
{
    public class UserService
    {
        private readonly Context _context;

        public UserService(Context context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                Cryptography crip = new Cryptography();
                var passwordCrip = string.IsNullOrEmpty(user.Password) ? user.Password : crip.GenerateHashMd5(user.Password);
                user.Password = passwordCrip;
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public void EditUser(User user, string userActual, string passwordActual)
        {
            Cryptography crip = new Cryptography();
            var passwordCrip = string.IsNullOrEmpty(user.Password) ? user.Password : crip.GenerateHashMd5(user.Password);
            if (user != null 
                && !string.IsNullOrEmpty(passwordCrip)
                && !string.IsNullOrEmpty(passwordActual))
            {
                var updateUser = (from a in _context.Users
                                  where a.UserName == userActual && a.Password == passwordCrip
                                  select a).SingleOrDefault();

                if(updateUser != null)
                {
                    updateUser.UserName = user.UserName;
                    updateUser.Password = crip.GenerateHashMd5(user.Password);
                    updateUser.Role = user.Role;
                    updateUser.DisabledDate = user.DisabledDate;

                    _context.SaveChanges();
                }
            }

        }

        public void Disabled(string userName)
        {
            if(!string.IsNullOrEmpty(userName))
            {
                var user = _context.Users.FirstOrDefault(a => a.UserName == userName);
                user.DisabledDate = DateTime.Now;

                if(user != null)
                {
                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
            }
        }
    }
}