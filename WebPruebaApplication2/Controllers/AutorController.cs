using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPruebaApplication2.Context;
using WebPruebaApplication2.Entities;
using WebPruebaApplication2.Helpers;

namespace WebPruebaApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly ILogger<AutorController> logger;
        public AutorController(ApplicationDBContext context, ILogger<AutorController> logger  )
        {
            this.context = context;
            this.logger = logger;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> Get(int id, [BindRequired] string param2)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if (autor==null){
                logger.LogWarning($"El autor de Id{id} no ha sido encontrado");
                return NotFound();
            }
            return autor;

        }

        [HttpGet("listado")]
        [ServiceFilter(typeof(MiFiltroDeAccion))]
        public ActionResult<IEnumerable<Autor>>Get()
        {
            logger.LogInformation("Obteniendo los autores");
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
            TryValidateModel(autor);
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
