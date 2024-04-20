using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Color = Entities.Concrete.Color;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public void Add(Color color)
        {
            _colorDal.Add(color); 
        }

        public void Delete(Color color)
        { 
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetByID(int id)
        {
            return _colorDal.Get(c => c.ColorID == id); 
        }

        public void Update(Color color)
        {
            _colorDal.Update(color); 
        }
    }
}
