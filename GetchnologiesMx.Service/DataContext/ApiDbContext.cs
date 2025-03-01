using GetechnologiesMx.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using GetechnologiesMx.Service.Dtos;

namespace GetechnologiesMx.Service.DataContext
{
    public class ApiDbContext : DbContext
    {

        protected readonly IConfiguration Configuration;
        //private readonly string conString;

        public ApiDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
            //conString = Configuration["ConnectionStrings:GetechnologiesMxDB"].ToString();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("GetechnologiesMxDB"));
        }
        ///
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<VentasDtos> Ventas { get; set; }
    }
}
