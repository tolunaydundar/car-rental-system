using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join category in context.Categories on car.CategoryId equals category.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new CarDetailDTO
                             {
                                 Id = car.Id,
                                 Brand = brand.Name,
                                 Model = car.Model,
                                 ModelYear = car.ModelYear,
                                 Color = color.Name,
                                 Category = category.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                             };

                return result.ToList();
            }
        }
    }
}
