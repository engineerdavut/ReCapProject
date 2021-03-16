using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AvailableCarDto:IDto
    {
        public int CarId { get; set; }

        public bool IsAvailable { get; set; }
    }
}
