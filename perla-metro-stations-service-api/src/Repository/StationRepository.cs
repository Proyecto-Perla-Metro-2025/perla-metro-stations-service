using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using perla_metro_stations_service_api.src.Data;
using perla_metro_stations_service_api.src.Models;

namespace perla_metro_stations_service_api.src.Repository
{
    public class StationRepository : IStationRepository
    {
        private readonly ApplicationDbContext _context;
        public StationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Station> AddStation(Station station)
        {
            if (await GetStationById(station.Id) != null)
            {
                throw new ArgumentException("Ya existe una estación con el mismo ID");
            }
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
            return Station;
        }

        public async Task<IEnumerable<Station>> GetAllStations()
        {
            return await _context.Stations.Where(s => s.IsActive).ToListAsync();
        }

        public Task<Station?> GetStationById(Guid id)
        {
            return _context.Stations.FindAsync(id).AsTask();
        }

        public async Task<Station?> UpdateStation(Station station, Guid id)
        {
            var existingStation = await _context.Stations.FindAsync(id);
            if (existingStation == null) return null;

            existingStation.Name = station.Name;
            existingStation.Line = station.Line;
            existingStation.IsActive = station.IsActive;

            await _context.SaveChangesAsync();
            return existingStation;
        }
    }
}