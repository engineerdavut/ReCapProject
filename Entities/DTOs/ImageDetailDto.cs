using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ImageDetailDto : IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string Path { get; set; }

        public string CarDescription { get; set; }
    }
}
