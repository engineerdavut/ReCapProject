using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentDetailService
    {
        IDataResult<List<RentDetail>> GetAll();

        IDataResult<RentDetail> GetRentDetailById(int rentDetailId);

        IDataResult<List<RentDetail>> GetRentDetailByCarId(int carId);

        IDataResult<List<RentDetail>> GetRentDetailByCustomerId(int customerId);

        IDataResult<List<RentDetail>> GetAvailableCars();

        IResult Add(RentDetail rentDetail);


        IResult Delete(RentDetail rentDetail);

        IResult Update(RentDetail rentDetail);

    }
}
