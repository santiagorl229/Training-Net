using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPruebaApplication2.Helpers
{
    public class MiFiltroDeExcepcion: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            
        }
    }
}
