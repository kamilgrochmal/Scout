using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scout.Application.Common.Services;
using Scout.Domain.Common.Entities;
using Scout.Domain.Common.Enums;
using Scout.Domain.ContactPersons.Entities;
using Scout.Domain.LeaseContracts.Entities;
using Scout.Domain.ObjectKeepers.Entities;
using Scout.Domain.ObjectOwners.Entities;
using Scout.Domain.ScoutObjects.Entities;

namespace Scout.Persistence;

public class ScoutDbContext : DbContext
{
    private readonly IDateService _dateTimeOffset;
    private readonly ICurrentUserService _currentUserService;

    public ScoutDbContext(DbContextOptions<ScoutDbContext> options) : base(options)
    {
    }

    public ScoutDbContext(DbContextOptions<ScoutDbContext> options, IDateService dateTimeOffset,
        ICurrentUserService currentUserService) : base(options)
    {
        _dateTimeOffset = dateTimeOffset;
        _currentUserService = currentUserService;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScoutDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    
    
    public DbSet<ContactPerson> ContactPersons { get; set; }
    public DbSet<ObjectKeeper> ObjectKeepers { get; set; }
    public DbSet<ObjectOwner> ObjectOwners { get; set; }
    public DbSet<ScoutObject> ScoutObjects { get; set; }
    public DbSet<LeaseContract> LeaseContracts { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.Email;
                    entry.Entity.CreatedDate = _dateTimeOffset.CurrentOffsetDate();
                    entry.Entity.Status = Status.Active;
                    
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.Email;
                    entry.Entity.LastModifiedDate = _dateTimeOffset.CurrentOffsetDate();
                    break;

                case EntityState.Deleted:
                    entry.Entity.LastModifiedBy = _currentUserService.Email;
                    entry.Entity.LastModifiedDate = _dateTimeOffset.CurrentOffsetDate();
                    entry.Entity.InactivatedBy = _currentUserService.Email;
                    entry.Entity.InactivatedDate = _dateTimeOffset.CurrentOffsetDate();
                    entry.Entity.Status = Status.Deleted;
                    entry.State = EntityState.Modified;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}