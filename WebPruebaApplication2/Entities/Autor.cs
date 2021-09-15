using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebPruebaApplication2.Helpers;

namespace WebPruebaApplication2.Entities
{
    public class Autor
    {

        public int Id { get; set; }

        [Required]
        [PrimerLetraMayuscula]
        public string Nombre { get; set; }
    }
}
