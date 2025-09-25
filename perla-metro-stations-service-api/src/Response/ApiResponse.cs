using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Response
{
    /// <summary>
    /// Respuesta estandarizada de la API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data">Datos a responder.</param>
    /// <param name="message">Mensaje de exito o error.</param>
    /// <param name="success">Indica si la solicitud fue exitosa.</param>
    public class ApiResponse<T>(T data, string message, bool success)
    {
        /// <summary>
        /// Datos a responder.
        /// </summary>
        public T Data { get; set; } = data;
        /// <summary>
        /// Mensaje de exito o error.
        /// </summary>
        public string Message { get; set; } = message;
        /// <summary>
        /// Indica si la solicitud fue exitosa.
        /// </summary>
        public bool Success { get; set; } = success;
    }
}   