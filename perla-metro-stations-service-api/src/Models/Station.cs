using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Models
{
    /// <summary>
    /// Clase para representar una estación de metro.
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Identificador único de la estación (Formato UUID4).
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Nombre de la estación.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Ubicación de la estación.
        /// </summary>
        [Required]
        public string Location { get; set; }
        /// <summary>
        /// Tipo de parada de la estación.
        /// </summary>
        [Required]
        public string StopType { get; set; }
        /// <summary>
        /// Estado de la estación (Activo o inactivo).
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}