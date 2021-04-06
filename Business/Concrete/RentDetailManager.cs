﻿using Business.Abstract;
using Core.Constanst;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class RentDetailManager:IRentDetailService
    {
        IRentDetailDal _rentDetailDal;

        public RentDetailManager(IRentDetailDal rentDetailDal)
        {
            _rentDetailDal = rentDetailDal;
        }

        
        public IDataResult<List<RentDetail>> GetAll()
        {
            _rentDetailDal.GetAll();
            return new SuccessDataResult<List<RentDetail>>(Messages.RentDetailListened);
        }
        [ValidationAspect(typeof(RentDetailValidator))]
        public IResult Add(RentDetail rentDetail)
        {                      
            if (rentDetail.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalError);
                
            }
            _rentDetailDal.Add(rentDetail);
            return new SuccessResult(Messages.CarRented);
        }
        
        public IDataResult<List<AvailableCarDto>> GetAvailableCars()
        {
            // _rentDetailDal.GetAvailableCars();
            //_rentDetailDal.GetAvailableCars(),
         
            return new SuccessDataResult<List<AvailableCarDto>>(_rentDetailDal.GetAvailableCars(),Messages.CarToBeRented);
        }
        
        public IResult Delete(RentDetail rentDetail)
        {
            _rentDetailDal.Delete(rentDetail);
            return new SuccessResult(Messages.RentDeleted);
        }
        [ValidationAspect(typeof(RentDetailValidator))]
        public IResult Update(RentDetail rentDetail)
        {
           // if (rentDetail.RentDate>DateTime.Now)
        //    {
          //      return new ErrorResult(Messages.RentalError);

          //  }
            _rentDetailDal.Update(rentDetail);
            return new SuccessResult(Messages.CarRentedUpdated);
        }
        
        public IDataResult<List<RentDetail>> GetRentDetailByCarId(int carId)
        {
            return new SuccessDataResult<List<RentDetail>>(_rentDetailDal.GetAll(rd => rd.CarId == carId));
        }
        
        public IDataResult<List<RentDetail>> GetRentDetailByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentDetail>>(_rentDetailDal.GetAll(rd => rd.CustomerId == customerId));
        }
        
        public IDataResult<RentDetail> GetRentDetailById(int rentDetailId)
        {
            return new SuccessDataResult<RentDetail>(_rentDetailDal.Get(c => c.RentDetailId == rentDetailId)
                , Messages.GetRentDetail);
        }
    }
}
