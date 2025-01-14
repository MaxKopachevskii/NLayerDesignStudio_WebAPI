﻿using NLayerDesignStudio_DAL.EF;
using NLayerDesignStudio_DAL.Entities;
using NLayerDesignStudio_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDesignStudio_DAL.Repositories
{
    public class ServiceRepository : IRepository<Service>
    {
        private DesignDbContext db;

        public ServiceRepository(DesignDbContext context)
        {
            this.db = context;
        }

        public void Create(Service item)
        {
            db.Services.Add(item);
        }

        public void Delete(int id)
        {
            var service = db.Services.Find(id);
            if (service != null)
            {
                db.Services.Remove(service);
            }
        }

        public Service Get(int id)
        {
            return db.Services.Find(id);
        }

        public IEnumerable<Service> GetAll()
        {
            return db.Services.Include(o => o.Master);
        }

        public void Update(Service item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
