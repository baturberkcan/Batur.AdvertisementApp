using AutoMapper;
using Batur.AdvertisementApp.Dtos.AppRoleDto;
using Batur.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AppRoleProfile:Profile
    {
        public AppRoleProfile()
        {
            CreateMap<AppRole, AppRoleListDto>().ReverseMap();
        }
    }
}
