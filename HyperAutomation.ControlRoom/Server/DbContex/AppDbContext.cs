using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperAutomation.ControlRoom.Shared.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Serilog;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HyperAutomation.ControlRoom.Server.Models
{
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
        DbSet<Credential> Credentials { get; set; }
        DbSet<Device> Devices { get; set; }
        DbSet<GlobalValue> GlobalValues { get; set; }
        DbSet<Setting> Settings { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<BotFolder> BotFolder { get; set; }
    }
}
