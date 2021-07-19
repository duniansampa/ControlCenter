using HyperAutomation.ControlRoom.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Server.Models
{
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

    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            //builder.HasData(new IdentityRole
            //{
            //    Name = "User",
            //    NormalizedName = "USER",
            //    Id = Guid.NewGuid().ToString(),
            //    ConcurrencyStamp = Guid.NewGuid().ToString()
            //});


            //builder.HasData(new IdentityRole
            //{
            //    Name = "Admin",
            //    NormalizedName = "ADMIN",
            //    Id = Guid.NewGuid().ToString(),
            //    ConcurrencyStamp = Guid.NewGuid().ToString()
            //});
        }
    }
}
