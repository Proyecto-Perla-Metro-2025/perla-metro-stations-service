using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Dtos
{
    public class StationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string StopType { get; set; }
        public string Status => IsActive ? "Active" : "Inactive";
        public bool IsActive { get; set; }
    }
}