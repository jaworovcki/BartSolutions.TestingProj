using BartSolutionsProject.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BartSolutionsProject.API.Data.Configurations;
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired();
        builder.HasIndex(a => a.Name).IsUnique();
        builder.HasOne(a => a.Incident).WithMany(i => i.Accounts).HasForeignKey(a => a.IncidentName);
        builder.HasMany(a => a.Contacts).WithOne(c => c.Account).HasForeignKey(c => c.AccountId);
    }
}