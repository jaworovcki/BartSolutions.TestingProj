using BartSolutionsProject.API.Data.Models;

namespace BartSolutionsProject.API.Repositories.Interfaces;
public interface IIncidentsRepository
{
    Task<Incident> CreateIncidentAsync(Incident incident);
    Task<Incident> GetIncidentByNameAsync(string incidentName);
}