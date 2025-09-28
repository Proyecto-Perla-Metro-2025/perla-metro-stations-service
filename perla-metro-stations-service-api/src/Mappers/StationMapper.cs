using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perla_metro_stations_service_api.src.Dtos;
using perla_metro_stations_service_api.src.Models;

namespace perla_metro_stations_service_api.src.Mappers
{
    /// <summary>
    /// Clase para estática para mapear entre entidades y DTOs de estación.
    /// </summary>
    public static class StationMapper
    {
        /// <summary>
        /// Método estático para mapear una entidad Station a un DTO StationDto.
        /// </summary>
        /// <param name="station">Entidad de la estación.</param>
        /// <returns>Retorna la estación como DTO.</returns>
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
        /// <summary>
        /// Método estático para mapear un DTO StationDto a una entidad Station.
        /// </summary>
        /// <param name="stationDto">Estación como DTO.</param>
        /// <returns>Retorna la estación como entidad.</returns>
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
        /// <summary>
        /// Método estático para mapear un DTO UpdateStationDto a una entidad Station existente.
        /// </summary>
        /// <param name="stationDto">Formulario de actualizar una estación como DTO.</param>
        /// <param name="existingStation">Estación existente.</param>
        /// <returns>Retorna la estación como entidad.</returns>
        public static Station editionToEntity(UpdateStationDto stationDto, Station existingStation)
        {
            return new Station
            {
                Id = existingStation.Id,
                Name = !string.IsNullOrEmpty(stationDto.Name) ? stationDto.Name : existingStation.Name,
                Location = !string.IsNullOrEmpty(stationDto.Location) ? stationDto.Location : existingStation.Location,
                StopType = !string.IsNullOrEmpty(stationDto.StopType) ? stationDto.StopType : existingStation.StopType,
            };
        }
        /// <summary>
        /// Método estático para mapear un DTO CreateStationDto a una nueva entidad Station.
        /// </summary>
        /// <param name="stationDto">Formulario de crear una estación como DTO.</param>
        /// <returns>Retorna la estación como entidad.</returns>
        public static Station createToEntity(CreateStationDto stationDto)
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
        public static StationDtoSearchID ToDtoSearchID(Station station)
        {
            return new StationDtoSearchID
            {
                Id = station.Id,
                Name = station.Name,
                Location = station.Location,
                StopType = station.StopType,
                Status = station.IsActive ? "Active" : null,
                IsActive = station.IsActive,
            };
        }
    }
}