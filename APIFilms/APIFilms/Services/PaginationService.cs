using System.Collections.Generic;
using APIFilms.Models;
using System.Linq;

namespace APIFilms.Services
{
    public class PaginationService
    {
        private readonly Context _context;

        public PaginationService(Context context)
        {
            _context = context;
        }

        public List<User> ReturnUserPagination(Pagination pagination, bool activeUsers)
        {
            int actualPage = pagination.NumberPage;
            int pageOfSize = pagination.PageOfSize;
            if (!activeUsers)
            {
                var usuarios = _context.Users.ToList();
                var items = usuarios.Skip((actualPage - 1) * pageOfSize).Take(pageOfSize).ToList();
                return items;
            }
            else
            {
                var orderUsers = _context.Users.Where(x => x.DisabledDate != null).OrderBy(x => x.UserName).ToList();
                var items = orderUsers.Skip((actualPage - 1) * pageOfSize).Take(pageOfSize).ToList();
                return items;
            }
        }

        public List<Vote> ReturnVotePagination(Pagination pagination)
        {
            var votos = _context.Votes.ToList();
            _context.Films.ToList();
            _context.Actors.ToList();
            _context.Directors.ToList();
            _context.Users.ToList();
            int actualPage = pagination.NumberPage;
            int pageOfSize = pagination.PageOfSize;
            var items = votos.Skip((actualPage - 1) * pageOfSize).Take(pageOfSize).ToList();

            return items;
        }
    }
}