using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scout.Domain.ObjectOwners.Entities;

namespace Scout.Persistence.Configurations;

public class ObjectOwnerConfiguration : IEntityTypeConfiguration<ObjectOwner>
{
    public void Configure(EntityTypeBuilder<ObjectOwner> builder)
    {
        
        
        builder.OwnsOne(a => a.Address)
            .Property(a => a.PostalCode)
            .HasColumnName("PostalCode");

        builder.OwnsOne(a => a.Address)
            .Property(a => a.City)
            .HasColumnName("City");
        
        builder.OwnsOne(a => a.Address)
            .Property(a => a.Street)
            .HasColumnName("Street");
        
        builder.OwnsOne(a => a.Address)
            .Property(a => a.PlotNumber)
            .HasColumnName("PlotNumber");
        
        builder.OwnsOne(a => a.Address)
            .Property(a => a.HouseNumber)
            .HasColumnName("HouseNumber");
    }
}