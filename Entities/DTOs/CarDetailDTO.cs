using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public  class CarDetailDTO : IDto
    {
        public string CarDescription;
        public string BrandName;
        public string ColorName;
        public int DailyPrice { get; set; }
    }
}
