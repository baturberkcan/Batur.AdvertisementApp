using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Entities
{
    public class Gender:BaseEntiy
    {
        public string Degination { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
