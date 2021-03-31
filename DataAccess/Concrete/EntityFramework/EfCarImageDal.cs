using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal:EfEntityFrameworkBase<CarImage,ReCapContext>,ICarImageDal
    {
        public List<ImageDetailDto> GetCarDetails()
        {
            using (ReCapContext reCapContext = new ReCapContext())
            {
                var result = from ci in reCapContext.CarImages
                             join c in reCapContext.Cars
                             on ci.CarId equals c.CarId
                             select new ImageDetailDto { CarId = c.CarId, CarName = c.CarName,
                                 Path =ci.ImagePath,
                                 CarDescription = c.CarDescription
                             };

                return result.ToList();

            }
        }

       
    }
}
