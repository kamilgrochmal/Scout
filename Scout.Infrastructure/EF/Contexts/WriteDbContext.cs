using Microsoft.EntityFrameworkCore;
using Scout.Application.Common.Services;
using Scout.Domain.Persons.Entities;
using Scout.Domain.ScoutObjects.Entities;
using Scout.Infrastructure.EF.Configurations;

namespace Scout.Infrastructure.EF.Contexts;

public class WriteDbContext : DbContext
{

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<ScoutObject>(configuration);
        modelBuilder.ApplyConfiguration<Person>(configuration);
        base.OnModelCreating(modelBuilder);
    }
    
    
   
    public DbSet<ScoutObject> ScoutObjects { get; set; }

    
}