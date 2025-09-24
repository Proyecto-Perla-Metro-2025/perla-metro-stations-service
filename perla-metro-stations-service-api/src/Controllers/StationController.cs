using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using perla_metro_stations_service_api.src.Dtos;
using perla_metro_stations_service_api.src.Exceptions;
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
        public async Task<IActionResult> GetAllStations([FromQuery] string? name, [FromQuery] string? stopType, [FromQuery] string? status)
        {
            try
            {
                var stations = await _stationService.GetAllStations(name, stopType, status);
                var response = new ApiResponse<object>(
                    stations,
                    "Stations retrieved successfully",
                    true
                );
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is StationNotFoundException)
                {
                    return StatusCode(404, new { Message = ex.Message });
                }
                else
                {
                    return StatusCode(500, new { Message = "An error occurred while retrieving all stations." });
                }
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
            catch (Exception ex)
            {
                if (ex is StationNotFoundException)
                {
                    return StatusCode(404, new { Message = ex.Message });
                }
                else
                {
                    return StatusCode(500, new { Message = "An error occurred while retrieving the station by ID." });
                }
            }
        }
        [HttpPost("CreateStation")]
        public async Task<IActionResult> CreateStation([FromBody] CreateStationDto createStationDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(createStationDto.Name) || string.IsNullOrWhiteSpace(createStationDto.Location) || string.IsNullOrWhiteSpace(createStationDto.StopType))
                    return StatusCode(400, new { Message = "Name, Location, and StopType are required fields." });
                var stopType = createStationDto.StopType.ToLower();
                if (stopType != "origen" && stopType != "intermedia" && stopType != "destino") return StatusCode(400, new { Message = "Invalid StopType, must be either 'Origen', 'Intermedia', or 'Destino'." });
                createStationDto.StopType = char.ToUpper(createStationDto.StopType[0]) + createStationDto.StopType.Substring(1).ToLower();
                await _stationService.CreateStation(createStationDto);
                var response = new ApiResponse<object>(
                    createStationDto,
                    "Station created successfully",
                    true
                );
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is DuplicateStationException)
                {
                    return StatusCode(409, new { Message = ex.Message });
                }
                else
                {
                    return StatusCode(500, new { Message = "An error occurred while creating the station." });
                }
            }
        }
        [HttpPut("UpdateStation/{id}")]
        public async Task<IActionResult> UpdateStation(Guid id, [FromBody] UpdateStationDto updateStationDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(updateStationDto.Name) || string.IsNullOrWhiteSpace(updateStationDto.Location) || string.IsNullOrWhiteSpace(updateStationDto.StopType))
                    return StatusCode(400, new { Message = "Name, Location, and StopType are required fields." });
                var stopType = updateStationDto.StopType?.ToLower();
                if (stopType != "origen" && stopType != "intermedia" && stopType != "destino")
                    return StatusCode(400, new { Message = "Invalid StopType, must be either 'Origen', 'Intermedia', or 'Destino'." });
                    
                updateStationDto.StopType = char.ToUpper(updateStationDto.StopType[0]) + updateStationDto.StopType.Substring(1).ToLower();
                var updatedStation = await _stationService.UpdateStation(updateStationDto, id);
                if (updatedStation == null) return StatusCode(404, new { Message = "Station not found" });
                var response = new ApiResponse<object>(
                    updatedStation,
                    "Station updated successfully",
                    true
                );
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is StationNotFoundException)
                {
                    return StatusCode(404, new { Message = ex.Message });
                }
                else if (ex is DuplicateStationException)
                {
                    return StatusCode(409, new { Message = ex.Message });
                }
                else
                {
                    return StatusCode(500, new { Message = "An error occurred while updating the station." });
                }
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
            catch (Exception ex)
            {
                if (ex is StationNotFoundException)
                {
                    return StatusCode(404, new { Message = ex.Message });
                }
                else
                {
                    return StatusCode(500, new { Message = "An error occurred while deleting the station." });
                }
            }
        }
    }
}