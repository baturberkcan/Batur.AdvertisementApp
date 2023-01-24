using AutoMapper;
using Batur.AdvertisementApp.Business.Interfaces;
using Batur.AdvertisementApp.DataAccess.UnitOfWork;
using Batur.AdvertisementApp.Dtos;
using Batur.AdvertisementApp.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Business.Services
{
    public class AppUserManager : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        public AppUserManager(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
