using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //TODO: Add rules and handle exceptions
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = IsAvailable(rental.CarId);

            if (result.Success == false)
            {
                return new ErrorResult(result.Message);
            }

            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.CarId == carId));
        }

        public IDataResult<List<Rental>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.CustomerId == customerId));
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDTO>> GetRentalDetails(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDTO>>(_rentalDal.GetRentalDetails(p => p.CarId == carId));
        }

        public IResult IsAvailable(int carId)
        {
            if (_rentalDal.GetRentalDetails(p => p.CarId == carId && p.ReturnDate == null).Count > 0)
            {
                return new ErrorResult(Messages.RentalCarIsRented);
            }

            return new SuccessResult();
        }

        public IResult ReturnCar(int carId)
        {
            if (IsAvailable(carId).Success == false)
            {
                Rental rental = _rentalDal.Get(p => p.CarId == carId && p.ReturnDate == null);
                rental.ReturnDate = DateTime.Now;
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalCarReturned);
            }

            return new ErrorResult(Messages.RentalCarIsNotRented);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
