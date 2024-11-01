using System.Reflection;
using BartSolutionsProject.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BartSolutionsProject.API.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        
    }

    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}