using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int brandId);
        List<Car> GetAllByCategoryId(int categoryId);
        List<Car> GetAllByColorId(int colorId);
        List<Car> GetAllByDailyPrice(int min, int max);
        List<Car> GetAllByModelYear(int min, int max);
        Car GetByCarId(int carId);
        List<CarDetailDTO> GetCarDetails();
        void Update(Car car);
    }
}
