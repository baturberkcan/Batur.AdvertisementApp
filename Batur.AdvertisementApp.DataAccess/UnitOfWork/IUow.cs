using Batur.AdvertisementApp.DataAccess.Interfaces;
using Batur.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntiy;
        Task SaveChangesAsync();
    }
}
