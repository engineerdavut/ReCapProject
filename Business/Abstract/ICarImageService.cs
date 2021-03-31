using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();

        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);


        IDataResult<CarImage> GetCarImageById(int carImageId);

        IResult Add(IFormFile formfile, CarImage carImage);

        IResult Delete(CarImage carImage);

        IResult Update(IFormFile formfile,CarImage carImage);

        IDataResult<List<ImageDetailDto>> GetImageDetails();
    }
}
