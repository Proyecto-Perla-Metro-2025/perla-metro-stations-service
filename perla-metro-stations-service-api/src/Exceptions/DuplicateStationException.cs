using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Exceptions
{
    public class DuplicateStationException : Exception
    {
        public DuplicateStationException(string message) : base(message) { }
    }
}