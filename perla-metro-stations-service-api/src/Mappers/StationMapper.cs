using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perla_metro_stations_service_api.src.Dtos;
using perla_metro_stations_service_api.src.Models;

namespace perla_metro_stations_service_api.src.Mappers
{
    public static class StationMapper
    {
        public static StationDto ToDto(Station station)
        {
            return new StationDto
            {
                Id = station.Id,
                Name = station.Name,
                Location = station.Location,
                StopType = station.StopType,
                IsActive = station.IsActive,
            };
        }
        public static Station ToEntity(StationDto stationDto)
        {
            return new Station
            {
                Id = stationDto.Id,
                Name = stationDto.Name,
                Location = stationDto.Location,
                StopType = stationDto.StopType,
                IsActive = stationDto.IsActive,
            };
        }
        public static Station editionToEntity(UpdateStationDto stationDto, Station existingStation)
        {
            return new Station
            {
                Id = existingStation.Id,
                Name = stationDto.Name ?? existingStation.Name,
                Location = stationDto.Location ?? existingStation.Location,
                StopType = stationDto.StopType ?? existingStation.StopType,
            };
        }
        public static Station createToEntity (CreateStationDto stationDto)
        {
            return new Station
            {
                Id = Guid.NewGuid(),
                Name = stationDto.Name,
                Location = stationDto.Location,
                StopType = stationDto.StopType,
                IsActive = stationDto.IsActive,
            };
        }
    }

}