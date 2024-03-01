using GetechnologiesMx.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetechnologiesMx.Service.DataContext
{
    public class ApiDbContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public ApiDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        ////protected override void OnConfiguring(DbContextOptionsBuilder options)
        ////{
        ////    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        ////}
        ///
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Persona> Persona { get; set; }
    }
}
