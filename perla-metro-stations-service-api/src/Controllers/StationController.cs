using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using perla_metro_stations_service_api.src.Dtos;
using perla_metro_stations_service_api.src.Mappers;
using perla_metro_stations_service_api.src.Services;

namespace perla_metro_stations_service_api.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStations()
        {
            var stations = await _stationService.GetAllStations();
            return Ok(stations);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStationById(Guid id)
        {
            var station = await _stationService.GetStationById(id);
            if (station is null) return NotFound();
            else
            {
                return Ok();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStation([FromBody] CreateStationDto createStationDto)
        {
            if (createStationDto == null) return BadRequest();
            await _stationService.CreateStation(createStationDto);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStation(Guid id, [FromBody] UpdateStationDto updateStationDto)
        {
            if (updateStationDto == null) return BadRequest();
            var updatedStation = await _stationService.UpdateStation(updateStationDto, id);
            if (updatedStation == null) return NotFound();
            return Ok(updatedStation);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStation(Guid id)
        {
            var deletedStation = await _stationService.DeleteStation(id);
            if (deletedStation == null) return NotFound();
            return Ok(deletedStation);
        }
    }
}