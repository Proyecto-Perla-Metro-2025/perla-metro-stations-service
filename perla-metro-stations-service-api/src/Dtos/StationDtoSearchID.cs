using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Dtos
{
    /// <summary>
    /// DTO para la representación de una estación al utilizar el endpoint de busqueda por ID.
    /// </summary>
    public class StationDtoSearchID
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
        /// Estado de la estación (Somo se muestra en caso que se encuentre activa).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Status { get; set; }
        /// <summary>
        /// Indica si la estación está activa o inactiva (boolean).
        /// </summary>
        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}