using Microsoft.EntityFrameworkCore;//Agregar
using WebApiLibros.Models;//agregar
namespace WebApiLibros.Data
{
    public class DbLibrosContext : DbContext
    {
        //constructor
        public DbLibrosContext(DbContextOptions<DbLibrosContext> options) : base(options) { }

        //Propiedades
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

    }
}
