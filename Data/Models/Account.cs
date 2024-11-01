namespace BartSolutionsProject.API.Data.Models;
public class Account
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string? IncidentName { get; set; }
    public Incident Incident { get; set; } = null!;

    public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}