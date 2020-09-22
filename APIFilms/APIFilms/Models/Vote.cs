using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIFilms.Models
{
    public class Vote
    {
        [BindNever]
        public int Id { get; set; }
        public Film Film { get; set; }
        public Classification Classification { get; set; }
        public User User { get; set; }
    }
}