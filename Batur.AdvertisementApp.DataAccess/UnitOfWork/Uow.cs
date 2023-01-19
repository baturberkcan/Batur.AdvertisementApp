using Batur.AdvertisementApp.DataAccess.Context;
using Batur.AdvertisementApp.DataAccess.Interfaces;
using Batur.AdvertisementApp.DataAccess.Repository;
using Batur.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batur.AdvertisementApp.DataAccess.UnitOfWork
{
    public class Uow:IUow
    {
        private readonly AdvertisementContext _context;

        public Uow(AdvertisementContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntiy
        {
            return new Repository<T>(_context);
        } 
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
