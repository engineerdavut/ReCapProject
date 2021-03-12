using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ReCapManager : IReCapService
    {
        IReCapDal _reCapDal;

        public ReCapManager(IReCapDal reCapDal)
        {
            _reCapDal = reCapDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _reCapDal.Add(car);
                Console.WriteLine("{0} araciniz gunluk {1} tl tutarla veritabanina eklendi"
                    , car.CarName, car.DailyPrice);
            }
            else
            {
                throw new Exception(" 2 harften kucuk ya da gunluk 0 tl den az kiralama bedeli giremezsiniz");
            }
        }

        public List<Car> GetAll()
        {
            return _reCapDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _reCapDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _reCapDal.GetAll(p => p.ColorId == id);
        }
    }
}
