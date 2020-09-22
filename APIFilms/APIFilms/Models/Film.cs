using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIFilms.Models
{
    public class Film
    {
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public Director Director { get; set; }
        public List<Actor> Actors { get; set; }
        public string Description {get; set;}

    }
}