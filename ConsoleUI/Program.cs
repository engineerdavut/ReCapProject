using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ReCapManager reCapManager = new ReCapManager(new InMemoryReCapDal());
            foreach (var car in reCapManager.GetAll())
            {
                Console.WriteLine("carid: " + car.CarId + "  carbrandid: " + car.BrandId + "   carcolorid: "
                    + car.ColorId + "   carname: " + car.CarName + "   cardailyprice: "
                    + car.DailyPrice + "   cardescription: " + car.Description);
            }

            ReCapManager reCapManager1 = new ReCapManager(new InMemoryReCapDal());
            foreach (var car in reCapManager1.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
            */
            ReCapManager carManager1 = new ReCapManager(new EfCarDal());
            foreach (var car in carManager1.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("-----------------------");
            foreach (var car in carManager1.GetCarsByBrandId(4))
            {

                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("-----------------------");
            foreach (var car in carManager1.GetCarsByColorId(7))
            {

                Console.WriteLine(car.CarName);
            }

            carManager1.Add(new Car
            {
                CarId = 8,
                BrandId = 6,
                ColorId = 3,
                CarName = "volkswagenpassat"
                ,
                DailyPrice = 400,
                CarDescription = "Ciziksiz, 2021 model,beyaz"
            });
            Console.ReadLine();
        }
    }
}
