using Batur.AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Dtos.AppRoleDto
{
    public class AppRoleListDto:IDto
    {
        public int Id { get; set; }
        public string Defination { get; set; }
    }
}
