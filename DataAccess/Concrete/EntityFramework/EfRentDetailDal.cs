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
    }
}
