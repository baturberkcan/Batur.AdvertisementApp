using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Entities
{
    public class AppUserRole : BaseEntiy
    {
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }

        public int RoleId { get; set; }
        public AppRole AppRole { get; set; }

    }
}
