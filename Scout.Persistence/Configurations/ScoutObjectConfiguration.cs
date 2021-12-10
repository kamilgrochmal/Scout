using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scout.Domain.ScoutObjects.Entities;

namespace Scout.Persistence.Configurations;

public class ScoutObjectConfiguration : IEntityTypeConfiguration<ScoutObject>
{
    public void Configure(EntityTypeBuilder<ScoutObject> builder)
    {
        // --- Address Configuration --- //
        
       
        
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
        
        // --- Address Configuration --- //
        
        // --- WGS Geolocalization Configuration --- //

        builder.OwnsOne(a => a.WgsGeoLocalization)
            .Property(a => a.Latitude)
            .HasColumnName("Latitude");

        builder.OwnsOne(a => a.WgsGeoLocalization)
            .Property(a => a.Longitude)
            .HasColumnName("Longitude");
        
        builder.OwnsOne(a => a.WgsGeoLocalization)
            .Property(a => a.TerrainHeight)
            .HasColumnName("TerrainHeight");
        
        // --- WGS Geolocalization Configuration --- //

        // --- Object Specification Configuration --- //

        builder.OwnsOne(a => a.ObjectSpecification)
            .Property(a => a.FirstAntennaSetHeight)
            .HasColumnName("FirstAntennaSetHeight");
        
        builder.OwnsOne(a => a.ObjectSpecification)
            .Property(a => a.SecondAntennaSetHeight)
            .HasColumnName("SecondAntennaSetHeight");
        
        builder.OwnsOne(a => a.ObjectSpecification)
            .Property(a => a.ThirdAntennaSetHeight)
            .HasColumnName("ThirdAntennaSetHeight");
        
        builder.OwnsOne(a => a.ObjectSpecification)
            .Property(a => a.ObjectHeight)
            .HasColumnName("ObjectHeight");
        
        builder.OwnsOne(a => a.ObjectSpecification)
            .Property(a => a.CoolingType)
            .HasColumnName("CoolingType");
        
        builder.OwnsOne(a => a.ObjectSpecification)
            .Property(a => a.PowerSupplyType)
            .HasColumnName("PowerSupplyType");
        
        builder.OwnsOne(a => a.ObjectSpecification)
            .Property(a => a.Others)
            .HasColumnName("Others");
        
        // --- Object Specification Configuration --- //


        builder.OwnsOne(a => a.IpAddress)
            .Property(a => a.Value)
            .HasColumnName("IpAddress");


    }
}