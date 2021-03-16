using Business.Abstract;
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
        public IResult Add(RentDetail rentDetail)
        {                      
            if (rentDetail.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalError);
                
            }
            _rentDetailDal.Add(rentDetail);
            return new SuccessResult(Messages.CarRented);
        }

        public IDataResult<List<RentDetail>> GetAvailableCars()
        {
           // _rentDetailDal.GetAvailableCars();
            return new SuccessDataResult<List<RentDetail>>(Messages.CarToBeRented);
        }
    }
}
