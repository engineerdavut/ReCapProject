using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
           // if (color.ColorName.Length > 2)
           // {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
               // Console.WriteLine("{0} renginiz  veritabanina eklendi"
               //     , color.ColorName);
           // }

            //    return new ErrorResult(Messages.ColorInvalid);
            
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IDataResult<Color> GetColorById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId)
                , Messages.GetColor);
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
          //  if (color.ColorName.Length > 2)
         //   {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);

          //  }

          //  return new ErrorResult(Messages.ColorInvalid);
        }
    }
}
