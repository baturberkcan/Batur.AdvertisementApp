using AutoMapper;
using Batur.AdvertisementApp.Business.Interfaces;
using Batur.AdvertisementApp.DataAccess.UnitOfWork;
using Batur.AdvertisementApp.Dtos.GenderDto;
using Batur.AdvertisementApp.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Business.Services
{
    public class GenderManager : Service<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderManager(IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
