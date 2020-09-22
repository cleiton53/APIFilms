using System;

namespace APIFilms.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }    
        public DateTime? DisabledDate { get; set; }
    }
}