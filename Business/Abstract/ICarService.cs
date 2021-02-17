using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        IDataResult<List<Car>> GetAllByCategoryId(int categoryId);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        IDataResult<List<Car>> GetAllByDailyPrice(int min, int max);
        IDataResult<List<Car>> GetAllByModelYear(int min, int max);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDTO>> GetCarDetails(int carId);
        IResult Update(Car car);
    }
}
