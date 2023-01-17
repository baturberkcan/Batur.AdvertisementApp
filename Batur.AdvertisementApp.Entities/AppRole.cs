using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Entities
{
    public class AppRole : BaseEntiy
    {
        public string Defination { get; set; }
        public List<AppUserRole> UserRoles { get; set; }

    }
}
