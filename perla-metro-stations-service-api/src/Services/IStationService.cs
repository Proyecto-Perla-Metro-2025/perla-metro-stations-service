using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_stations_service_api.src.Services
{
    public interface IStationService
    {
        Task<IEnumerable<StationDto?>> GetAllStationsAsync();
        Task<StationDto?> GetStationByIdAsync(Guid id);
        Task<StationDto> CreateStationAsync(StationDto station);
        Task UpdateStationAsync(StationDto station);
        Task DeleteStationAsync(Guid id);
    }
}