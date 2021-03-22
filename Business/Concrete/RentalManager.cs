using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalsDal;

        public RentalManager(IRentalDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }


        public IResult Add(Rental rentals)
        {
            if (rentals.ReturnDate!=null)
            {
               _rentalsDal.Add(rentals);
                return new SuccessResult(Messages.RentalsAdded);
            }
            else
            {
                return new SuccessResult(Messages.RentalReturnDateNotNull);

            }

        }

        public IResult Delete(Rental rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.RentalsDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(), Messages.RentalsListed);
        }
        public IResult Update(Rental rentals)
        {
            _rentalsDal.Update(rentals);
            return new SuccessResult(Messages.RentalsUpdated);

        }
    }
}
