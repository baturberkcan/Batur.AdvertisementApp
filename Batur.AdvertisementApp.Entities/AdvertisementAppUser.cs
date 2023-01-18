﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.Entities
{
    public class AdvertisementAppUser : BaseEntiy
    {
        public Advertisement AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }
        public AdvertisementAppUserStatus AdvertisementAppUserStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }




    }
}
