using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perla_metro_stations_service_api.src.Dtos;

namespace perla_metro_stations_service_api.src.Services
{
    public interface IStationService
    {
        Task<IEnumerable<StationDto?>> GetAllStations();
        Task<StationDto?> GetStationById(Guid id);
        Task<StationDto> CreateStation(CreateStationDto station);
        Task<StationDto?> UpdateStation(UpdateStationDto station, Guid id);
        Task<StationDto?> DeleteStation(Guid id);
    }
}