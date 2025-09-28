using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perla_metro_stations_service_api.src.Models;

namespace perla_metro_stations_service_api.src.Data
{
    /// <summary>
    /// Clase para sembrar datos iniciales en la base de datos.
    /// </summary>
    public static class Seeder
    {
        /// <summary>
        /// Método para sembrar datos iniciales en la base de datos.
        /// </summary>
        /// <param name="context">El contexto de la base de datos.</param>
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Stations.Any())
            {
                var stationsToSeed = new List<Station>
            {
                new Station
                {
                    Id = Guid.NewGuid(),
                    Name = "Estación Central",
                    Location = "Av. Central 1000",
                    StopType = "Origen",
                    IsActive = true
                },
                new Station
                {
                    Id = Guid.NewGuid(),
                    Name = "Estación La Portada",
                    Location = "Av. La Portada 2000",
                    StopType = "Destino",
                    IsActive = true
                },
                new Station
                {
                    Id = Guid.NewGuid(),
                    Name = "Estación Prat",
                    Location = "Calle Prat 3000",
                    StopType = "Intermedia",
                    IsActive = true
                },
                new Station
                {
                    Id = Guid.NewGuid(),
                    Name = "Estación Latorre",
                    Location = "Calle Latorre 4000",
                    StopType = "Intermedia",
                    IsActive = true
                },
                new Station
                {
                    Id = Guid.NewGuid(),
                    Name = "Estación Centro",
                    Location = "Av. Centro 5000",
                    StopType = "Intermedia",
                    IsActive = true
                },
                new Station
                {
                    Id = Guid.NewGuid(),
                    Name = "Estación Norte",
                    Location = "Av. Norte 6000",
                    StopType = "Destino",
                    IsActive = true
                },
                new Station
                {
                    Id = Guid.NewGuid(),
                    Name = "Estación Sur",
                    Location = "Av. Sur 7000",
                    StopType = "Origen",
                    IsActive = true
                },
                new Station
                {
                    Id = Guid.NewGuid(),
                    Name = "Estación Terminal",
                    Location = "Av. Terminal 8000",
                    StopType = "Destino",
                    IsActive = false // inactiva
                }
                };
                context.Stations.AddRange(stationsToSeed);
                context.SaveChanges();
            }
        }
    }
}