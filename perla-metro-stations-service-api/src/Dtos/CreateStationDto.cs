using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Dtos
{
    public class CreateStationDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string StopType { get; set; }
        public bool IsActive = true;
    }
}