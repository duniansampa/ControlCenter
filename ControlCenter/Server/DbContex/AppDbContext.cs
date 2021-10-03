using ControlCenter.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Serilog;

namespace ControlCenter.Server.DbContex;

public class AppDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUser<Guid>>(u =>
        {
            u.HasOne<UserProfile>()
            .WithOne()
            .HasForeignKey<UserProfile>(c => c.UserId);
        });

        modelBuilder.ApplyConfiguration(new BotEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new IdentityRoleConfiguration());
        modelBuilder.ApplyConfiguration(new IdentityUserConfiguration());
        modelBuilder.ApplyConfiguration(new IdentityUserRoleConfig());
        modelBuilder.ApplyConfiguration(new IdentityUserProfileConfig());

        //Shadow Property
        var allEntities = modelBuilder.Model.GetEntityTypes();

        foreach (var entity in allEntities)
        {
            //entity.AddProperty("CreatedDate", typeof(DateTime));
            //entity.AddProperty("UpdatedDate", typeof(DateTime));
        }
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e =>
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }

    private static void DisplayStates(IEnumerable<EntityEntry> entries)
    {
        foreach (var entry in entries)
        {
            Log.Error($"Entity: {entry.Entity.GetType().Name}, State: { entry.State.ToString()}");
        }
    }

    public DbSet<Bot> Bots { get; set; }
    public DbSet<Credential> Credentials { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<GlobalValue> GlobalValues { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<UserProfile> UserProfile { get; set; }
    public DbSet<BotFolder> BotFolder { get; set; }
}
