﻿using Business.Abstract;
using Core.Constanst;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colordal)
        {
            _colorDal = colordal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length > 2)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
               // Console.WriteLine("{0} renginiz  veritabanina eklendi"
               //     , color.ColorName);
            }

                return new ErrorResult(Messages.ColorInvalid);
            
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length > 2)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);

            }

            return new ErrorResult(Messages.ColorInvalid);
        }
    }
}
