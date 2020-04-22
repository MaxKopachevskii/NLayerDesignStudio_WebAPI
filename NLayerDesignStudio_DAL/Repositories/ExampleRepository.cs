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
    public class ExampleRepository : IRepository<Example>
    {
        DesignDbContext db;

        public ExampleRepository(DesignDbContext context)
        {
            this.db = context;
        }

        public void Create(Example item)
        {
            db.Examples.Add(item);
        }

        public void Delete(int id)
        {
            var example = db.Examples.Find(id);
            if (example != null)
            {
                db.Examples.Remove(example);
            }
        }

        public Example Get(int id)
        {
            return db.Examples.Find(id);
        }

        public IEnumerable<Example> GetAll()
        {
            return db.Examples;
        }

        public void Update(Example item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
