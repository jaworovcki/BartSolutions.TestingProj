using BartSolutionsProject.API.Data;
using BartSolutionsProject.API.Data.Models;
using BartSolutionsProject.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BartSolutionsProject.API.Repositories;
public class IncidentsRepository : IIncidentsRepository
{
    private readonly DataContext _context;

    public IncidentsRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Incident> CreateIncidentAsync(Incident incident)
    {
        _context.Incidents.Add(incident);
        await _context.SaveChangesAsync();
        return incident;
    }

    public async Task<Incident> GetIncidentByNameAsync(string incidentName)
    {
        return await _context.Incidents.FirstOrDefaultAsync(x => x.Name == incidentName);
    }
}