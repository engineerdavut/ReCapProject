using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentDetailDal : EfEntityFrameworkBase<RentDetail, ReCapContext>, IRentDetailDal
    {


        public List<AvailableCarDto> GetAvailableCars()
        {
            using (ReCapContext reCapContext= new ReCapContext())
            {
                var result = from c in reCapContext.Cars
                             join rd in reCapContext.RentDetails
                             on c.CarId equals rd.CarId
                             where rd.ReturnDate!=null
                             select new AvailableCarDto { CarId = c.CarId, IsAvailable = true };

                return result.ToList();

            }
        }

        public List<RentalsDetailDto> GetRentalsDetail()
        {
            using (ReCapContext reCapContext = new ReCapContext())
            {


                var result = from  rd in reCapContext.RentDetails
                             join c in reCapContext.Cars
                             on rd.CarId equals c.CarId                            
                             join cu in reCapContext.Customers
                             on rd.CustomerId equals cu.CustomerId                             
                             join b in reCapContext.Brands
                             on c.BrandId equals b.BrandId                            
                             join u in reCapContext.Users
                             on cu.UserId equals u.UserId
                             select new RentalsDetailDto {
                                 
                                 RentDetailId = rd.RentDetailId,
                                 BrandName=b.BrandName,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 RentDate=rd.RentDate,
                                 ReturnDate=rd.ReturnDate
                             };

                return result.ToList();

            }
        }
    }
}
