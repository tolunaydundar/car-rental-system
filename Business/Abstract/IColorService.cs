using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Delete(Color Color);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int ColorId);
        IResult Update(Color Color);
    }
}
