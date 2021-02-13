using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDTO> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from rental in context.Rentals
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join car in context.Cars on rental.CarId equals car.Id
                             join brand in context.Brands on car.BrandId equals brand.Id
                             select new RentalDetailDTO
                             {
                                 Id = rental.Id,
                                 PickupDate = rental.PickUpDate,
                                 ReturnDate = rental.ReturnDate,
                                 CustomerId = customer.Id,
                                 CustomerFirstName = customer.FirstName,
                                 CustomerLastName = customer.LastName,
                                 CustomerPhoneNumber = customer.PhoneNumber,
                                 CarId = car.Id,
                                 CarBrand = brand.Name,
                                 CarModel = car.Model,
                                 CarDailyPrice = car.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
