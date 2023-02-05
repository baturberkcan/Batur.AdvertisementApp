using Batur.AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Dtos.AppRoleDto
{
    public class AppRoleUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public int Defination { get; set; }
    }
}
