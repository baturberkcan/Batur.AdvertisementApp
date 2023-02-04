using AutoMapper;
using Batur.AdvertisementApp.Business.Interfaces;
using Batur.AdvertisementApp.Business.Mappings.AutoMapper;
using Batur.AdvertisementApp.Business.Services;
using Batur.AdvertisementApp.Business.ValidationRules;
using Batur.AdvertisementApp.DataAccess.Context;
using Batur.AdvertisementApp.DataAccess.UnitOfWork;
using Batur.AdvertisementApp.Dtos;
using Batur.AdvertisementApp.Dtos.GenderDto;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));

            });

            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();

            services.AddScoped<IProvidedServiceService, ProvidedServiceManager>();
            services.AddScoped<IAdvertisementService, AdvertisementManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IGenderService, GenderManager>();


        }
      
    }
}
