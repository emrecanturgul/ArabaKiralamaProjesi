using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace ConsoleUI
{
    public class Class1
    {
        public static void Main(string[] args )
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var newCar = new Car
            {
                Id = 6,
                BrandId = 3,
                Description = "yeni araba",
                ColorId = 4,
                DailyPrice = 2500,
                ModelYear = 2002
            };
            //arabaEkleme(carManager,newCar); 
            //var silinecekCar = carManager.GetCarById(5);
            //carManager.Delete(silinecekCar);
            arabaEkleme(carManager, kullanıcıVeriGirisi());
            
            foreach(var car in carManager.GetCarDetails())
            {   
                Console.Write(car.CarDescription + " ");
                Console.Write(car.BrandName + " ");
                Console.Write(car.ColorName + " ");
                Console.Write(car.DailyPrice);
                Console.WriteLine();
                //arablar şu şekilde listelenecek -> carName , brandName , colorName , dailyPrice

            }

        }

        private static void arabaEkleme(CarManager carManager,Car newCar)
        {
            
            
            carManager.Add(newCar);
            


        }
        private static Car kullanıcıVeriGirisi()
        {
            Console.WriteLine("id gir");
            int EId = Convert.ToInt32(Console.ReadLine());   
            Console.WriteLine("brand id gir: ");
            int EBrandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("description gir");
            string EDescription = Console.ReadLine();
            Console.WriteLine("colorID gir");
            int EColorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("dailyPrice gir");
            int EDailyPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("model year gir");
            int EModelYear = Convert.ToInt32(Console.ReadLine());
            var newCar = new Car
            {
                Id = EId, 
                BrandId = EBrandId,
                Description =EDescription,
                ColorId = EColorId,
                DailyPrice = EDailyPrice,    
                ModelYear = EModelYear
                
            };
            return newCar; 

        }
        
    }
}