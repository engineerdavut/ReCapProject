using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCarDal : IReCapDal
    {
        public void Add(Car entity)
        {
            using (ReCapContext reCapContext=new ReCapContext())
            {
                var addedContext = reCapContext.Entry(entity);
                addedContext.State = EntityState.Added;
                reCapContext.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContext reCapContext=new ReCapContext())
            {
                var deletedContext = reCapContext.Entry(entity);
                deletedContext.State = EntityState.Deleted;
                reCapContext.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext reCapContext=new ReCapContext())
            {
                return reCapContext.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext reCapContext=new ReCapContext())
            {
                return filter == null ? reCapContext.Set<Car>().ToList()
                    : reCapContext.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapContext reCapContext=new ReCapContext())
            {
                var updatedContext = reCapContext.Entry(entity);
                updatedContext.State = EntityState.Modified;
                reCapContext.SaveChanges();
            }
        }
    }
}
