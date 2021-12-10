using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scout.Domain.LeaseContracts.Entities;

namespace Scout.Persistence.Configurations;

public class LeaseContractConfiguration : IEntityTypeConfiguration<LeaseContract>
{
    public void Configure(EntityTypeBuilder<LeaseContract> builder)
    {
        // --- Contract Date --- //

        
        builder.OwnsOne(a => a.ContractDate)
            .Property(a => a.ContractConclusionDate)
            .HasColumnName("ContractConclusionDate")
            .IsRequired();

        builder.OwnsOne(a => a.ContractDate)
            .Property(a => a.ContractValidFrom)
            .HasColumnName("ContractValidFrom");

        builder.OwnsOne(a => a.ContractDate)
            .Property(a => a.ContractValidTo)
            .HasColumnName("ContractValidTo");

        builder.OwnsOne(a => a.ContractDate)
            .Property(a => a.PeriodOfNotice)
            .HasColumnName("PeriodOfNotice");
        // --- Contract Date --- //

        // --- Money --- //

        builder.OwnsOne(a => a.Rent)
            .Property(a => a.Value)
            .HasColumnName("Rent")
            .IsRequired();

        // --- Money --- //


        // --- Valorization --- //

        builder.OwnsOne(a => a.Valorization)
            .Property(a => a.IsValorization)
            .HasColumnName("IsValorization");


        builder.OwnsOne(a => a.Valorization)
            .Property(a => a.ValorizationFrom)
            .HasColumnName("ValorizationFrom");

        builder.OwnsOne(a => a.Valorization)
            .Property(a => a.ValorizationStake)
            .HasColumnName("ValorizationStake");

        // --- Valorization --- //
    }
}