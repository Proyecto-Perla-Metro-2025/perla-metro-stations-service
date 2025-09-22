using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perla_metro_stations_service_api.src.Dtos;
using perla_metro_stations_service_api.src.Mappers;
using perla_metro_stations_service_api.src.Models;
using perla_metro_stations_service_api.src.Repository;

namespace perla_metro_stations_service_api.src.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        
        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }
        
        public async Task<IEnumerable<StationDto?>> GetAllStations()
        {
            var stations = await _stationRepository.GetAllStations();
            var stationDtos = stations.Select(station => StationMapper.ToDto(station));
            return stationDtos;
        }

        public async Task<StationDto?> GetStationById(Guid id)
        {
            var station = await _stationRepository.GetStationById(id);
            return StationMapper.ToDto(station);
        }
        
        public async Task<StationDto> CreateStation(CreateStationDto station)
        {
            var stationEntity = StationMapper.createToEntity(station);
            var createdStation = await _stationRepository.AddStation(stationEntity);
            return StationMapper.ToDto(createdStation);
        }

        public async Task<StationDto?> UpdateStation(UpdateStationDto station, Guid id)
        {
            var existingStation = await _stationRepository.GetStationById(id);
            if (existingStation == null) return null;
            var stationEntity = StationMapper.editionToEntity(station, existingStation);
            var updatedStation = await _stationRepository.UpdateStation(stationEntity, id);
            return StationMapper.ToDto(updatedStation);
        }

        public async Task<StationDto?> DeleteStation(Guid id)
        {
            var deletedStation = await _stationRepository.DeleteStation(id);
            return StationMapper.ToDto(deletedStation);
        }
    }
}