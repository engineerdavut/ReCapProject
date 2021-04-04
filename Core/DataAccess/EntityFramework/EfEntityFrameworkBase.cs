using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityFrameworkBase<TEntity,TContext>
        where TEntity :class ,IEntity,new()
        where TContext :  DbContext , new()
    {
        public void Add(TEntity entity)
        {
            using (TContext tContext = new TContext())
            {
                var addedContext = tContext.Entry(entity);
                addedContext.State = EntityState.Added;
                tContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext tContext = new TContext())
            {
                var deletedContext = tContext.Entry(entity);
                deletedContext.State = EntityState.Deleted;
                tContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext tContext = new TContext())
            {
                return tContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext tContext = new TContext())
            {
                return filter == null ? tContext.Set<TEntity>().ToList()
                    : tContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext tContext = new TContext())
            {
                var updatedContext = tContext.Entry(entity);
                updatedContext.State = EntityState.Modified;
                tContext.SaveChanges();
            }
        }
    }
}
