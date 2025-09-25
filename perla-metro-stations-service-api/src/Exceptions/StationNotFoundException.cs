using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Exceptions
{
    /// <summary>
    /// Clase para manejar excepciones de estación no encontrada.
    /// </summary>
    public class StationNotFoundException : Exception
    {
        /// <summary>
        /// Constructor de la clase StationNotFoundException.
        /// </summary>
        /// <param name="message">Mensaje de error.</param>
        public StationNotFoundException(string message) : base(message) { }
    }
}