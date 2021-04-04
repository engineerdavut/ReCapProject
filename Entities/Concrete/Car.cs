
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; }

        public int BrandId { get; set; }
        // ColorId, ModelYear, DailyPrice, Description
        public int ColorId { get; set; }

        public string CarName { get; set; }
        public decimal DailyPrice { get; set; }
        public  string CarDescription { get; set; }

    }
}

