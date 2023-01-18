using Batur.AdvertisementApp.DataAccess.Configrations;
using Batur.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.DataAccess.Context
{
    public class AdvertisementContext : DbContext
    {
        public AdvertisementContext(DbContextOptions<AdvertisementContext> options) : base(options)
        {
          

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdvertisementConfigration());
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserConfigration());
            modelBuilder.ApplyConfiguration(new AdvertisementAppUserStatusConfigration());
            modelBuilder.ApplyConfiguration(new AppRoleConfigration());
            modelBuilder.ApplyConfiguration(new AppUserConfigration());
            modelBuilder.ApplyConfiguration(new AppUserRoleConfigration());
            modelBuilder.ApplyConfiguration(new GenderConfigration());
            modelBuilder.ApplyConfiguration(new MilitaryStatusConfigration());
            modelBuilder.ApplyConfiguration(new ProvidedServiceConfigration());

        }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
        public DbSet<AdvertisementAppUserStatus> AdvertisementAppUserStatuses { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }

    }
}
