﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constanst;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            // if (car.CarName.Length > 2 && car.DailyPrice > 0)
            // {
            _reCapDal.Add(car);
            return new SuccessResult( Messages.CarAdded);
                Console.WriteLine("{0} araciniz gunluk {1} tl tutarla veritabanina eklendi"
                    , car.CarName, car.DailyPrice);
                
           // }

               // return new ErrorResult(Messages.CarNameInvalid);
            
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _reCapDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_reCapDal.GetAll(),Messages.CarListened);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_reCapDal.Get(c => c.CarId == carId)
                , Messages.GetCar);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_reCapDal.GetCarDetails());
        }
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_reCapDal.GetAll(p => p.BrandId == brandId));
        }
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_reCapDal.GetAll(p => p.ColorId == colorId));
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            //if (car.CarName.Length > 2 && car.DailyPrice > 0)
            // {
                _reCapDal.Update(car);
                return new SuccessResult(Messages.CarAdded);
                Console.WriteLine("{0} araciniz gunluk {1} tl tutarla veritabanind guncellendi"
                    , car.CarName, car.DailyPrice);
                
           // }

          //  return new ErrorResult(Messages.CarNameInvalid);
        }
    }
}
