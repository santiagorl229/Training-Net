using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPruebaApplication2.Context;
using WebPruebaApplication2.Entities;

namespace WebPruebaApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public AutorController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}", Name = "obtenerAutor")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            return autor;
        }
        [HttpGet("listado")]
        public ActionResult<IEnumerable<Autor>>Get()
        {
            return context.Autores.ToList();
        }

        [HttpGet("Primer")]
        public ActionResult<Autor> GetPrimerAutor()
        {
            return context.Autores.FirstOrDefault();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            //if(!ModelState.IsValid){
            //    return BadRequest(ModelState);
            //}
            context.Autores.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("obtenerAutor", new { id = autor.Id }, autor);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;
        }

    }
}
