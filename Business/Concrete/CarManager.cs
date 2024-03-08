using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract; 

namespace Business.Concrete
{
    public class CarManager : ICarService
    {   ICarDal _carDal; 
        public CarManager(ICarDal carDal) {
            _carDal = carDal; 
        } 
        public List<Car> GetAll()
        {
            return _carDal.GetAll(); 
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id); 
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
            
        }

        public void Insert(Car car)
        {
            if(car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("araç eklendi");
            }
            else
            {
                Console.WriteLine("araç bilgileri hatalı");
            }
        }
    }
}
