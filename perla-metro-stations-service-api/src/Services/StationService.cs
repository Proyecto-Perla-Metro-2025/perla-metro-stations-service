using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perla_metro_stations_service_api.src.Dtos;
using perla_metro_stations_service_api.src.Exceptions;
using perla_metro_stations_service_api.src.Mappers;
using perla_metro_stations_service_api.src.Models;
using perla_metro_stations_service_api.src.Repository;

namespace perla_metro_stations_service_api.src.Services
{
    /// <summary>
    /// Implementación del servicio de estaciones.
    /// </summary>
    public class StationService : IStationService
    {
        /// <summary>
        /// Repository de las estaciones.
        /// </summary>
        private readonly IStationRepository _stationRepository;

        /// <summary>
        /// Constructor de la clase StationService.
        /// </summary>
        /// <param name="stationRepository">Repository de las estaciones.</param>
        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<IEnumerable<StationDto?>> GetAllStations(string? name, string? type, string? status)
        {
            var stations = await _stationRepository.GetAllStations();
            if (stations.Count() == 0) throw new StationNotFoundException("No stations found"); 
            if (!string.IsNullOrEmpty(name))
            {
                stations = stations.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(type))
            {
                stations = stations.Where(s => s.StopType.Equals(type, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(status))
            {
                if (status.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    stations = stations.Where(s => s.IsActive);
                }
                else if (status.Equals("false", StringComparison.OrdinalIgnoreCase))
                {
                    stations = stations.Where(s => !s.IsActive);
                }
            }
            var stationDtos = stations.Select(station => StationMapper.ToDto(station));
            return stationDtos;
        }

        public async Task<StationDtoSearchID?> GetStationById(Guid id)
        {
            var station = await _stationRepository.GetStationById(id);
            if (station == null) throw new StationNotFoundException("Station not found");
            return StationMapper.ToDtoSearchID(station);
        }

        public async Task<StationDto> CreateStation(CreateStationDto station)
        {
            var stationEntity = StationMapper.createToEntity(station);
            if (await _stationRepository.StationExists(stationEntity.Name))
            {
                throw new DuplicateStationException("A station with the same name already exists");
            }
            var createdStation = await _stationRepository.AddStation(stationEntity);
            return StationMapper.ToDto(createdStation);
        }

        public async Task<StationDto?> UpdateStation(UpdateStationDto station, Guid id)
        {
            var existingStation = await _stationRepository.GetStationById(id);
            if (existingStation == null) throw new StationNotFoundException("Station not found");

            if (!string.IsNullOrEmpty(station.Name) && station.Name != existingStation.Name)
            {
                bool duplicated = await _stationRepository.StationExists(station.Name, id);
                if (duplicated) throw new DuplicateStationException("A station with the same name already exists");
            }

            var stationEntity = StationMapper.editionToEntity(station, existingStation);
            var updatedStation = await _stationRepository.UpdateStation(stationEntity);
            return StationMapper.ToDto(updatedStation);
        }

        public async Task<StationDto?> DeleteStation(Guid id)
        {
            var deletedStation = await _stationRepository.DeleteStation(id);
            if (deletedStation == null) throw new StationNotFoundException("Station not found");
            return StationMapper.ToDto(deletedStation);
        }
    }
}