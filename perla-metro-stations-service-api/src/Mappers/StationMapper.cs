using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Mappers
{
    public static class StationMapper
    {
        public static StationDto ToDto(Station station)
        {
            if (station == null) return null;

            return new StationDto
            {
                Id = station.Id,
                Name = station.Name,
                Location = station.Location,
                stopType = station.StopType,
                isActive = station.IsActive,
            };
        }
        public static Station ToEntity(StationDto stationDto)
        {
            if (stationDto == null) return null;

            return new Station
            {
                Id = stationDto.Id,
                Name = stationDto.Name,
                Location = stationDto.Location,
                StopType = stationDto.stopType,
                IsActive = stationDto.isActive,
            };
        }
        public static Station editionToEntity(UpdateStationDto stationDto, Station existingStation)
        {
            if (stationDto == null || existingStation == null) return null;

            return new Station
            {
                Id = existingStation.Id,
                Name = stationDto.Name ?? existingStation.Name,
                Location = stationDto.Location ?? existingStation.Location,
                StopType = stationDto.stopType ?? existingStation.StopType,
                IsActive = stationDto.isActive ?? existingStation.IsActive,
            };
        }
    }

}