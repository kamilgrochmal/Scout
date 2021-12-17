using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scout.Domain.ObjectOwners.Entities;
using Scout.Domain.Persons.Entities;
using Scout.Domain.ScoutObjects.Entities;
using Scout.Domain.ScoutObjects.Enums;
using Scout.Domain.ValueObjects;

namespace Scout.Infrastructure.EF.Configurations;

public class WriteConfiguration : IEntityTypeConfiguration<ScoutObject>, IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<ScoutObject> builder)
    {
        builder.HasKey(a => a.Id);

        var scoutNameConverter =
            new ValueConverter<ScoutObjectName, string>(son => son.Value, son => new ScoutObjectName(son));


        builder
            .Property<ScoutObjectName>("_name")
            .HasConversion(scoutNameConverter)
            .HasColumnName("Name");

        builder
            .OwnsOne<Address>("_address", a =>
            {
                a.Property(x => x.City).HasColumnName("City");
                a.Property(x => x.PostalCode).HasColumnName("PostalCode");
                a.Property(x => x.Street).HasColumnName("Street");
                a.Property(x => x.PlotNumber).HasColumnName("PlotNumber");
            });

        builder
            .Property<ObjectStatus>("_objectStatus")
            .HasColumnName("ObjectStatus");

        builder
            .Property<ObjectType>("_objectType")
            .HasColumnName("ObjectType");

        builder.OwnsMany<ObjectOwner>("_objectOwners", oo =>
        {
            oo.HasKey(a => a.Id);
            oo.WithOwner().HasForeignKey("ScoutObjectId");
            oo.ToTable("ObjectOwners");

            oo.Property<string>("_companyName").HasColumnName("CompanyName");
            oo.OwnsOne<Address>("_address", a =>
            {
                a.Property(x => x.City).HasColumnName("City");
                a.Property(x => x.PostalCode).HasColumnName("PostalCode");
                a.Property(x => x.Street).HasColumnName("Street");
                a.Property(x => x.PlotNumber).HasColumnName("PlotNumber");
            });
            oo.Property<string>("_urlSite").HasColumnName("UrlSite");
            
        });
    }

    // public void Configure(EntityTypeBuilder<ObjectOwner> builder)
    // {
    //     throw new NotImplementedException();
    // }
    //
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property<string>("_firstName").HasColumnName("FirstName");
        builder.Property<string>("_lastName").HasColumnName("LastName");
        builder.Property<Email>("_email").HasConversion(a => a.EmailAddress, a => Email.Create(a)).HasColumnName("Email");
        builder.Property<PhoneNumber>("_phoneNumber").HasConversion(a => a.Number, a => PhoneNumber.Create(a)).HasColumnName("PhoneNumber");
        
    }
}