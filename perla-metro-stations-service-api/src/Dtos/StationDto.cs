using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Dtos
{
    public class StationDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string stopType { get; set; }
        public bool isActive { get; set; }
    }
}