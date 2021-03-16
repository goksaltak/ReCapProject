using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomersService
    {
        IDataResult<List<Customers>> GetAll();
        IResult Add(Customers customers);
        IResult Delete(Customers customers);
        IResult Update(Customers customers);
    }
}
