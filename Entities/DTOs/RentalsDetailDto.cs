﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalsDetailDto : IDto
    {
        public int RentDetailId { get; set; }
        public string BrandName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime? ReturnDate { get; set; }

    }
}
