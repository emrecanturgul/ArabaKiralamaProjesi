using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks; 

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var addedEntity = context.Entry(entity); 
                addedEntity.State = EntityState.Added;
                context.SaveChanges(); 
                 
            }
        }

        public void Delete(Car entity)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var deletedEntity = context.Entry(entity); 
                deletedEntity.State = EntityState.Deleted; 
                context.SaveChanges(); 

            } 
        }

        public Car Get(Expression<Func<Car, bool>>  filter )
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter); 

            }
        }

        

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                try
                {
                    IQueryable<Car> query = context.Set<Car>(); 
                    if (filter != null )
                    {
                        query = query.Where(filter); 
                    }  
                    return query.ToList(); 
                } 
                catch (Exception ex)
                {
                    Console.WriteLine("hata" +ex.Message);
                    return null;
                     

                }
            }
        }

        public void Update(Car entity)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var updatedEntity = context.Entry(entity); 
                updatedEntity.State  = EntityState.Modified; 
                context.SaveChanges(); 
            }
        }
    }
}
 