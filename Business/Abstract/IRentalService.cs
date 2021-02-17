using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetAllByCarId(int carId);
        IDataResult<List<Rental>> GetAllByCustomerId(int customerId);
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<RentalDetailDTO>> GetRentalDetails(int carId);
        IResult IsAvailable(int carId);
        IResult ReturnCar(int carId);
        IResult Update(Rental rental);
    }
}
