using AutoMapper;
using Batur.AdvertisementApp.Dtos;
using Batur.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();
            CreateMap<AppUser, AppUserCreateDto>().ReverseMap();

        }
    }
}
