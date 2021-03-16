using Business.Abstract;
using Core.Constanst;
using Core.Utilities.Results;
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

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length > 2 )
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
                Console.WriteLine("{0} markaniz  veritabanina eklendi"
                    , brand.BrandName);
            }

                return new ErrorResult(Messages.BrandInvalid);

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetBrandById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.BrandId == brandId)
                , Messages.GetBrand);
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
                Console.WriteLine("{0} markaniz  veritabaninda guncellendi."
                    , brand.BrandName);
            }

            return new ErrorResult(Messages.BrandInvalid);
        }
    }
}
