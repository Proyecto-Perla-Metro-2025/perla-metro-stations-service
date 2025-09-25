using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Dtos
{
    /// <summary>
    /// DTO para la creación de una estación.
    /// </summary>
    public class CreateStationDto
    {
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
        /// Estado de la estación (Activo por defecto).
        /// </summary>
        public bool IsActive = true;
    }
}