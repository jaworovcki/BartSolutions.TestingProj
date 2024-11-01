using BartSolutionsProject.API.Data.Models;
using BartSolutionsProject.API.DTOs;

namespace BartSolutionsProject.API.Services.Interfaces;
public interface IIncidentService
{
    Task<Incident> CreateIncidentAsync(CreateIncidentDto createIncidentDto);
    Task<Incident> GetIncidentByNameAsync(string incidentName);
}