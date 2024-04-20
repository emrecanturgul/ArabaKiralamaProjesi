using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public  class DataBaseContext  : DbContext
              
    { protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=emre\sqlexpress;Database=RentACarProject;Trusted_Connection=true");
            
        } 
        public DbSet<Car> Cars { get; set; } 
        public DbSet<Color> Colors { get; set; }    
        public DbSet<Brand> Brands1 { get; set; }  

        //Car , Color , Brand nesneleri için ef altyapısı yazacağız 

    }
}
