using System.ComponentModel.DataAnnotations.Schema;

namespace BartSolutionsProject.API.Data.Models;
public class Incident
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}