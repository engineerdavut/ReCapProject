using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ReCapManager : IReCapService
    {
        IReCapDal _reCapDal;

        public ReCapManager(IReCapDal reCapDal)
        {
            _reCapDal = reCapDal;
        }

        public List<Cars> GetAll()
        {
            return _reCapDal.GetAll();
        }
    }
}
