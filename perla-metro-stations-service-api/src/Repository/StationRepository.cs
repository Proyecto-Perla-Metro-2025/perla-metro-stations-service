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
            if (station == null) throw new StationNotFoundException("Station not found");

            station.IsActive = false;
            await _context.SaveChangesAsync();
            return station;
        }

        public async Task<IEnumerable<Station>> GetAllStations()
        {
            var stations = await _context.Stations.ToListAsync();
            if (stations.Count == 0) throw new StationNotFoundException("No stations found");
            return stations;
        }

        public async Task<Station?> GetStationById(Guid id)
        {
            var station = await _context.Stations.FindAsync(id);
            if (station == null) throw new StationNotFoundException("Station not found");
            if (!station.IsActive) throw new ArgumentException("Station is inactive");
            return station;
        }

        public async Task<Station?> UpdateStation(Station station, Guid id)
        {
            var existingStation = await _context.Stations.FindAsync(id);
            if (existingStation == null) throw new StationNotFoundException("Station not found");

            bool duplicated = await _context.Stations.AnyAsync(s => s.Id != id && s.Name == station.Name && s.Location == station.Location);
            if (duplicated) throw new DuplicateStationException("A station with the same name and location already exists");

            existingStation.Name = station.Name;
            existingStation.Location = station.Location;
            existingStation.StopType = station.StopType;
            existingStation.IsActive = station.IsActive;

            await _context.SaveChangesAsync();
            return existingStation;
        }
        public async Task<bool> StationExists(string name, string location)
        {
            return await _context.Stations.AnyAsync(s => s.Name == name && s.Location == location);
        }
    }
}