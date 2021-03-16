using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityFrameworkBase<Car, ReCapContext>, IReCapDal
    {


        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext reCapContext=new ReCapContext())
            {
                var result = from c in reCapContext.Cars
                             join b in reCapContext.Brands
                             on c.BrandId equals b.BrandId
                             join co in reCapContext.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName=co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();

            }
        }


    }
}
