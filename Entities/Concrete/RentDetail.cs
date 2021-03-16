﻿using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RentDetail : IEntity
    {
        public int RentDetailId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
