using Microsoft.EntityFrameworkCore;

namespace APIFilms.Models
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}