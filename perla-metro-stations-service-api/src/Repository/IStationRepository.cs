using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perla_metro_stations_service_api.src.Models;

namespace perla_metro_stations_service_api.src.Repository
{
    /// <summary>
    /// Interfaz para el patrón Repository de estaciones.
    /// </summary>
    public interface IStationRepository
    {
        /// <summary>
        /// Método para obtener todas las estaciones.
        /// </summary>
        /// <returns>Retorna todas las estaciones.</returns>
        Task<IEnumerable<Station>> GetAllStations();
        /// <summary>
        /// Método para obtener una estación por su ID.
        /// </summary>
        /// <param name="id">ID de la estación a buscar(UUID4).</param>
        /// <returns>Retorna la estación correspondiente al ID, error en caso de no encontrarla.</returns>
        Task<Station?> GetStationById(Guid id);
        /// <summary>
        /// Método para agregar una nueva estación.
        /// </summary>
        /// <param name="station">Estación a agregar.</param>
        /// <returns>Retorna la estación agregada, error en caso de no poder agregarla.</returns>
        Task<Station> AddStation(Station station);
        /// <summary>
        /// Método para actualizar una estación existente.
        /// </summary>
        /// <param name="station">Datos a actualizar.</param>
        /// <param name="id">ID de la estación a actualizar (UUID4).</param>
        /// <returns>Retorna la estación actualizada, error en caso de no encontrarla.</returns>
        Task<Station?> UpdateStation(Station station, Guid id);
        /// <summary>
        /// Método para eliminar una estación por su ID.
        /// </summary>
        /// <param name="id">ID de la estación a eliminar.</param>
        /// <returns>Retorna la estación eliminada, error en caso de no encontrarla.</returns>
        Task<Station?> DeleteStation(Guid id);
        /// <summary>
        /// Método para verificar si una estación existe por su nombre y ubicación.
        /// </summary>
        /// <param name="name">Nombre de la estación.</param>
        /// <param name="location">Ubicación de la estación.</param>
        /// <returns>Retorna true si la estación existe, false en caso contrario.</returns>
        Task<bool> StationExists(string name, string location);
    }
}