using Batur.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.DataAccess.Configrations
{
    public class AppRoleConfigration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Defination).HasMaxLength(300).IsRequired();
            builder.HasData(new AppRole[] {
                new()
                {
                    Defination="Admin",
                    Id=1
                },
                new()
                {
                    Defination="Member",
                    Id=2
                }
            });
        }

    }
}

