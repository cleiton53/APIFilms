using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIFilms.Models
{
    public class Director
    {
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}