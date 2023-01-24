using AutoMapper;
using Batur.AdvertisementApp.Dtos.GenderDto;
using Batur.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderListDto>().ReverseMap();
            CreateMap<Gender, GenderCreateDto>().ReverseMap();
            CreateMap<Gender, GenderUpdateDto>().ReverseMap();
        }
    }
}
