﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges(); 
            }
        }

        public void Delete(Color entity)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                 
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                return context.Set<Color>().SingleOrDefault(filter); 

            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList(); 
            }
        }

        public void Update(Color entity)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var updatedEntity = context.Entry(entity); 
                updatedEntity.State = EntityState.Modified; 
                context.SaveChanges(); 

            }
        } 
        
    }
}
