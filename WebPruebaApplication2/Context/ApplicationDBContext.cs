﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPruebaApplication2.Entities;

namespace WebPruebaApplication2.Context
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

    }    
}
