using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
