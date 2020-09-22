using System.Collections.Generic;
using APIFilms.Models;
using APIFilms.Repositories;
using APIFilms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIFilms.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly Context _context;

        public UserController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate(string userName, string password)
        {
            UserRepository userRepository = new UserRepository(_context);
            var user = userRepository.Get(userName, password);
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        [Route("add")]
        public IActionResult PostCadastrar(User user)
        {
            UserService serviceUser = new UserService(_context);
            serviceUser.AddUser(user);
            return Ok();
        }

        [HttpPut]
        [Route("edit")]
        [Authorize]
        public IActionResult PutEditar(string actualUser, string passwordActual, User user)
        {
            UserService serviceUser = new UserService(_context);
            serviceUser.EditUser(user, actualUser, passwordActual);
            return Ok();
        } 

        [HttpGet]
        [Route("list-user-active")]
        [Authorize(Roles = "Admin")]
        public List<User> GetListUsers(Pagination pagination, bool activeUsers)
        {
            PaginationService services = new PaginationService(_context);

            return services.ReturnUserPagination(pagination, activeUsers);
        }  

        [HttpPost]
        [Route("disabled-user")]
        [Authorize(Roles = "Admin")]
        public IActionResult PostExcluir(string userName)
        {
            UserService userService = new UserService(_context);
            userService.Disabled(userName);
            return Ok();
        }
    }
}