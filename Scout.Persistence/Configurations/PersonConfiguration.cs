using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scout.Domain.Persons.Entities;

namespace Scout.Persistence.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {

        builder.OwnsOne(a => a.PhoneNumberOne)
            .Property(a => a.Number)
            .HasColumnName("FirstPhoneNumber");


        builder.OwnsOne(a => a.Email)
            .Property(a => a.EmailAddress)
            .HasColumnName("Email");
    }
}