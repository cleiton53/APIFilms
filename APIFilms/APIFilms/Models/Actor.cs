using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIFilms.Models
{
    public class Actor
    {
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}