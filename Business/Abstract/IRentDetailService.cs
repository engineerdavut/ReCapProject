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

        IDataResult<List<RentDetail>> GetAvailableCars();

        IResult Add(RentDetail rentDetail);
    }
}
