using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
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

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0 )
            {   

                _carDal.Add(car);
                
            }
            else
            {
                Console.WriteLine("araç bilgileri hatalı");
            }
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public void Delete(Car car)
        {
            Console.WriteLine("silinen araba idsi" + car.Id);
            _carDal.Delete(car);
        }

        public Car GetCarById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }


    }
}
