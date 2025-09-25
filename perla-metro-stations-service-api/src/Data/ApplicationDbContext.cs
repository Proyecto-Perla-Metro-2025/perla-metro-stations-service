using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace perla_metro_stations_service_api.src.Data
{
    /// <summary>
    /// Clase para la conexión con la base de datos.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor de la clase ApplicationDbContext.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        /// <summary>
        /// DbSet de las estaciones.
        /// </summary>
        public DbSet<Models.Station> Stations { get; set; }
    }
}