using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        // *********************** ESTO VA SIEMPRE AL PPIO!! **************************

        //propiedades
        private readonly DbLibrosContext context;

        //constructor
        public AutorController(DbLibrosContext context)
        {
            this.context = context;

        }

        //Get api/autor
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.ToList();

        }
        //GET : api/autor/5
        [HttpGet("{id}")]
        public ActionResult<Autor> GetByID(int id)
        {
            Autor autor = (from a in context.Autores
                           where a.IdAutor== id
                           select a).SingleOrDefault();
            return autor;

        }
        // INSTERTAR 

        //POST : api/autor

        [HttpPost]
        public ActionResult<Autor> Post(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState) ;
            }
            context.Autores.Add(autor);
            context.SaveChanges();
            return Ok(); // devuelve el status code 200 ok 

        }

        // MODIFICAR

        //PUT: api/autor/2

        [HttpPut("{id}")]
        public ActionResult<Autor> Put(int id, [FromBody] Autor autor)
        {
            if (id != autor.IdAutor)
            {
                return BadRequest();
            }

            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }

        // BORRAR _ DELETE

        // DELETE: Api/autor/2

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = (from a in context.Autores
                         where a.IdAutor== id
                         select a).SingleOrDefault();
            if(autor == null)
            {
                return NotFound();
            }
            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;

        }

        // GET TRAER POR NOMBRE 
        //SE USA LISTA PORQUE PUEDEN TRAER VARIOS

        [HttpGet("nombre/{nombre}")]
        public ActionResult<IEnumerable<Autor>> GetByName(string nombre)
        {
            List<Autor> autores = (from a in context.Autores
                             where a.Nombre == nombre
                             select a).ToList();

            return autores;
        }

        //GET TRAER POR NOMBRE Y APELLIDO

        [HttpGet("nombreyapellido/{nombre}/{apellido}")]
        public ActionResult<Autor> GetByNameApellido(string nombre, string apellido)
        {
            Autor autor = (from a in context.Autores
                           where a.Nombre == nombre && a.Apellido == apellido
                           select a).SingleOrDefault();

            return autor;
        }

        //TRAER POR EDAD 
        //SE USA LISTA PORQUE PUEDEN TRAER VARIOS

        [HttpGet("edad/{edad}")]
        public ActionResult<IEnumerable<Autor>> GetByEdad(int edad)
        {
            List<Autor> autores = (from a in context.Autores
                           where a.Edad == edad
                           select a).ToList();

            return autores;
        }


    }
}
