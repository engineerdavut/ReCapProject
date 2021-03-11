using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IReCapDal
    {
        List<Cars> GetAll();
        void Add(Cars car);
        void Update(Cars car);
        void Delete(Cars car);

        List<Cars> GetAllByBrand(int BrandId);

        List<Cars> GetAllByColor(int ColorId);
    }
}
