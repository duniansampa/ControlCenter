using ControlCenter.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlCenter.Server.DbContex;

static class AdminUserData
{
    public static Guid AdminRoleId { get; } = Guid.NewGuid();
    public static Guid AdminUserId { get; } = Guid.NewGuid();
    public static string UserName { get; set; } = "masteradmin";
    public static string Email { get; set; } = "Admin@Admin.com";
    public static string FirstName { get; set; } = "Master";
    public static string LastName { get; set; } = "Admin";
    public static string PasswordHash { get; set; } = new PasswordHasher<IdentityUser<Guid>>().HashPassword(null, "masteradmin");
}

public class BotEntityTypeConfiguration : IEntityTypeConfiguration<Bot>
{
    public void Configure(EntityTypeBuilder<Bot> builder)
    {
        //builder.ToTable("Bots");

        //builder.Property(s => s.Name)
        //    .IsRequired();
        /*
        builder.HasData
        ( 
            new Bot
            {
                Name = "RH Bot",
                Type = 1,
                BotId = 1,
                Size = 20.1,
                Status = "Executando",
                ModifiedOn = DateTime.Now,
                ModifiedBy = new UserInfo
                {
                    UserName = "Dunian Coutinho Sampa"
                }
            },
            new Bot
            {
                Name = "Gerador de 2º via",
                Type = 1,
                BotId = 2,
                Size = 30.2,
                Status = "Parado",
                ModifiedOn = DateTime.Now.AddDays(-1),
                ModifiedBy = new UserInfo
                {
                    UserName = "Dunian Coutinho Sampa"
                }
            },
            new Bot
            {
                Name = "Demo Bot",
                Type = 1,
                BotId = 3,
                Size = 100.8,
                Status = "Executando",
                ModifiedOn = DateTime.Now.AddDays(-2),
                ModifiedBy = new UserInfo
                {
                    UserName = "Dunian Coutinho Sampa"
                }
            },
            new Bot
            {
                Name = "Robô de Finanças",
                Type = 1,
                BotId = 4,
                Size = 500.2,
                Status = "Parado",
                ModifiedOn = DateTime.Now.AddDays(-5),
                ModifiedBy = new UserInfo
                {
                    UserName = "Dunian Coutinho Sampa"
                }
            },
            new Bot
            {
                Name = "Welcome Bot",
                Type = 1,
                BotId = 5,
                Status = "Parado",
                Size = 487.5,
                ModifiedOn = DateTime.Now.AddDays(-10),
                ModifiedBy = new UserInfo
                {
                    UserName = "Dunian Coutinho Sampa"
                }
            },

            new Bot
            {
                Name = "Demo bot 2",
                Type = 1,
                BotId = 6,
                Status = "Parado",
                Size = 238,
                ModifiedOn = DateTime.Now.AddDays(-4),
                ModifiedBy = new UserInfo
                {
                    UserName = "Dunian Coutinho Sampa"
                }
            },

            new Bot
            {
                Name = "Robo Smart",
                Type = 1,
                BotId = 7,
                Status = "Parado",
                Size = 184.9,
                ModifiedOn = DateTime.Now.AddDays(-2),
                ModifiedBy = new UserInfo
                {
                    UserName = "Dunian Coutinho Sampa"
                }
            },

            new Bot
            {
                Name = "Demo bot 4",
                Type = 1,
                BotId = 8,
                Status = "Parado",
                Size = 89.3,
                ModifiedOn = DateTime.Now.AddDays(-3),
                ModifiedBy = new UserInfo
                {
                    UserName = "Dunian Coutinho Sampa"
                }
            },

            new Bot
            {
                Name = "RH Bot 5",
                Type = 1,
                BotId = 9,
                Status = "Parado",
                Size = 600.3,
                ModifiedOn = DateTime.Now.AddDays(-7),
                ModifiedBy = new UserInfo
                {
                    UserName = "Dunian Coutinho Sampa"
                }
            },

            new Bot
            {
                Name = "Contas a Pagar",
                Type = 1,
                BotId = 10,
                Status = "Parado",
                Size = 908.6,
                ModifiedOn = DateTime.Now,
                ModifiedBy = new UserInfo
                {
                    UserName = "Dunian Coutinho Sampa"
                }
            }
        );*/
    }
}

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder.HasData(new IdentityRole<Guid>
        {
            Name = "User",
            NormalizedName = "USER",
            Id = Guid.NewGuid(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });

        builder.HasData(new IdentityRole<Guid>
        {
            Name = "Admin",
            NormalizedName = "ADMIN",
            Id = AdminUserData.AdminRoleId,
            ConcurrencyStamp = Guid.NewGuid().ToString()
        });
    }
}

public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUser<Guid>> builder)
    {
        builder.HasData(new IdentityUser<Guid>
        {
            Id = AdminUserData.AdminUserId,
            UserName = AdminUserData.UserName,
            NormalizedUserName = AdminUserData.UserName.ToUpper(),
            Email = AdminUserData.Email,
            NormalizedEmail = AdminUserData.Email.ToUpper(),
            PhoneNumber = "00000000000",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            PasswordHash = AdminUserData.PasswordHash,
            SecurityStamp = new Guid().ToString(),
        });
    }
}

public class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasData(new IdentityUserRole<Guid>
        {
            RoleId = AdminUserData.AdminRoleId,
            UserId = AdminUserData.AdminUserId
        });
    }
}

public class IdentityUserProfileConfig : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasData(new UserProfile
        {
            UserId = AdminUserData.AdminUserId,
            UserName = AdminUserData.UserName,
            Email = AdminUserData.Email,
            Password = string.Empty,
            FirstName = AdminUserData.FirstName,
            LastName = AdminUserData.LastName,
            Foto = null,
            IsSuperUser = true,
            IsActive = true,
            //CreatedOn = DateTime.Now,
            //LastLogin = DateTime.Now,
            //ModifiedOn = DateTime.Now,
            //ModifiedByUserId = AdminUserData.AdminUserId,
            //ModifiedBy = this
        });
    }
}
