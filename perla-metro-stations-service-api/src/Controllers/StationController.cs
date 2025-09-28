using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using perla_metro_stations_service_api.src.Dtos;
using perla_metro_stations_service_api.src.Exceptions;
using perla_metro_stations_service_api.src.Response;
using perla_metro_stations_service_api.src.Services;

namespace perla_metro_stations_service_api.src.Controllers
{
    /// <summary>
    /// Controlador encargado de la gestión de las estaciones.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class StationController : ControllerBase
    {
        /// <summary>
        /// Servicio de la estación.
        /// </summary>
        private readonly IStationService _stationService;

        /// <summary>
        /// Constructor de la clase controlador de estaciones.
        /// </summary>
        /// <param name="stationService">Servicio de la estación.</param>
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }
        /// <summary>
        /// Metodo para obtener todas las estaciones.
        /// </summary>
        /// <param name="name">Parametro de filtro por nombre.</param>
        /// <param name="stopType">Parametro de filtro por tipo de parada.</param>
        /// <param name="status">Parametro de filtro por estado (Activo o inactivo).</param>
        /// <returns>Retorna todas las estaciones encontradas, se aplica filtro si corresponde.</returns>
        [HttpGet]
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
        /// <summary>
        /// Metodo para obtener una estación dado una ID.
        /// </summary>
        /// <param name="id">Id a buscar (Formato UUID4).</param>
        /// <returns>Retorna la estación encontrada o un mensaje de error en caso de no encontrarla.</returns> 
        [HttpGet("{id}")]
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
        /// <summary>
        /// Metodo para crear una estación.
        /// </summary>
        /// <param name="createStationDto">Formulario de creación de estación, solicita nombre, ubicación y tipo de parada.</param>
        /// <returns>Retorna la estación creada y un mensaje de exito, mensaje de error en caso contrario.</returns>
        [HttpPost]
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
        /// <summary>
        /// Metodo para actualizar una estación.
        /// </summary>
        /// <param name="id">Id de la estación a actualizar (Formato UUID4).</param>
        /// <param name="updateStationDto">Formulario de actualización de estación, solicita nombre, ubicación y tipo de parada.</param>
        /// <returns>Retorna la estación actualizada y un mensaje de éxito, mensaje de error en caso contrario.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStation(Guid id, [FromBody] UpdateStationDto updateStationDto)
        {
            try
            {
                if (!string.IsNullOrEmpty(updateStationDto.StopType))
                {
                    var stopType = updateStationDto.StopType?.ToLower();
                    if (stopType != "origen" && stopType != "intermedia" && stopType != "destino")
                        return StatusCode(400, new { Message = "Invalid StopType, must be either 'Origen', 'Intermedia', or 'Destino'." });

                    updateStationDto.StopType = char.ToUpper(updateStationDto.StopType[0]) + updateStationDto.StopType.Substring(1).ToLower();
                }
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
        /// <summary>
        /// Metodo para eliminar una estación.
        /// </summary>
        /// <param name="id">Id de la estación a eliminar (Formato UUID4).</param>
        /// <returns>Retorna la estación eliminada y un mensaje de éxito, mensaje de error en caso contrario.</returns>
        [HttpDelete("{id}")]
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