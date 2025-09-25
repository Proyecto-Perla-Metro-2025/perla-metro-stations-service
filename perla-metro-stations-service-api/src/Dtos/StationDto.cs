using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Dtos
{
    /// <summary>
    /// DTO para la representación de una estación.
    /// </summary>
    public class StationDto
    {
        /// <summary>
        /// Id de la estación (Formato UUID4).
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Nombre de la estación.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Ubicación de la estación.
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Tipo de parada de la estación.
        /// </summary>
        public string StopType { get; set; }
        /// <summary>
        /// Estado de la estación (Activo o Inactivo).
        /// </summary>
        public string Status => IsActive ? "Active" : "Inactive";
        /// <summary>
        /// Indica si la estación está activa o inactiva (boolean).
        /// </summary>
        public bool IsActive { get; set; }
    }
}