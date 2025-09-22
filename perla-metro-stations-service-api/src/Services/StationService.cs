using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        
        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }
        
        public async Task<IEnumerable<StationDto?>> GetAllStationsAsync()
        {
            return await _stationRepository.GetAllStationsAsync();
        }

        public async Task<StationDto?> GetStationByIdAsync(Guid id)
        {
            var station = await _stationRepository.GetStationByIdAsync(id);
            return station;
        }
        
        public async Task<StationDto> CreateStationAsync(StationDto station)
        {
            return await _stationRepository.AddStation(station);
        }

        public async Task UpdateStationAsync(StationDto station)
        {
            await _stationRepository.UpdateStationAsync(station);
        }
        
        public async Task DeleteStationAsync(Guid id)
        {
            await _stationRepository.DeleteStationAsync(id);
        }
    }
}