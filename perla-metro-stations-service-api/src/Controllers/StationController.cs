using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using perla_metro_stations_service_api.src.Dtos;
using perla_metro_stations_service_api.src.Mappers;
using perla_metro_stations_service_api.src.Response;
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
        [HttpGet("GetAllStations")]
        public async Task<IActionResult> GetAllStations()
        {
            try
            {
                var stations = await _stationService.GetAllStations();
                var response = new ApiResponse<object>(
                    stations,
                    "Stations retrieved successfully",
                    true
                );
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving all stations." });
            }
        }
        [HttpGet("GetStationById/{id}")]
        public async Task<IActionResult> GetStationById(Guid id)
        {
            try
            {
                var station = await _stationService.GetStationById(id);
                if (station == null) return StatusCode(404, new { Message = "Station not found" });
                var response = new ApiResponse<object>(
                    station,
                    "Station retrieved successfully",
                    true
                );
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the station by ID." });
            }
        }
        [HttpPost("CreateStation")]
        public async Task<IActionResult> CreateStation([FromBody] CreateStationDto createStationDto)
        {
            try
            {
                if (createStationDto == null) return StatusCode(400, new { Message = "Invalid station data" });
                await _stationService.CreateStation(createStationDto);
                var response = new ApiResponse<object>(
                    createStationDto,
                    "Station created successfully",
                    true
                );
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while creating the station." });
            }
        }
        [HttpPut("UpdateStation/{id}")]
        public async Task<IActionResult> UpdateStation(Guid id, [FromBody] UpdateStationDto updateStationDto)
        {
            try
            {
                if (updateStationDto == null) return StatusCode(400, new { Message = "Invalid station data" });
                var updatedStation = await _stationService.UpdateStation(updateStationDto, id);
                if (updatedStation == null) return StatusCode(404, new { Message = "Station not found" });
                var response = new ApiResponse<object>(
                    updatedStation,
                    "Station updated successfully",
                    true
                );
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the station." });
            }
        }
        [HttpDelete("DeleteStation/{id}")]
        public async Task<IActionResult> DeleteStation(Guid id)
        {
            try
            {
                var deletedStation = await _stationService.DeleteStation(id);
                if (deletedStation == null) return StatusCode(404, new { Message = "Station not found" });
                var response = new ApiResponse<object>(
                    deletedStation,
                    "Station deleted successfully",
                    true
                );
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the station." });
            }
        }
    }
}