using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perla_metro_stations_service_api.src.Dtos;

namespace perla_metro_stations_service_api.src.Services
{
    /// <summary>
    /// Interfaz del servicio de estaciones.
    /// </summary>
    public interface IStationService
    {
        /// <summary>
        /// Obtiene todas las estaciones con filtros opcionales.
        /// </summary>
        /// <param name="name">Filtro opcional de nombre.</param>
        /// <param name="type">Filtro opcional de tipo de parada.</param>
        /// <param name="status">Filtro opcional de estado.</param>
        /// <returns>Retorna todas las estaciones, aplicando filtro si corresponde.</returns>
        Task<IEnumerable<StationDto?>> GetAllStations(string? name, string? type, string? status);
        /// <summary>
        /// Obtiene una estación por su ID.
        /// </summary>
        /// <param name="id">ID de la estación (UUID4).</param>
        /// <returns>Retorna la estación correspondiente al ID, mensaje de error si no existe.</returns>
        Task<StationDtoSearchID?> GetStationById(Guid id);
        /// <summary>
        /// Crea una nueva estación.
        /// </summary>
        /// <param name="station">Datos de la estación a crear.</param>
        /// <returns>Retorna la estación creada, mensaje de error en caso de fallo.</returns>
        Task<StationDto> CreateStation(CreateStationDto station);
        /// <summary>
        /// Actualiza una estación existente.
        /// </summary>
        /// <param name="station">Datos a actualizar.</param>
        /// <param name="id">ID de la estación a actualizar (UUID4).</param>
        /// <returns>Retorna la estación actualizada, mensaje de error si no existe o fallo.</returns>
        Task<StationDto?> UpdateStation(UpdateStationDto station, Guid id);
        /// <summary>
        /// Elimina una estación existente.
        /// </summary>
        /// <param name="id">ID de la estación a eliminar (UUID4).</param>
        /// <returns>Retorna la estación eliminada, mensaje de error si no existe.</returns>
        Task<StationDto?> DeleteStation(Guid id);
    }
}