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


        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext reCapContext=new ReCapContext())
            {
                var result = from c in  filter== null? reCapContext.Cars:reCapContext.Cars.Where(filter)
                             join b in reCapContext.Brands
                             on c.BrandId equals b.BrandId
                             join co in reCapContext.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Image = (from i in reCapContext.CarImages
                                          where i.CarId==c.CarId select i.ImagePath
                                        ).ToList()

                             };
                return result.ToList();

            }
        }


    }
}
