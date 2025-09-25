using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Dtos
{
    /// <summary>
    /// DTO para la actualización de una estación.
    /// </summary>
    public class UpdateStationDto
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
    }
}