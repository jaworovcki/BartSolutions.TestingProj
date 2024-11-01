using BartSolutionsProject.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BartSolutionsProject.API.Data.Configurations;
public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName).IsRequired();
        builder.Property(c => c.LastName).IsRequired();
        builder.Property(c => c.Email).IsRequired();
        builder.HasIndex(c => c.Email).IsUnique();
        builder.HasOne(c => c.Account).WithMany(a => a.Contacts).HasForeignKey(c => c.AccountId);
    }
}