using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        // *********************** ESTO VA SIEMPRE AL PPIO!! **************************

        //propiedades
        private readonly DbLibrosContext context;

        //constructor
        public LibroController(DbLibrosContext context)
        {
            this.context = context;

        }

        /* Programar las siguientes acciones:
            GET—> traer todos los libros
            GET—>traer todos los libros por autorId
            GET→ Traer uno por Id
            POST→Insertar libros, retornar un Ok()
            PUT→modificar libro, pasado id y modelo. retornar un NoContent()
            DELETE —>Eliminar libro. Retornar el libro eliminado */

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.ToList();
        }

        [HttpGet("id/{id}")]
        public ActionResult<Libro> GetByID(int id)
        {
            Libro libro = (from a in context.Libros
                           where a.Id == id
                           select a).SingleOrDefault();
            return libro;

        }

        [HttpGet("autorid/{autorid}")]
        public ActionResult<Libro> GetByAutorId(int autorid)
        {
            Libro libro = (from l in context.Libros
                           where l.AutorId== autorid
                           select l).SingleOrDefault();
            return libro;

        }
        [HttpPost]
        public ActionResult<Libro> Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Libros.Add(libro);
            context.SaveChanges();
            return Ok(); // devuelve el status code 200 ok 

        }

        [HttpPut("idymodelo/{id}/{titulo}")]
        public ActionResult<Libro> Put(int id,string titulo, [FromBody] Libro libro)
        {
            if (id != libro.Id && titulo != libro.Titulo)
            {
                return BadRequest();
            }

            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var libro = (from l in context.Libros
                         where l.Id == id
                         select l).SingleOrDefault();
            if (libro == null)
            {
                return NotFound();
            }
            context.Libros.Remove(libro);
            context.SaveChanges();
            return libro;

        }


    }
}
