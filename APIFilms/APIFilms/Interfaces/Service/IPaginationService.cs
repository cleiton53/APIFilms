using System.Collections.Generic;
using APIFilms.Models;

namespace APIFilms.Interfaces
{
    public interface IPaginationService
    {
        List<User> ReturnUserPagination(Pagination pagination, bool activeUsers);
        List<Vote> ReturnVotePagination(Pagination pagination);

    }
}