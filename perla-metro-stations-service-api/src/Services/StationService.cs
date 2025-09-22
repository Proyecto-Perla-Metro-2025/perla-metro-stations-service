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
            var stations = await _stationRepository.GetAllStationsAsync();
            for (Station station : stations)
            {
                station = StationMapper.ToDto(station);
            }
            return stations;
        }

        public async Task<StationDto?> GetStationByIdAsync(Guid id)
        {
            var station = await _stationRepository.GetStationByIdAsync(id);
            return StationMapper.ToDto(station);
        }
        
        public async Task<StationDto> CreateStationAsync(StationDto station)
        {
            var stationEntity = StationMapper.ToEntity(station);
            var createdStation = await _stationRepository.AddStationAsync(stationEntity);
            return StationMapper.ToDto(createdStation);
        }

        public async Task<StationDto?> UpdateStationAsync(UpdateStationDto station, Guid id)
        {
            var existingStation = await _stationRepository.GetStationByIdAsync(id);
            if (existingStation == null) return null;
            var stationEntity = StationMapper.editionToEntity(station, existingStation);
            var updatedStation = await _stationRepository.UpdateStationAsync(stationEntity, id);
            return StationMapper.ToDto(updatedStation);
        }

        public async Task<StationDto?> DeleteStationAsync(Guid id)
        {
            var deletedStation = await _stationRepository.DeleteStationAsync(id);
            return StationMapper.ToDto(deletedStation);
        }
    }
}