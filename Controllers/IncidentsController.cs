using BartSolutionsProject.API.Data.Models;
using BartSolutionsProject.API.DTOs;
using BartSolutionsProject.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BartSolutionsProject.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentsController : ControllerBase
{
    private readonly IIncidentService _incidentService;

    public IncidentsController(IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Incident>> Create([FromBody] CreateIncidentDto incidentDto)
    {
        try
        {
            var incident = await _incidentService.CreateIncidentAsync(incidentDto);
            return CreatedAtAction(nameof(GetIncident), new { name = incident.Name }, incident);
        }
        catch (Exception)
        {
            return NotFound("Incident could not be created");
        }
    }

    [HttpGet(Name = "GetIncident")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Incident>> GetIncident([FromQuery] string name)
    {
        try
        {
            var incident = await _incidentService.GetIncidentByNameAsync(name);
            return Ok(incident);
        }
        catch (Exception)
        {
            return NotFound("Incident not found");
        }
    }
}