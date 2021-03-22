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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customersDal;

        public CustomerManager(ICustomerDal customersDal)
        {
            _customersDal = customersDal;
        }


        public IResult Add(Customer customers)
        {
            _customersDal.Add(customers);
            return new SuccessResult(Messages.CustomersAdded);
        }

        public IResult Delete(Customer customers)
        {
            _customersDal.Delete(customers);
            return new SuccessResult(Messages.CustomersDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customersDal.GetAll(), Messages.CustomersListed);
        }
        public IResult Update(Customer customers)
        {
            _customersDal.Update(customers);
            return new SuccessResult(Messages.CustomersUpdated);

        }
    }
}
