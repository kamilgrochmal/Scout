using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scout.Domain.ObjectKeepers.Entities;

namespace Scout.Persistence.Configurations;

public class ObjectKeeperConfiguration : IEntityTypeConfiguration<ObjectKeeper>
{
    public void Configure(EntityTypeBuilder<ObjectKeeper> builder)
    {
       
        builder.OwnsOne(a => a.PhoneNumberToPickUpTheKeys)
            .Property(a => a.Number)
            .HasColumnName("PhoneNumberToPickUpTheKeys")
            .IsRequired();
    }
}