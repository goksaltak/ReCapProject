using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetCarId(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarByColorDetails(int id);
        IDataResult<List<CarDetailDto>> GetCarByBrandDetails(int id);
        IDataResult<List<CarDetailDto>> GetCarByDetails(int id);
        IDataResult<List<CarDetailDto>> GetCarByColorAndBrandDetails(int colorid, int brandid);

    }
}
