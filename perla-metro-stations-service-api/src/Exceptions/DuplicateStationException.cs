using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Exceptions
{
    /// <summary>
    /// Clase para manejar excepciones de estaciones duplicadas.
    /// </summary>
    public class DuplicateStationException : Exception
    {
        /// <summary>
        /// Constructor de la clase DuplicateStationException.
        /// </summary>
        /// <param name="message">Mensaje de error.</param>
        public DuplicateStationException(string message) : base(message) { }
    }
}