using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos.Context
{
    internal class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {

        }  
        public DbSet<Producto> Productos { get; set; }
    }
}
