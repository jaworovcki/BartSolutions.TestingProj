using BartSolutionsProject.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BartSolutionsProject.API.Data.Configurations;
public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
{
    public void Configure(EntityTypeBuilder<Incident> builder)
    {
        builder.HasKey(i => i.Name);
        builder.Property(i => i.Name).ValueGeneratedOnAdd();
        builder.Property(i => i.Description).IsRequired();
        builder.HasMany(i => i.Accounts).WithOne(a => a.Incident).HasForeignKey(a => a.IncidentName);
    }
}