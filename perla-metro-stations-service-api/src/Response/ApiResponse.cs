using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Response
{
    public class ApiResponse<T>(T data, string message, bool success)
    {
        public T Data { get; set; } = data;
        public string Message { get; set; } = message;
        public bool Success { get; set; } = success;
    }
}   