using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryReCapDal : IReCapDal
    {
        List<Cars> _cars;
        public InMemoryReCapDal()
        {
            //_cars=cars;
            _cars = new List<Cars>
            {
                new Cars{CarId=1,BrandId=4,ColorId=6,CarName= "ToyotaCorolla"
                ,DailyPrice=30200, Description="Ciziksiz, 2000 model,beyaz"},
                new Cars{CarId=2,BrandId=2,ColorId=6,CarName= "opelinsigna"
                ,DailyPrice=70000, Description="Ciziksiz, 2010 model,beyaz"},
                new Cars{CarId=3,BrandId=1,ColorId=1,CarName= "renoclio"
                ,DailyPrice=72000, Description="Ciziksiz, 2013 model,kirmizi"},
                new Cars{CarId=4,BrandId=3,ColorId=7,CarName= "fiategea"
                ,DailyPrice=98000, Description="Ciziksiz, 2016 model,gri"},
                new Cars{CarId=5,BrandId=4,ColorId=5,CarName= "ToyotaCorolla"
                ,DailyPrice=100200, Description="Ciziksiz, 2019 model,siyah"},
                new Cars{CarId=6,BrandId=5,ColorId=2,CarName= "Lexus"
                ,DailyPrice=270000, Description="Ciziksiz, 2021 model,mavi"}

            };
        }

        public void Add(Cars car)
        {
            _cars.Add(car);
        }

        public void Delete(Cars car)
        {
            Cars carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }



        public void Update(Cars car)
        {
            Cars carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarName = car.CarName;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }



        List<Cars> IReCapDal.GetAll()
        {
            return _cars;
        }

        List<Cars> IReCapDal.GetAllByBrand(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        List<Cars> IReCapDal.GetAllByColor(int ColorId)
        {
            return _cars.Where(c => c.ColorId == ColorId).ToList();
        }
    }
}
