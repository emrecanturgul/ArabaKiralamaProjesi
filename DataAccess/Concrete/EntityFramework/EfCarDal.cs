using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
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
                bool flagId = context.Cars.Any(c => c.Id == entity.Id);
                if(flagId == false ) {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                    Console.WriteLine("araç eklendi yeni id" + entity.Id);
                } 
                else
                {
                    Console.WriteLine("hatalı Id girişi");
                }
                 
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

        public List<CarDetailDTO> GetCarDetails()
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands1 on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorID
                             select new CarDetailDTO
                             {
                                 CarDescription = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();


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
 