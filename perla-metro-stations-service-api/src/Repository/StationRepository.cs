using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using perla_metro_stations_service_api.src.Data;
using perla_metro_stations_service_api.src.Models;
using perla_metro_stations_service_api.src.Exceptions;
namespace perla_metro_stations_service_api.src.Repository
{
    /// <summary>
    /// Implementación de la interfaz IStationRepository para el patrón Repository de estaciones.
    /// </summary>
    public class StationRepository : IStationRepository
    {
        /// <summary>
        /// Contexto de la base de datos.
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Constructor de la clase StationRepository.
        /// </summary>
        /// <param name="context"></param>
        public StationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Station> AddStation(Station station)
        {
            _context.Stations.Add(station);
            await _context.SaveChangesAsync();
            return station;
        }

        public async Task<Station?> DeleteStation(Guid id)
        {
            var station = await _context.Stations.FindAsync(id);
            if (station == null) return null;
            station.IsActive = false;
            await _context.SaveChangesAsync();
            return station;
        }

        public async Task<IEnumerable<Station>> GetAllStations()
        {
            var stations = await _context.Stations.ToListAsync();
            return stations;
        }

        public async Task<Station?> GetStationById(Guid id)
        {
            var station = await _context.Stations.FindAsync(id);
            if (station == null) return null;
            return station;
        }

        public async Task<Station?> UpdateStation(Station station)
        {
            var existingStation = await _context.Stations.FindAsync(station.Id);
            if (existingStation == null) return null;
            existingStation.Name = station.Name;
            existingStation.Location = station.Location;
            existingStation.StopType = station.StopType;
            existingStation.IsActive = station.IsActive;
            await _context.SaveChangesAsync();
            return existingStation;
        }
        public async Task<bool> StationExists(string name, Guid? id = null)
        {
            return await _context.Stations.AnyAsync(s => s.Name == name && (!id.HasValue || s.Id != id.Value));
        }
    }
}