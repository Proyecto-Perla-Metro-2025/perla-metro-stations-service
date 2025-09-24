using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perla_metro_stations_service_api.src.Models;

namespace perla_metro_stations_service_api.src.Repository
{
    public interface IStationRepository
    {
        Task<IEnumerable<Station>> GetAllStations();
        Task<Station?> GetStationById(Guid id);
        Task<Station> AddStation(Station station);
        Task<Station?> UpdateStation(Station station, Guid id);
        Task<Station?> DeleteStation(Guid id);
        Task<bool> StationExists(string name, string location);
    }
}