
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entities.Abstract; 
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Car : IEntity
    {   
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; } 
        public string Description { get; set; }
    }
}
