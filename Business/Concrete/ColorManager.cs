using Business.Abstract;
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

        public void Add(Color color)
        {
            if (color.ColorName.Length > 2)
            {
                _colorDal.Add(color);
                Console.WriteLine("{0} renginiz  veritabanina eklendi"
                    , color.ColorName);
            }
            else
            {
                throw new Exception(" 3 harften kucuk renk giremezsiniz");
            }
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }
    }
}
