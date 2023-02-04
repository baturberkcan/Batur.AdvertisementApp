using AutoMapper;
using Batur.AdvertisementApp.Dtos;
using Batur.AdvertisementApp.UI.Models;

namespace Batur.AdvertisementApp.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile : Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>();
        }
    }
}
