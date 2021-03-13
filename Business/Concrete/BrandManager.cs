using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length > 2 )
            {
                _brandDal.Add(brand);
                Console.WriteLine("{0} markaniz  veritabanina eklendi"
                    , brand.BrandName);
            }
            else
            {
                throw new Exception(" 3 harften kucuk marka giremezsiniz");
            }
        }

 

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

 
    }
}
