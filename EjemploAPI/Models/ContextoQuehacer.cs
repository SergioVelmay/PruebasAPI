using Microsoft.EntityFrameworkCore;
using EjemploAPI.Models;

namespace EjemploAPI.Models
{
    public class ContextoQuehacer : DbContext
    {
        public ContextoQuehacer(DbContextOptions<ContextoQuehacer> opciones) : base(opciones)
        {
        }

        public DbSet<Quehacer> Quehaceres { get; set; }

        public DbSet<Book> Book { get; set; }
    }
}
