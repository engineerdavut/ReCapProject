﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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
        
        [CacheAspect]
        [SecuredOperation("ReCaps.Add,Admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IReCapService.Get")]
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
        
        public IResult Delete(Car car)
        {
            _reCapDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [PerformanceAspect(5)]
        
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_reCapDal.GetAll(),Messages.CarListened);
        }
       
        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_reCapDal.Get(c => c.CarId == carId)
                , Messages.GetCar);
        }
        
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_reCapDal.GetCarDetails());
        }
        
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_reCapDal.GetAll(p => p.BrandId == brandId));
        }
        
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_reCapDal.GetAll(p => p.ColorId == colorId));
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _reCapDal.Update(car);
            _reCapDal.Add(car);
            return new SuccessResult(Messages.CarUpdated);
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
