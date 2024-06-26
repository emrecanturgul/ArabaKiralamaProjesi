﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        //getCarsByBrandID ve GetCarsByColorId servislerini yazınız
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);

        List<CarDetailDTO> GetCarDetails();
        Car GetCarById(int id); 
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car); 
         
        
    }
}
