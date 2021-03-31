using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Constanst;
using Core.Helpers.FileHelpers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        


        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
            
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }



        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> GetCarImageById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == carImageId));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }


            return new SuccessDataResult<List<CarImage>>((CheckIfCarImageNull(carId).Data));
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<ImageDetailDto>> GetImageDetails()
        {
            return new SuccessDataResult<List<ImageDetailDto>>(_carImageDal.GetCarDetails());
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot"))
            + _carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelper.Update(formFile, oldPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckCarImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            try
            {
                string path = @"\images\defaultlogo.jpg";
                var result = _carImageDal.GetAll(ci => ci.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId));
        }

    }
}
