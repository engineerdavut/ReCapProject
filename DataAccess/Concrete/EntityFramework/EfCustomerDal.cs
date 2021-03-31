using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityFrameworkBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext reCapContext = new ReCapContext())
            {
                var result = from c in reCapContext.Customers
                             join u in reCapContext.Users
                             on c.UserId equals u.UserId
                             select new CustomerDetailDto { CustomerId = c.UserId, UserName = u.FirstName
                             + " - " + u.LastName,
                                 CompanyName = c.CompanyName
                             };

                return result.ToList();

            }
        }
    }
}
