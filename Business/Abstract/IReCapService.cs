using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReCapService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetCarsByBrandId(int branId);

        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IDataResult<Car> GetCarById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailById(int carId);

        IResult Add(Car car);

        IResult Delete(Car car);

        IResult Update(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IResult TransactionalOperation(Car car);
    }
}
