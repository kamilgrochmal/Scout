using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scout.Domain.ObjectOwners.Entities;
using Scout.Domain.Persons.Entities;
using Scout.Domain.ScoutObjects.Entities;
using Scout.Domain.ScoutObjects.Enums;
using Scout.Domain.ValueObjects;

namespace Scout.Infrastructure.EF.Configurations;

public class WriteConfiguration : IEntityTypeConfiguration<ScoutObject>, IEntityTypeConfiguration<Person>,
    IEntityTypeConfiguration<ObjectOwner>
{
    //F*ck i combined here configuration of read and write dbContext. There shouldn't be relations, because they could be easier define with ReadModels. But for now it works okey
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
    }

    public void Configure(EntityTypeBuilder<ObjectOwner> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property<string>("_companyName").HasColumnName("CompanyName");
        builder.Property<string>("_urlSite").HasColumnName("UrlSite");

        builder.OwnsOne<Address>("_address", a =>
        {
            a.Property(x => x.City).HasColumnName("City");
            a.Property(x => x.PostalCode).HasColumnName("PostalCode");
            a.Property(x => x.Street).HasColumnName("Street");
            a.Property(x => x.PlotNumber).HasColumnName("PlotNumber");
        });

        builder.HasOne("_person").WithMany().HasForeignKey("PersonId");
        builder.HasOne("_scoutObject").WithMany().HasForeignKey("ScoutObjectId");
    }

    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property<string>("_firstName").HasColumnName("FirstName");
        builder.Property<string>("_lastName").HasColumnName("LastName");
        builder.Property<Email>("_email").HasConversion(a => a.EmailAddress, a => Email.Create(a))
            .HasColumnName("Email");
        builder.Property<PhoneNumber>("_phoneNumber").HasConversion(a => a.Number, a => PhoneNumber.Create(a))
            .HasColumnName("PhoneNumber");
    }
}