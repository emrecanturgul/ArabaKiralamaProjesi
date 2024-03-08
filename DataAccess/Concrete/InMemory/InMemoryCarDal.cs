using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal    
    {
        List<Car> _cars; 
        public InMemoryCarDal()
        {
           _cars = new List<Car>() {
                new Car { Id = 1, BrandId = 1, ColorId = 1, Description = "BMW", ModelYear = 2018 },
                new Car { Id = 2, BrandId = 1, ColorId = 2, Description = "BMW", ModelYear = 2019 },
                new Car { Id = 3, BrandId = 2, ColorId = 3, Description = "AUDI", ModelYear = 2020 },
                new Car { Id = 4, BrandId = 2, ColorId = 4, Description = "AUDI", ModelYear = 2021 },

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => car.Id == c.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;


        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);

        }
        public List<Car> GetAll()
        {
            return _cars;
        }
        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public Car Get(Expression<Func<Car, bool>>  filter )
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
