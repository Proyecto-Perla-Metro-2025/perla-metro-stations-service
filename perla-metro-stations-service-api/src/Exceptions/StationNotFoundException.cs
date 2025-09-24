using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Exceptions
{
    public class StationNotFoundException : Exception
    {
        public StationNotFoundException(string message) : base(message) { }
    }
}