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
                throw new ArgumentException("A station with the same ID already exists");
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
            return station;
        }

        public async Task<IEnumerable<Station>> GetAllStations()
        {
            var stations = await _context.Stations.ToListAsync();
            if (stations == null) throw new ArgumentException("No stations found");
            return stations;
        }

        public async Task<Station?> GetStationById(Guid id)
        {
            var station = await _context.Stations.FindAsync(id);
            if (station != null && station.IsActive)
            {
                return station;
            }
            return null;
        }

        public async Task<Station?> UpdateStation(Station station, Guid id)
        {
            var existingStation = await _context.Stations.FindAsync(id);
            if (existingStation == null) return null;

            existingStation.Name = station.Name;
            existingStation.Location = station.Location;
            existingStation.StopType = station.StopType;
            existingStation.IsActive = station.IsActive;

            await _context.SaveChangesAsync();
            return existingStation;
        }
    }
}